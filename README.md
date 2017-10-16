# Alexa-Smart-Home
=============

RKon is a dotNet Core Framework for Alexa's Smart Home API. With Version 1.1 it will only support Payloadversion 3.
If you want to use it for the deprecated Payloadversion 2 you need to get Version 1.0.20


Version 1.1 (Payloadversion 3)
=============

With payloadversion 3 all requests and responses had to be updated. More informations can be found in the API reference on Amazon's developer page.
Incoming Requests can be read with Newtonsoft.Json like this:
```csharp
        public SmartHomeRequest FunctionHandler(string jsonString)
        {
            SmartHomeRequest request = JsonConvert.DeserializeObject<SmartHomeRequest>(jsonString);
            return request;
        }
```

Responses can be build from the Header of the request. 
```csharp
            SmartHomeResponse response = new SmartHomeResponse(request.Directive.Header);
```

If you want to create a ChangeReport you can decide if it should be initialised with a empty payload, or if you want to put the changes into the payload. (See API Reference)

```csharp
			bool usePayload = false;
            SmartHomeResponse changeReportResponse = SmartHomeResponse.CreateChangeReportEvent(usePayload);
```

To create error responses you, you can use SmartHomeResponse.CreateErrorResponse. It will throw an exception if you try to use it for a discovery request.

```csharp
            SmartHomeResponse bridgeUnreachableResponse = SmartHomeResponse.CreateErrorResponse(request.Directive.Header, ErrorTypes.BRIDGE_UNREACHABLE);
```

If you need to send a deffered response to alexa you can create one like this:

```csharp
            SmartHomeResponse defferedResponse = SmartHomeResponse.CreateDefferedResponse();
```

You can ask for the PayloadType of incoming requests by using request.GetPayloadType(). It will return the System.Type of the payload.

Under Rkon.Alexa.Net.Types you find multiple enums for specific values like errortypes, display categories or device modes.


Version 1.0 (Payloadversion 2):
=============


Every request and response of payloadversion 2 is supported. More informations can be found in the API reference on Amazon's developer page.

Usage:
-------

Handler:

```csharp
        public ISmartHomeResponse FunctionHandler(SmartHomeRequest input, ILambdaContext context)
        {
            ISmartHomeResponse shResponse = null;
            var logger = context.Logger;
            switch (input.Header.Namespace)
            {
                case Namespaces.DISCOVERY:
                    logger.LogLine("DiscoverRequest");
                    shResponse = handleDiscovery(input, context);
                    break;
                case Namespaces.CONTROL:
                    logger.LogLine("ControlRequest");
                    shResponse = handleControl(input, context);
                    break;
                case Namespaces.SYSTEM:
                    logger.LogLine("SystemRequest");
                    shResponse = handleSystem(input, context);
                    break;
                default:
                    logger.LogLine("UnknownNamespaceRequest. Namespace= " + input.Header.Namespace);
                    shResponse = handleUnknownNamespaceError(input, context);
                    break;
            }
            return shResponse;
        }
```

Every error in the api has it's own error response. For examle the "unexpected information received" error response:
```csharp
        private ISmartHomeResponse handleUnknownNamespaceError(SmartHomeRequest input, ILambdaContext context)
        {
            return new UnexpectedInformationReceivedErrorResponse(input.Header, "Namespace");
        }
```

Discovery Response for a test device:
```csharp
        private ISmartHomeResponse handleDiscovery(SmartHomeRequest input, ILambdaContext context)
        {
            ISmartHomeResponse response = new SmartHomeResponse(input.Header);
            if (response.Payload is DiscoverResponsePayload)
            {
                //id, Hersteller, Modell Name, Version, "Friendly Name", "Friendly Description", Ob erreichbar
                ResponseAppliance appliance = new ResponseAppliance("SampleId", "Agentilo GmbH", "ST007", "1.0.1", "Licht Küche", "Licht in der Küche", true);
                appliance.Actions.Add(ApplianceActions.TURN_OFF);
                appliance.Actions.Add(ApplianceActions.TURN_ON);
                appliance.AdditionalApplianceDetails.Add("Zusätzliche Info", "Optionale Infos");
                (response.Payload as DiscoverResponsePayload).DiscoveredAppliances.Add(appliance);
            }
            else
            {
                context.Logger.LogLine("RuntimeError While Discover");
                response = new RKon.Alexa.NET.Response.ErrorResponses.DriverInternalErrorResponse(input.Header);
            }
            return response;
        }
```


