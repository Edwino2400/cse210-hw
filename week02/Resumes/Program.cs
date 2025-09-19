using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Miner";
        job1._company = "Unki Mine";
        job1._startYear = 2001;
        job1._endYear = 2015;

        Job job2 = new Job();
        job2._jobTitle = "Teacher";
        job2._company = "Bata";
        job2._startYear = 2016;
        job2._endYear = 2025;

        Resume myResume = new Resume();
        myResume._name = "Sean Timber";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}