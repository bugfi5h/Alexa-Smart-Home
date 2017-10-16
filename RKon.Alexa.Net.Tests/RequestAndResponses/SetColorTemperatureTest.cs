using Newtonsoft.Json;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using Xunit;

namespace RKon.Alexa.Net.Tests
{
    public class SetColorTemperatureTest
    {
        private const string SET_COLOR_TEMPERATURE_REQUEST = @"
        {
            'header': {
                'messageId': 'ABC-123-DEF-456',
                'namespace': 'Alexa.ConnectedHome.Control',
                'name': 'SetColorTemperatureRequest',
                'payloadVersion': '2'
            },
            'payload': {
                'accessToken': 'token',
                'appliance': {
                    'additionalApplianceDetails': {},
                    'applianceId': 'appColorTemp'
                },
                'colorTemperature': {
                    'value': 2700
                }
            }
        }";

        [Fact]
        public void RequestCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_COLOR_TEMPERATURE_REQUEST);
            //Header Check
            TestFunctions.TestRequestHeader(requestFromString.Header, "ABC-123-DEF-456", Namespaces.CONTROL, HeaderNames.V2.SET_COLOR_TEMPERATURE_REQUEST);
            //Payload Check
            Assert.True(requestFromString.Payload != null);
            Assert.True(requestFromString.GetRequestPayloadType() == typeof(ColorTemperatureRequestPayload));
            ColorTemperatureRequestPayload payload = requestFromString.Payload as ColorTemperatureRequestPayload;
            TestFunctions.TestRequestApplianceAndAccessToken(payload, "token", "appColorTemp", null);
            Assert.True(payload.ColorTemperature != null);
            Assert.Equal(payload.ColorTemperature.Value,2700);
        }

        [Fact]
        public void ResponseCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_COLOR_TEMPERATURE_REQUEST);
            SmartHomeResponse response = TestFunctions.TestCreateResponseIfPossible(requestFromString.Header);
            //Header Check
            TestFunctions.TestResponseHeader(response.Header, requestFromString.Header.Namespace, HeaderNames.V2.SET_COLOR_TEMPERATURE_REQUEST);
            //Payload Check
            Assert.True(response.GetResponsePayloadType() == typeof(ColorTemperatureResponsePayload));
            ColorTemperatureResponsePayload payload = response.Payload as ColorTemperatureResponsePayload;
            TestFunctions.TestColorTemperatureResponsePayload(payload);
            Assert.True(TestFunctions.GenerateStringFromResponse(response) != null);
            Util.Util.WriteJsonToConsole("SetColorTemperatureConfirmation", response);
        }
    }
}
