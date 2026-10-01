using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("YouTube Videos Program");
        Console.WriteLine("=====================");

        VideoLibrary library = new VideoLibrary();

        Video video1 = new Video("The Power of Habit", "Sherelton Dennis", 360, 350000);
        video1.AddComment("Milton", "This was a very clear explanation.");
        video1.AddComment("Luah", "I want to watch this again.");

        Video video2 = new Video("Atomic Habits", "Luah Dennis", 420, 1800000);
        video2.AddComment("Diana", "The examples made the ideas easy to remember.");

        Video video3 = new Video("How to Learn Faster", "Jacob Dennis", 315, 950000);
        video3.AddComment("Manbah", "Great pacing and practical advice.");

        library.AddVideo(video1);
        library.AddVideo(video2);
        library.AddVideo(video3);

        library.DisplayVideos();
    }
}

class VideoLibrary
{
    private List<Video> videos;

    public VideoLibrary()
    {
        videos = new List<Video>();
    }

    public void AddVideo(Video video)
    {
        videos.Add(video);
    }

    public List<Video> GetVideos()
    {
        return videos;
    }

    public void DisplayVideos()
    {
        foreach (Video video in videos)
        {
            video.Display();
            Console.WriteLine();
        }
    }
}

class Video
{
    private string title;
    private string author;
    private int lengthSeconds;
    private int views;
    private List<Comment> comments;

    public Video(string title, string author, int lengthSeconds, int views)
    {
        this.title = title;
        this.author = author;
        this.lengthSeconds = lengthSeconds;
        this.views = views;
        this.comments = new List<Comment>();
    }

    public string Title
    {
        get { return title; }
    }

    public string Author
    {
        get { return author; }
    }

    public int LengthSeconds
    {
        get { return lengthSeconds; }
    }

    public int Views
    {
        get { return views; }
    }

    public void AddComment(string commenter, string text)
    {
        comments.Add(new Comment(commenter, text));
    }

    public void Display()
    {
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Author: {author}");
        Console.WriteLine($"Length: {lengthSeconds} seconds");
        Console.WriteLine($"Views: {views}");
        Console.WriteLine("Comments:");

        if (comments.Count == 0)
        {
            Console.WriteLine("  No comments yet.");
        }
        else
        {
            foreach (Comment comment in comments)
            {
                comment.Display();
            }
        }
    }
}

class Comment
{
    private string commenter;
    private string text;

    public Comment(string commenter, string text)
    {
        this.commenter = commenter;
        this.text = text;
    }

    public void Display()
    {
        Console.WriteLine($"  - {commenter}: {text}");
    }
}
