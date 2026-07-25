using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;

namespace TimedCapitalAutoTrader.CapitalAPI.Models.WebSocket.Base
{
    /// <summary>
    /// Base class for WebSocket response messages of the capital.com api.
    /// </summary>
    [JsonDerivedType(typeof(CapitalWebSocketMarketDataSubscribeResponseMessage), "marketData.subscribe")]
    internal abstract record class CapitalWebSocketResponseMessageBase : CapitalWebSocketMessageBase
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
    }
}
