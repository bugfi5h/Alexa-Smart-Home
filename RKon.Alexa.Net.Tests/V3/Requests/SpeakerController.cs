using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.V3.TestFunctions;
using RKon.Alexa.NET.Payloads;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Types;
using Xunit;

namespace RKon.Alexa.Net.Tests.V3.Requests
{
    public class SpeakerController
    {
        #region ADjustVolume
        private const string ADJUST_VOLUME = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.Speaker',
                    'name': 'AdjustVolume',
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
                    'volume': -20,
                    'volumeDefault': false
                }
            }
        }
        ";

        [Fact]
        public void RequestCreation_AdjustVolume_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(ADJUST_VOLUME);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_SPEAKER, HeaderNames.ADJUST_VOLUME);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(SpeakerAdjustVolumeRequestPayload), requestFromString.GetPayloadType());
            SpeakerAdjustVolumeRequestPayload payload = (requestFromString.Directive.Payload as SpeakerAdjustVolumeRequestPayload);
            //Channel
            Assert.NotNull(payload);
            Assert.Equal(-20, payload.Volume);
            Assert.Equal(false, payload.VolumeDefault);
        }
        #endregion
    }
}
