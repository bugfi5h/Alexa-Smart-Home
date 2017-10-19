using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.V3.TestFunctions;
using RKon.Alexa.NET.Payloads;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Types;
using Xunit;

namespace RKon.Alexa.Net.Tests.V3.Requests
{
    public class PercentageController
    {
        #region AdjustPercentage
        private const string ADJUST_PERCENTAGE = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.PercentageController',
                    'name': 'AdjustPercentage',
                    'payloadVersion': '3',
                    'messageId': '1bd5d003-31b9-476f-ad03-71d471922820',
                    'correlationToken': 'dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg=='
                },
                'endpoint': {
                    'scope': {
                        'type': 'BearerToken',
                        'token': 'access-token-from-skill'
                    },
                    'endpointId': 'endpoint-001',
                    'cookie': {}
                },
                'payload': {
                    'percentageDelta': -20
                }
            }
        }
        ";

        [Fact]
        public void RequestCreation_AdjustPercentage_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(ADJUST_PERCENTAGE);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_PERCENTAGECONTROLLER, HeaderNames.ADJUST_PERCENTAGE);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(AdjustPercentageRequestPayload),requestFromString.GetPayloadType());
            AdjustPercentageRequestPayload payload = (requestFromString.Directive.Payload as AdjustPercentageRequestPayload);
            //Channel
            Assert.NotNull(payload);
            Assert.Equal(-20, payload.PercentageDelta);
        }
        #endregion
        #region SetPercentage
        private const string SET_PERCENTAGE = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.PercentageController',
                    'name': 'SetPercentage',
                    'payloadVersion': '3',
                    'messageId': '1bd5d003-31b9-476f-ad03-71d471922820',
                    'correlationToken': 'dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg=='
                },
                'endpoint': {
                    'scope': {
                        'type': 'BearerToken',
                        'token': 'access-token-from-skill'
                    },
                    'endpointId': 'endpoint-001',
                    'cookie': {}
                },
                'payload': {
                    'percentage': 74
                }
            }
        }
        ";

        [Fact]
        public void RequestCreation_SetPercentage_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_PERCENTAGE);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_PERCENTAGECONTROLLER, HeaderNames.SET_PERCENTAGE);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(SetPercentageRequestPayload), requestFromString.GetPayloadType());
            SetPercentageRequestPayload payload = (requestFromString.Directive.Payload as SetPercentageRequestPayload);
            //Channel
            Assert.NotNull(payload);
            Assert.Equal(74, payload.Percentage);
        }
        #endregion
    }
}
