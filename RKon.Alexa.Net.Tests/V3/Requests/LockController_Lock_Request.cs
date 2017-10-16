using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.V3.TestFunctions;
using RKon.Alexa.NET.Payloads;
using RKon.Alexa.NET.Payloads.Response;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RKon.Alexa.Net.Tests.V3.Requests
{
    public class LockController_Lock_Request
    {
        private const string LOCK_REQUEST = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.LockController',
                    'name': 'Lock',
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
                'payload': {}
            }
        }
        ";

        [Fact]
        public void RequestCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(LOCK_REQUEST);
            //Directive Check
            Assert.True(requestFromString.Directive != null);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_LOCKCONTROLLER, HeaderNames.LOCK);
            Assert.Equal(requestFromString.Directive.Header.CorrelationToken, "dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==");
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(requestFromString.GetPayloadType(), typeof(Payload));


            /*
            Assert.True(requestFromString.GetPayloadType() == typeof(TurnOnOffRequestPayload));
            TurnOnOffRequestPayload payload = requestFromString.Payload as TurnOnOffRequestPayload;
            TestFunctionsV3.TestRequestApplianceAndAccessToken(payload, "accessToken", "appId", null);
            */
        }
    }
}
