using RKon.Alexa.NET.JsonObjects;
using RKon.Alexa.NET.Payloads;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using System.Collections.Generic;
using Xunit;

namespace RKon.Alexa.Net.Tests.V3.TestFunctions
{
    public class TestFunctionsV3
    {
        public static void TestBasicHealthCheckProperty(Property p, ConnectivityModes expectedMode, DateTime dateTime)
        {
            TestFunctionsV3.TestContextProperty(p, PropertyNames.CONNECTIVITY, Namespaces.ALEXA_ENDPOINTHEALTH, dateTime, 200, null);
            Assert.Equal(typeof(ConnectivityProperty), p.Value.GetType());
            ConnectivityProperty conn = p.Value as ConnectivityProperty;
            Assert.Equal(expectedMode, conn.Value);
        }

        public static void TestBasicEventWithEmptyPayload(SmartHomeResponse repo, string accessToken, string correlationToken, string endpointType, string endpointToken, string endpointID)
        {
            Assert.NotNull(repo.Event);
            Assert.Equal(typeof(Event), repo.Event.GetType());
            //Header Check
            TestFunctionsV3.TestHeaderV3(repo.Event.Header, accessToken, Namespaces.ALEXA, HeaderNames.RESPONSE);
            Assert.Equal(correlationToken, repo.Event.Header.CorrelationToken);
            //Endpoint Check
            Event e = repo.Event as Event;
            TestFunctionsV3.TestEndpointV3(e.Endpoint, endpointType, endpointToken, endpointID);
            //Payload Check
            Assert.Equal(typeof(Payload), repo.GetPayloadType());
        }

        public static void TestHeaderV3(DirectiveHeader header, string guid, string strNamespace, string strRequestName)
        {
            Assert.True(header != null);
            Assert.Equal(guid,header.MessageId);
            Assert.Equal(strNamespace,header.Namespace );
            Assert.Equal(strRequestName,header.Name );
            Assert.Equal("3",header.PayloadVersion);
        }

        public static void TestEndpointV3(Endpoint endpoint, string type, string token, string endpointId, Dictionary<string,string> Cookie = null)
        {
            Assert.True(endpoint != null);
            Assert.True(endpoint.Scope != null);
            Assert.Equal(type,endpoint.Scope.Type);
            Assert.Equal(token,endpoint.Scope.Token);
            Assert.Equal(endpointId,endpoint.EndpointID);
            CheckCookieDictionary(Cookie, endpoint.Cookie);
        }

        public static void TestResponseEndpointV3(ResponseEndpoint endpoint, string manufacturer, string friendlyName, 
            string description, string endpointId, Dictionary<string, string> Cookie, List<Capability> Capabilities, List<DisplayCategory> DisplayCategories )
        {
            Assert.NotNull(endpoint);
            Assert.Equal(endpointId, endpoint.EndpointID);
            Assert.Equal(description, endpoint.Description);
            Assert.Equal(friendlyName, endpoint.FriendlyName);
            CheckCookieDictionary(Cookie, endpoint.Cookies);
            Assert.NotNull(endpoint.DisplayCategories);
            Assert.Equal(DisplayCategories.Count, endpoint.DisplayCategories.Count);
            for(int i=0; i<DisplayCategories.Count; i++)
            {
                Assert.True(endpoint.DisplayCategories.Contains(DisplayCategories[i]));
            }

        }

        private static void TestCapability(Capability capability, Capability endpointCapability)
        {
            Assert.Equal(capability.GetType(), endpointCapability.GetType());
            Assert.Equal(capability.Type, endpointCapability.Type);
            switch (capability.Type)
            {
                case CapabilitiyTypes.AlexaInterface:
                    AlexaInterface alexaInterface = capability as AlexaInterface;
                    AlexaInterface endpointAlexaInterface = endpointCapability as AlexaInterface;
                    Assert.Equal(alexaInterface.Interface, endpointAlexaInterface.Interface);
                    Assert.Equal(alexaInterface.Version, endpointAlexaInterface.Version);
                    if(alexaInterface.Retrieveable != null)
                    {
                        Assert.Equal(alexaInterface.Retrieveable, endpointAlexaInterface.Retrieveable);
                    }else
                    {
                        Assert.Null(endpointAlexaInterface.Retrieveable);
                    }
                    if(alexaInterface.ProactivelyReported != null)
                    {
                        Assert.Equal(alexaInterface.ProactivelyReported, endpointAlexaInterface.ProactivelyReported);
                    }else
                    {
                        Assert.Null(endpointAlexaInterface.ProactivelyReported);
                    }
                    if(alexaInterface.Properties != null)
                    {
                        Assert.Equal(alexaInterface.Properties.Supported.Count, endpointAlexaInterface.Properties.Supported.Count);
                        for(int i=0; i< alexaInterface.Properties.Supported.Count; i++)
                        {
                            Assert.Equal(alexaInterface.Properties.Supported[i].Name, endpointAlexaInterface.Properties.Supported[i].Name);
                        }
                    }else
                    {
                        Assert.Null(endpointAlexaInterface.Properties);
                    }
                    break;
            }
        }

        private static void CheckCookieDictionary(Dictionary<string, string> Cookie, Dictionary<string, string> endpointCookies)
        {
            Assert.NotNull(endpointCookies);
            if (Cookie == null)
            {
                Assert.Equal(0, endpointCookies.Count);
            }
            else
            {
                Assert.Equal(Cookie.Count, endpointCookies.Count);
                foreach (string key in Cookie.Keys)
                {
                    Assert.True(endpointCookies.ContainsKey(key));
                    Assert.Equal(Cookie[key], endpointCookies[key]);
                }
            }
        }

        public static void TestContextProperty(Property prop, string name, string strNamespace, DateTime timeOfSample, int uncertaintyInMilliseconds, string customName)
        {
            Assert.Equal(name,prop.Name);
            Assert.Equal(strNamespace,prop.Namespace);
            Assert.Equal(timeOfSample.ToUniversalTime(),prop.TimeOfSample);
            Assert.Equal(uncertaintyInMilliseconds,prop.UncertaintyInMilliseconds);
            Assert.Equal(customName, prop.CustomName);
            // Value has to be Checked seperatly
        } 
    }
}
