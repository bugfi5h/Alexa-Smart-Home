using Newtonsoft.Json;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Request.RequestPayloads;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using Xunit;

namespace RKon.Alexa.Net.Tests.RequestAndResponses
{
    public class IncrementPercentageTest
    {
        private const string INCREMENT_PERCENTAGE_REQUEST = @"
        {
          'header': {
            'messageId': 'ABC-123-DEF-456',
            'name': 'IncrementPercentageRequest',
            'namespace': 'Alexa.ConnectedHome.Control',
            'payloadVersion': '2'
          },
          'payload': {
            'accessToken': 'accessToken',
            'appliance': {
              'additionalApplianceDetails': {},
              'applianceId': 'appPercentageInc',
            },
            'deltaPercentage': {
                'value': 10.0
            }
}
        }
        ";

        [Fact]
        public void RequestCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(INCREMENT_PERCENTAGE_REQUEST);
            //Header Check
            TestFunctions.TestRequestHeader(requestFromString.Header, "ABC-123-DEF-456", Namespaces.CONTROL, HeaderNames.V2.INCREMENT_PERCENTAGE_REQUEST);
            //Payload Check
            Assert.True(requestFromString.Payload != null);
            Assert.True(requestFromString.GetRequestPayloadType() == typeof(In_DecrementPercentageRequestPayload));
            In_DecrementPercentageRequestPayload payload = requestFromString.Payload as In_DecrementPercentageRequestPayload;
            TestFunctions.TestIn_DecrementPercentageRequestPayload(payload, "accessToken", "appPercentageInc", null, 10);
        }

        [Fact]
        public void ResponseCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(INCREMENT_PERCENTAGE_REQUEST);
            SmartHomeResponse response = TestFunctions.TestCreateResponseIfPossible(requestFromString.Header);
            //Header Check
            TestFunctions.TestResponseHeader(response.Header, requestFromString.Header.Namespace, HeaderNames.V2.INCREMENT_PERCENTAGE_REQUEST );
            //Payload Check
            Assert.True(response.GetResponsePayloadType() == typeof(ResponsePayload));
            Assert.True(TestFunctions.GenerateStringFromResponse(response) != null);
            Util.Util.WriteJsonToConsole("IncrementPercentageConfirmation", response);
        }
    }
}
