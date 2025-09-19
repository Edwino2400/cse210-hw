using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        
        int enteredNumber = -1;
        while (enteredNumber != 0)
        {
            Console.Write("Enter a number or enter 0 to quit: ");
            
            string userResponse = Console.ReadLine();
            enteredNumber = int.Parse(userResponse);
            
            // Number not zero entered
            if (enteredNumber != 0)
            {
                numbers.Add(enteredNumber);
            }
        }

        // Part 1: Calculate sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        // Part 2: Calculate the average
        
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Part 3: Find the Maximum
       
        
        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }
}