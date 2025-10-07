using System;
using System.Diagnostics;
using System.Threading;

namespace MindfulnessApp
{
    class BreathingActivity : Activity
    {
        private readonly int _inhaleSeconds;
        private readonly int _exhaleSeconds;

        public BreathingActivity(string name, string description, int promptInhaleSeconds = 4, int promptExhaleSeconds = 6)
            : base(name, description)
        {
            _inhaleSeconds = promptInhaleSeconds;
            _exhaleSeconds = promptExhaleSeconds;
        }

        protected override void PerformActivity(int durationSeconds)
        {
            var sw = Stopwatch.StartNew();
            bool inhale = true;
            while (sw.Elapsed.TotalSeconds < durationSeconds)
            {
                if (inhale)
                {
                    Console.WriteLine("Breathe in...");
                    PulsingCountdown(_inhaleSeconds);
                }
                else
                {
                    Console.WriteLine("Breathe out...");
                    PulsingCountdown(_exhaleSeconds);
                }
                inhale = !inhale;
            }
            sw.Stop();
        }

        private void PulsingCountdown(int seconds)
        {
            for (int s = seconds; s >= 1; s--)
            {
                int len = (seconds - s) + 1;
                Console.Write(new string('●', len));
                Thread.Sleep(800);
                Console.Write(new string('\b', len));
                Console.Write(new string(' ', len));
                Console.Write(new string('\b', len));
            }
            Console.WriteLine();
        }
    }
}
