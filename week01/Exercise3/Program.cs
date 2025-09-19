using System;

class Program
{
    static void Main(string[] args)
    {
        // Parts 1 and 2 user entered number
        Console.Write("What is the generated number?");
        int generatedNumber = int.Parse(Console.ReadLine());
        
        // Part 3 random number
        //Random randomGenerator = new Random();
        //int generatedNumber = randomGenerator.Next(1, 101);

        int guess = 9;

        
        while (guess != generatedNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (generatedNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (generatedNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("Congratulations the answer was correct!");
            }

        }                    
    }
}