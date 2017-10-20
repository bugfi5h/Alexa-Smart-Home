using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.V3.TestFunctions;
using RKon.Alexa.NET.JsonObjects;
using RKon.Alexa.NET.Payloads;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RKon.Alexa.Net.Tests.V3.Requests
{
    public class ThermostatController
    {
        #region AdjustTargetTemperature
        private const string ADJUST_T_TEMPERATURE = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.ThermostatController',
                    'name': 'AdjustTargetTemperature',
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
                    'targetSetpointDelta': {
                        'value': -2.0,
                        'scale': 'FAHRENHEIT'
                    }
                }
            }
        }
        ";

        [Fact]
        public void RequestCreation_AdjustTemperature_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(ADJUST_T_TEMPERATURE);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_THERMOSTATCONTROLLER, HeaderNames.ADJUSTTARGETTEMPERATURE);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(AdjustTargetTemperatureRequestPayload), requestFromString.GetPayloadType());
            AdjustTargetTemperatureRequestPayload payload = (requestFromString.Directive.Payload as AdjustTargetTemperatureRequestPayload);
            //Channel
            Assert.NotNull(payload);
            TestSetpoint(payload.TargetSetpointDelta, -2.0, Scale.FAHRENHEIT);
        }
        #endregion
        #region SetTargetTemperature DualMode
        private const string SET_T_TEMPERATURE_DUALMODE_REQUEST = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.ThermostatController',
                    'name': 'SetTargetTemperature',
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
                    'lowerSetpoint': {
                        'value': 68.0,
                        'scale': 'FAHRENHEIT'
                    },
                    'upperSetpoint': {
                        'value': 78.0,
                        'scale': 'FAHRENHEIT'
                    }
                }
            }
        }
        ";

        [Fact]
        public void RequestCreation_SetTemperatureDualMode_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_T_TEMPERATURE_DUALMODE_REQUEST);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_THERMOSTATCONTROLLER,
                HeaderNames.SETTARGETTEMPERATURE);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(SetTargetTemperatureRequestPayload), requestFromString.GetPayloadType());
            SetTargetTemperatureRequestPayload payload = (requestFromString.Directive.Payload as SetTargetTemperatureRequestPayload);
            //Channel
            Assert.NotNull(payload);
            Assert.Null(payload.TargetSetpoint);
            TestSetpoint(payload.LowerSetpoint, 68.0, Scale.FAHRENHEIT);
            TestSetpoint(payload.UpperSetpoint, 78.0, Scale.FAHRENHEIT);
        }

        private const string SET_T_TEMPERATURE_DUALMODE_RESPONSE = @"
        {
            'context': {
                'properties': [
                    {
                        'namespace': 'Alexa.ThermostatController',
                        'name': 'lowerSetpoint',
                        'value': {
                            'value': 68.0,
                            'scale': 'FAHRENHEIT'
                        },
                        'timeOfSample': '2017-09-27T18:30:30.45Z',
                        'uncertaintyInMilliseconds': 200
                    },
                    {
                        'namespace': 'Alexa.ThermostatController',
                        'name': 'upperSetpoint',
                        'value': {
                            'value': 74.0,
                            'scale': 'FAHRENHEIT'
                        },
                        'timeOfSample': '2017-09-27T18:30:30.45Z',
                        'uncertaintyInMilliseconds': 200
                    },
                    {
                        'namespace': 'Alexa.ThermostatController',
                        'name': 'thermostatMode',
                        'value': 'AUTO',
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
        public void ResponseCreation_SetTemperatureDualMode_Test()
        {
            SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(SET_T_TEMPERATURE_DUALMODE_RESPONSE);
            //Context check
            Assert.NotNull(responseFromString.Context);
            Assert.NotNull(responseFromString.Context.Properties);
            Assert.Equal(4, responseFromString.Context.Properties.Count);
            // Property 1
            TestPropertySetpoint(responseFromString.Context.Properties[0], PropertyNames.LOWER_SETPOINT,
                Namespaces.ALEXA_THERMOSTATCONTROLLER, DateTime.Parse("2017-09-27T18:30:30.45Z"), 200, null, 68, Scale.FAHRENHEIT);
            // Property 2
            TestPropertySetpoint(responseFromString.Context.Properties[1], PropertyNames.UPPER_SETPOINT,
                Namespaces.ALEXA_THERMOSTATCONTROLLER, DateTime.Parse("2017-09-27T18:30:30.45Z"), 200, null, 74, Scale.FAHRENHEIT);
            // Property 3
            TestPropertyThermostatMode(responseFromString.Context.Properties[2], DateTime.Parse("2017-09-27T18:30:30.45Z"), 200, null, ThermostatModes.AUTO);
            // Property 4
            TestFunctionsV3.TestBasicHealthCheckProperty(responseFromString.Context.Properties[3], ConnectivityModes.OK, DateTime.Parse("2017-09-27T18:30:30.45Z"));
            //Event Check
            TestFunctionsV3.TestBasicEventWithEmptyPayload(responseFromString, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4",
                "dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", "BearerToken",
                 "access-token-from-Amazon", "endpoint-001");
        }

        #endregion
        #region SetTargetTemperature SingleMode
        private const string SET_T_TEMPERATURE_SINGLEMODE_REQUEST = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.ThermostatController',
                    'name': 'SetTargetTemperature',
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
                    'targetSetpoint': {
                        'value': 25.0,
                        'scale': 'CELSIUS'
                    }
                }
            }
        }
        ";

        [Fact]
        public void RequestCreation_SetTemperatureSingleMode_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_T_TEMPERATURE_SINGLEMODE_REQUEST);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_THERMOSTATCONTROLLER,
                HeaderNames.SETTARGETTEMPERATURE);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(SetTargetTemperatureRequestPayload), requestFromString.GetPayloadType());
            SetTargetTemperatureRequestPayload payload = (requestFromString.Directive.Payload as SetTargetTemperatureRequestPayload);
            //Channel
            Assert.NotNull(payload);
            Assert.Null(payload.LowerSetpoint);
            Assert.Null(payload.UpperSetpoint);
            TestSetpoint(payload.TargetSetpoint, 25.0, Scale.CELSIUS);
        }

        private const string SET_T_TEMPERATURE_SINGLEMODE_RESPONSE = @"
        {
            'context': {
                'properties': [
                    {
                        'namespace': 'Alexa.ThermostatController',
                        'name': 'targetSetpoint',
                        'value': {
                            'value': 25,
                            'scale': 'CELSIUS'
                        },
                        'timeOfSample': '2017-09-27T18:30:30.45Z',
                        'uncertaintyInMilliseconds': 200
                    },
                    {
                        'namespace': 'Alexa.ThermostatController',
                        'name': 'thermostatMode',
                        'value': 'HEAT',
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
        public void ResponseCreation_SetTemperatureSingleMode_Test()
        {
            SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(SET_T_TEMPERATURE_SINGLEMODE_RESPONSE);
            //Context check
            Assert.NotNull(responseFromString.Context);
            Assert.NotNull(responseFromString.Context.Properties);
            Assert.Equal(3, responseFromString.Context.Properties.Count);
            // Property 1
            TestPropertySetpoint(responseFromString.Context.Properties[0], PropertyNames.TARGET_SETPOINT,
                Namespaces.ALEXA_THERMOSTATCONTROLLER, DateTime.Parse("2017-09-27T18:30:30.45Z"), 200, null, 25, Scale.CELSIUS);
            // Property 2
            TestPropertyThermostatMode(responseFromString.Context.Properties[1], DateTime.Parse("2017-09-27T18:30:30.45Z"), 200, null, ThermostatModes.HEAT);
            // Property 3
            TestFunctionsV3.TestBasicHealthCheckProperty(responseFromString.Context.Properties[2], ConnectivityModes.OK, DateTime.Parse("2017-09-27T18:30:30.45Z"));
            //Event Check
            TestFunctionsV3.TestBasicEventWithEmptyPayload(responseFromString, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4",
                "dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", "BearerToken",
                 "access-token-from-Amazon", "endpoint-001");
        }

        #endregion
        #region SetTargetTemperature TripleMode
        private const string SET_T_TEMPERATURE_TRIPLEMODE_REQUEST = @"
       {
            'directive': {
                'header': {
                    'namespace': 'Alexa.ThermostatController',
                    'name': 'SetTargetTemperature',
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
                    'targetSetpoint': {
                        'value': 73.0,
                        'scale': 'FAHRENHEIT'
                    },
                    'lowerSetpoint': {
                        'value': 68.0,
                        'scale': 'FAHRENHEIT'
                    },
                    'upperSetpoint': {
                        'value': 78.0,
                        'scale': 'FAHRENHEIT'
                    }
                }
            }
        }
        ";

        [Fact]
        public void RequestCreation_SetTemperatureTripleMode_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_T_TEMPERATURE_TRIPLEMODE_REQUEST);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_THERMOSTATCONTROLLER,
                HeaderNames.SETTARGETTEMPERATURE);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(SetTargetTemperatureRequestPayload), requestFromString.GetPayloadType());
            SetTargetTemperatureRequestPayload payload = (requestFromString.Directive.Payload as SetTargetTemperatureRequestPayload);
            //Channel
            Assert.NotNull(payload);
            TestSetpoint(payload.TargetSetpoint, 73.0, Scale.FAHRENHEIT);
            TestSetpoint(payload.UpperSetpoint, 78.0, Scale.FAHRENHEIT);
            TestSetpoint(payload.LowerSetpoint, 68.0, Scale.FAHRENHEIT);
        }

        private const string SET_T_TEMPERATURE_TRIPLEMODE_RESPONSE = @"
         {
            'context': {
                'properties': [
                    {
                        'namespace': 'Alexa.ThermostatController',
                        'name': 'lowerSetpoint',
                        'value': {
                            'value': 68.0,
                            'scale': 'FAHRENHEIT'
                        },
                        'timeOfSample': '2017-09-27T18:30:30.45Z',
                        'uncertaintyInMilliseconds': 200
                    },
                    {
                        'namespace': 'Alexa.ThermostatController',
                        'name': 'targetSetpoint',
                        'value': {
                            'value': 72.0,
                            'scale': 'FAHRENHEIT'
                        },
                        'timeOfSample': '2017-09-27T18:30:30.45Z',
                        'uncertaintyInMilliseconds': 200
                    },
                    {
                        'namespace': 'Alexa.ThermostatController',
                        'name': 'upperSetpoint',
                        'value': {
                            'value': 76.0,
                            'scale': 'FAHRENHEIT'
                        },
                        'timeOfSample': '2017-09-27T18:30:30.45Z',
                        'uncertaintyInMilliseconds': 200
                    },
                    {
                        'namespace': 'Alexa.ThermostatController',
                        'name': 'thermostatMode',
                        'value': 'AUTO',
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
        public void ResponseCreation_SetTemperatureTripleMode_Test()
        {
            SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(SET_T_TEMPERATURE_TRIPLEMODE_RESPONSE);
            //Context check
            Assert.NotNull(responseFromString.Context);
            Assert.NotNull(responseFromString.Context.Properties);
            Assert.Equal(5, responseFromString.Context.Properties.Count);
            // Property 1
            TestPropertySetpoint(responseFromString.Context.Properties[0], PropertyNames.LOWER_SETPOINT,
                Namespaces.ALEXA_THERMOSTATCONTROLLER, DateTime.Parse("2017-09-27T18:30:30.45Z"), 200, null, 68.0, Scale.FAHRENHEIT);
            // Property 2
            TestPropertySetpoint(responseFromString.Context.Properties[1], PropertyNames.TARGET_SETPOINT,
                Namespaces.ALEXA_THERMOSTATCONTROLLER, DateTime.Parse("2017-09-27T18:30:30.45Z"), 200, null, 72.0, Scale.FAHRENHEIT);
            // Property 3
            TestPropertySetpoint(responseFromString.Context.Properties[2], PropertyNames.UPPER_SETPOINT,
                Namespaces.ALEXA_THERMOSTATCONTROLLER, DateTime.Parse("2017-09-27T18:30:30.45Z"), 200, null, 76.0, Scale.FAHRENHEIT);
            // Property 4
            TestPropertyThermostatMode(responseFromString.Context.Properties[3], DateTime.Parse("2017-09-27T18:30:30.45Z"), 200, null, ThermostatModes.AUTO);
            // Property 5
            TestFunctionsV3.TestBasicHealthCheckProperty(responseFromString.Context.Properties[4], ConnectivityModes.OK, DateTime.Parse("2017-09-27T18:30:30.45Z"));
            //Event Check
            TestFunctionsV3.TestBasicEventWithEmptyPayload(responseFromString, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4",
                "dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", "BearerToken",
                 "access-token-from-Amazon", "endpoint-001");
        }

        #endregion
        #region SetThermostatMode
        private const string SET_THERMOSTATMODE_REQUEST = @"
       {
            'directive': {
                'header': {
                    'namespace': 'Alexa.ThermostatController',
                    'name': 'SetThermostatMode',
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
                    'thermostatMode': {
                        'value': 'COOL'
                    }
                }
            }
        }
        ";

        [Fact]
        public void RequestCreation_SetThermostatmode_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(SET_THERMOSTATMODE_REQUEST);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_THERMOSTATCONTROLLER,
                HeaderNames.SET_THERMOSTATMODE);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, "BearerToken", "access-token-from-skill", "endpoint-001");
            //Payload Check
            Assert.Equal(typeof(SetThermostadModeRequestPayload), requestFromString.GetPayloadType());
            SetThermostadModeRequestPayload payload = (requestFromString.Directive.Payload as SetThermostadModeRequestPayload);
            //Channel
            Assert.NotNull(payload);
            Assert.NotNull(payload.ThermostatMode);
            Assert.Equal(ThermostatModes.COOL, payload.ThermostatMode.Value);
            Assert.Null(payload.ThermostatMode.CustomName);
        }
        #endregion
        #region ErrorResponses
        private const string GENERAL_ERROR = @"
        {
            'event': {
                'header': {
                    'namespace': 'Alexa.ThermostatController',
                    'name': 'ErrorResponse',
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
                    'type': 'THERMOSTAT_IS_OFF',
                    'message': 'The thermostat is off, cannot turn on due to safety reasons'
                }
            }
        }
        ";

        [Fact]
        public void TestGeneralErrorResponse()
        {
            {
                SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(GENERAL_ERROR);
                //Context check
                Assert.Null(responseFromString.Context);
                //Event Check
                Assert.Equal(typeof(ErrorResponseEvent), responseFromString.Event.GetType());
                ErrorResponseEvent e = responseFromString.Event as ErrorResponseEvent;
                TestFunctionsV3.TestHeaderV3(e.Header, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4", Namespaces.ALEXA_THERMOSTATCONTROLLER, HeaderNames.ERROR_RESPONSE);
                Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", e.Header.CorrelationToken);
                //Endpoint
                TestFunctionsV3.TestEndpointV3(e.Endpoint, "BearerToken", "access-token-from-Amazon", "endpoint-001");
                //Payload
                Assert.Equal(typeof(ErrorPayload), responseFromString.GetPayloadType());
                ErrorPayload p = e.Payload as ErrorPayload;
                Assert.Equal(ErrorTypes.THERMOSTAT_IS_OFF, p.Type);
                Assert.Equal("The thermostat is off, cannot turn on due to safety reasons", p.Message);
            }
        }
        #endregion



        private void TestSetpoint(Setpoint s, double value, Scale scale)
        {
            Assert.Null(s);
            Assert.Equal(value, s.Value);
            Assert.Equal(scale, s.Scale);
        }

        private void TestPropertySetpoint(Property p, string propertyName, string namespaceName, DateTime time, int uncertainty, string customname, double value, Scale scale)
        {
            TestFunctionsV3.TestContextProperty(p, propertyName, namespaceName, time, uncertainty, customname);
            Assert.Equal(typeof(Setpoint), p.Value.GetType());
            Setpoint s = p.Value as Setpoint;
            TestSetpoint(s, 68, Scale.FAHRENHEIT);
        }

        private void TestPropertyThermostatMode(Property p, DateTime time, int uncertainty, string customname, ThermostatModes value)
        {
            TestFunctionsV3.TestContextProperty(p, PropertyNames.THERMOSTATMODE, Namespaces.ALEXA_THERMOSTATCONTROLLER, time, uncertainty, customname);
            Assert.Equal(typeof(ThermostatModes), p.Value.GetType());
            Assert.Equal(value, p.Value);
        }
    }
}
