using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

public class Student
{
    public string fullName;
    protected DateTime doB;
    protected string sex;
    protected string phoneNumber;
    protected string universityName;
    protected string gradeLevel;

    public virtual void ShowMyInfor()
    {
        Console.WriteLine("Full name: " + fullName);
        Console.WriteLine("Date of birth: " + doB.ToShortDateString());
        Console.WriteLine("Sex: " + sex);
        Console.WriteLine("Phone number: " + phoneNumber);
        Console.WriteLine("University name: " + universityName);
        Console.WriteLine("Grade level: " + gradeLevel);
    }
}

public class GoodStudent : Student
{
    //private readonly float gpa;
    //private readonly string bestRewardName;
    public float Gpa { get; set; }
    public string BestRewardName { get; set; }

    public override void ShowMyInfor()
    {
        base.ShowMyInfor();
        Console.WriteLine("GPA: " + Gpa);
        Console.WriteLine("Best reward name: " + BestRewardName);
    }
}

public class NormalStudent : Student
{
    //private readonly int englishScore;
    //private readonly double entryTestScore;

    public int EnglishScore { get; set; }
    public float EntryTestScore { get; set; }

    public override void ShowMyInfor()
    {
        base.ShowMyInfor();
        Console.WriteLine("English score: " + EnglishScore);
        Console.WriteLine("Entry test score: " + EntryTestScore);
    }
}

public class CheckVality
{
    public bool IsValidFullName(string fullName)
    {
        if (fullName.Length < 10 || fullName.Length > 50)
        {
            throw new InvalidFullNameException("Invalid Name");
        }
        return true;
    }

    public bool IsValidDOB(string doB)
    {
        DateTime dob;
        try
        {
            dob = DateTime.ParseExact(doB, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return true;
        }
        catch (FormatException)
        {
            throw new InvalidDOBException(
                "Invalid date format for DOB. Please enter date in format dd/MM/yyyy."
            );
        }
    }

    public bool IsValidPhoneNumber(string phoneNumber)
    {
        Regex regex = new Regex(@"^(090|098|091|031|035|038)\d{7}$");
        if (!regex.IsMatch(phoneNumber))
        {
            throw new InvalidPhoneNumberException(
                "Invalid phone number. Please enter a 10-digit phone number starting with 090, 098, 091, 031, 035, or 038."
            );
        }
        return true;
    }
}

class Candidate
{
    private readonly List<Student> dsStudents;

    public Candidate()
    {
        dsStudents = new List<Student>();
    }

    public void ChooseCandidates(int numCandidates)
    {
        if (numCandidates < 11 || numCandidates > 15)
        {
            Console.WriteLine("Number of candidates must be between 11 and 15.");
            return;
        }

        var goodStudents = dsStudents
            .OfType<GoodStudent>()
            .OrderByDescending(s => s.Gpa)
            .ThenBy(s => s.fullName);
        var normalStudents = dsStudents
            .OfType<NormalStudent>()
            .OrderByDescending(s => s.EntryTestScore)
            .ThenBy(s => s.EnglishScore);

        var chosenStudents = new List<Student>();

        foreach (var student in goodStudents)
        {
            if (chosenStudents.Count >= numCandidates)
            {
                break;
            }

            chosenStudents.Add(student);
        }

        foreach (var student in normalStudents)
        {
            if (chosenStudents.Count >= numCandidates)
            {
                break;
            }

            chosenStudents.Add(student);
        }

        Console.WriteLine($"Chosen candidates ({chosenStudents.Count}/{numCandidates}):");

        foreach (var student in chosenStudents)
        {
            Console.WriteLine(student.fullName);
        }
    }
}

public class InvalidFullNameException : Exception
{
    public InvalidFullNameException(string message)
        : base(message) { }
}

public class InvalidDOBException : Exception
{
    public InvalidDOBException(string message)
        : base(message) { }
}

public class InvalidPhoneNumberException : Exception
{
    public InvalidPhoneNumberException(string message)
        : base(message) { }
}
