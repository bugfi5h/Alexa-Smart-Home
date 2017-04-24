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
                Assert.True(requestFromString.Header != null);
                Assert.Equal(requestFromString.Header.MessageId, "ABC-123-DEF-456");
                Assert.Equal(requestFromString.Header.Name, HeaderNames.SET_COLOR_REQUEST);
                Assert.Equal(requestFromString.Header.Namespace, Namespaces.CONTROL);
                Assert.Equal(requestFromString.Header.PayloadVersion, "2");
                //Payload Check
                Assert.True(requestFromString.Payload != null);
                Assert.True(requestFromString.GetRequestPayloadType() == typeof(SetColorRequestPayload));
                SetColorRequestPayload payload = requestFromString.Payload as SetColorRequestPayload;
                Assert.Equal(payload.AccessToken, "auth");
                Assert.True(payload.Appliance != null);
                Assert.Equal(payload.Appliance.ApplianceId, "appRGB");
                Assert.True(payload.Appliance.AdditionalApplianceDetails.Count == 0);
                Assert.True(payload.Color != null);
                Assert.True(payload.Color.Hue == 0);
                Assert.True(payload.Color.Saturation == 1);
                Assert.True(payload.Color.Brightness == 1);
            }

            [Fact]
            public void ResponseCreationTest()
            {
                SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_COLOR_REQUEST);
                SmartHomeResponse response = null;
                try
                {
                    response = new SmartHomeResponse(requestFromString.Header);
                }
                catch (Exception) { }

                Assert.True(response != null);
                Assert.True(response.Header != null);
                Assert.True(response.Payload != null);
                //Header Check
                Assert.True(response.Header.MessageId != null);
                Assert.True(response.Header.Namespace == requestFromString.Header.Namespace);
                Assert.True(response.Header.Name == HeaderNames.ResponseHeaderNames[HeaderNames.SET_COLOR_REQUEST]);
                Assert.True(response.Header.PayloadVersion == "2");
                //Payload Check
                Assert.True(response.GetResponsePayloadType() == typeof(SetColorResponsePayload));
                SetColorResponsePayload payload = response.Payload as SetColorResponsePayload;
                Assert.True(payload.AchievedState != null);
                Assert.True(payload.AchievedState.Color != null);
                payload.AchievedState.Color.Hue = 0;
                payload.AchievedState.Color.Hue = 1;
                payload.AchievedState.Color.Hue = 1;
                string stringFromResponse = null;
                try
                {
                    stringFromResponse = JsonConvert.SerializeObject(response);
                }
                catch (Exception) { }
                Assert.True(stringFromResponse != null);
                Util.Util.WriteJsonToConsole("SetColorConfirmation", response);
            }
        }
    }
}
