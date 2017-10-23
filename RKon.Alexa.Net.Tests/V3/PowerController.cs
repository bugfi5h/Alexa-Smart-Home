using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.V3.TestFunctions;
using RKon.Alexa.NET.Payloads;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using Xunit;

namespace RKon.Alexa.Net.Tests.V3.Requests
{
    public class PowerController
    {
        #region TurnOff
        private const string TURN_OFF_REQUEST = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.PowerController',
                    'name': 'TurnOff',
                    'payloadVersion': '3',
                    'messageId': '1bd5d003-31b9-476f-ad03-71d471922820',
                    'correlationToken': 'dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg=='
                },
                'endpoint': {
                    'scope': {
                        'type': 'BearerToken',
                        'token': 'access-token-from-skill'
                    },
                    'endpointId': 'endpoint-001',
                    'cookie': {}
                },
                'payload': {}
            }
        }
        ";

        private const string TURN_OFF_RESPONSE = @"
        {
            'context': {
                'properties': [
                    {
                        'namespace': 'Alexa.PowerController',
                        'name': 'powerState',
                        'value': 'OFF',
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
                    'name': 'Response',
                    'payloadVersion': '3',
                    'messageId': '5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4',
                    'correlationToken': 'dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg=='
                },
                'endpoint': {
                    'scope': {
                        'type': 'BearerToken',
                        'token': 'access-token-from-Amazon'
                    },
                    'endpointId': 'endpoint-001'
                },
                'payload': {}
            }
        }
        ";

        [Fact]
        public void RequestCreation_TurnOff_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(TURN_OFF_REQUEST);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_POWERCONTROLLER, HeaderNames.TURN_OFF_REQUEST);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(Payload), requestFromString.GetPayloadType());
            Payload payload = (requestFromString.Directive.Payload as Payload);
            //Channel
            Assert.NotNull(payload);
        }

        [Fact]
        public void ResponseParse_TurnOff_Test()
        {
            SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(TURN_OFF_RESPONSE);
            //Context check
            Assert.NotNull(responseFromString.Context);
            Assert.NotNull(responseFromString.Context.Properties);
            Assert.Equal(2, responseFromString.Context.Properties.Count);
            // Property 1
            TestFunctionsV3.TestContextProperty(responseFromString.Context.Properties[0], PropertyNames.POWER_STATE, Namespaces.ALEXA_POWERCONTROLLER, DateTime.Parse("2017-09-27T18:30:30.45Z"), 200, null);
            Assert.Equal(typeof(PowerStates), responseFromString.Context.Properties[0].Value.GetType());
            Assert.Equal(PowerStates.OFF, responseFromString.Context.Properties[0].Value);
            // Property 2
            TestFunctionsV3.TestBasicHealthCheckProperty(responseFromString.Context.Properties[1], ConnectivityModes.OK, DateTime.Parse("2017-09-27T18:30:30.45Z"));
            //Event Check
            TestFunctionsV3.TestBasicEventWithEmptyPayload(responseFromString, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4",
                "dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", "BearerToken",
                 "access-token-from-Amazon", "endpoint-001");
        }
        #endregion
        #region TurnOn
        private const string TURN_ON_REQUEST = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.PowerController',
                    'name': 'TurnOn',
                    'payloadVersion': '3',
                    'messageId': '1bd5d003-31b9-476f-ad03-71d471922820',
                    'correlationToken': 'dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg=='
                },
                'endpoint': {
                    'scope': {
                        'type': 'BearerToken',
                        'token': 'access-token-from-skill'
                    },
                    'endpointId': 'endpoint-001',
                    'cookie': {}
                },
                'payload': {}
            }
        }
        ";

        private const string TURN_ON_RESPONSE = @"
        {
            'context': {
                'properties': [
                    {
                        'namespace': 'Alexa.PowerController',
                        'name': 'powerState',
                        'value': 'ON',
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
                    'name': 'Response',
                    'payloadVersion': '3',
                    'messageId': '5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4',
                    'correlationToken': 'dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg=='
                },
                'endpoint': {
                    'scope': {
                        'type': 'BearerToken',
                        'token': 'access-token-from-Amazon'
                    },
                    'endpointId': 'endpoint-001'
                },
                'payload': {}
            }
        }
        ";

        [Fact]
        public void RequestCreation_TurnOn_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(TURN_ON_REQUEST);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_POWERCONTROLLER, HeaderNames.TURN_ON_REQUEST);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(Payload), requestFromString.GetPayloadType());
            Payload payload = (requestFromString.Directive.Payload as Payload);
            //Channel
            Assert.NotNull(payload);
        }

        [Fact]
        public void ResponseParse_TurnOn_Test()
        {
            SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(TURN_ON_RESPONSE);
            //Context check
            Assert.NotNull(responseFromString.Context);
            Assert.NotNull(responseFromString.Context.Properties);
            Assert.Equal(2, responseFromString.Context.Properties.Count);
            // Property 1
            TestFunctionsV3.TestContextProperty(responseFromString.Context.Properties[0], PropertyNames.POWER_STATE, Namespaces.ALEXA_POWERCONTROLLER, DateTime.Parse("2017-09-27T18:30:30.45Z"), 200, null);
            Assert.Equal(typeof(PowerStates), responseFromString.Context.Properties[0].Value.GetType());
            Assert.Equal(PowerStates.ON, responseFromString.Context.Properties[0].Value);
            // Property 2
            TestFunctionsV3.TestBasicHealthCheckProperty(responseFromString.Context.Properties[1], ConnectivityModes.OK, DateTime.Parse("2017-09-27T18:30:30.45Z"));
            //Event Check
            TestFunctionsV3.TestBasicEventWithEmptyPayload(responseFromString, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4",
                "dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", "BearerToken",
                 "access-token-from-Amazon", "endpoint-001");
        }
        #endregion
    }
}
