using Newtonsoft.Json;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Request.RequestPayloads;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using Xunit;

namespace RKon.Alexa.Net.Tests
{
    public class SetColorTest
    {
        public class Tests
        {
            private const string SET_COLOR_REQUEST = @"
            {
              'header': {
                'messageId': 'ABC-123-DEF-456',
                'namespace': 'Alexa.ConnectedHome.Control',
                'name': 'SetColorRequest',
                'payloadVersion': '2'
              },
              'payload': {
                'accessToken': 'auth',
                'appliance': {
                  'applianceId': 'appRGB',
                  'additionalApplianceDetails': {}
                },
                'color': {
                  'hue': 0.0,
                  'saturation': 1.0000,
                  'brightness': 1.0000
                }
              }
            }";

            [Fact]
            public void RequestCreationTest()
            {
                SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_COLOR_REQUEST);
                //Header Check
                TestFunctions.TestRequestHeader(requestFromString.Header, "ABC-123-DEF-456", Namespaces.CONTROL, HeaderNames.SET_COLOR_REQUEST);
                //Payload Check
                Assert.True(requestFromString.Payload != null);
                Assert.True(requestFromString.GetRequestPayloadType() == typeof(SetColorRequestPayload));
                SetColorRequestPayload payload = requestFromString.Payload as SetColorRequestPayload;
                TestFunctions.TestRequestApplianceAndAccessToken(payload, "auth", "appRGB", null);
                Assert.True(payload.Color != null);
                Assert.True(payload.Color.Hue == 0);
                Assert.True(payload.Color.Saturation == 1);
                Assert.True(payload.Color.Brightness == 1);
            }

            [Fact]
            public void ResponseCreationTest()
            {
                SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_COLOR_REQUEST);
                SmartHomeResponse response = TestFunctions.TestCreateResponseIfPossible(requestFromString.Header);
                //Header Check
                TestFunctions.TestResponseHeader(response.Header, requestFromString.Header.Namespace, HeaderNames.SET_COLOR_REQUEST);
                //Payload Check
                Assert.True(response.GetResponsePayloadType() == typeof(SetColorResponsePayload));
                SetColorResponsePayload payload = response.Payload as SetColorResponsePayload;
                Assert.True(payload.AchievedState != null);
                Assert.True(payload.AchievedState.Color != null);
                payload.AchievedState.Color.Hue = 0;
                payload.AchievedState.Color.Hue = 1;
                payload.AchievedState.Color.Hue = 1;
                Assert.True(TestFunctions.GenerateStringFromResponse(response) != null);
                Util.Util.WriteJsonToConsole("SetColorConfirmation", response);
            }
        }
    }
}
