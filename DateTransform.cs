using System;
using System.Collections.Generic;
using System.Globalization;

public class DateTransform
{
    public static List<string> TransformDateFormat(List<string> dates)
    {
        var result = new List<string>();
        var formats = new string[] { "yyyy/MM/dd", "dd/MM/yyyy", "MM-dd-yyyy" };

        foreach (string date in dates)
        {
            DateTime parsedDate;
            bool success = DateTime.TryParseExact(
                date,
                formats,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out parsedDate
            );

            if (success)
            {
                result.Add(parsedDate.ToString("yyyyMMdd"));
            }
        }

        return result;
    }

    public static void Main(string[] args)
    {
        var input = new List<string> { "2010/02/20", "19/12/2016", "11-18-2012", "20130720" };
        TransformDateFormat(input).ForEach(Console.WriteLine);
        Console.ReadLine();
    }
}
