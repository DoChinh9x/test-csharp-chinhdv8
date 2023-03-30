using System;
using System.Collections.Generic;

public class WindowManager
{
    private LinkedList<string> windows;

    public WindowManager()
    {
        windows = new LinkedList<string>();
    }

    public void Open(string windowName)
    {
        windows.AddFirst(windowName);
    }

    public void Close(string windowName)
    {
        windows.Remove(windowName);
    }

    public string GetTopWindow()
    {
        if (windows.Count == 0)
        {
            throw new InvalidOperationException("No windows are open.");
        }
        return windows.First.Value;
    }

    public static void Main(string[] args)
    {
        WindowManager wm = new WindowManager();
        wm.Open("Calculator");
        wm.Open("Browser");
        wm.Open("Player");
        wm.Close("Browser");
        Console.WriteLine(wm.GetTopWindow()); // should print "Player"

        Console.ReadLine();
    }
}
