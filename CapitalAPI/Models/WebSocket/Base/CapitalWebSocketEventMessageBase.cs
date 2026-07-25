using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;

namespace TimedCapitalAutoTrader.CapitalAPI.Models.WebSocket.Base
{
    /// <summary>
    /// Base class for WebSocket event response messages of the capital.com api.
    /// </summary>
    [JsonDerivedType(typeof(), "")]
    internal abstract record class CapitalWebSocketEventMessageBase : CapitalWebSocketMessageBase
    {
        //   ---   Public Properties   ---

        
    }
}
