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
    public class ChannelController
    {
        #region ChangeChannel
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
        public void RequestCreation_ChangeChannel_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(CHANGE_CHANNEL);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_CHANNELCONTROLLER, HeaderNames.CHANGE_CHANNEL);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==",requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(ChangeChannelRequestPayload),requestFromString.GetPayloadType());
            ChangeChannelRequestPayload payload = (requestFromString.Directive.Payload as ChangeChannelRequestPayload);
            //Channel
            Assert.NotNull(payload.Channel);
            Assert.Equal("1234", payload.Channel.Number);
            Assert.Equal("KSTATION1", payload.Channel.CallSign);
            Assert.Equal("KSTATION2", payload.Channel.AffiliateCallSign);
            Assert.Equal("someUrl", payload.Channel.Uri );
            //ChannelMetaData
            Assert.NotNull(payload.ChannelMetaData);
            Assert.Equal("Alternate Channel Name", payload.ChannelMetaData.Name);
            Assert.Equal("urlToImage",payload.ChannelMetaData.Image );
        }
        #endregion
        #region skipChannel

        private const string SKIP_CHANNELS = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.ChannelController',
                    'name': 'SkipChannels',
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
                    'channelCount': 5
                }
            }
        }
        ";

        [Fact]
        public void RequestCreation_SkipChannel_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SKIP_CHANNELS);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_CHANNELCONTROLLER, HeaderNames.SKIP_CHANNELS);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", requestFromString.Directive.Header.CorrelationToken );
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(SkipChannelRequestPayload), requestFromString.GetPayloadType());
            SkipChannelRequestPayload payload = (requestFromString.Directive.Payload as SkipChannelRequestPayload);
            //Channel
            Assert.NotNull(payload);
            Assert.Equal(5,payload.ChannelCount);
        }
        #endregion
        #region ChannelResponse

        private const string CHANNEL_RESPONSE = @"
        {
            'context': {
                'properties': [
                    {
                        'namespace': 'Alexa.ChannelController',
                        'name': 'channel',
                        'value': {
                            'number': '1234',
                            'callSign': 'callsign1',
                            'affiliateCallSign': 'callsign2'
                        },
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
        public void ResponseParse_ChannelResponse_Test()
        {
            SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(CHANNEL_RESPONSE);
            //Context check
            Assert.NotNull(responseFromString.Context);
            Assert.NotNull(responseFromString.Context.Properties);
            Assert.Equal(2, responseFromString.Context.Properties.Count);
            // Property 1
            TestFunctionsV3.TestContextProperty(responseFromString.Context.Properties[0], PropertyNames.CHANNEL, Namespaces.ALEXA_CHANNELCONTROLLER, DateTime.Parse("2017-09-27T18:30:30.45Z"), 200, null);
            Assert.Equal(typeof(Channel), responseFromString.Context.Properties[0].Value.GetType());
            Channel channel = responseFromString.Context.Properties[0].Value as Channel;
            Assert.Null(channel.Uri);
            Assert.Equal("callsign2", channel.AffiliateCallSign);
            Assert.Equal("callsign1", channel.CallSign);
            Assert.Equal("1234", channel.Number);
            // Property 2
            TestFunctionsV3.TestBasicHealthCheckProperty(responseFromString.Context.Properties[1], ConnectivityModes.OK, DateTime.Parse("2017-09-27T18:30:30.45Z"));
            //Event Check
            TestFunctionsV3.TestBasicEventWithEmptyPayload(responseFromString, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4",
                "dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", "BearerToken",
                 "access-token-from-Amazon", "endpoint-001");
        }
        #endregion
    }
}
