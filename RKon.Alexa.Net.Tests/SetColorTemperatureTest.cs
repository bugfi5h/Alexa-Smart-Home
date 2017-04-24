using Newtonsoft.Json;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Request.RequestPayloads;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Assert.True(requestFromString.Header != null);
            Assert.Equal(requestFromString.Header.MessageId, "ABC-123-DEF-456");
            Assert.Equal(requestFromString.Header.Name, HeaderNames.SET_COLOR_TEMPERATURE_REQUEST);
            Assert.Equal(requestFromString.Header.Namespace, Namespaces.CONTROL);
            Assert.Equal(requestFromString.Header.PayloadVersion, "2");
            //Payload Check
            Assert.True(requestFromString.Payload != null);
            Assert.True(requestFromString.GetRequestPayloadType() == typeof(ColorTemperatureRequestPayload));
            ColorTemperatureRequestPayload payload = requestFromString.Payload as ColorTemperatureRequestPayload;
            Assert.Equal(payload.AccessToken, "token");
            Assert.True(payload.Appliance != null);
            Assert.Equal(payload.Appliance.ApplianceId, "appColorTemp");
            Assert.True(payload.Appliance.AdditionalApplianceDetails.Count == 0);
            Assert.True(payload.ColorTemperature != null);
            Assert.Equal(payload.ColorTemperature.Value,2700);
        }

        [Fact]
        public void ResponseCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_COLOR_TEMPERATURE_REQUEST);
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
            Assert.True(response.Header.Name == HeaderNames.ResponseHeaderNames[HeaderNames.SET_COLOR_TEMPERATURE_REQUEST]);
            Assert.True(response.Header.PayloadVersion == "2");
            //Payload Check
            Assert.True(response.GetResponsePayloadType() == typeof(ColorTemperatureResponsePayload));
            ColorTemperatureResponsePayload payload = response.Payload as ColorTemperatureResponsePayload;
            string stringFromResponse = null;
            Assert.True(payload.AchievedState != null);
            Assert.True(payload.AchievedState.ColorTemperature != null);
            payload.AchievedState.ColorTemperature.Value = 2700;
            try
            {
                stringFromResponse = JsonConvert.SerializeObject(response);
            }
            catch (Exception) { }
            Assert.True(stringFromResponse != null);
            Util.Util.WriteJsonToConsole("SetColorTemperatureConfirmation", response);
        }
    }
}
