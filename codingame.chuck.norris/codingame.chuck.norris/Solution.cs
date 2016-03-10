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
        private readonly StringToBinaryConverter StringToBinaryConverter = new StringToBinaryConverter();

        public string Execute(string message)
        {
            var bytesAsStrings = StringToBinaryConverter
                .Execute(message)
                .Select(c => c.ToString())
                .ToArray();

            var previousByte = bytesAsStrings.First();
            var series = new List<Serie>();
            var serie = new Serie(previousByte);
            for (var index = 0; index < bytesAsStrings.Length; index++)
            {
                var @byte = bytesAsStrings[index];
                if (@byte != previousByte)
                {
                    series.Add(serie);
                    serie = new Serie(@byte);
                }

                serie.Increment();
                previousByte = @byte;

                if (index == bytesAsStrings.Length - 1)
                {
                    series.Add(serie);
                }
            }

            return string.Join(" ", series);
        }
    }

    public class Serie
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
            var result = "0";
            if (Byte == "0")
            {
                result += "0";
            }

            return result + " ".PadRight(_count + 1, '0');
        }
    }

    public class StringToBinaryConverter
    {
        public string Execute(string message)
        {
            var array = Encoding.ASCII
                .GetBytes(message)
                .Select(i => Convert.ToString(i, 2));

            return string.Join(string.Empty, array);
        }
    }
}
