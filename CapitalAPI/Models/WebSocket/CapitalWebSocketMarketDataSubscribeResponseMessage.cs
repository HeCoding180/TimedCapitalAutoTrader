using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using TimedCapitalAutoTrader.CapitalAPI.Models.WebSocket.Base;

namespace TimedCapitalAutoTrader.CapitalAPI.Models.WebSocket
{
    internal record class CapitalWebSocketMarketDataSubscribeResponseMessage : CapitalWebSocketResponseMessageBase
    {
        //   ---   Public Properties   ---

        /// <summary>
        /// Identifier of the request that needs to be carried out.
        /// </summary>
        [JsonIgnore]
        public override int CorrelationID => 1;
    }
}
