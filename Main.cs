using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 0;
            while (true)
            {
                Console.WriteLine("Please enter a number");
                num = Int32.Parse(Console.ReadLine());

                List<int> primes = genPrime(num);
                foreach(int i in findPrimes(num, primes)) Console.WriteLine(i);

            }
        }
        /* Finds the three prime numbers that add up to the desired number */
        static List<int> findPrimes(int num, List<int> primes)
        {
            foreach(int a in primes.AsEnumerable().Reverse())
            {
                foreach(int b in primes)
                {
                    foreach(int c in primes)
                    {
                        if (a+b+c ==num) return new List<int> {a,b,c};
                    }
                }
            }
            return new List<int>{-1};
        }

        /* Generates a list of every prime number upto the inputted number.
        It checks whether a number is prime or not by checking whether any other prime divides into it */
        static List<int> genPrime(int max)
        {
            bool writeToList = false;
            List<int> primes;
            try {primes = readList(max);}
            catch {primes = new List<int>{2};}

            for (int i = primes[primes.Count -1] + 1; i < max; i++)
            {
                bool isPrime = true;
                foreach (int n in primes)
                {
                    if (i%n == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime) 
                {
                    primes.Add(i);
                    writeToList = true;
                }
                    

            }
            if (writeToList) writeList(primes);
            return primes;
        }
        
        /*Write all of the generated primes to a list. Currently write a totally new file everytime. Could be optimised to only add new primes to the txt file */
        static void writeList(List<int> _list)
        {
            using (StreamWriter sr = new StreamWriter("primes.txt"))
            {
                foreach (int i in _list) sr.WriteLine(i);
            }
        }

        /* Function for reading off the list of already generated primes from a txt file so that it 
        doesn't need to generate all of the primes from scratch */
        static List<int> readList(int max, bool print = false) 
        {
            
            List<int> primes = new List<int>();
            string line;
            using (StreamReader sr = new StreamReader("primes.txt"))
            {
                
                while ((line = sr.ReadLine()) != null  && Int32.Parse(line)<max)
                {
                    primes.Add(Int32.Parse(line));
                }

            }
            if (print)
            {
                foreach (int x in primes) Console.WriteLine(primes);
            }
            
            return primes;
        }
    }
}
