/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 * What is the smallest number > 1000000000 such that:
 *  it is prime
 *  the reverse is prime
 *  the sum of the digits is prime
 *  it contains all prime digits
 *  
 * By definition 0 is not prime
 * By definition 1 is not prime
 * 
 */
using System;


namespace e010
{
    class Program
    {
        static void Main(string[] args) {
            Console.WriteLine(Solve());
        }
        public static int Solve() {
            int result = 0;
            //int num = 10000;          // 10007 and 70001
            //int num = 100000;         // 100049 and 940001
            //int num = 1000000;        // 1000033 and 3300001
            int num = 1111111111;
            while (true) {
                if (CheckForPrimeDigits(num)) {
                    int sumOfDigits = 0;
                    sumOfDigits = CalcSumOfDigits(num);
                    if (IsPrime(num) && (IsPrime(sumOfDigits)) && (IsPrime(Convert.ToInt32(Reverse(Convert.ToString(num))))) ) {
                        Console.WriteLine(num + ", Sum of Digits = " + sumOfDigits);
                        result = num;
                        break;
                    }
                }
                num += 2;
            }
            return result;
        }
        private static Boolean IsPrime(int num) {
            Boolean isPrime = true;
            if (num % 2 == 0 || num == 0 || num == 1) { return false; }
            for (int i = 3; i < num / 2; i += 2) {
                if (num % i == 0) { isPrime = false; break; }
            }
            return isPrime;
        }

        public static string Reverse(string s) {
            // https://stackoverflow.com/questions/228038/best-way-to-reverse-a-string
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static int CalcSumOfDigits(int num) {
            int sum = 0;
            foreach (Char c in Convert.ToString(num)) {
                sum += Convert.ToInt32(c) - 48;
            }
            return sum;
        }
        public static Boolean CheckForNonPrimeDigits(int num)
        {
            Char[] c = Convert.ToString(num).ToCharArray();
            for(int i = 1; i < c.Length - 1; i++) {
                int digit;
                digit = c[i] - '0';
                if (IsPrime(digit) || digit == 0) { return false; }
            }
            return true;
        }
        public static Boolean CheckForPrimeDigits(int num)
        {
            Char[] c = Convert.ToString(num).ToCharArray();
            for (int i = 1; i < c.Length - 1; i++)
            {
                int digit;
                digit = c[i] - '0';
                if (!IsPrime(digit) || digit == 1) { return false; }
            }
            return true;
        }
    }
}
