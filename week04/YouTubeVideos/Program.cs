using System;
using System.Collections.Generic;

// Class comment
class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

// video
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> Comments { get; set; } = new List<Comment>();

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public void DisplayComments()
    {
        foreach (var comment in Comments)
        {
            Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
        }
    }
}

class Program
{
    static void Main()
    {
        // Dynamic list of videos
        List<Video> videos = new List<Video>
        {
            new Video("C# Basics", "Peter", 600),
            new Video("Object-Oriented Programming", "Ben", 900),
            new Video("Advanced C#", "Catherine", 1200)
        };

        // comments for each video
        Dictionary<string, List<Comment>> videoComments = new Dictionary<string, List<Comment>>
        {
            { "C# Basics", new List<Comment> {
                new Comment("Taurai", "Great tutorial!"),
                new Comment("Sean", "Very helpful, thanks!"),
                new Comment("Andrew", "I loved the examples.")
            }},
            { "Object-Oriented Programming", new List<Comment> {
                new Comment("Nutty", "OOP finally makes sense!"),
                new Comment("Jake", "Can you make a part 2?"),
                new Comment("Paul", "Excellent explanation.")
            }},
            { "Advanced C#", new List<Comment> {
                new Comment("Mike", "This was challenging but rewarding."),
                new Comment("Tyson", "Thanks for the deep dive."),
                new Comment("Loyd", "I learned a lot from this video.")
            }}
        };

        // Add comments to videos
        foreach (var video in videos)
        {
            if (videoComments.ContainsKey(video.Title))
            {
                foreach (var comment in videoComments[video.Title])
                {
                    video.AddComment(comment);
                }
            }
        }

        // Display videos 
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            video.DisplayComments();
            Console.WriteLine(new string('-', 50));
        }
    }
}
