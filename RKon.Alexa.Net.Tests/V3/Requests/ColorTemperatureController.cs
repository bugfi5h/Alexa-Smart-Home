﻿using Newtonsoft.Json;
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
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
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
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
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
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
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
        public void ResponseCreation_ColorTemperatureResponse_Test()
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
