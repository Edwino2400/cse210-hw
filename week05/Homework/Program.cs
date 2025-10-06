using System;

class Program
{
    static void Main(string[] args)
    {
       
        Assignment a1 = new Assignment("Edwin Chigara", "Divison");
        Console.WriteLine(a1.GetSummary());

       
        MathAssignment a2 = new MathAssignment("Peter Nyoni", "Fractions", "5.6", "1-10");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Sekai Chikosi", "African History", "Munhumutapa Empire");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}