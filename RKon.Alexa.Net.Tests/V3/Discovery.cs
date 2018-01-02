using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.V3.TestFunctions;
using RKon.Alexa.NET.JsonObjects;
using RKon.Alexa.NET.Payloads;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Response;
using RKon.Alexa.NET.Types;
using System.Collections.Generic;
using Xunit;

namespace RKon.Alexa.Net.Tests.V3.Requests
{
    public class Discovery
    {
        #region DiscoverRequest
        private const string DISCOVERY_REQUEST = @"
        {
            'directive': {
                'header': {
                    'namespace': 'Alexa.Discovery',
                    'name': 'Discover',
                    'payloadVersion': '3',
                    'messageId': '1bd5d003-31b9-476f-ad03-71d471922820'
                },
                'payload': {
                    'scope': {
                        'type': 'BearerToken',
                        'token': 'access-token-from-skill'
                    }
                }
            }
        }
        ";

        [Fact]
        public void RequestCreationTest()
        {
            SmartHomeRequest requestFromString = JsonConvert.DeserializeObject<SmartHomeRequest>(DISCOVERY_REQUEST);
            //Directive Check
            Assert.NotNull(requestFromString.Directive);
            //Header Check
            TestFunctionsV3.TestHeaderV3(requestFromString.Directive.Header, "1bd5d003-31b9-476f-ad03-71d471922820", Namespaces.ALEXA_DISCOVERY, HeaderNames.DISCOVERY_REQUEST);
            //Payload Check
            Assert.Equal(typeof(RequestPayloadWithScope),requestFromString.GetPayloadType());
            RequestPayloadWithScope payload = (requestFromString.Directive.Payload as RequestPayloadWithScope);
            Assert.NotNull(payload);
            Assert.NotNull(payload.Scope);
            Assert.Equal(ScopeTypes.BearerToken, payload.Scope.Type);
            Assert.Equal("access-token-from-skill", payload.Scope.Token);
        }
        #endregion
        #region DiscoveryResponse
        private const string DISCOVERY_RESPONSE = @"
        {
            'event': {
                'header': {
                    'namespace': 'Alexa.Discovery',
                    'name': 'Discover.Response',
                    'payloadVersion': '3',
                    'messageId': '0a58ace0-e6ab-47de-b6af-b600b5ab8a7a'
                },
                'payload': {
                    'endpoints': [
                        {
                            'endpointId': 'endpoint-001',
                            'manufacturerName': 'Sample Manufacturer',
                            'friendlyName': 'Switch',
                            'description': '001 Switch that can only be turned on/off',
                            'displayCategories': [
                                'SWITCH'
                            ],
                            'cookie': {
                                'detail1': 'For simplicity, this is the only appliance',
                                'detail2': 'that has some values in the additionalApplianceDetails'
                            },
                            'capabilities': [
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa',
                                    'version': '3'
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.PowerController',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'powerState'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.EndpointHealth',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'connectivity'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                }
                            ]
                        },
                        {
                            'endpointId': 'endpoint-002',
                            'manufacturerName': 'Sample Manufacturer',
                            'friendlyName': 'Light',
                            'description': '002 Light that is dimmable and can change color and color temperature',
                            'displayCategories': [
                                'LIGHT'
                            ],
                            'cookie': {},
                            'capabilities': [
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa',
                                    'version': '3'
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.PowerController',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'powerState'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.ColorController',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'color'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.ColorTemperatureController',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'colorTemperatureInKelvin'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.BrightnessController',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'brightness'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.PowerLevelController',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'powerLevel'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.PercentageController',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'percentage'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.EndpointHealth',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'connectivity'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                }
                            ]
                        },
                        {
                            'endpointId': 'endpoint-003',
                            'manufacturerName': 'Sample Manufacturer',
                            'friendlyName': 'White Light',
                            'description': '003 Light that is dimmable and can change color temperature only',
                            'displayCategories': [
                                'LIGHT'
                            ],
                            'cookie': {},
                            'capabilities': [
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa',
                                    'version': '3'
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.PowerController',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'powerState'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.ColorTemperatureController',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'colorTemperatureInKelvin'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.BrightnessController',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'brightness'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.PowerLevelController',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'powerLevel'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.PercentageController',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'percentage'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.EndpointHealth',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'connectivity'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                }
                            ]
                        },
                        {
                            'endpointId': 'endpoint-004',
                            'manufacturerName': 'Sample Manufacturer',
                            'friendlyName': 'Thermostat',
                            'description': '004 Thermostat that can change and query temperatures',
                            'displayCategories': [
                                'THERMOSTAT'
                            ],
                            'cookie': {},
                            'capabilities': [
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa',
                                    'version': '3'
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.ThermostatController',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'targetSetpoint'
                                            },
                                            {
                                                'name': 'thermostatMode'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.TemperatureSensor',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'temperature'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.EndpointHealth',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'connectivity'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                }
                            ]
                        },
                        {
                            'endpointId': 'endpoint-004-1',
                            'manufacturerName': 'Sample Manufacturer',
                            'friendlyName': 'Living Room Thermostat',
                            'description': '004-1 Thermostat that can change and query temperatures, supports dual setpoints',
                            'displayCategories': [
                                'OTHER'
                            ],
                            'cookie': {},
                            'capabilities': [
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa',
                                    'version': '3'
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.ThermostatController',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'upperSetpoint'
                                            },
                                            {
                                                'name': 'lowerSetpoint'
                                            },
                                            {
                                                'name': 'thermostatMode'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.TemperatureSensor',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'temperature'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.EndpointHealth',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'connectivity'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                }
                            ]
                        },
                        {
                            'endpointId': 'endpoint-005',
                            'manufacturerName': 'Sample Manufacturer',
                            'friendlyName': 'Lock',
                            'description': '005 Lock that can be locked and can query lock state',
                            'displayCategories': [
                                'SMARTLOCK'
                            ],
                            'cookie': {},
                            'capabilities': [
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa',
                                    'version': '3'
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.LockController',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'lockState'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.EndpointHealth',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'connectivity'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                }
                            ]
                        },
                        {
                            'endpointId': 'endpoint-006',
                            'manufacturerName': 'Sample Manufacturer',
                            'friendlyName': 'Goodnight',
                            'description': '006 Scene that can only be turned on',
                            'displayCategories': [
                                'SCENE_TRIGGER'
                            ],
                            'cookie': {},
                            'capabilities': [
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa',
                                    'version': '3'
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.SceneController',
                                    'version': '3',
                                    'supportsDeactivation': false,
                                    'proactivelyReported': true
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.EndpointHealth',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'connectivity'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                }
                            ]
                        },
                        {
                            'endpointId': 'endpoint-007',
                            'manufacturerName': 'Sample Manufacturer',
                            'friendlyName': 'Watch TV',
                            'description': '007 Activity that runs sequentially that can be turned on and off',
                            'displayCategories': [
                                'ACTIVITY_TRIGGER'
                            ],
                            'cookie': {},
                            'capabilities': [
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa',
                                    'version': '3'
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.SceneController',
                                    'version': '3',
                                    'supportsDeactivation': true,
                                    'proactivelyReported': true
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.EndpointHealth',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'connectivity'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                }
                            ]
                        },
                        {
                            'endpointId': 'endpoint-008',
                            'manufacturerName': 'Sample Manufacturer',
                            'friendlyName': 'Baby Camera',
                            'description': '008 Camera that streams from an RSTP source',
                            'displayCategories': [
                                'CAMERA'
                            ],
                            'cookie': {},
                            'capabilities': [
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa',
                                    'version': '3'
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.CameraStreamController',
                                    'version': '3',
                                    'cameraStreamConfigurations': [
                                        {
                                            'protocols': [
                                                'RTSP'
                                            ],
                                            'resolutions': [
                                                {
                                                    'width': 1280,
                                                    'height': 720
                                                }
                                            ],
                                            'authorizationTypes': [
                                                'NONE'
                                            ],
                                            'videoCodecs': [
                                                'H264'
                                            ],
                                            'audioCodecs': [
                                                'AAC'
                                            ]
                                        }
                                    ]
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.EndpointHealth',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'connectivity'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                }
                            ]
                        },
                        {
                            'endpointId': 'endpoint-009',
                            'manufacturerName': 'Sample Manufacturer',
                            'friendlyName': 'TV',
                            'description': '009 TV that supports various entertainment controllers',
                            'displayCategories': [
                                'OTHER'
                            ],
                            'cookie': {},
                            'capabilities': [
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa',
                                    'version': '3'
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.ChannelController',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'channel'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.InputController',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'input'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.Speaker',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'volume'
                                            },
                                            {
                                                'name': 'muted'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                },
                                {
                                    'type': 'AlexaInterface',
                                    'interface': 'Alexa.EndpointHealth',
                                    'version': '3',
                                    'properties': {
                                        'supported': [
                                            {
                                                'name': 'connectivity'
                                            }
                                        ],
                                        'proactivelyReported': true,
                                        'retrievable': true
                                    }
                                }
                            ]
                        }
                    ]
                }
            }
        }
        ";

        [Fact]
        public void ResponseParse_Discovery_Test()
        {
            SmartHomeResponse responseFromString = JsonConvert.DeserializeObject<SmartHomeResponse>(DISCOVERY_RESPONSE);
            //Context check
            Assert.Null(responseFromString.Context);
            //Event Check
            Assert.NotNull(responseFromString.Event);
            Assert.Equal(typeof(Event), responseFromString.Event.GetType());
            //Header Check
            TestFunctionsV3.TestHeaderV3(responseFromString.Event.Header, "0a58ace0-e6ab-47de-b6af-b600b5ab8a7a", Namespaces.ALEXA_DISCOVERY, HeaderNames.DISCOVERY_RESPONSE);
            Assert.Null(responseFromString.Event.Header.CorrelationToken);
            //Endpoint Check
            Event e = responseFromString.Event as Event;
            Assert.Null(e.Endpoint);
            //Payload Check
            Assert.Equal(typeof(DiscoveryPayload), responseFromString.GetPayloadType());
            DiscoveryPayload payload = e.Payload as DiscoveryPayload;
            Assert.NotNull(payload.Endpoints);
            Assert.Equal(10, payload.Endpoints.Count);
            #region Endpoint1
            List<DisplayCategory> categories = new List<DisplayCategory>() { DisplayCategory.SWITCH };
            Dictionary<string, string> cookies = new Dictionary<string, string>()
            {
                { "detail1", "For simplicity, this is the only appliance" },
                { "detail2", "that has some values in the additionalApplianceDetails" }
            };
            List<Capability> capabilities = new List<Capability>()
            {
                new AlexaInterface("Alexa","3",null, null, null),
                new AlexaInterface("Alexa.PowerController", "3", new List<string>() {"powerState"}, true, true),
                new AlexaInterface("Alexa.EndpointHealth", "3", new List<string>() {"connectivity"}, true, true)
            };
            TestFunctionsV3.TestResponseEndpointV3(payload.Endpoints[0], "Sample Manufacturer", "Switch", "001 Switch that can only be turned on/off",
                "endpoint-001", cookies, capabilities, categories);
            #endregion
            #region Endpoint2
            categories = new List<DisplayCategory>() { DisplayCategory.LIGHT };
            cookies = new Dictionary<string, string>();
            capabilities = new List<Capability>()
            {
                new AlexaInterface("Alexa","3",null,null,null),
                new AlexaInterface("Alexa.PowerController", "3", new List<string>() {"powerState"},true,true),
                new AlexaInterface("Alexa.ColorController", "3", new List<string>() {"color"},true,true),
                new AlexaInterface("Alexa.ColorTemperatureController", "3", new List<string>() {"colorTemperatureInKelvin"},true,true),
                new AlexaInterface("Alexa.BrightnessController", "3", new List<string>() {"brightness"},true,true),
                new AlexaInterface("Alexa.PowerLevelController", "3", new List<string>() {"powerLevel"},true,true),
                new AlexaInterface("Alexa.PercentageController", "3", new List<string>() {"percentage"},true,true),
                new AlexaInterface("Alexa.EndpointHealth", "3", new List<string>() {"connectivity"},true,true)
            };
            TestFunctionsV3.TestResponseEndpointV3(payload.Endpoints[1], "Sample Manufacturer", "Light", "002 Light that is dimmable and can change color and color temperature",
                "endpoint-002", cookies, capabilities, categories);
            #endregion
            #region Endpoint3
            categories = new List<DisplayCategory>() { DisplayCategory.LIGHT };
            cookies = new Dictionary<string, string>();
            capabilities = new List<Capability>()
            {
                new AlexaInterface("Alexa","3",null,null,null),
                new AlexaInterface("Alexa.PowerController", "3", new List<string>() {"powerState"},true,true),
                new AlexaInterface("Alexa.ColorTemperatureController", "3", new List<string>() {"colorTemperatureInKelvin"},true,true),
                new AlexaInterface("Alexa.BrightnessController", "3", new List<string>() {"brightness"},true,true),
                new AlexaInterface("Alexa.PowerLevelController", "3", new List<string>() {"powerLevel"},true,true),
                new AlexaInterface("Alexa.PercentageController", "3", new List<string>() {"percentage"},true,true),
                new AlexaInterface("Alexa.EndpointHealth", "3", new List<string>() {"connectivity"},true,true)
            };
            TestFunctionsV3.TestResponseEndpointV3(payload.Endpoints[2], "Sample Manufacturer", "White Light", "003 Light that is dimmable and can change color temperature only",
                "endpoint-003", cookies, capabilities, categories);
            #endregion
            #region Endpoint4
            categories = new List<DisplayCategory>() { DisplayCategory.THERMOSTAT };
            cookies = new Dictionary<string, string>();
            capabilities = new List<Capability>()
            {
                new AlexaInterface("Alexa","3",null,null,null),
                new AlexaInterface("Alexa.ThermostatController", "3", new List<string>() {"targetSetpoint","thermostatMode"},true,true),
                new AlexaInterface("Alexa.TemperatureSensor", "3", new List<string>() {"temperature"},true,true),
                new AlexaInterface("Alexa.EndpointHealth", "3", new List<string>() {"connectivity"},true,true)
            };
            TestFunctionsV3.TestResponseEndpointV3(payload.Endpoints[3], "Sample Manufacturer", "Thermostat", "004 Thermostat that can change and query temperatures",
                "endpoint-004", cookies, capabilities, categories);
            #endregion       
            #region Endpoint5
            categories = new List<DisplayCategory>() { DisplayCategory.OTHER };
            cookies = new Dictionary<string, string>();
            capabilities = new List<Capability>()
            {
                new AlexaInterface("Alexa","3",null,null,null),
                new AlexaInterface("Alexa.ThermostatController", "3", new List<string>() { "upperSetpoint", "lowerSetpoint", "thermostatMode"},true,true),
                new AlexaInterface("Alexa.TemperatureSensor", "3", new List<string>() {"temperature"},true,true),
                new AlexaInterface("Alexa.EndpointHealth", "3", new List<string>() {"connectivity"},true,true)
            };
            TestFunctionsV3.TestResponseEndpointV3(payload.Endpoints[4], "Sample Manufacturer", "Living Room Thermostat", "004-1 Thermostat that can change and query temperatures, supports dual setpoints",
                "endpoint-004-1", cookies, capabilities, categories);
            #endregion
            #region Endpoint6
            categories = new List<DisplayCategory>() { DisplayCategory.SMARTLOCK };
            cookies = new Dictionary<string, string>();
            capabilities = new List<Capability>()
            {
                new AlexaInterface("Alexa","3",null,null,null),
                new AlexaInterface("Alexa.LockController", "3", new List<string>() { "lockState"},true,true),
                new AlexaInterface("Alexa.EndpointHealth", "3", new List<string>() {"connectivity"},true,true)
            };
            TestFunctionsV3.TestResponseEndpointV3(payload.Endpoints[5], "Sample Manufacturer", "Lock", "005 Lock that can be locked and can query lock state",
                "endpoint-005", cookies, capabilities, categories);
            #endregion
            #region Endpoint7
            categories = new List<DisplayCategory>() { DisplayCategory.SCENE_TRIGGER };
            cookies = new Dictionary<string, string>();
            capabilities = new List<Capability>()
            {
                new AlexaInterface("Alexa","3",null,null,null),
                new AlexaInterface("Alexa.SceneController", "3", null,false,true),
                new AlexaInterface("Alexa.EndpointHealth", "3", new List<string>() {"connectivity"},true,true)
            };
            TestFunctionsV3.TestResponseEndpointV3(payload.Endpoints[6], "Sample Manufacturer", "Goodnight", "006 Scene that can only be turned on",
                "endpoint-006", cookies, capabilities, categories);
            #endregion
            #region Endpoint8
            categories = new List<DisplayCategory>() { DisplayCategory.ACTIVITY_TRIGGER };
            cookies = new Dictionary<string, string>();
            capabilities = new List<Capability>()
            {
                new AlexaInterface("Alexa","3",null,null,null),
                new AlexaInterface("Alexa.SceneController", "3", null,true,true),
                new AlexaInterface("Alexa.EndpointHealth", "3", new List<string>() {"connectivity"},true,true)
            };
            TestFunctionsV3.TestResponseEndpointV3(payload.Endpoints[7], "Sample Manufacturer", "Watch TV", "007 Activity that runs sequentially that can be turned on and off",
                "endpoint-007", cookies, capabilities, categories);
            #endregion
            #region Endpoint9
            categories = new List<DisplayCategory>() { DisplayCategory.CAMERA };
            cookies = new Dictionary<string, string>();
            CameraStreamConfigurations conf = new CameraStreamConfigurations();
            conf.Protocols.Add("RTSP");
            conf.Resolutions.Add(new Resolution(1280, 720));
            conf.AuthorizationTypes.Add("NONE");
            conf.VideoCodecs.Add("H264");
            conf.AudioCodecs.Add("AAC");
            List<CameraStreamConfigurations> confs = new List<CameraStreamConfigurations>()
            {
                conf
            };
            capabilities = new List<Capability>()
            {
                new AlexaInterface("Alexa","3",null,null,null),
                new AlexaInterface("Alexa.CameraStreamController", "3", null,true,true,confs),
                new AlexaInterface("Alexa.EndpointHealth", "3", new List<string>() {"connectivity"},true,true)
            };
            TestFunctionsV3.TestResponseEndpointV3(payload.Endpoints[8], "Sample Manufacturer", "Baby Camera", "008 Camera that streams from an RSTP source",
                "endpoint-008", cookies, capabilities, categories);
            #endregion
            #region Endpoint10
            categories = new List<DisplayCategory>() { DisplayCategory.OTHER };
            cookies = new Dictionary<string, string>();
            capabilities = new List<Capability>()
            {
                new AlexaInterface("Alexa","3",null,null,null),
                new AlexaInterface("Alexa.ChannelController", "3", new List<string>() {"channel"},true,true),
                new AlexaInterface("Alexa.InputController", "3", new List<string>() {"input"},true,true),
                new AlexaInterface("Alexa.Speaker", "3", new List<string>() {"volume","muted"},true,true),
                new AlexaInterface("Alexa.EndpointHealth", "3", new List<string>() {"connectivity"},true,true)
            };
            TestFunctionsV3.TestResponseEndpointV3(payload.Endpoints[9], "Sample Manufacturer", "TV", "009 TV that supports various entertainment controllers",
                "endpoint-009", cookies, capabilities, categories);
            #endregion
        }

        [Fact]
        public void ResponseCreation_Discovery_Test()
        {
            SmartHomeRequest request = JsonConvert.DeserializeObject<SmartHomeRequest>(DISCOVERY_REQUEST);
            SmartHomeResponse response = new SmartHomeResponse(request.Directive.Header);
            Assert.Null(response.Context);
            Assert.NotNull(response.Event);
            Assert.Equal(typeof(Event), response.Event.GetType());
            Event e = response.Event as Event;
            TestFunctionsV3.CheckResponseCreatedBaseHeader(e.Header, request.Directive.Header, Namespaces.ALEXA_DISCOVERY, HeaderNames.DISCOVERY_RESPONSE);
            Assert.NotNull(e.Payload);
            Assert.Null(e.Endpoint);
            Assert.Equal(typeof(DiscoveryPayload), e.Payload.GetType());
            DiscoveryPayload p = e.Payload as DiscoveryPayload;
            Assert.NotNull(p.Endpoints);
            Dictionary<string, string> cookies = new Dictionary<string, string>()
            {
                { "detail1","For simplicity, this is the only appliance" }
            };
            List<DisplayCategory> categories = new List<DisplayCategory>() { DisplayCategory.SWITCH };
            List<Capability> capabilities = new List<Capability>();
            capabilities.Add(new AlexaInterface("Alexa","3",null,null,null,null));
            capabilities.Add(new AlexaInterface(Namespaces.ALEXA_POWERCONTROLLER, "3", new List<string>() { PropertyNames.POWER_STATE }, true, true));
            capabilities.Add(new AlexaInterface(Namespaces.ALEXA_ENDPOINTHEALTH, "3", new List<string>() { PropertyNames.CONNECTIVITY }, true, true));
            p.Endpoints.Add(new ResponseEndpoint("endpoint-001","Sample Manufacturer","Switch","001 Switch",cookies,categories,capabilities));
            Assert.NotNull(JsonConvert.SerializeObject(response));
            Util.Util.WriteJsonToConsole("DiscoveryResponse", response);
        }
        #endregion
    }
}
