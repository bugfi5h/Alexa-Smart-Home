using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.V3.TestFunctions;
using RKon.Alexa.NET.Payloads;
using RKon.Alexa.NET.Payloads.Request;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Types;
using Xunit;

namespace RKon.Alexa.Net.Tests.V3.Requests
{
    public class Discovery_Request
    {
        private const string DISCOVERY_REQUEST = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.Discovery',
                    'name': 'Discover',
                    'payloadVersion': '3',
                    'messageId': '1bd5d003-31b9-476f-ad03-71d471922820'
                },
                'payload': {
                    'scope': {
                        'type': 'BearerToken',
                        'token': 'access-token-from-skill'
                    }
                }
            }
        }
        ";

        [Fact]
        public void RequestCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(DISCOVERY_REQUEST);
            //Directive Check
            Assert.True(requestFromString.Directive != null);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_DISCOVERY, HeaderNames.DISCOVERY_REQUEST);
            //Payload Check
            Assert.Equal(requestFromString.GetPayloadType(), typeof(RequestPayloadWithScope));
            RequestPayloadWithScope payload = (requestFromString.Directive.Payload as RequestPayloadWithScope);
            Assert.True(payload != null);
            Assert.True(payload.Scope != null);
            Assert.Equal(payload.Scope.Type, "BearerToken");
            Assert.Equal(payload.Scope.Token, "access-token-from-skill");
        }
    }
}
