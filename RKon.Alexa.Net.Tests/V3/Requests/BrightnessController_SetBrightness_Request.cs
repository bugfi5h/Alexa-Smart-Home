using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.V3.TestFunctions;
using RKon.Alexa.NET.Payloads.Request;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Types;
using Xunit;

namespace RKon.Alexa.Net.Tests.V3.Requests
{
    public class BrightnessController_SetBrightness_Request
    {
        private const string SET_BRIGHTNESS = @"
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

        [Fact]
        public void RequestCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_BRIGHTNESS);
            //Directive Check
            Assert.True(requestFromString.Directive != null);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_BRIGHTNESSCONTROLLER, HeaderNames.SET_BRIGHTNESS);
            Assert.Equal(requestFromString.Directive.Header.CorrelationToken, "dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==");
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(requestFromString.GetPayloadType(), typeof(SetBrightnessRequestPayload));
            Assert.Equal((requestFromString.Directive.Payload as SetBrightnessRequestPayload).Brightness, 75);
        }
    }
}
