using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeCorners.CLI
{
    class Program
    {
        public static readonly Dictionary<Argument, string> ArgumentMap = new Dictionary<Argument, string>();
        private static readonly List<Argument> LeagalArguments = new List<Argument>() { Arguments.URL, Arguments.NAME };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                PrintHelpList();
                return;
            }

            try
            {
                ParseProgramArguments(args);
                var filename    = ArgumentMap.ContainsKey(Arguments.NAME)   ? ArgumentMap[Arguments.NAME] : null;
                var url         = ArgumentMap.ContainsKey(Arguments.URL)    ? ArgumentMap[Arguments.URL]  : null;
                
                ChromeCorners.Instance.Configure(new Configuration {
                    Filename = filename,
                    Url      = url
                }).Create();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"argument format -> 'key=value'");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        static void PrintHelpList()
        {
            Console.WriteLine();
            Console.WriteLine("Argument format: ");
            Console.WriteLine("\t<targumentName>=<value>");
            Console.WriteLine();

            Console.WriteLine("Arguments: ");
            foreach (var argument in LeagalArguments)
                Console.WriteLine(argument);
            
            Console.WriteLine();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void ParseProgramArguments(string[] args)
        {
            foreach (var arg in args)
            {
                foreach (var argument in LeagalArguments)
                {
                    if (arg.ToLower().StartsWith(argument.ArgumentKey.ToLower()))
                    {
                        var argValue = arg.Split('=')[1];
                        ArgumentMap.Add(argument, argValue);   
                    }
                }
            }
        }
    }
}