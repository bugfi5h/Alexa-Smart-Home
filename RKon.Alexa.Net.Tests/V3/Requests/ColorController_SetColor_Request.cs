using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.V3.TestFunctions;
using RKon.Alexa.NET.Payloads.Request;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Types;
using Xunit;

namespace RKon.Alexa.Net.Tests.V3.Requests
{
    public class ColorController_SetColor_Request
    {
        private const string SET_COLOR = @"
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

        [Fact]
        public void RequestCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_COLOR);
            //Directive Check
            Assert.True(requestFromString.Directive != null);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_COLORCONTROLLER, HeaderNames.SET_COLOR);
            Assert.Equal(requestFromString.Directive.Header.CorrelationToken, "dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==");
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(requestFromString.GetPayloadType(), typeof(SetColorRequestPayload));
            SetColorRequestPayload payload = (requestFromString.Directive.Payload as SetColorRequestPayload);
            Assert.True(payload.Color != null);
            Assert.Equal(payload.Color.Hue, 350.5);
            Assert.Equal(payload.Color.Saturation, 0.7138);
            Assert.Equal(payload.Color.Brightness, 0.6524);
        }
    }
}
