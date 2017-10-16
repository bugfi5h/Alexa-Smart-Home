﻿using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.V3.TestFunctions;
using RKon.Alexa.NET.JsonObjects;
using RKon.Alexa.NET.Payloads;
using RKon.Alexa.NET.Payloads.Request;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using Xunit;

namespace RKon.Alexa.Net.Tests.V3.Requests
{
    public class BrightnessController_AdjustBrightness_Request
    {
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
        public void RequestCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(ADJUST_BRIGHTNESS_RESPONSE);
            //Directive Check
            Assert.True(requestFromString.Directive != null);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_BRIGHTNESSCONTROLLER, HeaderNames.ADJUST_BRIGHTNESS);
            Assert.Equal(requestFromString.Directive.Header.CorrelationToken, "dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==");
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001",0);
            //Payload Check
            Assert.Equal(typeof(AdjustBrightnessRequestPayload),requestFromString.GetPayloadType() );
            Assert.Equal(-25,(requestFromString.Directive.Payload as AdjustBrightnessRequestPayload).BrightnessDelta );
        }

        [Fact]
        public void ResponseCreationTest()
        {
            SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(ADJUST_BRIGHTNESS_REQUEST);

            //Context check
            Assert.True(responseFromString.Context != null);
            Assert.True(responseFromString.Context.Properties != null);
            Assert.Equal(2,responseFromString.Context.Properties.Count);
            // Property 1
            TestFunctionsV3.TestContextProperty(responseFromString.Context.Properties[0], PropertyNames.BRIGHTNESS, Namespaces.ALEXA_BRIGHTNESSCONTROLLER, "2017-02-03T16:20:50.52Z", 200, null);
            Assert.Equal(typeof(System.Int32),responseFromString.Context.Properties[0].Value.GetType());
            Assert.Equal(50, responseFromString.Context.Properties[0].Value);
            // Property 2
            TestFunctionsV3.TestContextProperty(responseFromString.Context.Properties[1], PropertyNames.CONNECTIVITY, Namespaces.ALEXA_ENDPOINTHEALTH, "2017-09-27T18:30:30.45Z", 200, null);
            Assert.Equal(responseFromString.Context.Properties[1].Value.GetType(), typeof(ConnectivityProperty));
            ConnectivityProperty conn = responseFromString.Context.Properties[1].Value as ConnectivityProperty;
            Assert.Equal(ConnectivityModes.OK, conn.Value);
            //Event Check
            Assert.True(responseFromString.Event != null);
            Assert.Equal(typeof(Event), responseFromString.Event.GetType());
            //Header Check
            TestFunctionsV3.TestHeaderV3(responseFromString.Event.Header, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4", Namespaces.ALEXA, HeaderNames.RESPONSE);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", responseFromString.Event.Header.CorrelationToken);
            //Endpoint Check
            Event e = responseFromString.Event as Event;
            TestFunctionsV3.TestEndpointV3(e.Endpoint, "BearerToken", "access-token-from-Amazon", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(Payload),responseFromString.GetPayloadType());
        }
    }
}
