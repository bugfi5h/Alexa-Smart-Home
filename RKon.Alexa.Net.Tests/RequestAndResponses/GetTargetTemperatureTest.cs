using Newtonsoft.Json;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Request.RequestPayloads;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using Xunit;

namespace RKon.Alexa.Net.Tests.RequestAndResponses
{
    public class GetTargetTemperatureTest
    {
        private const string GET_TARGET_TEMPERATURE_REQUEST = @"
        {
            'header': {
                'messageId': 'ABC-123-DEF-456',
                'namespace': 'Alexa.ConnectedHome.Query',
                'name': 'GetTargetTemperatureRequest',
                'payloadVersion': '2'
            },
            'payload': {
                'accessToken': 'token',
                'appliance': {
                    'additionalApplianceDetails': {},
                    'applianceId': 'appGetTemp'
                }
            }
        }";

        [Fact]
        public void RequestCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(GET_TARGET_TEMPERATURE_REQUEST);
            //Header Check
            TestFunctions.TestRequestHeader(requestFromString.Header, "ABC-123-DEF-456", Namespaces.QUERY, HeaderNames.GET_TARGET_TEMPERATURE_REQUEST);
            //Payload Check
            Assert.True(requestFromString.Payload != null);
            Assert.True(requestFromString.GetRequestPayloadType() == typeof(GetTemperatureRequestPayload));
            GetTemperatureRequestPayload payload = requestFromString.Payload as GetTemperatureRequestPayload;
            TestFunctions.TestGetTemperatureRequestPayload(payload, "token", "appGetTemp", null);
        }

        [Fact]
        public void ResponseCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(GET_TARGET_TEMPERATURE_REQUEST);
            SmartHomeResponse response = TestFunctions.TestCreateResponseIfPossible(requestFromString.Header);
            //Header Check
            TestFunctions.TestResponseHeader(response.Header, requestFromString.Header.Namespace, HeaderNames.GET_TARGET_TEMPERATURE_REQUEST);
            //Payload Check
            Assert.True(response.GetResponsePayloadType() == typeof(GetTargetTemperatureResponsePayload));
            GetTargetTemperatureResponsePayload payload = response.Payload as GetTargetTemperatureResponsePayload;
            Assert.True(payload.TargetTemperature == null);
            Assert.True(payload.CoolingTargetTemperature == null);
            Assert.True(payload.HeatingTargetTemperature == null);
            Assert.Equal(payload.ApplianceResponseTimestamp, null);          
            Assert.True(TestFunctions.GenerateStringFromResponse(response) != null);
            payload.TargetTemperature = new TargetTemperature();
            payload.TargetTemperature.Value = 22;
            Assert.True(TestFunctions.GenerateStringFromResponse(response) != null);
            payload.TargetTemperature = null;
            payload.CoolingTargetTemperature = new TargetTemperature();
            payload.CoolingTargetTemperature.Value = 1;
            payload.HeatingTargetTemperature = new TargetTemperature();
            payload.HeatingTargetTemperature.Value = 2;
            Assert.True(TestFunctions.GenerateStringFromResponse(response) != null);
            Assert.False(payload.TemperatureMode.TrySetTemperatureMode(DeviceModes.CUSTOM, null));
            Assert.True(payload.TemperatureMode.TrySetTemperatureMode(DeviceModes.AUTO, null));
            Assert.True(payload.TemperatureMode.TrySetTemperatureMode(DeviceModes.CUSTOM, "friendy"));
            Util.Util.WriteJsonToConsole("GetTemperatureReadingResponse", response);
        }

    }
}


