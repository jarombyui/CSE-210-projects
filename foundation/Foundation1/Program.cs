using System;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // Length in seconds
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public void AddComment(string commenterName, string commentText)
    {
        Comments.Add(new Comment(commenterName, commentText));
    }
}

public class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Create and add videos with comments
        videos.Add(new Video("Video 1", "Channel A", 300));
        videos.Add(new Video("Interesting Talk", "Professor B", 1200));
        videos.Add(new Video("Funny Compilation", "Comedy Channel", 600));
        videos.Add(new Video("Music Video", "Musician X", 240));

        videos[0].AddComment("John Doe", "Great video!");
        videos[0].AddComment("Jane Smith", "I agree, very informative.");
        videos[0].AddComment("Alice Miller", "Looking forward to more content!");

        videos[1].AddComment("David Lee", "Excellent presentation!");
        videos[1].AddComment("Sarah Jones", "Learned a lot, thanks!");
        videos[1].AddComment("Michael Brown", "Would love to see a follow-up!");

        videos[2].AddComment("Brian Johnson", "Hilarious!");
        videos[2].AddComment("Emily Carter", "Can't stop laughing!");
        videos[2].AddComment("Charles Williams", "Shared it with my friends!");

        videos[3].AddComment("Olivia Garcia", "Beautiful song!");
        videos[3].AddComment("Noah Thompson", "Amazing vocals!");
        videos[3].AddComment("Sophia Hernandez", "Definitely on repeat!");

        // Display video information
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }

            Console.WriteLine();
        }
    }
}