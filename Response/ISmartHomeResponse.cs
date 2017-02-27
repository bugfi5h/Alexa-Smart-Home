using RKon.Alexa.NET.Response.Payloads;


namespace RKon.Alexa.NET.Response
{
    public interface ISmartHomeResponse
    {
        ResponseHeader Header { get; set; }
        ResponsePayload Payload { get; set; }
        System.Type GetResponsePayloadType();
    }
}
