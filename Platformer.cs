using System;
using System.Collections.Generic;

public class Platformer
{
    private int currentPosition;
    private readonly List<int> tiles;
    private int valuePosition;

    public Platformer(int numberOfTiles, int position)
    {
        tiles = new List<int>();
        for (int i = 0; i < numberOfTiles; i++)
        {
            tiles.Add(i);
        }
        currentPosition = position;
        valuePosition = tiles[currentPosition];
    }

    public void JumpLeft()
    {
        currentPosition = tiles.IndexOf(valuePosition);
        currentPosition -= 2;
        valuePosition = tiles[currentPosition];
        tiles.Remove(currentPosition + 2);
    }

    public void JumpRight()
    {
        currentPosition = tiles.IndexOf(valuePosition);
        currentPosition += 2;
        valuePosition = tiles[currentPosition];
        tiles.Remove(currentPosition - 2);
    }

    public int Position()
    {
        return valuePosition;
    }

    public static void Main(string[] args)
    {
        Platformer platformer = new Platformer(6, 3);
        Console.WriteLine(platformer.Position()); // should print 3

        platformer.JumpLeft();
        Console.WriteLine(platformer.Position()); // should print 1

        platformer.JumpRight();
        Console.WriteLine(platformer.Position()); // should print 4

        Console.ReadLine();
    }
}
