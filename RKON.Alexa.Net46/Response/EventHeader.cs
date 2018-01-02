using System;
using RKon.Alexa.NET46.Request;
using RKon.Alexa.NET46.Types;

namespace RKon.Alexa.NET46.Response
{
    /// <summary>
    /// Header of Responseevents
    /// </summary>
    public class EventHeader : DirectiveHeader
    {
        /// <summary>
        /// Creates the ResponseHeader
        /// </summary>
        public EventHeader(DirectiveHeader reqHeader)
        {
            MessageId = System.Guid.NewGuid().ToString();
            PayloadVersion = reqHeader.PayloadVersion;
            Namespace = _GetNamespace(reqHeader);
            Name = _GetName(reqHeader);
            CorrelationToken = reqHeader.CorrelationToken;
        }

        /// <summary>
        /// Creates a header for a ErrorResponse
        /// </summary>
        /// <param name="correlationToken"></param>
        /// <param name="hNamespace"></param>
        /// <returns></returns>
        public static EventHeader CreateErrorHeader(string correlationToken, string hNamespace)
        {
            EventHeader e = new EventHeader();
            e.MessageId = System.Guid.NewGuid().ToString();
            e.PayloadVersion = "3";
            if(hNamespace == Namespaces.ALEXA_THERMOSTATCONTROLLER)
            {
                e.Namespace = Namespaces.ALEXA_THERMOSTATCONTROLLER;
            }else
            {
                e.Namespace = Namespaces.ALEXA;
            }
            e.Name = HeaderNames.ERROR_RESPONSE;
            e.CorrelationToken = correlationToken;
            return e;
        }

        /// <summary>
        /// Standartconstructor
        /// </summary>
        public EventHeader()
        {

        }

        /// <summary>
        /// Creates a header for a Changereport
        /// </summary>
        /// <returns></returns>
        public static EventHeader CreateChangeReportHeader()
        {
            EventHeader e = new EventHeader();
            e.MessageId = System.Guid.NewGuid().ToString();
            e.PayloadVersion = "3";
            e.Namespace = Namespaces.ALEXA;
            e.Name = HeaderNames.CHANGE_REPORT;
            return e;
        }

        /// <summary>
        /// Creates a header for a DefferedResponses
        /// </summary>
        /// <returns></returns>
        public static EventHeader CreateDefferedResponseHeader()
        {
            EventHeader e = new EventHeader();
            e.MessageId = System.Guid.NewGuid().ToString();
            e.PayloadVersion = "3";
            e.Namespace = Namespaces.ALEXA;
            e.Name = HeaderNames.DEFFERED_RESPONSE;
            return e;
        }
        
        private string _GetNamespace(DirectiveHeader reqHeader)
        {
            string name_space = Namespaces.ALEXA;
            if(reqHeader.Namespace == Namespaces.ALEXA_DISCOVERY)
            {
                name_space = Namespaces.ALEXA_DISCOVERY;
            }else if(reqHeader.Namespace == Namespaces.ALEXA_CAMERASTREAMCONTROLLER)
            {
                name_space = Namespaces.ALEXA_CAMERASTREAMCONTROLLER;
            }else if(reqHeader.Namespace == Namespaces.ALEXA_SCENECONTROLLER)
            {
                name_space = Namespaces.ALEXA_SCENECONTROLLER;
            }else if(reqHeader.Namespace == Namespaces.ALEXA_AUTHORIZATION)
            {
                name_space = Namespaces.ALEXA_AUTHORIZATION;
            }
            return name_space;
        }

        private string _GetName(DirectiveHeader reqHeader)
        {
            string name = HeaderNames.RESPONSE;
            if(reqHeader.Namespace == Namespaces.ALEXA_SCENECONTROLLER)
            {
                if (reqHeader.Name == HeaderNames.ACTIVATE)
                {
                    name = HeaderNames.ACTIVATION_STARTED;
                }
                if (reqHeader.Name == HeaderNames.DEACTIVATE)
                {
                    name = HeaderNames.DEACTIVATION_STARTED;
                }
            }
            if(reqHeader.Name == HeaderNames.REPORT_STATE)
            {
                name = HeaderNames.STATE_REPORT;
            }
            if (reqHeader.Name == HeaderNames.DISCOVERY_REQUEST)
            {
                name = HeaderNames.DISCOVERY_RESPONSE;
            }
            if(reqHeader.Name == HeaderNames.ACCEPT_GRANT)
            {
                name = HeaderNames.ACCEPT_GRANT_RESPONSE;
            }
            return name;
        }

    }
}
