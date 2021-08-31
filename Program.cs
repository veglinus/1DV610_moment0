using System;
using System.Linq;
using System.Threading;

namespace _1DV610_moment0
{
    class Program
    {
        public static void translate(string input) {

            char[] consonants = {'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'x', 'z'};

            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine("yo is this thing on");
             
                char character = input[i];
                if (consonants.Contains(character)) { // check if consonant or vowel
                    input = input.Insert(i + 1, "o" + character);

                    i += 2; // due to adding 2 characters, o and duplicate character we need the loop to move 2 chars forward in the next iteration
                } 
            }

            Console.WriteLine(input);

        }
        static void Main(string[] args)
        {

            Console.WriteLine("Översätt något till rövarspråket!");

            var input = Console.ReadLine().ToLower();
            translate(input);

            
        }
    }
}
