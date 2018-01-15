using RKon.Alexa.NET.JsonObjects;
using RKon.Alexa.NET.JsonObjects.Scopes;
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
            Assert.Equal(typeof(ConnectivityPropertyValue), p.Value.GetType());
            ConnectivityPropertyValue conn = p.Value as ConnectivityPropertyValue;
            Assert.Equal(expectedMode, conn.Value);
        }

        public static void TestBasicEventWithEmptyPayload(SmartHomeResponse repo, string accessToken, string correlationToken, ScopeTypes endpointType, string endpointToken, string endpointID)
        {
            Assert.NotNull(repo.Event);
            Assert.Equal(typeof(Event), repo.Event.GetType());
            //Header Check
            TestFunctionsV3.TestHeaderV3(repo.Event.Header, accessToken, Namespaces.ALEXA, HeaderNames.RESPONSE);
            Assert.Equal(correlationToken, repo.Event.Header.CorrelationToken);
            //Endpoint Check
            Event e = repo.Event as Event;
            TestFunctionsV3.TestEndpointV3(e.Endpoint, endpointID);
            TestFunctionsV3.TestBearerTokenV3(e.Endpoint.Scope, endpointToken);
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

        public static void TestEndpointV3(Endpoint endpoint, string endpointId, Dictionary<string,string> Cookie = null)
        {
            Assert.True(endpoint != null);
            Assert.True(endpoint.Scope != null);
            Assert.Equal(endpointId,endpoint.EndpointID);
            CheckCookieDictionary(Cookie, endpoint.Cookie);
        }

        private static void TestScope(Scope scope, ScopeTypes expected)
        {
            Assert.NotNull(scope);
            Assert.Equal(expected, scope.Type);
        }

        public static void TestBearerTokenV3(Scope scope, string expectedToken)
        {
            TestScope(scope, ScopeTypes.BearerToken);
            Assert.True(scope is BearerToken);
            BearerToken token = scope as BearerToken;
            Assert.Equal(expectedToken, token.Token);
        }

        internal static void TestBearerTokenWithPartitionV3(Scope scope, string expectedToken, string partition, string user)
        {
            TestScope(scope, ScopeTypes.BearerTokenWithPartition);
            Assert.True(scope is BearerTokenWithPartition);
            BearerTokenWithPartition token = scope as BearerTokenWithPartition;
            Assert.Equal(expectedToken, token.Token);
            Assert.Equal(partition, token.Partition);
            Assert.Equal(user, token.UserId);
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
                    if(alexaInterface.Properties != null)
                    {
                        Assert.Equal(alexaInterface.Properties.Supported.Count, endpointAlexaInterface.Properties.Supported.Count);
                        for(int i=0; i< alexaInterface.Properties.Supported.Count; i++)
                        {
                            Assert.Equal(alexaInterface.Properties.Supported[i].Name, endpointAlexaInterface.Properties.Supported[i].Name);
                        }
                        if (alexaInterface.Properties.Retrieveable != null)
                        {
                            Assert.Equal(alexaInterface.Properties.Retrieveable, endpointAlexaInterface.Properties.Retrieveable);
                        }
                        else
                        {
                            Assert.Null(endpointAlexaInterface.Properties.Retrieveable);
                        }
                        if (alexaInterface.Properties.ProactivelyReported != null)
                        {
                            Assert.Equal(alexaInterface.Properties.ProactivelyReported, endpointAlexaInterface.Properties.ProactivelyReported);
                        }
                        else
                        {
                            Assert.Null(endpointAlexaInterface.Properties.ProactivelyReported);
                        }
                    }
                    else
                    {
                        Assert.Null(endpointAlexaInterface.Properties);
                    }
                    break;
            }
        }

        /// <summary>
        /// HeaderNamespace and Name can be left null. Namespaces.Alexa and HeaderNames.Response will be used
        /// </summary>
        /// <param name="h"></param>
        /// <param name="source"></param>
        /// <param name="headerNamespace"></param>
        /// <param name="headerName"></param>
        public static void CheckResponseCreatedBaseHeader(EventHeader h, DirectiveHeader source, string headerNamespace = Namespaces.ALEXA, string headerName = HeaderNames.RESPONSE)
        {
            Assert.NotNull(h);
            Assert.Equal(headerNamespace, h.Namespace);
            Assert.Equal(headerName, h.Name);
            Assert.Equal("3", h.PayloadVersion);
            Assert.Equal(source.CorrelationToken, h.CorrelationToken);
        }

        private static void CheckCookieDictionary(Dictionary<string, string> Cookie, Dictionary<string, string> endpointCookies)
        {
            if (Cookie == null)
            {
                if(endpointCookies != null)
                    Assert.Equal(0, endpointCookies.Count);
            }
            else
            {
                Assert.NotNull(endpointCookies);
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
