using RKon.Alexa.NET.JsonObjects;
using RKon.Alexa.NET.Payloads.Request;
using RKon.Alexa.NET.Request;
using System.Collections.Generic;
using Xunit;

namespace RKon.Alexa.Net.Tests.V3.TestFunctions
{
    public class TestFunctionsV3
    {
        public static void TestHeaderV3(DirectiveHeader header, string guid, string strNamespace, string strRequestName)
        {
            Assert.True(header != null);
            Assert.Equal(header.MessageId, guid);
            Assert.Equal(header.Namespace, strNamespace);
            Assert.Equal(header.Name, strRequestName);
            Assert.Equal(header.PayloadVersion, "3");
        }

        public static void TestEndpointV3(Endpoint endpoint, string type, string token, string endpointId, int cookieCount = 0)
        {
            Assert.True(endpoint != null);
            Assert.True(endpoint.Scope != null);
            Assert.Equal(endpoint.Scope.Type, type);
            Assert.Equal(endpoint.Scope.Token, token);
            Assert.Equal(endpoint.EndpointID, endpointId);
            if(endpoint.Cookie != null)
            {
                Assert.True(endpoint.Cookie.Count == cookieCount);
            }
        }

        public static void TestRequestPayloadCameraStreams(InitializeCameraRequestPayload payload, int index, string protocol, Resolution resolution, string auth, string videoCodec, string audioCodec)
        {
            Assert.Equal(payload.CameraStreams[index].Protocol, protocol);
            Assert.Equal(payload.CameraStreams[index].Resolution, resolution);
            Assert.Equal(payload.CameraStreams[index].AuthorizationType, auth);
            Assert.Equal(payload.CameraStreams[index].VideoCodec, videoCodec);
            Assert.Equal(payload.CameraStreams[index].AudioCodec, audioCodec);
        }

        public static void TestContextProperty(Property prop, string name, string strNamespace, string timeOfSample, int uncertaintyInMilliseconds, string customName)
        {
            Assert.Equal(prop.Name, name);
            Assert.Equal(prop.Namespace, strNamespace);
            Assert.Equal(prop.TimeOfSample, timeOfSample);
            Assert.Equal(prop.UncertaintyInMilliseconds, uncertaintyInMilliseconds);
            Assert.Equal(prop.CustomName, customName);
            // Value has to be Checked seperatly
        } 
    }
}
