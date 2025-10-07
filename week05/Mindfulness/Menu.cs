using System;

namespace MindfulnessApp
{
    class Menu
    {
        private readonly PromptPool _reflectionPrompts;
        private readonly PromptPool _reflectionQuestions;
        private readonly PromptPool _listingPrompts;

        public Menu()
        {
            _reflectionPrompts = new PromptPool(new[] {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            });

            _reflectionQuestions = new PromptPool(new[] {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            });

            _listingPrompts = new PromptPool(new[] {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            });
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Activities");
                Console.WriteLine("====================\n");
                Console.WriteLine("1) Breathing Activity");
                Console.WriteLine("2) Reflection Activity");
                Console.WriteLine("3) Listing Activity");
                Console.WriteLine("4) Quit\n");
                Console.Write("Choose an activity (1-4): ");
                var key = Console.ReadKey(true).KeyChar;

                if (key == '4' || key == 'q' || key == 'Q')
                {
                    Console.WriteLine("\nGoodbye!");
                    System.Threading.Thread.Sleep(800);
                    break;
                }

                Activity activity = null;

                switch (key)
                {
                    case '1':
                        activity = new BreathingActivity(
                            "Breathing Activity",
                            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.",
                            promptInhaleSeconds: 4, promptExhaleSeconds: 6);
                        break;

                    case '2':
                        activity = new ReflectionActivity(
                            "Reflection Activity",
                            "This activity will help you reflect on times in your life when you have shown strength and resilience.",
                            _reflectionPrompts, _reflectionQuestions);
                        break;

                    case '3':
                        activity = new ListingActivity(
                            "Listing Activity",
                            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
                            _listingPrompts);
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice. Press any key to continue.");
                        Console.ReadKey(true);
                        continue;
                }

                activity.Run();
            }
        }
    }
}
