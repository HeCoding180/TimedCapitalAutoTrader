using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using TimedCapitalAutoTrader.CapitalAPI.Models.WebSocket.Base;

namespace TimedCapitalAutoTrader.CapitalAPI.Models.WebSocket
{
    internal record class CapitalWebSocketMarketDataSubscribeRequestMessage : CapitalWebSocketRequestMessageBase
    {
        //   ---   Public Properties   ---

        /// <summary>
        /// Identifier of the request that needs to be carried out.
        /// </summary>
        [JsonIgnore]
        public override int CorrelationID => 1;

        //   ---   Constructors   ---

        /// <summary>
        /// Creates a new instance of the <see cref="CapitalWebSocketMarketDataSubscribeRequestMessage"/> class.
        /// </summary>
        /// <param name="session"><see cref="CapitalSession"/> instance containing the session details for the request.</param>
        protected CapitalWebSocketMarketDataSubscribeRequestMessage(CapitalSession session, IEnumerable<>) : base(session)
        {

        }

        //   ---   Public Methods (static)   ---

        public static CapitalWebSocketMarketDataSubscribeRequestMessage Create(IEnumerable<string> instrumentEpics)
        {
            Task<CapitalWebSocketMarketDataSubscribeRequestMessage> creationTask = CreateAsync(instrumentEpics);
            creationTask.Wait();
            return creationTask.Result;
        }

        /// <summary>
        /// Method used to create a new instance of the <see cref="CapitalWebSocketMarketDataSubscribeRequestMessage"/> class.
        /// </summary>
        /// <returns>An awaitable <see cref="Task"/> resulting in a new <see cref="CapitalWebSocketMarketDataSubscribeRequestMessage"/> instance.</returns>
        public static async Task<CapitalWebSocketMarketDataSubscribeRequestMessage> CreateAsync(IEnumerable<string> instrumentEpics)
        {
            CapitalSession session = await CapitalSession.GetCurrentSessionAsync();

            return new CapitalWebSocketMarketDataSubscribeRequestMessage(session);
        }
    }
}
