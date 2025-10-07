using System;
using System.Diagnostics;

namespace MindfulnessApp
{
    class ReflectionActivity : Activity
    {
        private readonly PromptPool _promptPool;
        private readonly PromptPool _questionPool;

        public ReflectionActivity(string name, string description, PromptPool promptPool, PromptPool questionPool)
            : base(name, description)
        {
            _promptPool = promptPool;
            _questionPool = questionPool;
        }

        protected override void PerformActivity(int durationSeconds)
        {
            var sw = Stopwatch.StartNew();

            string prompt = _promptPool.Next();
            Console.WriteLine($"\nPrompt:\n{prompt}\n");
            Console.WriteLine("When you're ready, reflect on the following questions:");
            ShowSpinner(2);

            while (sw.Elapsed.TotalSeconds < durationSeconds)
            {
                string question = _questionPool.Next();
                Console.WriteLine($"\n{question}");
                ShowSpinner(5);
            }

            sw.Stop();
        }
    }
}
