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
    public class ColorController
    {
        #region SetColor
        private const string SET_COLOR_REQUEST = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.ColorController',
                    'name': 'SetColor',
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
                    'color': {
                        'hue': 350.5,
                        'saturation': 0.7138,
                        'brightness': 0.6524
                    }
                }
            }
        }
        ";

        private const string SET_COLOR_RESPONSE = @"
        {
            'context': {
                'properties': [
                    {
                        'namespace': 'Alexa.ColorController',
                        'name': 'color',
                        'value': {
                            'hue': 350.5,
                            'saturation': 0.7138,
                            'brightness': 0.6524
                        },
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
        public void RequestCreation_SetColor_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_COLOR_REQUEST);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_COLORCONTROLLER, HeaderNames.SET_COLOR);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==",requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(SetColorRequestPayload),requestFromString.GetPayloadType());
            SetColorRequestPayload payload = (requestFromString.Directive.Payload as SetColorRequestPayload);
            Assert.NotNull(payload.Color);
            Assert.Equal(350.5,payload.Color.Hue);
            Assert.Equal(0.7138,payload.Color.Saturation);
            Assert.Equal(0.6524,payload.Color.Brightness);
        }

        [Fact]
        public void ResponseCreation_SetColor_Test()
        {
            SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(SET_COLOR_RESPONSE);
            //Context check
            Assert.NotNull(responseFromString.Context);
            Assert.NotNull(responseFromString.Context.Properties);
            Assert.Equal(2, responseFromString.Context.Properties.Count);
            // Property 1
            TestFunctionsV3.TestContextProperty(responseFromString.Context.Properties[0], PropertyNames.COLOR, Namespaces.ALEXA_COLORCONTROLLER, DateTime.Parse("2017-09-27T18:30:30.45Z"), 200, null);
            Assert.Equal(typeof(Color), responseFromString.Context.Properties[0].Value.GetType());
            Color color = responseFromString.Context.Properties[0].Value as Color;
            Assert.Equal(0.6524, color.Brightness);
            Assert.Equal(350.5, color.Hue);
            Assert.Equal(0.7138, color.Saturation);
            // Property 2
            TestFunctionsV3.TestContextProperty(responseFromString.Context.Properties[1], PropertyNames.CONNECTIVITY, Namespaces.ALEXA_ENDPOINTHEALTH, DateTime.Parse("2017-09-27T18:30:30.45Z"), 200, null);
            Assert.Equal(typeof(ConnectivityProperty), responseFromString.Context.Properties[1].Value.GetType());
            ConnectivityProperty conn = responseFromString.Context.Properties[1].Value as ConnectivityProperty;
            Assert.Equal(ConnectivityModes.OK, conn.Value);
            //Event Check
            Assert.NotNull(responseFromString.Event);
            Assert.Equal(typeof(Event), responseFromString.Event.GetType());
            //Header Check
            TestFunctionsV3.TestHeaderV3(responseFromString.Event.Header, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4", Namespaces.ALEXA, HeaderNames.RESPONSE);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", responseFromString.Event.Header.CorrelationToken);
            //Endpoint Check
            Event e = responseFromString.Event as Event;
            TestFunctionsV3.TestEndpointV3(e.Endpoint, "BearerToken", "access-token-from-Amazon", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(Payload), responseFromString.GetPayloadType());
        }
        #endregion
    }
}
