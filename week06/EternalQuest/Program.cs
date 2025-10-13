using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int totalScore = 0;
    const string filename = "goals.txt";

    static void Main(string[] args)
    {
        LoadGoals();
        bool running = true;

        while (running)
        {
            Console.WriteLine($"\nTotal Score: {totalScore}");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Show Goals");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoalMenu(); break;
                case "2": RecordEventMenu(); break;
                case "3": ShowGoals(); break;
                case "4": SaveGoals(); break;
                case "5": running = false; break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    static void CreateGoalMenu()
    {
        Console.WriteLine("Choose Goal Type: 1. Simple 2. Eternal 3. Checklist");
        string type = Console.ReadLine();
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                goals.Add(new SimpleGoal(name, points));
                break;
            case "2":
                goals.Add(new EternalGoal(name, points));
                break;
            case "3":
                Console.Write("Enter required completions: ");
                int required = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, points, required, bonus));
                break;
            default:
                Console.WriteLine("Invalid type.");
                break;
        }
    }

    static void RecordEventMenu()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
        }
        Console.Write("Select a goal to record: ");
        int choice = int.Parse(Console.ReadLine()) - 1;
        if (choice >= 0 && choice < goals.Count)
        {
            int earned = goals[choice].RecordEvent();
            totalScore += earned;
            Console.WriteLine($"You earned {earned} points!");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    static void ShowGoals()
    {
        Console.WriteLine("\nGoals:");
        foreach (Goal g in goals)
        {
            Console.WriteLine(g.GetDetailsString());
        }
    }

    static void SaveGoals()
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(totalScore);
            foreach (Goal g in goals)
            {
                outputFile.WriteLine(g.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    static void LoadGoals()
    {
        if (!File.Exists(filename)) return;

        string[] lines = File.ReadAllLines(filename);
        if (lines.Length == 0) return;

        totalScore = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] split = line.Split(":");
            string type = split[0];
            string data = split[1];

            switch (type)
            {
                case "SimpleGoal":
                    goals.Add(SimpleGoal.CreateFromString(data));
                    break;
                case "EternalGoal":
                    goals.Add(EternalGoal.CreateFromString(data));
                    break;
                case "ChecklistGoal":
                    goals.Add(ChecklistGoal.CreateFromString(data));
                    break;
            }
        }
    }
}
