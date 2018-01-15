using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.V3.TestFunctions;
using RKon.Alexa.NET.JsonObjects;
using RKon.Alexa.NET.Payloads;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using Xunit;

namespace RKon.Alexa.Net.Tests.V3.Requests
{
    public class BrightnessController
    {
        #region AdjustBrightness
        private const string ADJUST_BRIGHTNESS_REQUEST = @"
            {
                'directive': {
                    'header': {
                        'namespace': 'Alexa.BrightnessController',
                        'name': 'AdjustBrightness',
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
                    'payload': {
                        'brightnessDelta': -25
                    }
                }
            }
        ";

        private const string ADJUST_BRIGHTNESS_RESPONSE = @"
        {
            'context': {
                'properties': [
                    {
                        'namespace': 'Alexa.BrightnessController',
                        'name': 'brightness',
                        'value': 50,
                        'timeOfSample': '2017-02-03T16:20:50.52Z',
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
        public void RequestCreation_AdjustBrightness_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(ADJUST_BRIGHTNESS_REQUEST);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_BRIGHTNESSCONTROLLER, HeaderNames.ADJUST_BRIGHTNESS);
            Assert.Equal(requestFromString.Directive.Header.CorrelationToken, "dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==");
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "endpoint-001");
            TestFunctionsV3.TestBearerTokenV3(requestFromString.Directive.Endpoint.Scope, "access-token-from-skill");
            //Payload Check
            Assert.Equal(typeof(AdjustBrightnessRequestPayload), requestFromString.GetPayloadType());
            Assert.Equal(-25, (requestFromString.Directive.Payload as AdjustBrightnessRequestPayload).BrightnessDelta);
        }

        [Fact]
        public void ResponseParse_AdjustBrightness_Test()
        {
            SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(ADJUST_BRIGHTNESS_RESPONSE);
            //Context check
            Assert.NotNull(responseFromString.Context);
            Assert.NotNull(responseFromString.Context.Properties);
            Assert.Equal(2, responseFromString.Context.Properties.Count);
            // Property 1
            TestFunctionsV3.TestContextProperty(responseFromString.Context.Properties[0], PropertyNames.BRIGHTNESS, Namespaces.ALEXA_BRIGHTNESSCONTROLLER, System.DateTime.Parse("2017-02-03T16:20:50.52Z"), 200, null);
            Assert.Equal(typeof(int), responseFromString.Context.Properties[0].Value.GetType());
            Assert.Equal(50, responseFromString.Context.Properties[0].Value);
            // Property 2
            TestFunctionsV3.TestBasicHealthCheckProperty(responseFromString.Context.Properties[1], ConnectivityModes.OK, DateTime.Parse("2017-09-27T18:30:30.45Z"));
            //Event Check
            TestFunctionsV3.TestBasicEventWithEmptyPayload(responseFromString, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4",
                "dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", ScopeTypes.BearerToken,
                 "access-token-from-Amazon", "endpoint-001");
        }

        [Fact]
        public void ResponseCreation_AdjustBrightness_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(ADJUST_BRIGHTNESS_REQUEST);
            SmartHomeResponse response = new SmartHomeResponse(requestFromString.Directive.Header);
            Assert.NotNull(response);
            Assert.Null(response.Context);
            Assert.NotNull(response.Event);
            Assert.Equal(typeof(Event), response.Event.GetType());
            Event e = response.Event as Event;
            TestFunctionsV3.CheckResponseCreatedBaseHeader(e.Header, requestFromString.Directive.Header);
            Assert.Null(e.Endpoint);
            Assert.NotNull(e.Payload);
            Util.Util.WriteJsonToConsole("AdjustBrightness", response);
        }
#endregion
        #region SetBrightness
        private const string SET_BRIGHTNESS_REQUEST = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.BrightnessController',
                    'name': 'SetBrightness',
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
                'payload': {
                    'brightness': 75
                }
            }
        }
        ";

        private const string SET_BRIGHTNESS_RESPONSE = @"
        {
            'context': {
                'properties': [
                    {
                        'namespace': 'Alexa.BrightnessController',
                        'name': 'brightness',
                        'value': 75,
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
        }";

        [Fact]
        public void RequestCreation_SetBrightness_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_BRIGHTNESS_REQUEST);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_BRIGHTNESSCONTROLLER,
                HeaderNames.SET_BRIGHTNESS);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "endpoint-001");
            TestFunctionsV3.TestBearerTokenV3(requestFromString.Directive.Endpoint.Scope, "access-token-from-skill");
            //Payload Check
            Assert.Equal(typeof(SetBrightnessRequestPayload), requestFromString.GetPayloadType());
            Assert.Equal(75, (requestFromString.Directive.Payload as SetBrightnessRequestPayload).Brightness);
        }

        [Fact]
        public void ResponseParse_SetBrightness_Test()
        {
            SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(SET_BRIGHTNESS_RESPONSE);
            //Context check
            Assert.NotNull(responseFromString.Context);
            Assert.NotNull(responseFromString.Context.Properties);
            Assert.Equal(2, responseFromString.Context.Properties.Count);
            // Property 1
            TestFunctionsV3.TestContextProperty(responseFromString.Context.Properties[0], PropertyNames.BRIGHTNESS, Namespaces.ALEXA_BRIGHTNESSCONTROLLER, DateTime.Parse("2017-09-27T18:30:30.45Z"), 200, null);
            Assert.Equal(typeof(System.Int32), responseFromString.Context.Properties[0].Value.GetType());
            Assert.Equal(75, responseFromString.Context.Properties[0].Value);
            // Property 2
            TestFunctionsV3.TestBasicHealthCheckProperty(responseFromString.Context.Properties[1], ConnectivityModes.OK, DateTime.Parse("2017-09-27T18:30:30.45Z"));
            //Event Check
            TestFunctionsV3.TestBasicEventWithEmptyPayload(responseFromString, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4",
                "dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", ScopeTypes.BearerToken,
                 "access-token-from-Amazon", "endpoint-001");
        }

        [Fact]
        public void ResponseCreation_SetBrightness_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_BRIGHTNESS_REQUEST);
            SmartHomeResponse response = new SmartHomeResponse(requestFromString.Directive.Header);
            Assert.NotNull(response);
            Assert.Null(response.Context);
            response.Context = new Context();
            response.Context.Properties.Add(new Property(Namespaces.ALEXA_BRIGHTNESSCONTROLLER, PropertyNames.BRIGHTNESS, 75,
                DateTime.Parse("2017-09-27T18:30:30.45Z").ToUniversalTime(), 200));
            response.Context.Properties.Add(new Property(Namespaces.ALEXA_ENDPOINTHEALTH, PropertyNames.CONNECTIVITY, new ConnectivityPropertyValue(ConnectivityModes.OK),
                DateTime.Parse("2017-09-27T18:30:30.45Z").ToUniversalTime(), 200));
            Assert.NotNull(response.Event);
            Event e = response.Event;
            TestFunctionsV3.CheckResponseCreatedBaseHeader(e.Header, requestFromString.Directive.Header);
            Assert.Null(e.Endpoint);
            e.Endpoint = new Endpoint("endpoint-001", new NET.JsonObjects.Scopes.BearerToken("access-token-from-Amazon"));
            Assert.NotNull(e.Payload);
            Assert.Equal(typeof(Payload), e.Payload.GetType());
            Assert.NotNull(JsonConvert.SerializeObject(response));
            Util.Util.WriteJsonToConsole("SetBrightness", response);
        }
        #endregion
    }
}
