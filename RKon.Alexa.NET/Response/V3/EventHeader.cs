﻿using RKon.Alexa.NET.Request.V3;
using RKon.Alexa.NET.Types;

namespace RKon.Alexa.NET.Response.V3
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
        /// Standardconstructor
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
            e.Name = HeaderNames.V3.CHANGE_REPORT;
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
            }
            return name_space;
        }

        private string _GetName(DirectiveHeader reqHeader)
        {
            string name = HeaderNames.V3.RESPONSE;
            if(reqHeader.Name == HeaderNames.V3.REPORT_STATE)
            {
                name = HeaderNames.V3.STATE_REPORT;
            }
            if (reqHeader.Name == HeaderNames.V3.DISCOVERY_REQUEST)
            {
                name = HeaderNames.V3.DISCOVERY_RESPONSE;
            }
            return name;
        }

    }
}
