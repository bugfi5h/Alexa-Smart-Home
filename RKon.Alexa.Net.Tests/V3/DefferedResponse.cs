using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.V3.TestFunctions;
using RKon.Alexa.NET.Payloads;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using Xunit;

namespace RKon.Alexa.Net.Tests.V3
{
    public class DefferedResponse
    {
        private const string DEFFERED = @"
        {
            'event': {
                'header': {
                    'namespace': 'Alexa',
                    'name': 'DeferredResponse',
                    'payloadVersion': '3',
                    'messageId': '5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4',
                    'correlationToken': 'dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg=='
                },
                'payload': {
                    'estimatedDeferralInSeconds': 20
                }
            }
        }
        ";
        [Fact]
        public void ResponseParse_DefferedResponse_Test()
        {
            SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(DEFFERED);
            //Context check
            Assert.Null(responseFromString.Context);
            //Event Check
            Assert.NotNull(responseFromString.Event);
            Assert.Equal(typeof(Event), responseFromString.Event.GetType());
            Event e = responseFromString.Event as Event;
            TestFunctionsV3.TestHeaderV3(e.Header, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4", Namespaces.ALEXA, HeaderNames.DEFFERED_RESPONSE);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", e.Header.CorrelationToken);
            Assert.NotNull(e.Payload);
            Assert.Equal(typeof(DefferedResponsePayload), e.Payload.GetType());
            DefferedResponsePayload p = e.Payload as DefferedResponsePayload;
            Assert.Equal(20, p.EstimatedDeferralInSeconds);
        }
    }
}
