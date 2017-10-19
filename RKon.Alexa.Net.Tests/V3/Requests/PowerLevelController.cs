using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.V3.TestFunctions;
using RKon.Alexa.NET.Payloads;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Types;
using Xunit;

namespace RKon.Alexa.Net.Tests.V3.Requests
{
    public class PowerLevelController
    {
        #region AdjustPowerLevel
        private const string ADJUST_POWER_LEVEL = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.PowerLevelController',
                    'name': 'AdjustPowerLevel',
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
                    'powerLevelDelta': 3
                }
            }
        }
        ";

        [Fact]
        public void RequestCreation_AdjustPowerLevel_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(ADJUST_POWER_LEVEL);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_POWERLEVELCONTROLLER, HeaderNames.ADJUST_POWER_LEVEL);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(AdjustPowerLevelRequestPayload), requestFromString.GetPayloadType());
            AdjustPowerLevelRequestPayload payload = (requestFromString.Directive.Payload as AdjustPowerLevelRequestPayload);
            //Channel
            Assert.NotNull(payload);
            Assert.Equal(3, payload.PowerLevelDelta);
        }
        #endregion
        #region
        private const string SET_POWER_LEVEL = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.PowerLevelController',
                    'name': 'SetPowerLevel',
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
                    'powerLevel': 42
                }
            }
        }
        ";

        [Fact]
        public void RequestCreation_SetPowerLevel_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_POWER_LEVEL);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_POWERLEVELCONTROLLER, HeaderNames.SET_POWER_LEVEL);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(PowerLevelRequestPayload), requestFromString.GetPayloadType());
            PowerLevelRequestPayload payload = (requestFromString.Directive.Payload as PowerLevelRequestPayload);
            //Channel
            Assert.NotNull(payload);
            Assert.Equal(42, payload.PowerLevel);
        }
        #endregion
    }
}
