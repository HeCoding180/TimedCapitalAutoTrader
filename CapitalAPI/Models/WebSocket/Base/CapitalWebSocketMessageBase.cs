using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TimedCapitalAutoTrader.CapitalAPI.Models.WebSocket.Base
{
    /// <summary>
    /// Class for capital.com request messages.
    /// </summary>
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "destination")]
    internal abstract record class CapitalWebSocketMessageBase
    {
        
    }
}
