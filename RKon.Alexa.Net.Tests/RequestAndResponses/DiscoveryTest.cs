using Newtonsoft.Json;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Request.RequestPayloads;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using Xunit;

namespace RKon.Alexa.Net.Tests
{
    public class DiscoveryTest
    {
        private const string DISCOVERY_REQUEST = @"
        {
            'header': {
                'messageId': '6d6d6e14-8aee-473e-8c24-0d31ff9c17a2',
                'name': 'DiscoverAppliancesRequest',
                'namespace': 'Alexa.ConnectedHome.Discovery',
                'payloadVersion': '2'
            },
            'payload': {
                'accessToken': 'AuthToken'
            }
        }
        ";

        [Fact]
        public void RequestCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(DISCOVERY_REQUEST);
            //Header Check
            TestFunctions.TestRequestHeader(requestFromString.Header, "6d6d6e14-8aee-473e-8c24-0d31ff9c17a2", Namespaces.DISCOVERY, HeaderNames.DISCOVERY_REQUEST);
            //Payload Check
            Assert.True(requestFromString.Payload != null);
            Assert.True(requestFromString.GetRequestPayloadType() == typeof(DiscoveryRequestPayload));
            DiscoveryRequestPayload payload = requestFromString.Payload as DiscoveryRequestPayload;
            Assert.Equal(payload.AccessToken, "AuthToken");
        }

        [Fact]
        public void ResponseCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(DISCOVERY_REQUEST);
            SmartHomeResponse response = TestFunctions.TestCreateResponseIfPossible(requestFromString.Header);
            //Header Check
            TestFunctions.TestResponseHeader(response.Header, requestFromString.Header.Namespace, HeaderNames.DISCOVERY_REQUEST);
            //Payload Check
            Assert.True(response.GetResponsePayloadType() == typeof(DiscoverResponsePayload));
            DiscoverResponsePayload payload = response.Payload as DiscoverResponsePayload;
            Assert.True(payload.DiscoveredAppliances != null);
            ResponseAppliance app = new ResponseAppliance("uniqueThermostatDeviceId", "yourManufacturerName", "fancyThermostat", "1.0", "Bedroom Thermostat", "descriptionThatIsShownToCustomer", true);
            Assert.True(TestFunctions.GenerateStringFromResponse(response) != null);
            payload.DiscoveredAppliances.Add(app);
            Assert.True(TestFunctions.GenerateStringFromResponse(response) != null);
            Util.Util.WriteJsonToConsole("DiscoveryResponse", response);
        }
    }
}
