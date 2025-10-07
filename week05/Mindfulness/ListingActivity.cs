using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace MindfulnessApp
{
    class ListingActivity : Activity
    {
        private readonly PromptPool _promptPool;

        public ListingActivity(string name, string description, PromptPool promptPool)
            : base(name, description)
        {
            _promptPool = promptPool;
        }

        protected override void PerformActivity(int durationSeconds)
        {
            string prompt = _promptPool.Next();
            Console.WriteLine($"\nPrompt:\n{prompt}\n");
            Console.WriteLine("You will have a few seconds to think, then start listing items. Press Enter after each item.");
            Console.Write("Prepare: ");
            Countdown(5);

            var items = new List<string>();
            var sw = Stopwatch.StartNew();

            Console.WriteLine("Start listing (press Enter after each). Time starts now!");
            while (sw.Elapsed.TotalSeconds < durationSeconds)
            {
                if (Console.KeyAvailable)
                {
                    var line = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(line)) items.Add(line);
                }
                else
                {
                    Thread.Sleep(100);
                }
            }

            Console.WriteLine($"\nYou listed {items.Count} items.\n");
        }
    }
}
