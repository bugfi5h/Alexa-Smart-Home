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

namespace RKon.Alexa.Net.Tests.RequestAndResponses
{
    public class RetrieveCameraStreamUriTest
    {
        private const string RETRIEVE_CAMERA_STREAM_URI_REQUEST = @"
        {
            'header': {
                'namespace':'Alexa.ConnectedHome.Query',
                'name':'RetrieveCameraStreamUriRequest',
                'payloadVersion':'2',
                'messageId':'ABC-123-DEF-456'
            },
            'payload': {
                'accessToken':'accessToken',
                'directedId':'dirID',
                'appliance': {
                    'applianceId': 'camera',
                    'additionalApplianceDetails': {
                      'extraDetail1': 'optionalDetailForSkillAdapterToReferenceThisDevice',
                      'extraDetail2': 'There can be multiple entries'
                    }
                 }
             }
         }
        ";

        [Fact]
        public void RequestCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(RETRIEVE_CAMERA_STREAM_URI_REQUEST);
            //Header Check
            TestFunctions.TestRequestHeader(requestFromString.Header, "ABC-123-DEF-456", Namespaces.QUERY, HeaderNames.V2.RETRIEVE_CAMERA_STREAM_URI_REQUEST);
            //Payload Check
            Assert.True(requestFromString.Payload != null);
            Assert.True(requestFromString.GetRequestPayloadType() == typeof(RetrieveCameraStreamUriRequestPayload));
            RetrieveCameraStreamUriRequestPayload payload = requestFromString.Payload as RetrieveCameraStreamUriRequestPayload;
            Dictionary<string, object> additionalApplianceDetails = new Dictionary<string, object>();
            additionalApplianceDetails.Add("extraDetail1", "optionalDetailForSkillAdapterToReferenceThisDevice");
            additionalApplianceDetails.Add("extraDetail2", "There can be multiple entries");
            TestFunctions.TestRetrieveCameraStreamUriRequestPayload(payload, "accessToken", "camera", additionalApplianceDetails, "dirID");
        }

        [Fact]
        public void ResponseCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(RETRIEVE_CAMERA_STREAM_URI_REQUEST);
            SmartHomeResponse response = TestFunctions.TestCreateResponseIfPossible(requestFromString.Header);
            //Header Check
            TestFunctions.TestResponseHeader(response.Header, requestFromString.Header.Namespace, HeaderNames.V2.RETRIEVE_CAMERA_STREAM_URI_REQUEST);
            //Payload Check
            Assert.True(response.GetResponsePayloadType() == typeof(RetrieveCameraStreamUriResponsePayload));
            RetrieveCameraStreamUriResponsePayload payload = response.Payload as RetrieveCameraStreamUriResponsePayload;
            Assert.True(TestFunctions.GenerateStringFromResponse(response) != null);
            Util.Util.WriteJsonToConsole("RetrieveCameraStreamUriResponse", response);
        }
    }
}
