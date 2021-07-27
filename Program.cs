using System;
using System.Collections.Generic;

namespace ConsoleTowers
{
    class Towers
    {
        const int towersCount = 3;
        const int diskValue = 5;
        string answer = "";
        
        Stack<int>[] map = new Stack<int>[towersCount];

        public Towers()
        {
            Random rand = new Random();

            for (int i = 0; i < towersCount; i++) 
                map[i] = new Stack<int>();

            for (int i = 1; i < diskValue + 1; i++)
            {
                map[rand.Next(towersCount)].Push(i);
                answer += i.ToString();
            }
        }
        
        public bool Push(int Tower1, int Tower2)
        {
            string userAnwser = "";

            try
            {
                if (map[Tower2].Count > 0)
                    if (map[Tower1].Peek() > map[Tower2].Peek())
                        throw new Exception();

                map[Tower2].Push(map[Tower1].Pop());

                foreach (int a in map[Tower2])
                    userAnwser += a.ToString();
            } catch { }
			
            return userAnwser == answer; 
        }

        public void Show()
        {
            foreach (Stack<int> tower in map)
            {
                string str = "";

                foreach (int a in tower) 
                    str += a.ToString();

                int n = str.Length;

                for (int i = 0; i < towersCount - n + 1; i++)
                    str = ' ' + str;

                Console.WriteLine(str);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Towers towers = new Towers();

            while (true)
                try
                {
                    Console.Clear();
                    towers.Show();

                    int a = Convert.ToInt32(Console.ReadLine());
                    int b = Convert.ToInt32(Console.ReadLine());

                    if (towers.Push(a - 1, b - 1)) break;
                } catch { } 
        }
    }
}
