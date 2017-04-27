using Newtonsoft.Json;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Request.RequestPayloads;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using Xunit;

namespace RKon.Alexa.Net.Tests.RequestAndResponses
{
    public class GetTemperatureReadingTest
    {
        private const string GET_TEMPERATURE_READING_REQUEST = @"
        {
            'header': {
                'messageId': 'ABC-123-DEF-456',
                'namespace': 'Alexa.ConnectedHome.Query',
                'name': 'GetTemperatureReadingRequest',
                'payloadVersion': '2'
            },
            'payload': {
                'accessToken': 'token',
                'appliance': {
                    'additionalApplianceDetails': {},
                    'applianceId': 'appGetTemp'
                }
            }
        }";

        [Fact]
        public void RequestCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(GET_TEMPERATURE_READING_REQUEST);
            //Header Check
            TestFunctions.TestRequestHeader(requestFromString.Header, "ABC-123-DEF-456", Namespaces.QUERY, HeaderNames.GET_TEMPERATURE_READING_REQUEST);
            //Payload Check
            Assert.True(requestFromString.Payload != null);
            Assert.True(requestFromString.GetRequestPayloadType() == typeof(GetTemperatureRequestPayload));
            GetTemperatureRequestPayload payload = requestFromString.Payload as GetTemperatureRequestPayload;
            TestFunctions.TestGetTemperatureRequestPayload(payload, "token", "appGetTemp", null);
        }

        [Fact]
        public void ResponseCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(GET_TEMPERATURE_READING_REQUEST);
            SmartHomeResponse response = TestFunctions.TestCreateResponseIfPossible(requestFromString.Header);
            //Header Check
            TestFunctions.TestResponseHeader(response.Header, requestFromString.Header.Namespace, HeaderNames.GET_TEMPERATURE_READING_REQUEST);
            //Payload Check
            Assert.True(response.GetResponsePayloadType() == typeof(GetTemperatureReadingResponsePayload));
            GetTemperatureReadingResponsePayload payload = response.Payload as GetTemperatureReadingResponsePayload;
            Assert.True(payload.TemperatureReading != null);
            payload.TemperatureReading.Value = 27;
            Assert.Equal(payload.ApplianceResponseTimestamp, null);
            Assert.True(TestFunctions.GenerateStringFromResponse(response) != null);
            payload.ApplianceResponseTimestamp = DateTime.UtcNow;
            Assert.True(TestFunctions.GenerateStringFromResponse(response) != null);
            Util.Util.WriteJsonToConsole("GetTemperatureReadingResponse", response);
        }
    }
}


