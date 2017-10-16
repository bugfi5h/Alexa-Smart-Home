using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.V3.TestFunctions;
using RKon.Alexa.NET.Payloads.Request;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Types;
using Xunit;

namespace RKon.Alexa.Net.Tests.V3.Requests
{
    public class CameraStreamController_Request
    {
        private const string INIT_CAMERA_STREAMS = @"
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

        [Fact]
        public void RequestCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(INIT_CAMERA_STREAMS);
            //Directive Check
            Assert.True(requestFromString.Directive != null);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_CAMERASTREAMCONTROLLER, HeaderNames.INIT_CAMERA_STREAMS);
            Assert.Equal(requestFromString.Directive.Header.CorrelationToken, "dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==");
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(requestFromString.GetPayloadType(), typeof(InitializeCameraRequestPayload));
            InitializeCameraRequestPayload payload = (requestFromString.Directive.Payload as InitializeCameraRequestPayload);
            Assert.True(payload.CameraStreams != null);
            for (int i = 0; i < payload.CameraStreams.Count; i++)
            {
                TestFunctionsV3.TestRequestPayloadCameraStreams(payload, i,
                    payload.CameraStreams[i].Protocol,
                    payload.CameraStreams[i].Resolution,
                    payload.CameraStreams[i].AuthorizationType,
                    payload.CameraStreams[i].VideoCodec,
                    payload.CameraStreams[i].AudioCodec);
            }
        }
    }
}
