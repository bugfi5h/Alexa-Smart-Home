using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.V3.TestFunctions;
using RKon.Alexa.NET.Payloads;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using Xunit;

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
        public void ResponseParse_SetBrightness_Test()
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
            TestFunctionsV3.TestEndpointV3(e.Endpoint, "BearerToken", "access-token-from-Amazon", "endpoint-001");
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
    }
}
