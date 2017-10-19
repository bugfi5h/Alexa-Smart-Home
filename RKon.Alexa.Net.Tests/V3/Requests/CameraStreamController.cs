using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.V3.TestFunctions;
using RKon.Alexa.NET.JsonObjects;
using RKon.Alexa.NET.Payloads;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using System.IO;
using Xunit;

namespace RKon.Alexa.Net.Tests.V3.Requests
{
    public class CameraStreamController
    {
        #region CameraStream
        private const string INIT_CAMERA_STREAMS_REQUEST = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.CameraStreamController',
                    'name': 'InitializeCameraStreams',
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
                    'cameraStreams': [
                        {
                            'protocol': 'RTSP',
                            'resolution': {
                                'width': 1920,
                                'height': 1080
                            },
                            'authorizationType': 'BEARER',
                            'videoCodec': 'H264',
                            'audioCodec': 'AAC'
                        },
                        {
                            'protocol': 'RTSP',
                            'resolution': {
                                'width': 1280,
                                'height': 720
                            },
                            'authorizationType': 'BEARER',
                            'videoCodec': 'MPEG2',
                            'audioCodec': 'G711'
                        }
                    ]
                }
            }
        }
        ";

        private const string CAMERA_STREAM_RESPONSE = @"
        {
            'context': {
                'properties': [
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
                    'namespace': 'Alexa.CameraStreamController',
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
                'payload': {
                    'cameraStreams': [
                        {
                            'uri': 'rtsp://username:password@link.to.video:443/feed1.mp4',
                            'expirationTime': '2017-09-27T20:30:30.45Z',
                            'idleTimeoutSeconds': 30,
                            'protocol': 'RTSP',
                            'resolution': {
                                'width': 1920,
                                'height': 1080
                            },
                            'authorizationType': 'BASIC',
                            'videoCodec': 'H264',
                            'audioCodec': 'AAC'
                        },
                        {
                            'uri': 'rtsp://username:password@link.to.video:443/feed2.mp4',
                            'expirationTime': '2017-09-27T20:30:30.45Z',
                            'idleTimeoutSeconds': 60,
                            'protocol': 'RTSP',
                            'resolution': {
                                'width': 1280,
                                'height': 720
                            },
                            'authorizationType': 'DIGEST',
                            'videoCodec': 'MPEG2',
                            'audioCodec': 'G711'
                        }
                    ],
                    'imageUri': 'https://username:password@link.to.image/image.jpg'
                }
            }
        }
        ";

        [Fact]
        public void RequestCreation_CameraStream_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(INIT_CAMERA_STREAMS_REQUEST);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_CAMERASTREAMCONTROLLER, HeaderNames.INIT_CAMERA_STREAMS);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(InitializeCameraRequestPayload),requestFromString.GetPayloadType());
            InitializeCameraRequestPayload payload = (requestFromString.Directive.Payload as InitializeCameraRequestPayload);
            Assert.NotNull(payload.CameraStreams);
            Assert.Equal(2, payload.CameraStreams.Count);
            TestRequestCameraStream(payload.CameraStreams[0], "RTSP", 1920, 1080, "BASIC", "H264", "AAC");
            TestRequestCameraStream(payload.CameraStreams[1], "RTSP", 1280, 720, "BEARER", "MPEG2", "G711");
        }

        private void TestRequestCameraStream(CameraStream s, string protocol, int width, int height, 
            string authorizationType, string videoCodec, string audioCodec )
        {
            Assert.Equal(protocol, s.Protocol);
            Assert.NotNull(s.Resolution);
            Assert.Equal(width, s.Resolution.Width);
            Assert.Equal(height , s.Resolution.Height);
            Assert.Equal(authorizationType, s.AuthorizationType);
            Assert.Equal(videoCodec, s.VideoCodec);
            Assert.Equal(audioCodec, s.AudioCodec);
        }

        [Fact]
        public void ResponseCreation_CameraStream_Test()
        {
            SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(CAMERA_STREAM_RESPONSE);
            //Context check
            Assert.NotNull(responseFromString.Context);
            Assert.NotNull(responseFromString.Context.Properties);
            Assert.Equal(1, responseFromString.Context.Properties.Count);
            // Property 1
            TestFunctionsV3.TestContextProperty(responseFromString.Context.Properties[0], PropertyNames.CONNECTIVITY, Namespaces.ALEXA_ENDPOINTHEALTH, DateTime.Parse("2017-09-27T18:30:30.45Z"), 200, null);
            Assert.Equal(responseFromString.Context.Properties[0].Value.GetType(), typeof(ConnectivityProperty));
            ConnectivityProperty conn = responseFromString.Context.Properties[0].Value as ConnectivityProperty;
            Assert.Equal(ConnectivityModes.OK, conn.Value);
            //Event Check
            Assert.NotNull(responseFromString.Event);
            Assert.Equal(typeof(Event), responseFromString.Event.GetType());
            //Header Check
            TestFunctionsV3.TestHeaderV3(responseFromString.Event.Header, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4", Namespaces.ALEXA_CAMERASTREAMCONTROLLER, HeaderNames.RESPONSE);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", responseFromString.Event.Header.CorrelationToken);
            //Endpoint Check
            Event e = responseFromString.Event as Event;
            TestFunctionsV3.TestEndpointV3(e.Endpoint, "BearerToken", "access-token-from-Amazon", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(ResponseCameraStreamsPayload), responseFromString.GetPayloadType());
            ResponseCameraStreamsPayload payload = responseFromString.Event.Payload as ResponseCameraStreamsPayload;
            Assert.NotNull(payload.CameraStreams);
            Assert.Equal(2, payload.CameraStreams.Count);
            TestResponseCameraStream(payload.CameraStreams[0], "rtsp://username:password@link.to.video:443/feed1.mp4",
                DateTime.Parse("2017-09-27T20:30:30.45Z"), 30, "RTSP", 1920, 1080, "BASIC", "H264", "AAC");
            TestResponseCameraStream(payload.CameraStreams[1], "rtsp://username:password@link.to.video:443/feed2.mp4",
                DateTime.Parse("2017-09-27T20:30:30.45Z"), 60, "RTSP", 1280, 720, "DIGEST", "MPEG2", "G711");
            Assert.Equal("https://username:password@link.to.image/image.jpg", payload.ImageURI);
        }

        private void TestResponseCameraStream(ResponseCameraStream s, string uri, DateTime expirationTime, int idleTimeout, 
            string protocol, int width, int height, string authorizationType, string videoCodec, string audioCodec)
        {
            Assert.Equal(uri, s.URI);
            Assert.Equal(expirationTime.ToUniversalTime(), s.ExpirationTime);
            Assert.Equal(idleTimeout, s.IdleTimeoutSeconds);
            TestRequestCameraStream(s, protocol, width, height, authorizationType, videoCodec, audioCodec);
        }
        #endregion
    }
}