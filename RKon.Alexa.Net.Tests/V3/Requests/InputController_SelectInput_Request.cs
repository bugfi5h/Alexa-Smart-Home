using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.V3.TestFunctions;
using RKon.Alexa.NET.Payloads.Request;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Types;
using Xunit;

namespace RKon.Alexa.Net.Tests.V3.Requests
{
    public class InputController_SelectInput_Request
    {
        private const string SELECT_INPUT = @"
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

        [Fact]
        public void RequestCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SELECT_INPUT);
            //Directive Check
            Assert.True(requestFromString.Directive != null);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_INPUTCONTROLLER, HeaderNames.SELECT_INPUT);
            Assert.Equal(requestFromString.Directive.Header.CorrelationToken, "dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==");
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(requestFromString.GetPayloadType(), typeof(SelectInputRequestPayload));
            SelectInputRequestPayload payload = (requestFromString.Directive.Payload as SelectInputRequestPayload);
            //Channel
            Assert.True(payload != null);
            Assert.Equal(payload.Input, "HDMI1");
        }
    }
}
