using System;
using System.Linq;

namespace _1DV610_moment0
{
    class Program
    {


        public static void randomize(string input) {
            string sweChars = "abcdefghijklmnopqrstuvwxyzåäö";
            var scramble = Math.Ceiling(input.Length / 0.7);

            string modifiedInput = input;

            for (int i = 0; i < scramble; i++)
            {
                Random random = new Random();
                // In every for loop we need to create a random position and a random character

                char randomChar = sweChars[random.Next(sweChars.Length)]; // Generate random number from length of string as index for random char
                int randomPosition = random.Next(sweChars.Length);
                
                input.Remove(randomPosition, 1).Insert(randomPosition, randomChar.ToString()); // Placing the randomChar in the random position




                // Create logic for showing the random string, trying an answer, etc
                // Difficulty can be measured with the scramble formula, maybe higher for more difficulty etc
            }


        }
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
