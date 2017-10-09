using Newtonsoft.Json;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Request.RequestPayloads;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using Xunit;

namespace RKon.Alexa.Net.Tests.RequestAndResponses
{
    public class TurnOnTest
    {
        private const string TURN_ON_REQUEST = @"
        {
          'header': {
            'messageId': '01ebf625-0b89-4c4d-b3aa-32340e894688',
            'name': 'TurnOnRequest',
            'namespace': 'Alexa.ConnectedHome.Control',
            'payloadVersion': '2'
          },
          'payload': {
            'accessToken': 'accessToken',
            'appliance': {
              'additionalApplianceDetails': {},
              'applianceId': 'appId',
            }
          }
        }
        ";

        [Fact]
        public void RequestCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(TURN_ON_REQUEST);
            //Header Check
            TestFunctions.TestRequestHeader(requestFromString.Header, "01ebf625-0b89-4c4d-b3aa-32340e894688", Namespaces.CONTROL, HeaderNames.V2.TURN_ON_REQUEST);
            //Payload Check
            Assert.True(requestFromString.Payload != null);
            Assert.True(requestFromString.GetRequestPayloadType() == typeof(TurnOnOffRequestPayload));
            TurnOnOffRequestPayload payload = requestFromString.Payload as TurnOnOffRequestPayload;
            TestFunctions.TestRequestApplianceAndAccessToken(payload, "accessToken", "appId", null);
        }

        [Fact]
        public void ResponseCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(TURN_ON_REQUEST);
            SmartHomeResponse response = TestFunctions.TestCreateResponseIfPossible(requestFromString.Header);
            //Header Check
            TestFunctions.TestResponseHeader(response.Header, requestFromString.Header.Namespace, HeaderNames.V2.TURN_ON_REQUEST);
            //Payload Check
            Assert.True(response.GetResponsePayloadType() == typeof(ResponsePayload));
            Assert.True(TestFunctions.GenerateStringFromResponse(response) != null);
            Util.Util.WriteJsonToConsole("TurnOnConfirmation", response);
        }
    }
}
