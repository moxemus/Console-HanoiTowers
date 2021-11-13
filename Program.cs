using System;
using System.Collections.Generic;

static class Towers
{
    static int towersCount = 3;
    static int diskValue = 5;
    static string correctAnswer = "12345";

    static Stack<int>[] map = new Stack<int>[towersCount];

    static public bool Push(int Tower1, int Tower2)
    {
        string userAnwser = "";

        if (map[Tower2].Count > 0 && map[Tower1].Peek() > map[Tower2].Peek())
            return false;

        map[Tower2].Push(map[Tower1].Pop());

        foreach (int a in map[Tower2])
            userAnwser += a.ToString();

        return userAnwser == correctAnswer;
    }

    static public void ShowInConsole()
    {
        foreach (Stack<int> tower in map)
        {
            string str = "";

            foreach (int a in tower) str += a.ToString();

            for (int i = 0; i < towersCount - str.Length + 1; i++)
                str = ' ' + str;

            Console.WriteLine(str);
        }
    }

    static void Main(string[] args)
    {
        for (int i = 0; i < Towers.towersCount; i++)
            Towers.map[i] = new Stack<int>();

        for (int i = 1; i < Towers.diskValue + 1; i++)
            Towers.map[new Random().Next(Towers.towersCount)].Push(i);

        while (true)
            try
            {
                Console.Clear();
                Towers.ShowInConsole();

                if (Towers.Push(Convert.ToInt32(Console.ReadLine()) - 1,
                    Convert.ToInt32(Console.ReadLine()) - 1)) break;
            }
            catch { };
    }
}
