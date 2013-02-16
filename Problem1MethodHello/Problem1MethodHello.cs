using System;
//Write a method that asks the user for his name
//and prints “Hello, <name>” (for example, “Hello, Peter!”). 
//Write a program to test this method.

class Problem1MethodHello
{
    static void Greetings()
    {
        Console.WriteLine("What`s your name?");
        string name = Console.ReadLine();
        Console.WriteLine("Hello, {0}!", name);
    }
    static void Main()
    {
        Greetings();
    }
}

