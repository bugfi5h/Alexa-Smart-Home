using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.V3.TestFunctions;
using RKon.Alexa.NET.Payloads;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using Xunit;
using System.Collections.Generic;
using RKon.Alexa.NET.JsonObjects;

namespace RKon.Alexa.Net.Tests.V3
{
    public class ChangeReport
    {
        private const string CHANGE_REPORT = @"
        {
            'context': {
                'properties': [
                    {
                        'namespace': 'Alexa.BrightnessController',
                        'name': 'brightness',
                        'value': 85,
                        'timeOfSample': '2017-09-27T18:30:30.45Z',
                        'uncertaintyInMilliseconds': 200
                    },
                    {
                        'namespace': 'Alexa.EndpointHealth',
                        'name': 'connectivity',
                        'value': {
                            'value': 'OK'
                        },
                        'timeOfSample': '2017-09-27T18:30:30.45Z',
                        'uncertaintyInMilliseconds': 200
                    }
                ]
            },
            'event': {
                'header': {
                    'namespace': 'Alexa',
                    'name': 'ChangeReport',
                    'payloadVersion': '3',
                    'messageId': '5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4'
                },
                'endpoint': {
                    'scope': {
                        'type': 'BearerToken',
                        'token': 'access-token-from-Amazon'
                    },
                    'endpointId': 'endpoint-001'
                },
                'payload': {
                    'change': {
                        'cause': {
                            'type': 'PHYSICAL_INTERACTION'
                        },
                        'properties': [
                            {
                                'namespace': 'Alexa.PowerController',
                                'name': 'powerState',
                                'value': 'ON',
                                'timeOfSample': '2017-09-27T18:30:30.45Z',
                                'uncertaintyInMilliseconds': 200
                            }
                        ]
                    }
                }
            }
        }
        ";

        [Fact]
        public void ResponseParse_ChangeReport_Test()
        {
            SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(CHANGE_REPORT);
            //Context check
            Assert.NotNull(responseFromString.Context);
            Assert.NotNull(responseFromString.Context.Properties);
            Assert.Equal(2, responseFromString.Context.Properties.Count);
            // Property 1
            TestFunctionsV3.TestContextProperty(responseFromString.Context.Properties[0], PropertyNames.BRIGHTNESS, Namespaces.ALEXA_BRIGHTNESSCONTROLLER, DateTime.Parse("2017-09-27T18:30:30.45Z"), 200, null);
            Assert.Equal(typeof(System.Int32), responseFromString.Context.Properties[0].Value.GetType());
            Assert.Equal(85, responseFromString.Context.Properties[0].Value);
            // Property 2
            TestFunctionsV3.TestBasicHealthCheckProperty(responseFromString.Context.Properties[1], ConnectivityModes.OK, DateTime.Parse("2017-09-27T18:30:30.45Z"));
            //Event Check
            Assert.NotNull(responseFromString.Event);
            Assert.Equal(typeof(Event), responseFromString.Event.GetType());
            Event e = responseFromString.Event as Event;
            TestFunctionsV3.TestHeaderV3(e.Header, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4", Namespaces.ALEXA, HeaderNames.CHANGE_REPORT);
            TestFunctionsV3.TestEndpointV3(e.Endpoint, ScopeTypes.BearerToken, "access-token-from-Amazon", "endpoint-001");
            Assert.NotNull(e.Payload);
            Assert.Equal(typeof(ChangeReportPayload), e.Payload.GetType());
            ChangeReportPayload p = e.Payload as ChangeReportPayload;
            Assert.NotNull(p.Change);
            Assert.NotNull(p.Change.Cause);
            Assert.Equal(CauseTypes.PHYSICAL_INTERACTION, p.Change.Cause.Type);
            Assert.NotNull(p.Change.Properties);
            Assert.Equal(1, p.Change.Properties.Count);
            TestFunctionsV3.TestContextProperty(p.Change.Properties[0], PropertyNames.POWER_STATE, Namespaces.ALEXA_POWERCONTROLLER, DateTime.Parse("2017-09-27T18:30:30.45Z"), 200, null);
            Assert.Equal(typeof(PowerStates), p.Change.Properties[0].Value.GetType());
            Assert.Equal(PowerStates.ON, p.Change.Properties[0].Value);
        }

        [Fact]
        public void ResponseCreation_ChangeReport_Test()
        {
            SmartHomeResponse response = SmartHomeResponse.CreateChangeReportEvent(true);
            Assert.NotNull(response.Event);
            Assert.Null(response.Context);
            response.Context = new Context();
            Property p1 = new Property(Namespaces.ALEXA_BRIGHTNESSCONTROLLER, PropertyNames.BRIGHTNESS, 85, 
                DateTime.Parse("2017-09-27T18:30:30.45Z").ToUniversalTime(), 200);
            Property p2 = new Property(Namespaces.ALEXA_ENDPOINTHEALTH, PropertyNames.CONNECTIVITY, new ConnectivityPropertyValue(ConnectivityModes.OK),
                DateTime.Parse("2017-09-27T18:30:30.45Z").ToUniversalTime(), 200);
            response.Context.Properties.Add(p1);
            response.Context.Properties.Add(p2);
            Assert.Equal(typeof(Event), response.Event.GetType());
            Event e = response.Event as Event;
            //Header
            Assert.NotNull(e.Header);
            Assert.Equal(Namespaces.ALEXA, e.Header.Namespace);
            Assert.Equal(HeaderNames.CHANGE_REPORT, e.Header.Name);
            e.Header.MessageId = "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4";
            //Payload
            Assert.NotNull(e.Payload);
            Assert.Equal(typeof(ChangeReportPayload), e.Payload.GetType());
            Assert.Throws<JsonSerializationException>(() => JsonConvert.SerializeObject(response));
            ChangeReportPayload p = e.Payload as ChangeReportPayload;
            p.Change = new Change();
            Assert.Throws<JsonSerializationException>(() => JsonConvert.SerializeObject(response));
            p.Change.Cause = new Cause(CauseTypes.PHYSICAL_INTERACTION);
            p.Change.Properties.Add(new Property(Namespaces.ALEXA_POWERCONTROLLER, PropertyNames.POWER_STATE, PowerStates.ON, 
                DateTime.Parse("2017-09-27T18:30:30.45Z").ToUniversalTime(), 200));
            //Endpoint
            Assert.Null(e.Endpoint);
            //Diffrent Response
            SmartHomeResponse responseWithOutPayload = SmartHomeResponse.CreateChangeReportEvent(false);
            Assert.NotNull(responseWithOutPayload.Event.Payload);
            Assert.Equal(typeof(Payload), responseWithOutPayload.GetPayloadType());
            Assert.NotNull(JsonConvert.SerializeObject(response));
            Util.Util.WriteJsonToConsole("ChangeReport", response);
        }
    }
}
