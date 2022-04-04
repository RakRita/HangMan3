using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangMan3
{
    public class Program
    {

        static void Main(string[] args)
        {

            Random random = new Random();



            string[] wordBank = new string[10] { "redislandred", "islandblueiland", "bluevioletblue", "violetrange", "rangeblackrange", "blackwhiteblack", "whiteforeswhite", "forestcloud", "cloudgreklandcloud", "greklandgrekland" };
            string secretWord = wordBank[random.Next(0, wordBank.Length)];
            secretWord.ToCharArray();
            char[] secret = new char[secretWord.Length];


            StringBuilder sb = new StringBuilder();
            string input1;
            int count = 10;
            bool guess = true;

            List<char> corrcetGuesses = new List<char>();
            List<char> inCorrcetGuesses = new List<char>();



            Console.WriteLine("Du har 10 gissningar");
            Console.WriteLine(secretWord);
            Console.WriteLine();


            for (int i = 0; i < secret.Length; i++)
            {
                secret[i] = '_';
            }


            //Console.WriteLine();


            while (guess)
            {

                if (sb.Length != 0) { Console.WriteLine("\nDessa bokstäver finns inte i ordet: " + sb.ToString()); }
                Console.WriteLine("Du har " + count + " gissningar kvar");


                for (int x = 0; x < secret.Length; x++)
                {
                    Console.Write(secret[x] + " ");

                }
                Console.WriteLine();
                Console.WriteLine("Gissa en bokstav eller hela ordet");
                input1 = Console.ReadLine();

                // Console.WriteLine();


                if (input1.Length == 1)
                {


                    char input = char.Parse(input1);




                    if (corrcetGuesses.Contains(input))
                    {
                        Console.WriteLine("Du har redan gissat på: " + input + " och det var en av de rätta bokstäverna");

                        continue;
                    }

                    if (inCorrcetGuesses.Contains(input))
                    {
                        Console.WriteLine("Du har redan gissat på " + input + " och det var fel");

                        continue;
                    }




                    if (!secretWord.Contains(input))
                    {
                        count--;
                        sb.Append(input);

                        inCorrcetGuesses.Add(input);

                    }





                    for (int i = 0; i < secretWord.Length; i++)
                    {


                        if (secretWord[i] == input)
                        {
                            corrcetGuesses.Add(input);
                            secret[i] = input;


                        }
                    }


                    int x = 1;
                    if (x % 2 == 0)
                        for (x = 0; x < secret.Length; x++)
                        {

                            {
                                Console.Write(secret[x] + " ");
                            }




                        }



                    Console.WriteLine();
                    if (!secret.Contains('_'))
                    {
                        Console.WriteLine("Du gissade rätt");
                        break;
                    }
                }
                else if (input1.Length >= 1)
                {
                    if (secretWord == input1)
                    {
                        Console.WriteLine("Rätt gissat");
                        break;
                    }
                    if (secretWord != input1)
                    {
                        count--;
                        Console.WriteLine("Du gissade fel ord och har" + count + "gissningar kvar.");
                    }
                }





                if (count == 0)


                    guess = false;

            }

            Console.ReadLine();





        }
    }
}




