using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("YouTube Videos Program");
        Console.WriteLine("=====================");

        VideoLibrary library = new VideoLibrary();

        Video video1 = new Video("The Power of Habit", "Sherelton Dennis", 360);
        video1.AddComment(new Comment("Milton", "This was a very clear explanation."));
        video1.AddComment(new Comment("Luah", "I want to watch this again."));
        video1.AddComment(new Comment("Diana", "The examples were easy to remember."));

        Video video2 = new Video("Atomic Habits", "Luah Dennis", 420);
        video2.AddComment(new Comment("Ava", "The examples helped me stay focused."));
        video2.AddComment(new Comment("Noah", "This gave me a better system for change."));
        video2.AddComment(new Comment("Emma", "Really helpful and practical."));

        Video video3 = new Video("How to Learn Faster", "Jacob Dennis", 315);
        video3.AddComment(new Comment("Manbah", "Great pacing and practical advice."));
        video3.AddComment(new Comment("Zoe", "I liked the examples and timing."));
        video3.AddComment(new Comment("Ethan", "This made the strategies easy to understand."));

        library.AddVideo(video1);
        library.AddVideo(video2);
        library.AddVideo(video3);

        library.DisplayVideos();
    }
}
