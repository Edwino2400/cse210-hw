using System;
using System.Collections.Generic;




public class Job
{
    public string _jobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Teacher";
        job1._company = "St Patrick's School";
        job1._startYear = 2011;
        job1._endYear = 2013;

        Job job2 = new Job();
        job2._jobTitle = "Miner";
        job2._company = "Anglo American";
        job2._startYear = 2016;
        job2._endYear = 2024;

        Resume myResume = new Resume();
        myResume._name = "John Doe";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}