using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.V3.TestFunctions;
using RKon.Alexa.NET.Payloads;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using Xunit;

namespace RKon.Alexa.Net.Tests.V3.Requests
{
    public class SpeakerController
    {
        #region AdjustVolume
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
        #region SetMute
        private const string SET_MUTE_REQUEST = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.Speaker',
                    'name': 'SetMute',
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
                    'mute': true
                }
            }
        }
        ";

        [Fact]
        public void RequestCreation_SetMute_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_MUTE_REQUEST);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_SPEAKER, HeaderNames.SET_MUTE);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(SetMuteRequestPayload), requestFromString.GetPayloadType());
            SetMuteRequestPayload payload = (requestFromString.Directive.Payload as SetMuteRequestPayload);
            //Channel
            Assert.NotNull(payload);
            Assert.Equal(true, payload.Mute);
        }

        #endregion
        #region SetVolume
        private const string SET_VOLUME_REQUEST = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.Speaker',
                    'name': 'SetVolume',
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
                    'volume': 50
                }
            }
        }
        ";

        [Fact]
        public void RequestCreation_SetVolume_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_VOLUME_REQUEST);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_SPEAKER, HeaderNames.SET_VOLUME);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(SetMuteRequestPayload), requestFromString.GetPayloadType());
            SetVolumeRequestPayload payload = (requestFromString.Directive.Payload as SetVolumeRequestPayload);
            //Channel
            Assert.NotNull(payload);
            Assert.Equal(50, payload.Volume);
        }

        #endregion
        #region SpeakerResponse
        private const string SPEAKER_RESPONSE = @"
        {
            'context': {
                'properties': [
                    {
                        'namespace': 'Alexa.Speaker',
                        'name': 'volume',
                        'value': 50,
                        'timeOfSample': '2017-09-27T18:30:30.45Z',
                        'uncertaintyInMilliseconds': 200
                    },
                    {
                        'namespace': 'Alexa.Speaker',
                        'name': 'muted',
                        'value': false,
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
        public void ResponseParse_SpeakerResponse_Test()
        {
            SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(SPEAKER_RESPONSE);
            //Context check
            Assert.NotNull(responseFromString.Context);
            Assert.NotNull(responseFromString.Context.Properties);
            Assert.Equal(3, responseFromString.Context.Properties.Count);
            // Property 1
            TestFunctionsV3.TestContextProperty(responseFromString.Context.Properties[0], PropertyNames.VOLUME, Namespaces.ALEXA_SPEAKER, DateTime.Parse("2017-09-27T18:30:30.45Z"), 200, null);
            Assert.Equal(typeof(int), responseFromString.Context.Properties[0].Value.GetType());
            Assert.Equal(50, responseFromString.Context.Properties[0].Value);
            // Property 2
            TestFunctionsV3.TestContextProperty(responseFromString.Context.Properties[1], PropertyNames.MUTED, Namespaces.ALEXA_SPEAKER, DateTime.Parse("2017-09-27T18:30:30.45Z"), 200, null);
            Assert.Equal(typeof(bool), responseFromString.Context.Properties[1].Value.GetType());
            Assert.Equal(false, responseFromString.Context.Properties[1].Value);
            // Property 3
            TestFunctionsV3.TestBasicHealthCheckProperty(responseFromString.Context.Properties[2], ConnectivityModes.OK, DateTime.Parse("2017-09-27T18:30:30.45Z"));
            //Event Check
            TestFunctionsV3.TestBasicEventWithEmptyPayload(responseFromString, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4",
                "dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", "BearerToken",
                 "access-token-from-Amazon", "endpoint-001");
        }
        #endregion

    }
}
