using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;

namespace MathLibrary
{
    public class MathClass
    {
        public BigInteger binaryToDecimal(string input)
        {
            BigInteger result = 0;
            BigInteger addThis = 1;
            //string convertable = input.ToString(); //"11111111111111111111110000000000000000000000000000000000000000000000000000000000000000000000000000000111111111111111111111111111111111111111111111111111111111111111111111111111111111";

            for (int i = input.Count(); i != 0; i--)
            {
                if (input[i - 1] == '1')
                    result += addThis;
                else if (input[i - 1] == '0') { }
                else
                {
                    result = 666;
                    break;
                }
                addThis *= 2;
            }

            //Console.WriteLine(result);
            return result;
        }

        public string Convert(decimal amount, string fromCurrency, string toCurrency)
        {
            try
            {
             
                string apiURL = String.Format("https://www.google.com/finance/converter?a={0}&from={1}&to={2}&meta={3}", amount, fromCurrency, toCurrency, Guid.NewGuid().ToString());

                var request = WebRequest.Create(apiURL);

                var streamReader = new StreamReader(request.GetResponse().GetResponseStream(), System.Text.Encoding.ASCII);

                var result = Regex.Matches(streamReader.ReadToEnd(), "<span class=\"?bld\"?>([^<]+)</span>")[0].Groups[1].Value;

                return result;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        // 3 ja 5 jaollisten lukujen summa
        public int SumOfNaturals(int naturalsBelow)
        {
            int sum = 0;

            for (int i = 1; i < naturalsBelow; i++)
            {
                if ((i % 3 == 0) || (i % 5 == 0))
                {
                    sum = sum + i;
                }
            }
            //Console.WriteLine("Answer: " + sum);

            return sum;
        }

       //10001:n alkuluku. HUOM! Todella raskas laskutoimitus, kestää i7 3770:lla ja 16Gb muistia lähes 12 minuuttia!!
        public int Alkuluku()
        {
            Thread oThread = new Thread(calculating);
            oThread.Start();
            

            int mil = 100000000;
            int[] numbers;
            numbers = new int[mil];
            int divisible = 0;
            int counter = 0;
            int[] primes = new int[100000];

            numbers[0] = 1;

            for (int i = 2; i < mil; i++)
            {
                numbers[i - 1] = i;

                for (int x = 0; x < i; x++)
                {
                    if (i % numbers[x] == 0)
                        divisible++;

                    if (divisible > 2)
                        break;

                }


                if (divisible == 2)
                {
                    primes[counter] = i;
                    counter++;
                }

                divisible = 0;

                if (counter == 10001)
                {
                    break;
                }

            }
         
            oThread.Abort();
            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < mil; i++)
            {
                numbers[i] = 0;
            }


            Console.WriteLine(primes[10000]);

            //numbers = new int[0];
            //primes = new int[0];

          //  GC.Collect(GC.MaxGeneration); // muuten ohjelma vie yli 400 megaa muistia
            return primes[10000];
        }

      
        // Lasketaan sadan ensimmäisen luonnollisen luvun toisen potenssien summa ja sadan esnsimmäisen luvun summan potenssi, jotka vähennetään toisistaan.
        public int PotenssisummienErotus()
        {
            Thread oThread = new Thread(calculating);
            oThread.Start();

            int n = 100;
            int[] naturals = new int[n];
            int temp = 0;
            for (int i = 1; i < n + 1; i++)
            {
                naturals[i - 1] = i;
                temp = temp + i;
            }
            Console.WriteLine(temp);

            double sumOfSquares = (Math.Pow((double)n, 3.00) / 3) + (Math.Pow((double)n, 2.00) / 2) + (n / 6);
            Math.Pow((double)n, 3.00);

            temp = (int)Math.Pow((double)temp, 2.00);
            int temp2 = (int)Math.Ceiling(Math.Round(sumOfSquares, 1));

            int answer = temp - temp2;

            oThread.Abort();

            return answer;
        }

        public void calculating()
        {
            Console.Write("Calculating");
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                Console.Write(".");
            }
        }
    }
}
