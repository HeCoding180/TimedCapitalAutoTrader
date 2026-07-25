using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TimedCapitalAutoTrader.CapitalAPI
{
    /// <summary>
    /// Class containing the API session details.
    /// </summary>
    internal class CapitalSession
    {
        //   ---   Private Properties (static)   ---

        /// <summary>
        /// Sets or gets the current <see cref="CapitalSession"/>.
        /// </summary>
        private static CapitalSession? currentSession { set; get; }

        //   ---   Public Properties   ---

        /// <summary>
        /// Gets the client session token (CST).
        /// </summary>
        public required string CstToken { init; get; }

        /// <summary>
        /// Gets the security token.
        /// </summary>
        public required string SecurityToken { init; get; }

        //   ---   Constructors   ---

        /// <summary>
        /// Creates a new instance of the <see cref="CapitalSession"/> class.
        /// </summary>
        public CapitalSession()
        {

        }

        //   ---   Public Methods (static)   ---

        /// <summary>
        /// Method used to create a new session.
        /// </summary>
        [MemberNotNull(nameof(currentSession))]
        public static void CreateSession()
        {
            CreateSessionAsync().Wait();
        }

        /// <summary>
        /// Method used to asynchronously create a new session.
        /// </summary>
        /// <returns>An awaitable task representing the opertaion.</returns>
        [MemberNotNull(nameof(currentSession))]
        public static async Task CreateSessionAsync()
        {
            // TODO: Implement session creation.
            throw new NotImplementedException("Session creation has not been implemented yet.");
        }

        /// <summary>
        /// Method used to get the current session.
        /// </summary>
        /// <returns>The <see cref="CapitalSession"/> instance with the current session details.</returns>
        public static async Task<CapitalSession> GetCurrentSessionAsync()
        {
            if (currentSession is null)
            {
                await CreateSessionAsync();
            }

            return currentSession;
        }

        /// <summary>
        /// Method used to get the current session.
        /// </summary>
        /// <returns>The <see cref="CapitalSession"/> instance with the current session details.</returns>
        public static CapitalSession GetCurrentSession()
        {
            Task<CapitalSession> task = GetCurrentSessionAsync();
            task.Wait();
            return task.Result;
        }
    }
}
