# Alexa-Smart-Home
=============

Nuget package will be available soon..
private try on creating a c# framework for the alexa smart home API.

It will only work with Payload Version 2 at the moment.

Get Requests for temperature and percentage are not supported.

Documentation will be tanslated as soon as possible.

In Deutsch:
-------

C# Framework zur Verwendung für Smart Home Skill Adapter. Nach dem Prinzip des [Alexa Skills Kit Frameworks von Tim Heuer]( https://github.com/timheuer/Slight.Alexa)

Momentan werden alle Requests und Responses der Payload Version 2 unterstützt, die im deutschen Raum verfügbar sind. Nähere Infos zu der API findet man unter alexa/smart-home auf der Amazon Developer Seite.

Achtung: 
Die Get Requests für Temperatur und Prozent werden noch nicht unterstützt.

Nutzung:
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

Für jeden Fehler in der API, gib es eine passende Error Response. Zum Beispiel für Unexpeceted Information Received:
```csharp
        private ISmartHomeResponse handleUnknownNamespaceError(SmartHomeRequest input, ILambdaContext context)
        {
            return new UnexpectedInformationReceivedErrorResponse(input.Header, "Namespace");
        }
```

Discovery Response mit Dummy Gerät:
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


