using System;

class Program
{
    static void Main(string[] args)
    {
        // Example scripture
        Reference reference = new Reference("Psalms", 27, 13);
        Scripture scripture = new Scripture(reference, "I remain confident of this: I will see the goodness of the Lord in the land of the living");

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.AllWordsHidden())
            {
                break;
            }

            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords();
        }

        Console.WriteLine("\nAll words are now hidden!!!");
    }
}
