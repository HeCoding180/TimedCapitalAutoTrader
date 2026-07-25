using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;

namespace TimedCapitalAutoTrader.CapitalAPI.Models.WebSocket.Base
{
    /// <summary>
    /// Base class for WebSocket request messages of the capital.com api.
    /// </summary>
    [JsonDerivedType(typeof(CapitalWebSocketMarketDataSubscribeRequestMessage), "marketData.subscribe")]
    internal abstract record class CapitalWebSocketRequestMessageBase : CapitalWebSocketMessageBase
    {
        //   ---   Public Properties   ---

        /// <summary>
        /// Identifier of the request that needs to be carried out.
        /// </summary>
        [JsonIgnore]
        public abstract int CorrelationID { get; }

        /// <summary>
        /// Property mapping to the <see cref="CorrelationID"/>. Used for serialization.
        /// </summary>
        [Browsable(false)]
        [JsonPropertyName("correlationId")]
        public string CorrelationIDStr => CorrelationID.ToString();

        /// <summary>
        /// Gets the Client Session Token (CST).
        /// </summary>
        [JsonPropertyName("cst")]
        public string CstToken { get; }

        /// <summary>
        /// Gets the security token.
        /// </summary>
        [JsonPropertyName("securityToken")]
        public string SecurityToken { get; }

        /// <summary>
        /// Gets the payload of the request.
        /// </summary>
        [JsonPropertyName("payload")]
        public Dictionary<string, object> Payload { get; }

        //   ---   Constructors   ---

        /// <summary>
        /// Creates a new instance of the <see cref="CapitalWebSocketRequestMessageBase"/> class.
        /// </summary>
        /// <param name="session"><see cref="CapitalSession"/> instance containing the session details for the request.</param>
        protected CapitalWebSocketRequestMessageBase(CapitalSession session)
        {
            CstToken = session.CstToken;
            SecurityToken = session.SecurityToken;

            Payload = new Dictionary<string, object>();
        }
    }
}
