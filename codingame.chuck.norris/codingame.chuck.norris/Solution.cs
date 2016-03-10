namespace codingame.chuck.norris
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Solution
    {
        static void Main(string[] args)
        {
            string MESSAGE = Console.ReadLine();

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Console.WriteLine(new ChuckNorrisBinaryConverter().Execute(MESSAGE));
        }
    }

    public class ChuckNorrisBinaryConverter
    {
        private static readonly StringToBinaryConverter StringToBinaryConverter = new StringToBinaryConverter();

        public string Execute(string message)
        {
            var arrayOfStrings = StringToBinaryConverter
                .Execute(message)
                .Select(c => c.ToString())
                .ToArray();

            var results = arrayOfStrings
                .Select((s, index) => new { Index = index, @Byte = s });

            var previousByte = results.First().Byte;
            var series = new List<Serie>();
            var count = 0;
            var serie = new Serie(previousByte);
            foreach (var item in results)
            {
                if (item.Byte != previousByte)
                {
                    series.Add(serie);
                    serie = new Serie(item.Byte);
                }

                serie.Increment();
                previousByte = item.Byte;

                if (item.Index == results.Count() - 1)
                {
                    series.Add(serie);
                }
            }

            return string.Join(" ", series);
        }

        private class Serie
        {
            private int _count;

            public Serie(string @byte)
            {
                @Byte = @byte;
            }

            public string @Byte { get; private set; }

            public void Increment()
            {
                _count++;
            }

            public override string ToString()
            {
                var result = "0 ";
                if (Byte == "1")
                {
                    result += "0";
                }
                else
                {
                    result += "00";
                }

                return result + " ".PadRight(_count, '0');
            }
        }
    }

    public class StringToBinaryConverter
    {
        public string Execute(string message)
        {
            var array = Encoding.ASCII
                .GetBytes(message)
                .Select(i => Convert.ToString(i, 2));

            return string.Join("", array);
        }
    }
}
