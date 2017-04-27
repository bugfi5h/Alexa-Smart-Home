using Newtonsoft.Json;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Request.RequestPayloads;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using Xunit;

namespace RKon.Alexa.Net.Tests.RequestAndResponses
{
    public class HealthCheckTest
    {
        private const string HEALTH_CHECK_REQUEST = @"
        {
          'header': {
            'messageId': '243550dc-5f95-4ae4-ad43-4e1e7cb037fd',
            'name': 'HealthCheckRequest',
            'namespace': 'Alexa.ConnectedHome.System',
            'payloadVersion': '2'
          },
          'payload': {
            'initiationTimestamp': '1435302567000'
           }
        }
        ";

        [Fact]
        public void RequestCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(HEALTH_CHECK_REQUEST);
            //Header Check
            TestFunctions.TestRequestHeader(requestFromString.Header, "243550dc-5f95-4ae4-ad43-4e1e7cb037fd", Namespaces.SYSTEM, HeaderNames.HEALTH_CHECK_REQUEST);
            //Payload Check
            Assert.True(requestFromString.Payload != null);
            Assert.True(requestFromString.GetRequestPayloadType() == typeof(HealthCheckRequestPayload));
            HealthCheckRequestPayload payload = requestFromString.Payload as HealthCheckRequestPayload;
            Assert.Equal(payload.InitiationTimestamp, 1435302567000);
        }

        [Fact]
        public void ResponseCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(HEALTH_CHECK_REQUEST);
            SmartHomeResponse response = TestFunctions.TestCreateResponseIfPossible(requestFromString.Header);
            //Header Check
            TestFunctions.TestResponseHeader(response.Header, requestFromString.Header.Namespace, HeaderNames.HEALTH_CHECK_REQUEST);
            //Payload Check
            Assert.True(response.GetResponsePayloadType() == typeof(HealthCheckResponsePayload));
            HealthCheckResponsePayload payload = response.Payload as HealthCheckResponsePayload;
            Assert.Equal(payload.IsHealthy, false);
            Assert.Equal(payload.Description, "The system is currenty not healthy");
            payload.SetHealthyStatus(true);
            Assert.Equal(payload.IsHealthy, true);
            Assert.Equal(payload.Description, "The system is currenty healthy");
            payload.SetHealthyStatus(false);
            Assert.Equal(payload.IsHealthy, false);
            Assert.Equal(payload.Description, "The system is currenty not healthy");
            Assert.True(TestFunctions.GenerateStringFromResponse(response) != null);
            Util.Util.WriteJsonToConsole("HealthCheckResponse", response);
        }
    }
}
