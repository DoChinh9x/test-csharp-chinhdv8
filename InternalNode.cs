using System;
using System.Collections.Generic;

public class InternalNodes
{
    public static int Count(params int[] tree)
    {
        int n = tree.Length;
        int[] children = new int[n];
        int internalNodes = 0;

        for (int i = 0; i < n; i++)
        {
            if (tree[i] != -1)
            {
                children[tree[i]]++;
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (children[i] > 0)
            {
                internalNodes++;
            }
        }

        return internalNodes;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(InternalNodes.Count(1, 3, 1, -1, 3));

        Console.ReadLine();
    }
}

