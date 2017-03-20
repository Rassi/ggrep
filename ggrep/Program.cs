using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ggrep
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!args.Any())
            {
                Console.WriteLine("Usage:");
                Console.WriteLine("ggrep PATTERN [FILE]");
                Environment.Exit(1);
            }

            var fileName = (args.Count() > 1) ? args[1] : null;
            var pattern = args[0];

            string input = null;

            if (fileName != null)
            {
                input = File.ReadAllText(fileName);
            }
            else
            {
                // read stdin
                string line;
                while ((line = Console.ReadLine()) != null)
                {
                    input += line + "\n";
                }
            }

            //Console.WriteLine(string.Format("input: {0}", input));
            var matches = Regex.Matches(input, pattern, RegexOptions.Multiline);
            foreach (Match match in matches)
            {
                Console.WriteLine(string.Join(" ", match.Groups.OfType<Group>().Skip(1)));
            }

        }
    }
}
