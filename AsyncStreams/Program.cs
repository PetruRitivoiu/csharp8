using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AsyncStreams
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Async Streams");

            await foreach (var current in GetData())
            {
                Console.WriteLine(current);
            }

            #region Lyrics
            //await foreach (var current in GetLyrics())
            //{
            //    Console.WriteLine(current);
            //}
            #endregion
        }

        #region Data
        public static async IAsyncEnumerable<int> GetData()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return await Task.Delay(500).ContinueWith((_) => i);
            }
        }

        public static async IAsyncEnumerable<string> GetLyrics()
        {
            using var sr = new StreamReader("Lyrics.txt");
            string line = string.Empty;

            while ((line = sr.ReadLine()) != null)
            {
                yield return await Task.Delay(1000).ContinueWith((_) => line);
            }
        }
        #endregion
    }

}
