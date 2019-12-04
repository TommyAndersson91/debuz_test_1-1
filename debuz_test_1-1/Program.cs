using System;
using System.Linq;

namespace debuz_test_1_1
{


//Please write the program that will randomly pick numbers from 0 - 9 to 4 unique numbers(For example: 3, 6, 0, 9).
//Then make the program receives input from user as a guessing answer(For example: 1, 2, 3, 9).
//And program have to answer back with 2 values one is how many correct numbers and how many correct positions.
//For example, this answer should be (2, 1) which is 3 and 9 are correct numbers but only 9 is in the right position.

//Write the program, with the following details:
//Random numbers from 0 - 9 to 4 numbers uniquely.
//Receive input from user from 0 - 9 to 4 numbers.
//When all 4 inputs are received, display the guess result, which how many correct numbers and how many correct positions.
//Can continuously receive inputs until both results (correct numbers, correct positions) are correct  (4, 4).  

    class Program
    {

       static int[] randomNumbers = new int[4];
       static int[] guessedNumbers = new int[4];
        static int numberOfGuesses;
        static int correctNumbers;
        static int correctPositions; 

        static void Main(string[] args)
        {
            SetNumbers();
            Guess();
        }


        public static void SetNumbers()
        {
            var numbers = Enumerable.Range(0, 9).ToArray();
            var rnd = new Random();

            for (int i = 0; i < numbers.Length; ++i)
            {
                int randomIndex = rnd.Next(numbers.Length);
                int temp = numbers[randomIndex];
                numbers[randomIndex] = numbers[i];
                numbers[i] = temp;
            }

            for (int i = 0; i < 4; ++i)
            {
                randomNumbers[i] = numbers[i];
                
                 // Uncomment to display the random unique numbers
                 Console.WriteLine(randomNumbers[i]);
                 
            }
        }

        public static void Guess()
        {
            while (numberOfGuesses < 4)
            {
                Console.WriteLine("Please enter a number between 0-9 [Guess: " + (numberOfGuesses+1) + " /4]");

                guessedNumbers[numberOfGuesses] = Int32.Parse(Console.ReadLine());
                numberOfGuesses++;
            }
            foreach (var guessedNumber in guessedNumbers)
            {
                foreach (var randomNumber in randomNumbers)
                {
                    if (guessedNumber.Equals(randomNumber))
                    {
                        correctNumbers++;
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (guessedNumbers[i] == randomNumbers[i])
                {
                    correctPositions++;
                }
            }

            if (correctPositions == 4 && correctNumbers == 4)
            {
                Console.WriteLine
                ("You guessed the correct number: " + correctNumbers + " / 4 times" + "\n"
                + "You guessed the correct positions: " + correctPositions + " / 4 times");
                Console.WriteLine("Congratulations you have won the game!");
             
            } else
            {

                Console.WriteLine
                ("You guessed the correct number: " + correctNumbers + " / 4 times" + "\n"
                 + "You guessed the correct positions: " + correctPositions + " / 4 times \n");

                numberOfGuesses = 0;
                correctNumbers = 0;
                correctPositions = 0;
                Guess();
            }
        }




    }
}
