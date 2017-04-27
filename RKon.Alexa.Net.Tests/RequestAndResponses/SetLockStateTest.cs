using Newtonsoft.Json;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Request.RequestPayloads;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using System.Collections.Generic;
using Xunit;

namespace RKon.Alexa.Net.Tests
{
    public class SetLockStateTest
    {
        private const string SET_LOCK_STATE_REQUEST = @"
            {
                'header':{
                    'messageId':'01ebf625-0b89-4c4d-b3aa-32340e894688',
                    'name':'SetLockStateRequest',
                    'namespace':'Alexa.ConnectedHome.Control',
                    'payloadVersion':'2'
                },
                'payload':{
                    'accessToken':'authToken',
                    'appliance':{
                        'applianceId':'appDoor',
                        'additionalApplianceDetails':{
                            'extraDetail1':'optionalDetailForSkillAdapterToReferenceThisDevice',
                            'extraDetail2':'There can be multiple entries',
                            'extraDetail3':'but they should only be used for reference purposes.',
                        }
                    },
                    'lockState':'LOCKED'
                }
            }";

        [Fact]
        public void RequestCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_LOCK_STATE_REQUEST);
            //Header Check
            TestFunctions.TestRequestHeader(requestFromString.Header, "01ebf625-0b89-4c4d-b3aa-32340e894688", Namespaces.CONTROL, HeaderNames.SET_LOCK_STATE_REQUEST);
            //Payload Check
            Assert.True(requestFromString.Payload != null);
            Assert.True(requestFromString.GetRequestPayloadType() == typeof(SetLockStateRequestPayload));
            SetLockStateRequestPayload payload = requestFromString.Payload as SetLockStateRequestPayload;
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"extraDetail1" , "optionalDetailForSkillAdapterToReferenceThisDevice" },
                {"extraDetail2" , "There can be multiple entries" },
                {"extraDetail3","but they should only be used for reference purposes." }
            };
            TestFunctions.TestRequestApplianceAndAccessToken(payload, "authToken", "appDoor", dic);
            Assert.Equal(payload.Appliance.AdditionalApplianceDetails, dic);
            Assert.Equal(payload.LockState , DeviceModes.LOCKED);
        }

        [Fact]
        public void ResponseCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_LOCK_STATE_REQUEST);
            SmartHomeResponse response = TestFunctions.TestCreateResponseIfPossible(requestFromString.Header);
            //Header Check
            TestFunctions.TestResponseHeader(response.Header, requestFromString.Header.Namespace, HeaderNames.SET_LOCK_STATE_REQUEST);
            //Payload Check
            Assert.True(response.GetResponsePayloadType() == typeof(SetLockStateResponsePayload));
            SetLockStateResponsePayload payload = response.Payload as SetLockStateResponsePayload;
            Assert.True(TestFunctions.GenerateStringFromResponse(response) == null);
            Assert.False(payload.TrySetLockState("testIt"));
            Assert.True(payload.TrySetLockState(DeviceModes.UNLOCKED.ToLower()));
            Assert.True(payload.TrySetLockState(DeviceModes.LOCKED));
            Assert.True(TestFunctions.GenerateStringFromResponse(response) != null);
            Util.Util.WriteJsonToConsole("SetLockStateResponse", response);
        }
    }
}
