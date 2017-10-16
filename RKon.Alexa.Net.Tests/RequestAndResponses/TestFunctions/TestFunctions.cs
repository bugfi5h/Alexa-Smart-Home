/*using Newtonsoft.Json;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Request.RequestPayloads;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using System.Collections.Generic;
using Xunit;

namespace RKon.Alexa.Net.Tests
{
    public class TestFunctions
    {
        public static void TestRequestApplianceAndAccessToken<T>(T payload, string accessToken,string appId, Dictionary<string, object> details) where T : RequestPayloadWithAppliance
        {
            Assert.Equal(payload.AccessToken, accessToken);
            Assert.True(payload.Appliance != null);
            Assert.Equal(payload.Appliance.ApplianceId, appId);
            if (details != null)
                Assert.Equal(payload.Appliance.AdditionalApplianceDetails, details);
            else
                Assert.Equal(payload.Appliance.AdditionalApplianceDetails.Count, 0);
        }

        public static void TestTargetTemperatureResponsePayload(TargetTemperatureResponsePayload payload)
        {
            Assert.True(payload.TemperatureMode != null);
            Assert.True(payload.PreviousState != null);
            Assert.True(payload.PreviousState.TargetTemperature != null);
            Assert.True(payload.PreviousState.Mode != null);
            payload.TargetTemperature.Value = 25;
            payload.PreviousState.TargetTemperature.Value = 12;
            Assert.False(payload.TemperatureMode.TrySetTemperatureMode("sad"));
            Assert.True(payload.TemperatureMode.TrySetTemperatureMode(DeviceModes.COOL));
            Assert.False(payload.PreviousState.Mode.TrySetTemperatureMode("sad"));
            Assert.True(payload.PreviousState.Mode.TrySetTemperatureMode(DeviceModes.HEAT));
        }
        public static void TestColorTemperatureResponsePayload(ColorTemperatureResponsePayload payload)
        {
            Assert.True(payload.AchievedState != null);
            Assert.True(payload.AchievedState.ColorTemperature != null);
            payload.AchievedState.ColorTemperature.Value = 2700;
        }

        public static void TestIn_DecrementTemperatureRequestPayload(In_DecrementTemperatureRequestPayload payload, string accessToken, string appId, Dictionary<string,object> details, double temp)
        {
            TestRequestApplianceAndAccessToken(payload,accessToken, appId, details);
            Assert.True(payload.DeltaTemperature != null);
            Assert.Equal(payload.DeltaTemperature.Value, temp);
        }

        public static void TestIn_DecrementPercentageRequestPayload(In_DecrementPercentageRequestPayload payload, string accessToken, string appId, Dictionary<string, object> details,double value)
        {
            Assert.True(payload.DeltaPercentage != null);
            Assert.Equal(payload.DeltaPercentage.Value, value);
            TestRequestApplianceAndAccessToken(payload, accessToken, appId, details);
        }

        public static void TestIn_DecrementColorTemperatureRequestPayload(In_DecrementColorTemperatureRequestPayload payload, string accessToken, string appId, Dictionary<string, object> details)
        {
            TestRequestApplianceAndAccessToken(payload, accessToken, appId, details);
        }

        public static void TestGetTemperatureRequestPayload(GetTemperatureRequestPayload payload, string accessToken, string appId, Dictionary<string, object> details)
        {
            TestRequestApplianceAndAccessToken(payload, accessToken, appId, details);
        }

        public static void TestRetrieveCameraStreamUriRequestPayload(RetrieveCameraStreamUriRequestPayload payload, string accessToken, string appId, Dictionary<string, object> details, string dirID)
        {
            Assert.True(payload.DirectedId != null);
            Assert.True(payload.DirectedId == dirID);
            TestRequestApplianceAndAccessToken(payload, accessToken, appId, details);
        }

        public static SmartHomeResponse TestCreateResponseIfPossible(RequestHeader header)
        {
            SmartHomeResponse response = null;
            try
            {
                response = new SmartHomeResponse(header);
            }
            catch (Exception)
            {
            }
            Assert.True(response != null);
            Assert.True(response.Header != null);
            Assert.True(response.Payload != null);
            return response;
        }

        public static void TestResponseHeader(ResponseHeader header, string strNamespace, string strRequestName)
        {
            Assert.True(header.MessageId != null);
            Assert.Equal(header.Namespace,strNamespace);
            Assert.Equal(header.Name,HeaderNames.V2.ResponseHeaderNames[strRequestName]);
            Assert.Equal(header.PayloadVersion,"2");
        }

        public static void TestRequestHeader(RequestHeader header,string guid, string strNamespace, string strRequestName)
        {
            Assert.True(header != null);
            Assert.Equal(header.MessageId, guid);
            Assert.Equal(header.Namespace,strNamespace);
            Assert.Equal(header.Name,strRequestName);
            Assert.Equal(header.PayloadVersion,"2");
        }

        public static string GenerateStringFromResponse(ISmartHomeResponse response)
        {
            string textResponse = null;
            try
            {
                textResponse = JsonConvert.SerializeObject(response);
            }
            catch (Exception) { }
            return textResponse;
        }
    }
}
*/