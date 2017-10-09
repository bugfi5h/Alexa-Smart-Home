using Newtonsoft.Json;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Request.RequestPayloads;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using Xunit;

namespace RKon.Alexa.Net.Tests
{
    public class DecrementColorTemperatureTest
    {
        private const string DECREMENT_COLOR_TEMPERATURE_REQUEST = @"
        {
          'header': {
            'messageId': 'ABC-123-DEF-456',
            'name': 'DecrementColorTemperatureRequest',
            'namespace': 'Alexa.ConnectedHome.Control',
            'payloadVersion': '2'
          },
          'payload': {
            'accessToken': 'accessToken',
            'appliance': {
              'additionalApplianceDetails': {},
              'applianceId': 'appColorDecrement',
            }
          }
        }
        ";

        [Fact]
        public void RequestCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(DECREMENT_COLOR_TEMPERATURE_REQUEST);
            //Header Check
            TestFunctions.TestRequestHeader(requestFromString.Header, "ABC-123-DEF-456", Namespaces.CONTROL, HeaderNames.V2.DECREMENT_COLOR_TEMPERATURE_REQUEST);
            //Payload Check
            Assert.True(requestFromString.Payload != null);
            Assert.True(requestFromString.GetRequestPayloadType() == typeof(In_DecrementColorTemperatureRequestPayload));
            In_DecrementColorTemperatureRequestPayload payload = requestFromString.Payload as In_DecrementColorTemperatureRequestPayload;
            TestFunctions.TestIn_DecrementColorTemperatureRequestPayload(payload, "accessToken", "appColorDecrement", null);
        }

        [Fact]
        public void ResponseCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(DECREMENT_COLOR_TEMPERATURE_REQUEST);
            SmartHomeResponse response = TestFunctions.TestCreateResponseIfPossible(requestFromString.Header);
            //Header Check
            TestFunctions.TestResponseHeader(response.Header, requestFromString.Header.Namespace, HeaderNames.V2.DECREMENT_COLOR_TEMPERATURE_REQUEST);
            //Payload Check
            Assert.True(response.GetResponsePayloadType() == typeof(ColorTemperatureResponsePayload));
            ColorTemperatureResponsePayload payload = response.Payload as ColorTemperatureResponsePayload;
            TestFunctions.TestColorTemperatureResponsePayload(payload);
            Assert.True(TestFunctions.GenerateStringFromResponse(response) != null);
            Util.Util.WriteJsonToConsole("DecrementColorTemperatureConfirmation", response);
        }
    }
}
