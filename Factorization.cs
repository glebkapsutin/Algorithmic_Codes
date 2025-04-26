using System;
using System.Collections.Generic;

namespace First_cods_in_university.Fact
{
    class Fact
    {
        // Метод для нахождения простых чисел с использованием решета Эратосфена
        public static List<int> SieveOfEratosthenes(int limit)
        {
            bool[] isPrime = new bool[limit + 1];
            for (int i = 2; i <= limit; i++)
                isPrime[i] = true;

            for (int p = 2; p * p <= limit; p++)
            {
                if (isPrime[p])
                {
                    for (int i = p * p; i <= limit; i += p)
                        isPrime[i] = false;
                }
            }

            List<int> primes = new List<int>();
            for (int i = 2; i <= limit; i++)
            {
                if (isPrime[i])
                    primes.Add(i);
            }

            return primes;
        }
        public static bool IsPrime(int number, List<int> primes)
        {
            foreach (int prime in primes)
            {
                if (prime * prime > number) break;
                if (number % prime == 0) return false;
            }
            return true;
        }
         // Метод факторизации числа методом Ферма
        public static List<int> FermatFactor(int N)
        {
            List<int> factors = new List<int>();

            if (N % 2 == 0)
            {
                throw new ArgumentException("Число должно быть нечётным.");
            }

            int x = (int)Math.Ceiling(Math.Sqrt(N));
            int y2 = x * x - N;

            while (Math.Sqrt(y2) % 1 != 0)  // Пока y^2 не является полным квадратом
            {
                x++;
                y2 = x * x - N;
            }

            int y = (int)Math.Sqrt(y2);
            int factor1 = x - y;
            int factor2 = x + y;

            factors.Add(factor1);
            factors.Add(factor2);

            return factors;
        }

        // Метод факторизации числа
        public static void Factorize(int number)
        {
            int originalNumber = number;
            List<int> primes = SieveOfEratosthenes(number);
            Dictionary<int, int> factors = new Dictionary<int, int>();

            foreach (int prime in primes)
            {
                while (number % prime == 0)
                {
                    if (factors.ContainsKey(prime))
                        factors[prime]++;
                    else
                        factors[prime] = 1;

                    number /= prime;
                }
            }

            // Вывод результата
            Console.WriteLine($"Факторизация числа {originalNumber}:");
            foreach (var factor in factors)
            {
                Console.WriteLine($"{factor.Key}^{factor.Value}");
            }

            // Если число не разложилось полностью (т.е. оно само является простым)
            if (number > 1)
            {
                Console.WriteLine($"{number}^1");
            }
        }

    }
}
