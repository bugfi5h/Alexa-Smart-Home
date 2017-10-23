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
    public class InputController
    {
        private const string SELECT_INPUT_REQUEST = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.InputController',
                    'name': 'SelectInput',
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
                    'input': 'HDMI1'
                }
            }
        }
        ";

        private const string SELECT_INPUT_RESPONSE = @"
        {
            'context': {
                'properties': [
                    {
                        'namespace': 'Alexa.InputController',
                        'name': 'input',
                        'value': 'HDMI1',
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
        public void RequestCreation_SelectInput_Request_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SELECT_INPUT_REQUEST);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_INPUTCONTROLLER, HeaderNames.SELECT_INPUT);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(SelectInputRequestPayload), requestFromString.GetPayloadType());
            SelectInputRequestPayload payload = (requestFromString.Directive.Payload as SelectInputRequestPayload);
            //Channel
            Assert.NotNull(payload);
            Assert.Equal("HDMI1", payload.Input);
        }

        [Fact]
        public void ResponseParse_SelectInput_Test()
        {
            SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(SELECT_INPUT_RESPONSE);
            //Context check
            Assert.NotNull(responseFromString.Context);
            Assert.NotNull(responseFromString.Context.Properties);
            Assert.Equal(2, responseFromString.Context.Properties.Count);
            // Property 1
            TestFunctionsV3.TestContextProperty(responseFromString.Context.Properties[0], PropertyNames.INPUT, Namespaces.ALEXA_INPUTCONTROLLER, DateTime.Parse("2017-09-27T18:30:30.45Z"), 200, null);
            Assert.Equal(typeof(System.Int32), responseFromString.Context.Properties[0].Value.GetType());
            Assert.Equal(75, responseFromString.Context.Properties[0].Value);
            // Property 2
            TestFunctionsV3.TestBasicHealthCheckProperty(responseFromString.Context.Properties[1], ConnectivityModes.OK, DateTime.Parse("2017-09-27T18:30:30.45Z"));
            //Event Check
            TestFunctionsV3.TestBasicEventWithEmptyPayload(responseFromString, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4",
                "dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", "BearerToken",
                 "access-token-from-Amazon", "endpoint-001");
        }

    }
}
