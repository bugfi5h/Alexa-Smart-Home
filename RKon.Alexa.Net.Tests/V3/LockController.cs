using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.V3.TestFunctions;
using RKon.Alexa.NET.JsonObjects;
using RKon.Alexa.NET.Payloads;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using Xunit;

namespace RKon.Alexa.Net.Tests.V3.Requests
{
    public class LockController
    {
        #region Lock
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

        private const string LOCK_RESPONSE = @"
        {
            'context': {
                'properties': [
                    {
                        'namespace': 'Alexa.LockController',
                        'name': 'lockState',
                        'value': 'LOCKED',
                        'timeOfSample': '2017-09-27T18:30:30.45Z',
                        'uncertaintyInMilliseconds': 200
                    },
                    {
                        'namespace': 'Alexa.EndpointHealth',
                        'name': 'connectivity',
                        'value': {
                            'value': 'OK'
                        },
                        'timeOfSample': '2017-09-27T18:30:30.45Z',
                        'uncertaintyInMilliseconds': 200
                    }
                ]
            },
            'event': {
                'header': {
                    'namespace': 'Alexa',
                    'name': 'Response',
                    'payloadVersion': '3',
                    'messageId': '5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4',
                    'correlationToken': 'dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg=='
                },
                'endpoint': {
                    'scope': {
                        'type': 'BearerToken',
                        'token': 'access-token-from-Amazon'
                    },
                    'endpointId': 'endpoint-001'
                },
                'payload': {}
            }
        }
        ";

        [Fact]
        public void RequestCreation_Lock_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(LOCK_REQUEST);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_LOCKCONTROLLER, HeaderNames.LOCK);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, ScopeTypes.BearerToken, "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(Payload), requestFromString.GetPayloadType());


            /*
            Assert.True(requestFromString.GetPayloadType() == typeof(TurnOnOffRequestPayload));
            TurnOnOffRequestPayload payload = requestFromString.Payload as TurnOnOffRequestPayload;
            TestFunctionsV3.TestRequestApplianceAndAccessToken(payload, "accessToken", "appId", null);
            */
        }

        [Fact]
        public void ResponseParse_Lock_Test()
        {
            SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(LOCK_RESPONSE);
            //Context check
            Assert.NotNull(responseFromString.Context);
            Assert.NotNull(responseFromString.Context.Properties);
            Assert.Equal(2, responseFromString.Context.Properties.Count);
            // Property 1
            TestFunctionsV3.TestContextProperty(responseFromString.Context.Properties[0], PropertyNames.LOCK_STATE, Namespaces.ALEXA_LOCKCONTROLLER, DateTime.Parse("2017-09-27T18:30:30.45Z"), 200, null);
            Assert.Equal(typeof(LockModes), responseFromString.Context.Properties[0].Value.GetType());
            Assert.Equal(LockModes.LOCKED, responseFromString.Context.Properties[0].Value);
            // Property 2
            TestFunctionsV3.TestBasicHealthCheckProperty(responseFromString.Context.Properties[1], ConnectivityModes.OK, DateTime.Parse("2017-09-27T18:30:30.45Z"));
            //Event Check
            TestFunctionsV3.TestBasicEventWithEmptyPayload(responseFromString, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4",
                "dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", ScopeTypes.BearerToken,
                 "access-token-from-Amazon", "endpoint-001");
        }

        [Fact]
        public void ResponseCreation_LOCK_Test()
        {
            SmartHomeRequest request = JsonConvert.DeserializeObject<SmartHomeRequest>(LOCK_REQUEST);
            SmartHomeResponse response = new SmartHomeResponse(request.Directive.Header);
            Assert.Null(response.Context);
            response.Context = new Context();
            Property p = new Property(Namespaces.ALEXA_LOCKCONTROLLER, PropertyNames.LOCK_STATE,
               LockModes.LOCKED, DateTime.Parse("2017-09-27T18:30:30.45Z").ToUniversalTime(), 200);
            ConnectivityPropertyValue value = new ConnectivityPropertyValue(ConnectivityModes.OK);
            Property p2 = new Property(Namespaces.ALEXA_ENDPOINTHEALTH, PropertyNames.CONNECTIVITY, value,
                DateTime.Parse("2017-09-27T18:30:30.45Z").ToUniversalTime(), 200);
            response.Context.Properties.Add(p);
            response.Context.Properties.Add(p2);
            Assert.NotNull(response.Event);
            Assert.Equal(typeof(Event), response.Event.GetType());
            Event e = response.Event as Event;
            TestFunctionsV3.CheckResponseCreatedBaseHeader(e.Header, request.Directive.Header);
            Assert.Null(e.Endpoint);
            e.Endpoint = new Endpoint("endpoint-001", new Scope(ScopeTypes.BearerToken, "access-token-from-Amazon"));
            Assert.NotNull(e.Payload);
            Assert.Equal(typeof(Payload), response.GetPayloadType());
            Assert.NotNull(JsonConvert.SerializeObject(response));
            Util.Util.WriteJsonToConsole("Lock", response);
        }
        #endregion
        #region Unlock
        private const string UNLOCK_REQUEST = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.LockController',
                    'name': 'Unlock',
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

        private const string UNLOCK_RESPONSE = @"
        {
            'context': {
                'properties': [
                    {
                        'namespace': 'Alexa.LockController',
                        'name': 'lockState',
                        'value': 'UNLOCKED',
                        'timeOfSample': '2017-09-27T18:30:30.45Z',
                        'uncertaintyInMilliseconds': 200
                    },
                    {
                        'namespace': 'Alexa.EndpointHealth',
                        'name': 'connectivity',
                        'value': {
                            'value': 'OK'
                        },
                        'timeOfSample': '2017-09-27T18:30:30.45Z',
                        'uncertaintyInMilliseconds': 200
                    }
                ]
            },
            'event': {
                'header': {
                    'namespace': 'Alexa',
                    'name': 'Response',
                    'payloadVersion': '3',
                    'messageId': '5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4',
                    'correlationToken': 'dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg=='
                },
                'endpoint': {
                    'scope': {
                        'type': 'BearerToken',
                        'token': 'access-token-from-Amazon'
                    },
                    'endpointId': 'endpoint-001'
                },
                'payload': {}
            }
        }
        ";

        [Fact]
        public void RequestCreation_Unlock_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(UNLOCK_REQUEST);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_LOCKCONTROLLER, HeaderNames.UNLOCK);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, ScopeTypes.BearerToken, "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(Payload), requestFromString.GetPayloadType());
        }

        [Fact]
        public void ResponseParse_Unlock_Test()
        {
            SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(UNLOCK_RESPONSE);
            //Context check
            Assert.NotNull(responseFromString.Context);
            Assert.NotNull(responseFromString.Context.Properties);
            Assert.Equal(2, responseFromString.Context.Properties.Count);
            // Property 1
            TestFunctionsV3.TestContextProperty(responseFromString.Context.Properties[0], PropertyNames.LOCK_STATE, Namespaces.ALEXA_LOCKCONTROLLER, DateTime.Parse("2017-09-27T18:30:30.45Z"), 200, null);
            Assert.Equal(typeof(LockModes), responseFromString.Context.Properties[0].Value.GetType());
            Assert.Equal(LockModes.UNLOCKED, responseFromString.Context.Properties[0].Value);
            // Property 2
            TestFunctionsV3.TestBasicHealthCheckProperty(responseFromString.Context.Properties[1], ConnectivityModes.OK, DateTime.Parse("2017-09-27T18:30:30.45Z"));
            //Event Check
            TestFunctionsV3.TestBasicEventWithEmptyPayload(responseFromString, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4",
                "dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", ScopeTypes.BearerToken,
                 "access-token-from-Amazon", "endpoint-001");
        }

        [Fact]
        public void ResponseCreation_Unlock_Test()
        {
            SmartHomeRequest request = JsonConvert.DeserializeObject<SmartHomeRequest>(UNLOCK_REQUEST);
            SmartHomeResponse response = new SmartHomeResponse(request.Directive.Header);
            Assert.Null(response.Context);
            response.Context = new Context();
            Property p = new Property(Namespaces.ALEXA_LOCKCONTROLLER, PropertyNames.LOCK_STATE,
               LockModes.UNLOCKED, DateTime.Parse("2017-09-27T18:30:30.45Z").ToUniversalTime(), 200);
            ConnectivityPropertyValue value = new ConnectivityPropertyValue(ConnectivityModes.OK);
            Property p2 = new Property(Namespaces.ALEXA_ENDPOINTHEALTH, PropertyNames.CONNECTIVITY, value,
                DateTime.Parse("2017-09-27T18:30:30.45Z").ToUniversalTime(), 200);
            response.Context.Properties.Add(p);
            response.Context.Properties.Add(p2);
            Assert.NotNull(response.Event);
            Assert.Equal(typeof(Event), response.Event.GetType());
            Event e = response.Event as Event;
            TestFunctionsV3.CheckResponseCreatedBaseHeader(e.Header, request.Directive.Header);
            Assert.Null(e.Endpoint);
            e.Endpoint = new Endpoint("endpoint-001", new Scope(ScopeTypes.BearerToken, "access-token-from-Amazon"));
            Assert.NotNull(e.Payload);
            Assert.Equal(typeof(Payload), response.GetPayloadType());
            Assert.NotNull(JsonConvert.SerializeObject(response));
            Util.Util.WriteJsonToConsole("Lock", response);
        }
        #endregion
    }
}
