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
    public class ColorTemperatureController
    {
        #region decreaseTemperature
        private const string DECREASE_COLORTEMPERATURE = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.ColorTemperatureController',
                    'name': 'DecreaseColorTemperature',
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

        [Fact]
        public void RequestCreation_DecreaseColorTemperature_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(DECREASE_COLORTEMPERATURE);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_COLORTEMPERATURECONTROLLER, HeaderNames.DECREASE_COLORTEMPERATURE);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==",requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "endpoint-001");
            TestFunctionsV3.TestBearerTokenV3(requestFromString.Directive.Endpoint.Scope, "access-token-from-skill");
            //Payload Check
            Assert.Equal(typeof(Payload),requestFromString.GetPayloadType());
            Payload payload = (requestFromString.Directive.Payload as Payload);
            Assert.NotNull(payload);
        }
        #endregion
        #region increaseTemperature
        private const string INCREASE_COLORTEMPERATURE = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.ColorTemperatureController',
                    'name': 'IncreaseColorTemperature',
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

        [Fact]
        public void RequestCreation_IncreaseColorTemperature_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(INCREASE_COLORTEMPERATURE);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_COLORTEMPERATURECONTROLLER, HeaderNames.INCREASE_COLORTEMPERATURE);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==",requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "endpoint-001");
            TestFunctionsV3.TestBearerTokenV3(requestFromString.Directive.Endpoint.Scope, "access-token-from-skill");
            //Payload Check
            Assert.Equal(typeof(Payload),requestFromString.GetPayloadType());
            Payload payload = (requestFromString.Directive.Payload as Payload);
            Assert.NotNull(payload);
        }
        #endregion
        #region SetTemperature
        private const string SET_COLORTEMPERATURE = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.ColorTemperatureController',
                    'name': 'SetColorTemperature',
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
                    'colorTemperatureInKelvin': 5000
                }
            }
        }
        ";

        [Fact]
        public void RequestCreation_SetColorTemperature_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_COLORTEMPERATURE);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_COLORTEMPERATURECONTROLLER, HeaderNames.SET_COLORTEMPERATURE);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==",requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "endpoint-001");
            TestFunctionsV3.TestBearerTokenV3(requestFromString.Directive.Endpoint.Scope, "access-token-from-skill");
            //Payload Check
            Assert.Equal(typeof(SetColorTemperatureRequestPayload),requestFromString.GetPayloadType());
            SetColorTemperatureRequestPayload payload = (requestFromString.Directive.Payload as SetColorTemperatureRequestPayload);
            Assert.NotNull(payload);
            Assert.Equal(5000, payload.ColorTemperatureInKelvin);
        }
        #endregion
        #region ColorTemperatureResponse
        private const string COLOR_TEMP_RESPONSE = @"
        {
            'context': {
                'properties': [
                    {
                        'namespace': 'Alexa.ColorTemperatureController',
                        'name': 'colorTemperatureInKelvin',
                        'value': 5000,
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
        public void ResponseParse_ColorTemperatureResponse_Test()
        {
            SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(COLOR_TEMP_RESPONSE);
            //Context check
            Assert.NotNull(responseFromString.Context);
            Assert.NotNull(responseFromString.Context.Properties);
            Assert.Equal(2, responseFromString.Context.Properties.Count);
            // Property 1
            TestFunctionsV3.TestContextProperty(responseFromString.Context.Properties[0], PropertyNames.COLOR_TEMPERATURE_IN_KELVIN, Namespaces.ALEXA_COLORTEMPERATURECONTROLLER, DateTime.Parse("2017-09-27T18:30:30.45Z"), 200, null);
            Assert.Equal(typeof(System.Int32), responseFromString.Context.Properties[0].Value.GetType());
            Assert.Equal(5000, responseFromString.Context.Properties[0].Value);
            // Property 2
            TestFunctionsV3.TestBasicHealthCheckProperty(responseFromString.Context.Properties[1], ConnectivityModes.OK, DateTime.Parse("2017-09-27T18:30:30.45Z"));
            //Event Check
            TestFunctionsV3.TestBasicEventWithEmptyPayload(responseFromString, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4",
                "dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", ScopeTypes.BearerToken,
                 "access-token-from-Amazon", "endpoint-001");
        }

        [Fact]
        public void ResponseCreation_ColorTemperatureResponse_Test()
        {
            SmartHomeRequest request = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_COLORTEMPERATURE);
            SmartHomeResponse response = new SmartHomeResponse(request.Directive.Header);
            Assert.Null(response.Context);
            response.Context = new Context();
            Color color = new Color(350.5, 0.7138, 0.6524);
            Property p = new Property(Namespaces.ALEXA_COLORTEMPERATURECONTROLLER, PropertyNames.COLOR_TEMPERATURE_IN_KELVIN,
                5000, DateTime.Parse("2017-09-27T18:30:30.45Z").ToUniversalTime(), 200);
            ConnectivityPropertyValue value = new ConnectivityPropertyValue(ConnectivityModes.OK);
            Property p2 = new Property(Namespaces.ALEXA_ENDPOINTHEALTH, PropertyNames.CONNECTIVITY, value, 
                DateTime.Parse("2017-09-27T18:30:30.45Z").ToUniversalTime(), 200);
            response.Context.Properties.Add(p);
            response.Context.Properties.Add(p2);
            Assert.NotNull(response.Event);
            Assert.Equal(typeof(Event), response.Event.GetType());
            Event e = response.Event as Event;
            TestFunctionsV3.CheckResponseCreatedBaseHeader(e.Header, request.Directive.Header);
            Assert.Null(e.Endpoint);
            e.Endpoint = new Endpoint("endpoint-001", new NET.JsonObjects.Scopes.BearerToken("access-token-from-Amazon"));
            Assert.NotNull(e.Payload);
            Assert.Equal(typeof(Payload), response.GetPayloadType());
            Assert.NotNull(JsonConvert.SerializeObject(response));
            Util.Util.WriteJsonToConsole("ColorTemperature", response);
        }
        #endregion
    }
}
