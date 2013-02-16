using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

struct Object
{
    public int x;
    public int y;
    public string c;
    public ConsoleColor color;
}

class FallingRocks
{
    static void PrintOnPosition(int x, int y, string c,
    ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(c);
    }

    static void PrintStringOnPosition(int x, int y, string str,
        ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(str);
    }

    static void Main()
    {
        string randomSymbol;
        int livesCount = 5;
        int score = 0;
        Console.BufferHeight = Console.WindowHeight = 25;
        Console.BufferWidth = Console.WindowWidth = 40;
        Object dwarf = new Object();
        dwarf.x = 2;
        dwarf.y = Console.WindowHeight - 1;
        dwarf.c = "(0)";
        dwarf.color = ConsoleColor.White;
        Random randomGenerator = new Random();
        List<Object> rocks = new List<Object>();
         while (true)
        {
            {
                int chance = randomGenerator.Next(0, 100);
                if (chance > 50)
                {
                    randomSymbol = Convert.ToString(Convert.ToChar(randomGenerator.Next('\u0021', '\u002F')));
                    Object newRock = new Object();
                    newRock.color = ConsoleColor.Green;
                    newRock.x = randomGenerator.Next(0, Console.WindowWidth - 1);
                    newRock.y = 0;
                    newRock.c = randomSymbol;
                    rocks.Add(newRock);
                }
                if (chance > 70)
                {
                    randomSymbol = Convert.ToString(Convert.ToChar(randomGenerator.Next('\u0021', '\u002F')));
                    Object newRock = new Object();
                    newRock.color = ConsoleColor.Red;
                    newRock.x = randomGenerator.Next(0, Console.WindowWidth - 1);
                    newRock.y = 0;
                    newRock.c = randomSymbol;
                    rocks.Add(newRock);
                }
                if (chance > 90)
                {
                    randomSymbol = Convert.ToString(Convert.ToChar(randomGenerator.Next('\u0021', '\u002F')));
                    Object newRock = new Object();
                    newRock.color = ConsoleColor.Yellow;
                    newRock.x = randomGenerator.Next(0, Console.WindowWidth - 1);
                    newRock.y = 0;
                    newRock.c = randomSymbol;
                    rocks.Add(newRock);
                }
            }

            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (dwarf.x - 1 >= 0)
                    {
                        dwarf.x = dwarf.x - 1;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (dwarf.x + 1 < Console.WindowWidth - 3)
                    {
                        dwarf.x = dwarf.x + 1;
                    }
                }
            }
            List<Object> newList = new List<Object>();
            for (int i = 0; i < rocks.Count; i++)
            {
                Object oldRock = rocks[i];
                Object newRock = new Object();
                newRock.x = oldRock.x;
                newRock.y = oldRock.y + 1;
                newRock.c = oldRock.c;
                newRock.color = oldRock.color;

                if (newRock.y == dwarf.y && (newRock.x == dwarf.x
                    || newRock.x == dwarf.x + 1 || newRock.x == dwarf.x + 2))
                {
                        livesCount--;
                    
                    if (livesCount == 0)
                    {
                        PrintStringOnPosition(8, 10, "GAME OVER!!!", ConsoleColor.Red);
                        PrintStringOnPosition(6, 12, "Your score is:" + score, ConsoleColor.Red);
                        PrintStringOnPosition(6, 14, "Press any key to exit...",
                            ConsoleColor.Red);
                    
                            Console.ReadLine();
                            Environment.Exit(0);
                    }
                    
                }
                
                if (newRock.y < Console.WindowHeight)
                {
                    newList.Add(newRock);
                    score++;
                }
            }
            rocks = newList;
            Console.Clear();
            
            PrintOnPosition(dwarf.x, dwarf.y, dwarf.c, dwarf.color);
            
            foreach (Object rock in rocks)
            {
                PrintOnPosition(rock.x, rock.y, rock.c, rock.color);
            }
            PrintStringOnPosition(0, 0, "Lives:" + livesCount, ConsoleColor.White);
            Thread.Sleep(150);
        }
    }
}

