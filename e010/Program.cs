/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 * What is the smallest number > 1000000001 such that:
 *  it is prime
 *  the reverse is prime
 *  the sum of the digits is prime
 *  it contains all prime digits
 *  
 * By definition 0 is not prime
 * By definition 1 is not prime
 * 
 * For 11111111: Solution = 133337333
 * 
 */
using System;


namespace e010 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Solution = " + Solve());
            Console.ReadLine();
        }
        public static long Solve() {
            long result = 0;
            long num = 1000000001;
            while (true) {
                Boolean isPrime;
                isPrime = true;
                int limit;
                limit = (int)Math.Sqrt(num);
                for (long i = 3; i <= limit; i += 2) {if (num % i == 0) { isPrime = false; break; }}

                if (isPrime) {
                    String numString = Convert.ToString(num);
                    int sumOfDigits = 0;
                    sumOfDigits = CalcSumOfDigits(numString);
                    if (IsPrime(sumOfDigits)) {
                        if (CheckForPrimeDigits(numString)) {
                            if ((IsPrime(Convert.ToInt32(Reverse(numString)))) ) {
//                              Console.WriteLine(num + ", Sum of Digits = " + sumOfDigits);
                                result = num;
                                break;
                            }
                        }
                    }
                }
                num += 2;
                if (num % 555555 == 0) {Console.WriteLine(num); }
            }
            return result;
        }
        private static Boolean IsPrime(long num) {
            Boolean isPrime = true;
            long limit;
            limit = (int)Math.Sqrt(num);
            if (num % 2 == 0 || num == 0 || num == 1) { return false; }
            for (int i = 3; i <= limit; i += 2) {
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
        public static int CalcSumOfDigits(String num) {
            int sum = 0;
            foreach (Char c in num) {
                sum += Convert.ToInt32(c) - 48;
            }
            return sum;
        }
        public static Boolean CheckForNonPrimeDigits(long num)
        {
            Char[] c = Convert.ToString(num).ToCharArray();
            for(int i = 1; i < c.Length - 1; i++) {
                int digit;
                digit = c[i] - '0';
                if (IsPrime(digit) || digit == 0) { return false; }
            }
            return true;
        }
        public static Boolean CheckForPrimeDigits(String numString)
        {
            Char[] c = numString.ToCharArray();
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
