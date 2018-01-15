﻿
namespace RKon.Alexa.NET.Types
{
    /// <summary>
    /// Supported Types of Scopes
    /// </summary>
    public enum ScopeTypes
    {
        /// <summary>
        /// Provides an OAuth bearer token for accessing a linked customer account or identifying an Alexa customer.
        /// </summary>
        BearerToken,
        /// <summary>
        /// Provides an OAuth bearer token for accessing a linked customer account and the physical location where the discovery request should be applied
        /// </summary>
        BearerTokenWithPartition
    }
}
