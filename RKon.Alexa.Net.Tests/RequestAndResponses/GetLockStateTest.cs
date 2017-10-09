using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.Util;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Request.RequestPayloads;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using System.Collections.Generic;
using Xunit;

namespace RKon.Alexa.Net.Tests
{
    public class Tests
    {
        private const string GET_LOCK_STATE_REQUEST = @"
            {
                'header':{
                    'messageId':'01ebf625-0b89-4c4d-b3aa-32340e894688',
                    'name':'GetLockStateRequest',
                    'namespace':'Alexa.ConnectedHome.Query',
                    'payloadVersion':'2'
                },
                'payload':{
                    'accessToken':'accessToken',
                    'appliance':{
                        'applianceId':'device1',
                        'additionalApplianceDetails':{
                            'extraDetail1':'optionalDetailForSkillAdapterToReferenceThisDevice',
                            'extraDetail2':'There can be multiple entries',
                        }
                    }
                }
            }";

        [Fact]
        public void RequestCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(GET_LOCK_STATE_REQUEST);
            //Header Check
            TestFunctions.TestRequestHeader(requestFromString.Header, "01ebf625-0b89-4c4d-b3aa-32340e894688", Namespaces.QUERY, HeaderNames.V2.GET_LOCK_STATE_REQUEST);
            //Payload Check
            Assert.True(requestFromString.Payload != null);
            Assert.True(requestFromString.GetRequestPayloadType() == typeof(GetLockStateRequestPayload));
            GetLockStateRequestPayload payload = requestFromString.Payload as GetLockStateRequestPayload;
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"extraDetail1" , "optionalDetailForSkillAdapterToReferenceThisDevice" },
                {"extraDetail2" , "There can be multiple entries" },
            };
            TestFunctions.TestRequestApplianceAndAccessToken(payload, "accessToken", "device1", dic);
        }

        [Fact]
        public void ResponseCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(GET_LOCK_STATE_REQUEST);
            SmartHomeResponse response = TestFunctions.TestCreateResponseIfPossible(requestFromString.Header);
            //Header Check
            TestFunctions.TestResponseHeader(response.Header, requestFromString.Header.Namespace, HeaderNames.V2.GET_LOCK_STATE_REQUEST);
            //Payload Check
            Assert.True(response.GetResponsePayloadType() == typeof(GetLockStateResponsePayload));
            GetLockStateResponsePayload payload = response.Payload as GetLockStateResponsePayload;
            Assert.True(TestFunctions.GenerateStringFromResponse(response) == null);
            Assert.False(payload.TrySetLockState("testWord"));
            Assert.True(payload.TrySetLockState(DeviceModes.UNLOCKED.ToLower()));
            Assert.True(payload.TrySetLockState(DeviceModes.LOCKED));
            Assert.Equal(payload.ApplianceResponseTimeStamp, null);
            Assert.True(TestFunctions.GenerateStringFromResponse(response) != null);
            payload.ApplianceResponseTimeStamp = DateTime.UtcNow;
            Util.Util.WriteJsonToConsole("GetLockStateResponse", response);
        }
    }
}
