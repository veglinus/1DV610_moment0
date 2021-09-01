using System;
using System.Linq;

/*
Piratespeak guessing game!
The program picks a word from the dictionary and scrambles some of the letters,
before translating it to piratespeak. Your job is to guess the correct word.

You can add more words by adding them to the dictionary array.

By Linus Hvenfelt, 2021.
*/

namespace _1DV610_moment0
{
    class Program
    {
        static string phrase = "";
        static string codedWord = "";
        static int lives = 3;
        static string[] dictionary = {"glitter", "hangman", "webcam", "keyboard"};

        public static void newGame() {
            Program.lives = 3;


            string randomWord = dictionary[new Random().Next(0, Program.dictionary.Length)];

            Program.phrase = randomWord;
            translate(randomWord);

        }
        public static string randomize(string input) {
            input = input.ToLower();

            string sweChars = "abcdefghijklmnopqrstuvwxyzåäö";
            var scramble = Math.Ceiling(input.Length * 0.3);

            string modifiedInput = input;

            for (int i = 0; i < scramble; i++)
            {
                Random random = new Random();
                // In every for loop we need to create a random position and a random character

                char randomChar = sweChars[random.Next(1, sweChars.Length)]; // Generate random number from length of string as index for random char
                int randomPosition = random.Next(1, input.Length);

                //Console.WriteLine("randomChar: " + randomChar + " - " + "randomPosition: " + randomPosition);

                modifiedInput = input.Remove(randomPosition, 1);
                modifiedInput = input.Insert(randomPosition, randomChar.ToString()); // Placing the randomChar in the random position

                // Create logic for showing the random string, trying an answer, etc
                // Difficulty can be measured with the scramble formula, maybe higher for more difficulty etc
            }
            Console.WriteLine("Word has been scrambled! Word is now: " + modifiedInput);

            return modifiedInput;
        }
        public static void translate(string input) {

            input = randomize(input);

            char[] consonants = {'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'x', 'z'};
            for (int i = 0; i < input.Length; i++)
            { 
                char character = input[i];
                if (consonants.Contains(character)) { // check if consonant or vowel
                    input = input.Insert(i + 1, "o" + character);

                    i += 2; // due to adding 2 characters, o and duplicate character we need the loop to move 2 chars forward in the next iteration
                } 
            }

            Program.codedWord = input;
            //Console.WriteLine(input);

        }
        static void awaitUser() {
            Console.WriteLine("Guess the scrambled translated rövarspråks-word!");
            Console.WriteLine(Program.codedWord + " - correct word is: " + Program.phrase);
            var userInput = Console.ReadLine().ToLower();

            if (userInput == Program.phrase && lives > 0) {
                Console.WriteLine("That's correct! The word was " + Program.phrase + ".");
            } else {
                lives--;

                if (lives < 0) {
                    Console.WriteLine("Oh dear, you lost. The word was " + Program.phrase + ".");
                } else {
                    Console.Clear();
                    Console.WriteLine("That's not quite it.. " + Program.lives + " lives left.");
                    awaitUser();
                }
            }
        }
        static void Main(string[] args)
        {
            newGame();
            Console.Clear();
            awaitUser();
        }
    }
}
