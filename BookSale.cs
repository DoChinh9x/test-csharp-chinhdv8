using System;
using System.Collections.Generic;
using System.Linq;

public class BookSale
{
    public static int NthLowestSelling(int[] sales, int n)
    {
        var salesCount = new Dictionary<int, int>();
        foreach (int bookId in sales)
        {
            if (salesCount.ContainsKey(bookId))
            {
                salesCount[bookId]++;
            }
            else
            {
                salesCount[bookId] = 1;
            }
        }

        var sortedIds = salesCount.OrderBy(kv => kv.Value).Select(kv => kv.Key).ToList();

        return sortedIds[n - 1];
    }

    public static void Main(string[] args)
    {
        int x = NthLowestSelling(new int[] { 5, 4, 3, 2, 1, 5, 4, 3, 2, 5, 4, 3, 5, 4, 5 }, 2);
        Console.WriteLine(x);

        Console.ReadLine();
    }
}
