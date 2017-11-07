using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.V3.TestFunctions;
using RKon.Alexa.NET.Payloads;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using Xunit;

namespace RKon.Alexa.Net.Tests.V3
{
    public class ErrorResponses
    {
        #region GeneralError
        private const string GENERAL_ERROR = @"
        {
            'event': {
                'header': {
                    'namespace': 'Alexa',
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
                    'type': 'ENDPOINT_UNREACHABLE',
                    'message': 'Unable to reach endpoint-001 because it appears to be offline'
                }
            }
        }
        ";

        [Fact]
        public void TestGeneralErrorResponse()
        {
                SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(GENERAL_ERROR);
                //Context check
                Assert.Null(responseFromString.Context);
                //Event Check
                Assert.Equal(typeof(Event), responseFromString.Event.GetType());
                Event e = responseFromString.Event as Event;
                TestFunctionsV3.TestHeaderV3(e.Header, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4", Namespaces.ALEXA, HeaderNames.ERROR_RESPONSE);
                Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", e.Header.CorrelationToken);
                //Endpoint
                TestFunctionsV3.TestEndpointV3(e.Endpoint, ScopeTypes.BearerToken, "access-token-from-Amazon", "endpoint-001");
                //Payload
                Assert.Equal(typeof(ErrorPayload), responseFromString.GetPayloadType());
                ErrorPayload p = e.Payload as ErrorPayload;
                Assert.Equal(ErrorTypes.ENDPOINT_UNREACHABLE, p.Type);
                Assert.Equal("Unable to reach endpoint-001 because it appears to be offline", p.Message);
        }
        #endregion
        #region EndpointLowPower
        private const string ENDPOINT_LOW_POWER = @"
        {
            'event': {
                'header': {
                    'namespace': 'Alexa',
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
                    'type': 'ENDPOINT_LOW_POWER',
                    'message': 'The lock battery is low',
                    'percentageState': 5
                }
            }
        }
        ";

        [Fact]
        public void TestEndpointLowPowerResponse()
        {
            SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(ENDPOINT_LOW_POWER);
            //Context check
            Assert.Null(responseFromString.Context);
            //Event Check
            Assert.Equal(typeof(Event), responseFromString.Event.GetType());
            Event e = responseFromString.Event as Event;
            TestFunctionsV3.TestHeaderV3(e.Header, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4", Namespaces.ALEXA, HeaderNames.ERROR_RESPONSE);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", e.Header.CorrelationToken);
            //Endpoint
            TestFunctionsV3.TestEndpointV3(e.Endpoint, ScopeTypes.BearerToken, "access-token-from-Amazon", "endpoint-001");
            //Payload
            Assert.Equal(typeof(EndpointLowPowerErrorPayload), responseFromString.GetPayloadType());
            EndpointLowPowerErrorPayload p = e.Payload as EndpointLowPowerErrorPayload;
            Assert.Equal(ErrorTypes.ENDPOINT_LOW_POWER, p.Type);
            Assert.Equal("The lock battery is low", p.Message);
            Assert.Equal(5, p.PercentageState);
        }
        #endregion
        #region TempValueOutOfRange
        private const string TEMPVALUE_OOR = @"
        {
            'event': {
                'header': {
                    'namespace': 'Alexa',
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
                    'type': 'TEMPERATURE_VALUE_OUT_OF_RANGE',
                    'message': 'The requested temperature of -15 is out of range',
                    'validRange': {
                        'minimumValue': {
                            'value': 15.0,
                            'scale': 'CELSIUS'
                        },
                        'maximumValue': {
                            'value': 30.0,
                            'scale': 'CELSIUS'
                        }
                    }
                }
            }
        }
        ";

        [Fact]
        public void TestTempValueOORResponse()
        {
            SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(TEMPVALUE_OOR);
            //Context check
            Assert.Null(responseFromString.Context);
            //Event Check
            Assert.Equal(typeof(Event), responseFromString.Event.GetType());
            Event e = responseFromString.Event as Event;
            TestFunctionsV3.TestHeaderV3(e.Header, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4", Namespaces.ALEXA, HeaderNames.ERROR_RESPONSE);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", e.Header.CorrelationToken);
            //Endpoint
            TestFunctionsV3.TestEndpointV3(e.Endpoint, ScopeTypes.BearerToken, "access-token-from-Amazon", "endpoint-001");
            //Payload
            Assert.Equal(typeof(TemperatureOutOfRangeErrorPayload), responseFromString.GetPayloadType());
            TemperatureOutOfRangeErrorPayload p = e.Payload as TemperatureOutOfRangeErrorPayload;
            Assert.Equal(ErrorTypes.TEMPERATURE_VALUE_OUT_OF_RANGE, p.Type);
            Assert.Equal("The requested temperature of -15 is out of range", p.Message);
            Assert.NotNull(p.ValidRange);
            Assert.NotNull(p.ValidRange.MaximumValue);
            Assert.Equal(30.0, p.ValidRange.MaximumValue.Value);
            Assert.Equal(Scale.CELSIUS, p.ValidRange.MaximumValue.Scale);
            Assert.NotNull(p.ValidRange.MinimumValue);
            Assert.Equal(15.0, p.ValidRange.MinimumValue.Value);
            Assert.Equal(Scale.CELSIUS, p.ValidRange.MinimumValue.Scale);
        }
        #endregion
        #region ValueOOR
        private const string VALUE_OOR = @"
        {
            'event': {
                'header': {
                    'namespace': 'Alexa',
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
                    'type': 'VALUE_OUT_OF_RANGE',
                    'message': 'The color temperature cannot be set to 500',
                    'validRange': {
                        'minimumValue': 1000,
                        'maximumValue': 10000
                    }
                }
            }
        }
        ";

        [Fact]
        public void TestValueOORResponse()
        {
            SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(VALUE_OOR);
            //Context check
            Assert.Null(responseFromString.Context);
            //Event Check
            Assert.Equal(typeof(Event), responseFromString.Event.GetType());
            Event e = responseFromString.Event as Event;
            TestFunctionsV3.TestHeaderV3(e.Header, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4", Namespaces.ALEXA, HeaderNames.ERROR_RESPONSE);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", e.Header.CorrelationToken);
            //Endpoint
            TestFunctionsV3.TestEndpointV3(e.Endpoint, ScopeTypes.BearerToken, "access-token-from-Amazon", "endpoint-001");
            //Payload
            Assert.Equal(typeof(ValueOutRangeErrorPayload), responseFromString.GetPayloadType());
            ValueOutRangeErrorPayload p = e.Payload as ValueOutRangeErrorPayload;
            Assert.Equal(ErrorTypes.VALUE_OUT_OF_RANGE, p.Type);
            Assert.Equal("The color temperature cannot be set to 500", p.Message);
            Assert.NotNull(p.ValidRange);
            Assert.Equal(1000, p.ValidRange.MinimumValue);
            Assert.Equal(10000, p.ValidRange.MaximumValue);
        }
        #endregion
    }
}
