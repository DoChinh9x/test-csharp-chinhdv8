using System;
using System.Collections.Generic;

public class PaperStrip
{
    public static int MinPieces(int[] original, int[] desired)
    {
        Dictionary<int, int> pos = new Dictionary<int, int>();
        for (int i = 0; i < original.Length; i++)
        {
            pos[original[i]] = i;
        }
        List<List<int>> pieces = new List<List<int>>();
        for (int i = 0; i < desired.Length; i++)
        {
            int num = desired[i];
            if (pos[num] == i)
            {
                continue;
            }
            int j = pos[num];
            int k = i;
            List<int> piece = new List<int>();
            while (j != k)
            {
                piece.Add(original[j]);
                j = (j + 1) % original.Length;
                if (j == pos[num])
                {
                    return -1;
                }
            }
            piece.Add(num);
            pieces.Add(piece);
        }

        return pieces.Count;
    }

    public static void Main(string[] args)
    {
        int[] original = new int[] { 1, 4, 3, 2 };
        int[] desired = new int[] { 1, 2, 4, 3 };
        Console.WriteLine(PaperStrip.MinPieces(original, desired));

        int[] original10 = new int[] { 8, 2, 3, 5, 7, 6, 9, 1, 10, 4 };
        int[] desired10 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Console.WriteLine(PaperStrip.MinPieces(original10, desired10));

        Console.ReadLine();
    }
}
