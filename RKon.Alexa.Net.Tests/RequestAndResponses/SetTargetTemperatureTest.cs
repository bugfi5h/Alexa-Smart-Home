using Newtonsoft.Json;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Request.RequestPayloads;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using Xunit;

namespace RKon.Alexa.Net.Tests.RequestAndResponses
{
    public class SetTargetTemperatureTest
    {
        private const string SET_TARGET_TEMPERATURE_REQUEST = @"
        {
            'header': {
                'messageId': 'b6602211-b4b3-4960-b063-f7e3967c00c4',
                'namespace': 'Alexa.ConnectedHome.Control',
                'name': 'SetTargetTemperatureRequest',
                'payloadVersion': '2'
            },
            'payload': {
                'accessToken': 'token',
                'appliance': {
                    'additionalApplianceDetails': {},
                    'applianceId': 'appTemp'
                },
                'targetTemperature': {
                    'value': 25.0
                }
            }
        }";

        [Fact]
        public void RequestCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_TARGET_TEMPERATURE_REQUEST);
            //Header Check
            TestFunctions.TestRequestHeader(requestFromString.Header, "b6602211-b4b3-4960-b063-f7e3967c00c4", Namespaces.CONTROL, HeaderNames.V2.SET_TARGET_TEMPERATURE_REQUEST);
            //Payload Check
            Assert.True(requestFromString.Payload != null);
            Assert.True(requestFromString.GetRequestPayloadType() == typeof(SetTemperatureRequestPayload));
            SetTemperatureRequestPayload payload = requestFromString.Payload as SetTemperatureRequestPayload;

            TestFunctions.TestRequestApplianceAndAccessToken(payload, "token", "appTemp", null);
            Assert.True(payload.TargetTemperature != null);
            Assert.Equal(payload.TargetTemperature.Value, 25);
        }

        [Fact]
        public void ResponseCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_TARGET_TEMPERATURE_REQUEST);
            SmartHomeResponse response = TestFunctions.TestCreateResponseIfPossible(requestFromString.Header);
            //Header Check
            TestFunctions.TestResponseHeader(response.Header, requestFromString.Header.Namespace, HeaderNames.V2.SET_TARGET_TEMPERATURE_REQUEST);
            //Payload Check
            Assert.True(response.GetResponsePayloadType() == typeof(TargetTemperatureResponsePayload));
            TargetTemperatureResponsePayload payload = response.Payload as TargetTemperatureResponsePayload;
            TestFunctions.TestTargetTemperatureResponsePayload(payload);
            Assert.True(TestFunctions.GenerateStringFromResponse(response) != null);
            Util.Util.WriteJsonToConsole("SetTemperatureConfirmation", response);
        }
    }
}
