using Newtonsoft.Json;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Request.RequestPayloads;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using Xunit;

namespace RKon.Alexa.Net.Tests.RequestAndResponses
{
    public class SetPercentageTest
    {
        private const string SET_PERCENTAGE_REQUEST = @"
        {
          'header': {
            'messageId': '95872301-4ff6-4146-b3a4-ae84c760c13e',
            'name': 'SetPercentageRequest',
            'namespace': 'Alexa.ConnectedHome.Control',
            'payloadVersion': '2'
          },
          'payload': {
            'percentageState': {
                'value': 50.0
            },
            'accessToken': 'accessToken',
            'appliance': {
              'additionalApplianceDetails': {},
              'applianceId': 'appSetPercentage',
            }
          }
        }
        ";

        [Fact]
        public void RequestCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_PERCENTAGE_REQUEST);
            //Header Check
            TestFunctions.TestRequestHeader(requestFromString.Header, "95872301-4ff6-4146-b3a4-ae84c760c13e", Namespaces.CONTROL, HeaderNames.V2.SET_PERCENTAGE_REQUEST);
            //Payload Check
            Assert.True(requestFromString.Payload != null);
            Assert.True(requestFromString.GetRequestPayloadType() == typeof(SetPercentageRequestPayload));
            SetPercentageRequestPayload payload = requestFromString.Payload as SetPercentageRequestPayload;
            Assert.True(payload.PercentageState != null);
            Assert.Equal(payload.PercentageState.Value,50);
            TestFunctions.TestRequestApplianceAndAccessToken(payload, "accessToken", "appSetPercentage", null);
        }

        [Fact]
        public void ResponseCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_PERCENTAGE_REQUEST);
            SmartHomeResponse response = TestFunctions.TestCreateResponseIfPossible(requestFromString.Header);
            //Header Check
            TestFunctions.TestResponseHeader(response.Header, requestFromString.Header.Namespace, HeaderNames.V2.SET_PERCENTAGE_REQUEST);
            //Payload Check
            Assert.True(response.GetResponsePayloadType() == typeof(ResponsePayload));
            Assert.True(TestFunctions.GenerateStringFromResponse(response) != null);
            Util.Util.WriteJsonToConsole("SetPercentageConfirmation", response);
        }
    }
}
