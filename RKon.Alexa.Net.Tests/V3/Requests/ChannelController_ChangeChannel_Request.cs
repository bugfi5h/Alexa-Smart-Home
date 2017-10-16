using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.V3.TestFunctions;
using RKon.Alexa.NET.Payloads.Request;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Types;
using Xunit;

namespace RKon.Alexa.Net.Tests.V3.Requests
{
    public class ChannelController_ChangeChannel_Request
    {
        private const string CHANGE_CHANNEL = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.ChannelController',
                    'name': 'ChangeChannel',
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
                    'channel': {
                        'number': '1234',
                        'callSign': 'KSTATION1',
                        'affiliateCallSign': 'KSTATION2',
                        'uri': 'someUrl'
                    },
                    'channelMetadata': {
                        'name': 'Alternate Channel Name',
                        'image': 'urlToImage'
                    }
                }
            }
        }
        ";

        [Fact]
        public void RequestCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(CHANGE_CHANNEL);
            //Directive Check
            Assert.True(requestFromString.Directive != null);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_CHANNELCONTROLLER, HeaderNames.CHANGE_CHANNEL);
            Assert.Equal(requestFromString.Directive.Header.CorrelationToken, "dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==");
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(requestFromString.GetPayloadType(), typeof(ChangeChannelRequestPayload));
            ChangeChannelRequestPayload payload = (requestFromString.Directive.Payload as ChangeChannelRequestPayload);
            //Channel
            Assert.True(payload.Channel != null);
            Assert.Equal(payload.Channel.Number, "1234");
            Assert.Equal(payload.Channel.CallSign, "KSTATION1");
            Assert.Equal(payload.Channel.AffiliateCallSign, "KSTATION2");
            Assert.Equal(payload.Channel.Uri, "someUrl");
            //ChannelMetaData
            Assert.True(payload.ChannelMetaData != null);
            Assert.Equal(payload.ChannelMetaData.Name, "Alternate Channel Name");
            Assert.Equal(payload.ChannelMetaData.Image, "urlToImage");
        }
    }
}
