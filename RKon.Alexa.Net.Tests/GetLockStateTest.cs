using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.Util;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Request.RequestPayloads;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
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
            Assert.True(requestFromString.Header != null);
            Assert.Equal(requestFromString.Header.MessageId, "01ebf625-0b89-4c4d-b3aa-32340e894688");
            Assert.Equal(requestFromString.Header.Name, HeaderNames.GET_LOCK_STATE_REQUEST);
            Assert.Equal(requestFromString.Header.Namespace, Namespaces.QUERY);
            Assert.Equal(requestFromString.Header.PayloadVersion, "2");
            //Payload Check
            Assert.True(requestFromString.Payload != null);
            Assert.True(requestFromString.GetRequestPayloadType() == typeof(GetLockStateRequestPayload));
            GetLockStateRequestPayload payload = requestFromString.Payload as GetLockStateRequestPayload;
            Assert.Equal(payload.AccessToken, "accessToken");
            Assert.True(payload.Appliance != null);
            Assert.Equal(payload.Appliance.ApplianceId, "device1");
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"extraDetail1" , "optionalDetailForSkillAdapterToReferenceThisDevice" },
                {"extraDetail2" , "There can be multiple entries" },
            };
            Assert.Equal(payload.Appliance.AdditionalApplianceDetails, dic);
        }

        [Fact]
        public void ResponseCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(GET_LOCK_STATE_REQUEST);
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
            Assert.True(response.Header.Name == HeaderNames.ResponseHeaderNames[HeaderNames.GET_LOCK_STATE_REQUEST]);
            Assert.True(response.Header.PayloadVersion == "2");
            //Payload Check
            Assert.True(response.GetResponsePayloadType() == typeof(GetLockStateResponsePayload));
            GetLockStateResponsePayload payload = response.Payload as GetLockStateResponsePayload;
            string stringFromResponse = null;
            try
            {
                stringFromResponse = JsonConvert.SerializeObject(response);
            }
            catch (Exception) { }
            Assert.True(stringFromResponse == null);
            Assert.False(payload.TrySetLockState("testWord"));
            Assert.True(payload.TrySetLockState(DeviceModes.UNLOCKED.ToLower()));
            Assert.True(payload.TrySetLockState(DeviceModes.LOCKED));
            try
            {
                stringFromResponse = JsonConvert.SerializeObject(response);
            }
            catch (Exception) { }
            Assert.True(stringFromResponse != null);
            payload.ApplianceResponseTimeStamp = DateTime.UtcNow;
            Util.WriteJsonToConsole("GetLockStateResponse", response);
        }
    }
}
