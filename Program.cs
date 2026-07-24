using Microsoft.Extensions.Logging;
using System;

namespace TimedCapitalAutoTrader
{
    internal class Program
    {
        //   ---   Internal Fields (static)   ---

        /// <summary>
        /// Static field containing the <see cref="ILoggerFactory"/> that is used to create <see cref="ILogger"/> instances for this application.
        /// </summary>
        internal static ILoggerFactory ApplicationLoggerFactory = LoggerFactory.Create(builder =>{
            builder.AddSimpleConsole(options =>
            {
                options.IncludeScopes = true;
                options.SingleLine = true;              // Prints everything on 1 line per log
                options.TimestampFormat = "HH:mm:ss ";  // Adds timestamps
            });
        });

        /// <summary>
        /// Static field containing whether trades should be executed in the live trading environment.
        /// </summary>
        internal static bool UseLiveTradingEnvironment = false;

        //   ---   Application Entry Point   ---

        /// <summary>
        /// Application entry point.
        /// </summary>
        /// <param name="args">Console parametersycm</param>
        static void Main(string[] args)
        {
            try
            {
                for (int i = 1; i < args.Length; i++)
                {
                    ProcessArgument(args, i, out int skipArgs);
                    i += skipArgs;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Invalid argument provided: " + ex.Message);
            }
        }

        //   ---   Internal Methods (static)   ---

        /// <summary>
        /// Method used to process 
        /// </summary>
        /// <param name="args">List containing all arguments.</param>
        /// <param name="index">Index of the argument that is to be processed.</param>
        /// <param name="skipArgs">Out parameter that specifies how many additional arguments were processed.</param>
        internal static void ProcessArgument(string[] args, int index, out int skipArgs)
        {
            string arg = args[index];

            skipArgs = 0;

            switch (arg.ToLower().Trim())
            {
                case "/e":
                case "/env":
                    // Environment argument
                    skipArgs = 1;

                    string envString = args[index + 1].ToLower().Trim();
                    
                    if (envString == "demo")
                    {
                        // Demo environment
                        UseLiveTradingEnvironment = false;
                    }
                    else if (envString == "live")
                    {
                        // Live environment
                        UseLiveTradingEnvironment = true;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid environment argument: " + envString);
                    }

                    break;
                case "/?":
                case "/h":
                case "/help":
                    Console.WriteLine("---   Timed Capital Auto Trader Help  ---");
                    Console.WriteLine();
                    Console.WriteLine("TimedCapitalAutoTrader");
                    Console.WriteLine();
                    Console.WriteLine("/e:env\t\tSets the evironment in which trades should be run. Default is demo:");
                    Console.WriteLine("\t\t  demo: Trades are executed in the demo environment (https://demo-api-capital.backend-capital.com/)");
                    Console.WriteLine("\t\t  live: Trades are executed in the live environment (https://api-capital.backend-capital.com/)");
                    Console.WriteLine("/?:h:help\tDisplays this help page.");
                    break;
            }
        }
    }
}