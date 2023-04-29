using System;
using System.Threading;

class Program
{
    static int numPhilosophers = 5;
    static object[] forks = new object[numPhilosophers];

    static void Main(string[] args)
    {
        for (int i = 0; i < numPhilosophers; i++)
        {
            forks[i] = new object();
        }

        for (int i = 0; i < numPhilosophers; i++)
        {
            int philosopherNumber = i;
            Thread thread = new Thread(() => Eat(philosopherNumber));
            thread.Start();
        }

        Console.ReadLine();
    }

    static void Eat(int philosopherNumber)
    {
        int leftFork = philosopherNumber;
        int rightFork = (philosopherNumber + 1) % numPhilosophers;

        lock (forks[leftFork])
        {
            lock (forks[rightFork])
            {
                Console.WriteLine("Philosopher " + philosopherNumber + " is eating");
            }
        }
    }
}