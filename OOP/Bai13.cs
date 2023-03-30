using System.Collections.Generic;
using System;
using System.Security.Policy;
using System.Text.RegularExpressions;

public abstract class Employee
{
    public string ID { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDay { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public int Employee_type { get; set; }
    public int Employee_count { get; set; }
    public List<Certificate> Certificates { get; set; }

    public Employee(
        string id,
        string fullName,
        DateTime birthDay,
        string phone,
        string email,
        int employee_type,
        int employee_count
    )
    {
        this.ID = id;
        this.FullName = fullName;
        this.BirthDay = birthDay;
        this.Phone = phone;
        this.Email = email;
        this.Employee_type = employee_type;
        this.Employee_count = employee_count;
        this.Certificates = new List<Certificate> { new Certificate() };
    }

    public void AddCertificate(Certificate certificate)
    {
        Certificates.Add(certificate);
    }

    public void RemoveCertificate(Certificate certificate)
    {
        Certificates.Remove(certificate);
    }

    public abstract void ShowInfo();
}

public class Certificate
{
    public string CertificatedID { get; set; }
    public string CertificatedName { get; set; }
    public string CertificatedRank { get; set; }
    public DateTime CertificatedDate { get; set; }
}

public class Experience : Employee
{
    public int ExpInYear { get; set; }
    public string ProSkill { get; set; }

    public Experience(
        string id,
        string fullName,
        DateTime birthDay,
        string phone,
        string email,
        int expInYear,
        string proSkill,
        int employee_count
    )
        : base(id, fullName, birthDay, phone, email, 0, employee_count)
    {
        this.ExpInYear = expInYear;
        this.ProSkill = proSkill;
    }

    public override void ShowInfo()
    {
        Console.WriteLine(
            $"ID: {this.ID}, Name: {this.FullName}, BirthDay: {this.BirthDay:dd/MM/yyyy}, Phone: {this.Phone}, Email: {this.Email}, Employee_type: Experience, Experience_in_year: {this.ExpInYear}, Pro_skill: {this.ProSkill}"
        );
    }
}

public class Fresher : Employee
{
    public DateTime Graduation_date { get; set; }
    public string Graduation_rank { get; set; }
    public string Education { get; set; }

    public Fresher(
        string id,
        string fullName,
        DateTime birthDay,
        string phone,
        string email,
        DateTime graduation_date,
        string graduation_rank,
        string education,
        int employee_count
    )
        : base(id, fullName, birthDay, phone, email, 1, employee_count)
    {
        this.Graduation_date = graduation_date;
        this.Graduation_rank = graduation_rank;
        this.Education = education;
    }

    public override void ShowInfo() =>
        Console.WriteLine(
            $"ID: {this.ID}, Name: {this.FullName}, BirthDay: {this.BirthDay:dd/MM/yyyy},Phone: {this.Phone}, Email: {this.Email}, Employee_type: Fresher, Graduation_date: {this.Graduation_date:dd/MM/yyyy}, Graduation_rank: {this.Graduation_rank}, Education: {this.Education}"
        );
}

public class Intern : Employee
{
    public string Majors { get; set; }
    public int Semester { get; set; }
    public string University_name { get; set; }

    public Intern(
        string id,
        string fullName,
        DateTime birthDay,
        string phone,
        string email,
        string majors,
        int semester,
        string university_name,
        int employee_count
    )
        : base(id, fullName, birthDay, phone, email, 2, employee_count)
    {
        Majors = majors;
        Semester = semester;
        University_name = university_name;
    }

    public override void ShowInfo()
    {
        Console.WriteLine(
            $"ID: {this.ID}, Name: {this.FullName}, BirthDay: {this.BirthDay:dd/MM/yyyy},Phone: {this.Phone}, Email: {this.Email}, Majors: {this.Majors}, Semester: {this.Semester}, University_name: {this.University_name}"
        );
    }
}

class QLNV
{
    private readonly List<Experience> dsExperience;
    private readonly List<Fresher> dsFresher;
    private readonly List<Intern> dsIntern;
    private readonly List<Employee> dsEmployee;

    public QLNV()
    {
        dsExperience = new List<Experience>();
        dsFresher = new List<Fresher>();
        dsIntern = new List<Intern>();
    }

    public void AddExperience(Experience e)
    {
        if (!CheckValidity.IsValidEmail(e.Email))
        {
            throw new EmailException("Invalid Email");
        }
        if (!CheckValidity.IsValidName(e.FullName))
        {
            throw new FullNameException("Invalid Name");
        }
        if (!CheckValidity.IsValidBirthDay(e.BirthDay))
        {
            throw new BirthDayException("Invalid Birthday");
        }
        if (!CheckValidity.IsValidPhoneNumber(e.Phone))
        {
            throw new PhoneException("Invalid Phone Number");
        }
        dsExperience.Add(e);
    }

    public void AddFresher(Fresher f)
    {
        if (!CheckValidity.IsValidEmail(f.Email))
        {
            throw new EmailException("Invalid Email");
        }
        if (!CheckValidity.IsValidName(f.FullName))
        {
            throw new FullNameException("Invalid Name");
        }
        if (!CheckValidity.IsValidBirthDay(f.BirthDay))
        {
            throw new BirthDayException("Invalid Birthday");
        }
        if (!CheckValidity.IsValidPhoneNumber(f.Phone))
        {
            throw new PhoneException("Invalid Phone Number");
        }
        dsFresher.Add(f);
    }

    public void AddIntern(Intern n)
    {
        if (!CheckValidity.IsValidEmail(n.Email))
        {
            throw new EmailException("Invalid Email");
        }
        if (!CheckValidity.IsValidName(n.FullName))
        {
            throw new FullNameException("Invalid Name");
        }
        if (!CheckValidity.IsValidBirthDay(n.BirthDay))
        {
            throw new BirthDayException("Invalid Birthday");
        }
        if (!CheckValidity.IsValidPhoneNumber(n.Phone))
        {
            throw new PhoneException("Invalid Phone Number");
        }
        dsIntern.Add(n);
    }

    public int FindEmployeeById(string id)
    {
        foreach (Employee employee in dsEmployee)
        {
            if (employee.ID == id)
            {
                return employee.Employee_type;
            }
        }
        return -1;
    }

    public void FindAllExperience()
    {
        Console.WriteLine("Danh sách các nhân viên experience là: ");
        foreach (Experience e in dsExperience)
        {
            e.ShowInfo();
        }
        Console.WriteLine();
    }

    public void FindAllFresher()
    {
        Console.WriteLine("Danh sách các nhân viên fresher là: ");
        foreach (Fresher f in dsFresher)
        {
            f.ShowInfo();
        }
        Console.WriteLine();
    }

    public void FindAllIntern()
    {
        Console.WriteLine("Danh sách các nhân viên intern là: ");
        foreach (Intern n in dsIntern)
        {
            n.ShowInfo();
        }
        Console.WriteLine();
    }

    public void UpdateExprience(Experience e, string id)
    {
        if (!CheckValidity.IsValidEmail(e.Email))
        {
            throw new EmailException("Invalid Email");
        }
        if (!CheckValidity.IsValidName(e.FullName))
        {
            throw new FullNameException("Invalid Name");
        }
        if (!CheckValidity.IsValidBirthDay(e.BirthDay))
        {
            throw new BirthDayException("Invalid Birthday");
        }
        if (!CheckValidity.IsValidPhoneNumber(e.Phone))
        {
            throw new PhoneException("Invalid Phone Number");
        }
        foreach (Experience e2 in dsExperience)
        {
            if (e2.ID == id)
            {
                e2.ID = e.ID;
                e2.FullName = e.FullName;
                e2.BirthDay = e.BirthDay;
                e2.Phone = e.Phone;
                e2.Email = e.Email;
                e2.Employee_type = e.Employee_type;
                e2.ExpInYear = e.ExpInYear;
                e2.ProSkill = e.ProSkill;
                break;
            }
        }
        Console.WriteLine("Updated successfully!");
    }

    public void UpdateFresher(Fresher f, string id)
    {
        if (!CheckValidity.IsValidEmail(f.Email))
        {
            throw new EmailException("Invalid Email");
        }
        if (!CheckValidity.IsValidName(f.FullName))
        {
            throw new FullNameException("Invalid Name");
        }
        if (!CheckValidity.IsValidBirthDay(f.BirthDay))
        {
            throw new BirthDayException("Invalid Birthday");
        }
        if (!CheckValidity.IsValidPhoneNumber(f.Phone))
        {
            throw new PhoneException("Invalid Phone Number");
        }
        foreach (Fresher f2 in dsFresher)
        {
            if (f2.ID == id)
            {
                f2.ID = f.ID;
                f2.FullName = f.FullName;
                f2.BirthDay = f.BirthDay;
                f2.Phone = f.Phone;
                f2.Email = f.Email;
                f2.Employee_type = f.Employee_type;
                f2.Graduation_date = f.Graduation_date;
                f2.Graduation_rank = f.Graduation_rank;
                f2.Education = f.Education;
                break;
            }
        }
        Console.WriteLine("Updated successfully!");
    }

    public void UpdateIntern(Intern intern, string id)
    {
        if (!CheckValidity.IsValidEmail(intern.Email))
        {
            throw new EmailException("Invalid Email");
        }
        if (!CheckValidity.IsValidName(intern.FullName))
        {
            throw new FullNameException("Invalid Name");
        }
        if (!CheckValidity.IsValidBirthDay(intern.BirthDay))
        {
            throw new BirthDayException("Invalid Birthday");
        }
        if (!CheckValidity.IsValidPhoneNumber(intern.Phone))
        {
            throw new PhoneException("Invalid Phone Number");
        }
        foreach (Intern intern2 in dsIntern)
        {
            if (intern2.ID == id)
            {
                intern2.ID = intern.ID;
                intern2.FullName = intern.FullName;
                intern2.BirthDay = intern.BirthDay;
                intern2.Phone = intern.Phone;
                intern2.Email = intern.Email;
                intern2.Employee_type = intern.Employee_type;
                intern2.Majors = intern.Majors;
                intern2.Semester = intern.Semester;
                intern2.University_name = intern.University_name;
                break;
            }
        }
        Console.WriteLine("Updated successfully!");
    }

    public void DeleteEmployee(string id)
    {
        foreach (Experience e in dsExperience)
        {
            if (e.ID == id)
            {
                dsExperience.Remove(e);
            }
        }
        foreach (Fresher fresher in dsFresher)
        {
            if (fresher.ID == id)
            {
                dsFresher.Remove(fresher);
            }
        }
        foreach (Intern n in dsIntern)
        {
            if (n.ID == id)
            {
                dsIntern.Remove(n);
            }
        }
        Console.WriteLine("Deleted successfully!");
    }
}

public class BirthDayException : Exception
{
    public BirthDayException(string message)
        : base(message) { }
}

public class PhoneException : Exception
{
    public PhoneException(string message)
        : base(message) { }
}

public class EmailException : Exception
{
    public EmailException(string message)
        : base(message) { }
}

public class FullNameException : Exception
{
    public FullNameException(string message)
        : base(message) { }
}

class CheckValidity
{
    public static bool IsValidBirthDay(DateTime birthDay)
    {
        DateTime now = DateTime.Now;
        int age = now.Year - birthDay.Year;
        if (now.Month < birthDay.Month || (now.Month == birthDay.Month && now.Day < birthDay.Day))
        {
            age--;
        }
        return age >= 18;
    }

    public static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    public static bool IsValidName(string name)
    {
        return !string.IsNullOrEmpty(name) && name.Length <= 50;
    }

    public static bool IsValidPhoneNumber(string phoneNumber)
    {
        return !string.IsNullOrEmpty(phoneNumber)
            && Regex.IsMatch(phoneNumber, @"^(\+[0-9]{2,3})?[0-9]{9,10}$");
    }
}
