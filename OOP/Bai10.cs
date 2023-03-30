using System;
using System.Linq;

class VanBan
{
    public string Content { get; set; }

    // Constructor
    public VanBan()
    {
        Content = "";
    }

    public VanBan(string st)
    {
        Content = st;
    }

    // Count number of words in the text
    public int CountWords()
    {
        return Content.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    // Count number of characters 'A' in the text (case-insensitive)
    public int CountAs()
    {
        return Content.ToLower().Count(c => c == 'a');
    }

    // Normalize the text
    public void Normalize()
    {
        Content = Content.Trim(); // Remove leading and trailing whitespaces
        Content = string.Join(
            " ",
            Content.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        ); // Remove multiple consecutive whitespaces
    }
}

class Program
{
    static void Main(string[] args)
    {
        VanBan vb = new VanBan("This is a sample text with   multiple     spaces.");
        Console.WriteLine("Number of words: " + vb.CountWords());
        Console.WriteLine("Number of 'A's: " + vb.CountAs());
        vb.Normalize();
        Console.WriteLine("Normalized text: " + vb.Content);

        Console.ReadLine();
    }
}
