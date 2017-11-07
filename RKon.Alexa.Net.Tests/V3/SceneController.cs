using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.V3.TestFunctions;
using RKon.Alexa.NET.JsonObjects;
using RKon.Alexa.NET.Payloads;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using Xunit;

namespace RKon.Alexa.Net.Tests.V3
{
    public class SceneController
    {
        #region Activate
        private const string ACTIVATE = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.SceneController',
                    'name': 'Activate',
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
        public void RequestCreation_Activate_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(ACTIVATE);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_SCENECONTROLLER, HeaderNames.ACTIVATE);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, ScopeTypes.BearerToken, "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(Payload), requestFromString.GetPayloadType());
        }

        private const string ACTIVATION_STARTED = @"
        {
            'context': {
                'properties': [
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
                    'namespace': 'Alexa.SceneController',
                    'name': 'ActivationStarted',
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
                'payload': {
                    'cause': {
                        'type': 'VOICE_INTERACTION'
                    },
                    'timestamp': '2017-09-27T18:30:30.45Z'
                }
            }
        }
        ";

        [Fact]
        public void ResponseParse_ActivationStarted_Test()
        {
            SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(ACTIVATION_STARTED);
            //Context check
            Assert.NotNull(responseFromString.Context);
            Assert.NotNull(responseFromString.Context.Properties);
            Assert.Equal(1, responseFromString.Context.Properties.Count);
            // Property 1
            TestFunctionsV3.TestBasicHealthCheckProperty(responseFromString.Context.Properties[0], ConnectivityModes.OK, DateTime.Parse("2017-09-27T18:30:30.45Z"));
            //Event Check
            Assert.NotNull(responseFromString.Event);
            Assert.Equal(typeof(Event), responseFromString.Event.GetType());
            Event e = responseFromString.Event as Event;
            TestFunctionsV3.TestHeaderV3(e.Header, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4", Namespaces.ALEXA_SCENECONTROLLER, HeaderNames.ACTIVATION_STARTED);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", e.Header.CorrelationToken);
            TestFunctionsV3.TestEndpointV3(e.Endpoint, ScopeTypes.BearerToken, "access-token-from-Amazon", "endpoint-001");
            Assert.NotNull(e.Payload);
            Assert.Equal(typeof(SceneStartedResponsePayload), responseFromString.GetPayloadType());
            SceneStartedResponsePayload p = e.Payload as SceneStartedResponsePayload;
            Assert.NotNull(p.Cause);
            Assert.Equal(CauseTypes.VOICE_INTERACTION, p.Cause.Type);
            Assert.Equal(DateTime.Parse("2017-09-27T18:30:30.45Z").ToUniversalTime(), p.Timestamp);
        }

        [Fact]
        public void ResponseCreation_Activate_Test()
        {
            SmartHomeRequest request = JsonConvert.DeserializeObject<SmartHomeRequest>(ACTIVATE);
            SmartHomeResponse response = new SmartHomeResponse(request.Directive.Header);
            Assert.Null(response.Context);
            response.Context = new Context();
            ConnectivityPropertyValue value = new ConnectivityPropertyValue(ConnectivityModes.OK);
            Property p2 = new Property(Namespaces.ALEXA_ENDPOINTHEALTH, PropertyNames.CONNECTIVITY, value,
                DateTime.Parse("2017-09-27T18:30:30.45Z").ToUniversalTime(), 200);
            response.Context.Properties.Add(p2);
            Assert.NotNull(response.Event);
            Assert.Equal(typeof(Event), response.Event.GetType());
            Event e = response.Event as Event;
            TestFunctionsV3.CheckResponseCreatedBaseHeader(e.Header, request.Directive.Header,Namespaces.ALEXA_SCENECONTROLLER, HeaderNames.ACTIVATION_STARTED);
            Assert.Null(e.Endpoint);
            e.Endpoint = new Endpoint("endpoint-001", new Scope(ScopeTypes.BearerToken, "access-token-from-Amazon"));
            Assert.NotNull(e.Payload);
            Assert.Equal(typeof(SceneStartedResponsePayload), response.GetPayloadType());
            SceneStartedResponsePayload p = response.Event.Payload as SceneStartedResponsePayload;
            Assert.Null(p.Cause);
            Assert.Throws<JsonSerializationException>(() => JsonConvert.SerializeObject(response));
            p.Cause = new Cause(CauseTypes.VOICE_INTERACTION); 
            p.Timestamp = DateTime.Parse("2017-09-27T18:30:30.45Z").ToUniversalTime();
            Assert.NotNull(JsonConvert.SerializeObject(response));
            Util.Util.WriteJsonToConsole("Activate", response);
        }
        #endregion
        #region Deactivate
        private const string DEACTIVATE = @"
       {
            'directive': {
                'header': {
                    'namespace': 'Alexa.SceneController',
                    'name': 'Deactivate',
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
        public void RequestCreation_DeActivate_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(DEACTIVATE);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_SCENECONTROLLER, HeaderNames.DEACTIVATE);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, ScopeTypes.BearerToken, "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(Payload), requestFromString.GetPayloadType());
        }

        private const string DEACTIVATION_STARTED = @"
        {
            'context': {
                'properties': [
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
                    'namespace': 'Alexa.SceneController',
                    'name': 'DeactivationStarted',
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
                'payload': {
                    'cause': {
                        'type': 'APP_INTERACTION'
                    },
                    'timestamp': '2017-09-27T18:30:30.45Z'
                }
            }
        }
        ";

        [Fact]
        public void ResponseParse_DeactivationStarted_Test()
        {
            SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(DEACTIVATION_STARTED);
            //Context check
            Assert.NotNull(responseFromString.Context);
            Assert.NotNull(responseFromString.Context.Properties);
            Assert.Equal(1, responseFromString.Context.Properties.Count);
            // Property 1
            TestFunctionsV3.TestBasicHealthCheckProperty(responseFromString.Context.Properties[0], ConnectivityModes.OK, DateTime.Parse("2017-09-27T18:30:30.45Z"));
            //Event Check
            Assert.NotNull(responseFromString.Event);
            Assert.Equal(typeof(Event), responseFromString.Event.GetType());
            Event e = responseFromString.Event as Event;
            TestFunctionsV3.TestHeaderV3(e.Header, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4", Namespaces.ALEXA_SCENECONTROLLER, HeaderNames.DEACTIVATION_STARTED);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", e.Header.CorrelationToken);
            TestFunctionsV3.TestEndpointV3(e.Endpoint, ScopeTypes.BearerToken, "access-token-from-Amazon", "endpoint-001");
            Assert.NotNull(e.Payload);
            Assert.Equal(typeof(SceneStartedResponsePayload), responseFromString.GetPayloadType());
            SceneStartedResponsePayload p = e.Payload as SceneStartedResponsePayload;
            Assert.NotNull(p.Cause);
            Assert.Equal(CauseTypes.APP_INTERACTION, p.Cause.Type);
            Assert.Equal(DateTime.Parse("2017-09-27T18:30:30.45Z").ToUniversalTime(), p.Timestamp);
        }

        [Fact]
        public void ResponseCreation_Deactivate_Test()
        {
            SmartHomeRequest request = JsonConvert.DeserializeObject<SmartHomeRequest>(DEACTIVATE);
            SmartHomeResponse response = new SmartHomeResponse(request.Directive.Header);
            Assert.Null(response.Context);
            response.Context = new Context();
            ConnectivityPropertyValue value = new ConnectivityPropertyValue(ConnectivityModes.OK);
            Property p2 = new Property(Namespaces.ALEXA_ENDPOINTHEALTH, PropertyNames.CONNECTIVITY, value,
                DateTime.Parse("2017-09-27T18:30:30.45Z").ToUniversalTime(), 200);
            response.Context.Properties.Add(p2);
            Assert.NotNull(response.Event);
            Assert.Equal(typeof(Event), response.Event.GetType());
            Event e = response.Event as Event;
            TestFunctionsV3.CheckResponseCreatedBaseHeader(e.Header, request.Directive.Header, Namespaces.ALEXA_SCENECONTROLLER, HeaderNames.DEACTIVATION_STARTED);
            Assert.Null(e.Endpoint);
            e.Endpoint = new Endpoint("endpoint-001", new Scope(ScopeTypes.BearerToken, "access-token-from-Amazon"));
            Assert.NotNull(e.Payload);
            Assert.Equal(typeof(SceneStartedResponsePayload), response.GetPayloadType());
            SceneStartedResponsePayload p = response.Event.Payload as SceneStartedResponsePayload;
            Assert.Null(p.Cause);
            Assert.Throws<JsonSerializationException>(() => JsonConvert.SerializeObject(response));
            p.Cause = new Cause(CauseTypes.APP_INTERACTION);
            p.Timestamp = DateTime.Parse("2017-09-27T18:30:30.45Z").ToUniversalTime();
            Assert.NotNull(JsonConvert.SerializeObject(response));
            Util.Util.WriteJsonToConsole("Deactivate", response);
        }
        #endregion
    }
}
