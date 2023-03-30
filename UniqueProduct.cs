using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class UniqueProduct
{
    public static string FirstUniqueProduct(string[] products)
    {
        Dictionary<string, int> productCounts = new Dictionary<string, int>();
        foreach (string product in products)
        {
            if (productCounts.ContainsKey(product))
            {
                productCounts[product]++;
            }
            else
            {
                productCounts[product] = 1;
            }
        }
        foreach (string product in products)
        {
            if (productCounts[product] == 1)
            {
                return product;
            }
        }
        return "";
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(FirstUniqueProduct(new string[] { "Apple", "Computer", "Apple", "Bag" }));

        Console.ReadLine();
    }
}
