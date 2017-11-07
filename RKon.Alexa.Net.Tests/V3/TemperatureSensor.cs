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
    public class TemperatureSensor
    {
        private const string REPORT_STATE = @"
        {
          'directive': {
            'header': {
              'messageId': '5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4',
              'correlationToken': 'dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==',
              'namespace': 'Alexa',
              'name': 'ReportState',
              'payloadVersion': '3'
            },
            'endpoint': {
              'endpointId': 'appliance-001',
              'cookie': {},
              'scope':{  
                    'type':'BearerToken',
                    'token':'some-access-token'
              }
            },
            'payload': {
            }
          }
        }
        ";

        [Fact]
        public void RequestCreation_AdjustPowerLevel_Test()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(REPORT_STATE);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4", Namespaces.ALEXA, HeaderNames.REPORT_STATE);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", requestFromString.Directive.Header.CorrelationToken);
            //Endpoint Check
            TestFunctionsV3.TestEndpointV3(requestFromString.Directive.Endpoint, ScopeTypes.BearerToken, "some-access-token", "appliance-001");
            //Payload Check
            Assert.NotNull(requestFromString.Directive.Payload);
            Assert.Equal(typeof(Payload), requestFromString.GetPayloadType());
        }

        private const string TEMPERATURESENSOR_RESPONSE = @"
        {
            'context': {
                'properties': [
                    {
                        'namespace': 'Alexa.TemperatureSensor',
                        'name': 'temperature',
                        'value': {
                            'value': 24.0,
                            'scale': 'CELSIUS'
                        },
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
                    'name': 'StateReport',
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
        public void ResponseParse_TemperatureSensor_Test()
        {
            SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(TEMPERATURESENSOR_RESPONSE);
            //Context check
            Assert.NotNull(responseFromString.Context);
            Assert.NotNull(responseFromString.Context.Properties);
            Assert.Equal(2, responseFromString.Context.Properties.Count);
            // Property 1
            TestFunctionsV3.TestContextProperty(responseFromString.Context.Properties[0], PropertyNames.TEMPERATURE,
                Namespaces.ALEXA_TEMPERATURESENSOR, DateTime.Parse("2017-09-27T18:30:30.45Z"), 200, null);
            Assert.Equal(typeof(Setpoint), responseFromString.Context.Properties[0].Value.GetType());
            Setpoint s = responseFromString.Context.Properties[0].Value as Setpoint;
            Assert.Equal(24.0, s.Value);
            Assert.Equal(Scale.CELSIUS, s.Scale);
            // Property 2
            TestFunctionsV3.TestBasicHealthCheckProperty(responseFromString.Context.Properties[1], ConnectivityModes.OK, DateTime.Parse("2017-09-27T18:30:30.45Z"));
            //Event Check
            Assert.NotNull(responseFromString.Event);
            Assert.Equal(typeof(Event), responseFromString.Event.GetType());
            Event e = responseFromString.Event as Event;
            TestFunctionsV3.TestHeaderV3(e.Header, "5f8a426e-01e4-4cc9-8b79-65f8bd0fd8a4", Namespaces.ALEXA, HeaderNames.STATE_REPORT);
            Assert.Equal("dFMb0z+PgpgdDmluhJ1LddFvSqZ/jCc8ptlAKulUj90jSqg==", e.Header.CorrelationToken);
            TestFunctionsV3.TestEndpointV3(e.Endpoint, ScopeTypes.BearerToken, "access-token-from-Amazon", "endpoint-001");
            Assert.NotNull(e.Payload);
            Assert.Equal(typeof(Payload), responseFromString.GetPayloadType());
        }

        [Fact]
        public void ResponseCreation_TemperatureSensor_Test()
        {
            SmartHomeRequest request = JsonConvert.DeserializeObject<SmartHomeRequest>(REPORT_STATE);
            SmartHomeResponse response = new SmartHomeResponse(request.Directive.Header);
            Assert.Null(response.Context);
            response.Context = new Context();
            Setpoint s = new Setpoint(24.0,Scale.CELSIUS);
            Property p = new Property(Namespaces.ALEXA_TEMPERATURESENSOR, PropertyNames.TEMPERATURE, 50,
              DateTime.Parse("2017-09-27T18:30:30.45Z").ToUniversalTime(), 200);
            ConnectivityPropertyValue value = new ConnectivityPropertyValue(ConnectivityModes.OK);
            Property p2 = new Property(Namespaces.ALEXA_ENDPOINTHEALTH, PropertyNames.CONNECTIVITY, value,
                DateTime.Parse("2017-09-27T18:30:30.45Z").ToUniversalTime(), 200);
            response.Context.Properties.Add(p);
            response.Context.Properties.Add(p2);
            Assert.NotNull(response.Event);
            Assert.Equal(typeof(Event), response.Event.GetType());
            Event e = response.Event as Event;
            TestFunctionsV3.CheckResponseCreatedBaseHeader(e.Header, request.Directive.Header, headerName: HeaderNames.STATE_REPORT);
            Assert.Null(e.Endpoint);
            e.Endpoint = new Endpoint("endpoint-001", new Scope(ScopeTypes.BearerToken, "access-token-from-Amazon"));
            Assert.NotNull(e.Payload);
            Assert.Equal(typeof(Payload), response.GetPayloadType());
            Assert.NotNull(JsonConvert.SerializeObject(response));
            Util.Util.WriteJsonToConsole("TemperatureSensor", response);
        }
    }
}
