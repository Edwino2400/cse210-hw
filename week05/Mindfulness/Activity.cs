using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace MindfulnessApp
{
    abstract class Activity
    {
        private readonly string _name;
        private readonly string _description;
        private int _durationSeconds;

        protected Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public void Run()
        {
            Console.Clear();
            StartMessage();
            _durationSeconds = PromptDuration();
            PrepareToBegin();
            PerformActivity(_durationSeconds);
            EndMessage(_durationSeconds);
            LogCompletion(_durationSeconds);
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(true);
        }

        protected abstract void PerformActivity(int durationSeconds);

        private void StartMessage()
        {
            Console.WriteLine($"--- {_name} ---\n");
            Console.WriteLine(_description + "\n");
        }

        private int PromptDuration()
        {
            int duration = 0;
            while (duration <= 0)
            {
                Console.Write("Enter the duration of the activity in seconds: ");
                var input = Console.ReadLine();
                if (!int.TryParse(input, out duration) || duration <= 0)
                {
                    Console.WriteLine("Please enter a positive integer number of seconds.");
                    duration = 0;
                }
            }
            return duration;
        }

        private void PrepareToBegin()
        {
            Console.WriteLine("\nGet ready...\n");
            ShowSpinner(3);
        }

        private void EndMessage(int durationSeconds)
        {
            Console.WriteLine("\nWell done!\n");
            Console.WriteLine($"You have completed the {_name} for {durationSeconds} seconds.");
            ShowSpinner(3);
        }

        protected void ShowSpinner(int seconds)
        {
            var sw = Stopwatch.StartNew();
            var spinner = new[] { "|", "/", "-", "\\" };
            int idx = 0;
            while (sw.Elapsed.TotalSeconds < seconds)
            {
                Console.Write(spinner[idx]);
                Thread.Sleep(250);
                Console.Write('\b');
                idx = (idx + 1) % spinner.Length;
            }
            Console.WriteLine();
        }

        protected void Countdown(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write('\b');
            }
            Console.WriteLine();
        }

        private void LogCompletion(int duration)
        {
            try
            {
                File.AppendAllLines("activity_log.txt", new[] { $"{DateTime.UtcNow:o} | {_name} | {duration}s" });
            }
            catch { }
        }
    }
}
