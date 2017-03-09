using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeCorners
{
    class Program
    {
        public static readonly Dictionary<Argument, string> ArgumentMap = new Dictionary<Argument, string>();
        
        private static readonly List<Argument> LeagalArguments = new List<Argument>() {
            Arguments.URL,
            Arguments.NAME
        };

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

                var filename        = ArgumentMap.ContainsKey(Arguments.NAME)  ? ArgumentMap[Arguments.NAME]   : null;
                var url             = ArgumentMap.ContainsKey(Arguments.URL)   ? ArgumentMap[Arguments.URL]    : null;
                var createdFile     = ScriptWriter.WriteScript(filename, url);
                var shortCutPath    = Path.GetFullPath(createdFile);
                var desktop         = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

                ShortCutWriter.CreateShortcut(Path.GetFileNameWithoutExtension(createdFile), desktop, shortCutPath);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"argument format -> 'key=value'");
            }
        }

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