using Newtonsoft.Json;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Request.RequestPayloads;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using Xunit;

namespace RKon.Alexa.Net.Tests
{
    public class IncrementTargetTemperatureTest
    {
        private const string INCREMENT_TARGET_TEMPERATURE_REQUEST = @"
        {
          'header': {
            'messageId': '77ff65eb-a015-4777-99ba-6e90d200dd6c',
            'name': 'IncrementTargetTemperatureRequest',
            'namespace': 'Alexa.ConnectedHome.Control',
            'payloadVersion': '2'
          },
          'payload': {
            'deltaTemperature': {
                'value': 3.6
            },
            'accessToken': 'accessToken',
            'appliance': {
              'additionalApplianceDetails': {},
              'applianceId': 'appIncrement',
            }
          }
        }
        ";

        [Fact]
        public void RequestCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(INCREMENT_TARGET_TEMPERATURE_REQUEST);
            //Header Check
            TestFunctions.TestRequestHeader(requestFromString.Header, "77ff65eb-a015-4777-99ba-6e90d200dd6c", Namespaces.CONTROL, HeaderNames.V2.INCREMENT_TARGET_TEMPERATURE_REQUEST);
            //Payload Check
            Assert.True(requestFromString.Payload != null);
            Assert.True(requestFromString.GetRequestPayloadType() == typeof(In_DecrementTemperatureRequestPayload));
            In_DecrementTemperatureRequestPayload payload = requestFromString.Payload as In_DecrementTemperatureRequestPayload;
            TestFunctions.TestIn_DecrementTemperatureRequestPayload(payload, "accessToken", "appIncrement", null, 3.6);
        }

        [Fact]
        public void ResponseCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(INCREMENT_TARGET_TEMPERATURE_REQUEST);
            SmartHomeResponse response = TestFunctions.TestCreateResponseIfPossible(requestFromString.Header);
            //Header Check
            TestFunctions.TestResponseHeader(response.Header, requestFromString.Header.Namespace, HeaderNames.V2.INCREMENT_TARGET_TEMPERATURE_REQUEST);
            //Payload Check
            Assert.True(response.GetResponsePayloadType() == typeof(TargetTemperatureResponsePayload));
            TargetTemperatureResponsePayload payload = response.Payload as TargetTemperatureResponsePayload;
            TestFunctions.TestTargetTemperatureResponsePayload(payload);
            Assert.True(TestFunctions.GenerateStringFromResponse(response) != null);
            Util.Util.WriteJsonToConsole("IncrementTemperatureConfirmation", response);
        }
    }
}
