﻿using System;
using System.Collections.Generic;


namespace Lab2WS
{
    class Program
    {
        private static readonly FileReader fileReader = new FileReader();
        private static readonly WordMatcher wordMatcher = new WordMatcher();

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the scrambled words manually or as a file: f - file, m = manual");

                string option = Console.ReadLine() ?? throw new Exception("String is null");

                switch (option.ToUpper())
                {
                    case "F":
                        Console.WriteLine("Enter the full path and filename >");
                        ExecuteScrambledWordsInFileScenario();
                        break;
                    case "M":
                        Console.WriteLine("Enter word(s) separated by a comma");
                        ExecuteScrambledWordsManualEntryScenario();
                        break;
                    default:
                        Console.WriteLine("The entered option was not recognized");
                        break;
                }

                // Optional for now (when you have no loop)  (Take out when finished)
                Console.ReadKey();

            }
            catch (Exception e)
            {
                Console.WriteLine("Sorry an error has occurred.. " + e.Message);
            }



        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            string fileName = Console.ReadLine();
            string[] scrambledWords = fileReader.Read(fileName);
            DisplayMatchedScrambledWords(scrambledWords);
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            // 1 get the user's input - comma separated string containing scrambled words
            // 2 Extract the words into a string (red,blue,green) 
            // 3 Call the DisplayMatchedUnscrambledWords method passing the scrambled words string array
            Console.WriteLine("Hey bro, enter words separated by commas");
            string inputManual = Console.ReadLine();



            string[] scrambledInput = inputManual.Split(',');
            DisplayMatchedScrambledWords(scrambledInput);



        }

        private static void DisplayMatchedScrambledWords(string[] scrambledWords)
        {
            string[] wordList = fileReader.Read(@"wordlist.txt"); // Put in a constants file. CAPITAL LETTERS.  READONLY.

            List<MatchedWord> matchedWords = wordMatcher.Match(scrambledWords, wordList);


            // Rule:  Use a formatter to display ... eg:  {0}{1}

            // Rule:  USe an IF to determine if matchedWords is empty or not......
            //            if empty - display no words found message.
            //            if NOT empty - Display the matches.... use "foreach" with the list (matchedWords)

                        if (matchedWords==null)

                        {
                            Console.WriteLine("ERROR! No words found");
                        }

            else

            {

                foreach (MatchedWord displayedword in matchedWords){
                    
                    
                    
                    String displayFound = String.Format("Match found for: {0}{1}", scrambledWords, wordList);
                 }
            }
        }

    }
}