using System;
using System.Collections.Generic;


namespace Lab2WS

{
    class Program

    {

        private static readonly FileReader fileReader = new FileReader();

        private static readonly WordMatcher wordMatcher = new WordMatcher();

       static bool check1 = false;
       static bool check2 = false;

        static void Main(string[] args)

                {

                 

                    while (check1 == false)
                    {

                        try

                        {

                            Console.WriteLine("ENTER SCRAMBLED WORDS MANUALLY OR ENTER FILE NAME :  F FOR file, M FOR manual");


                                    //reads case that user inputs
                            string myCase = Console.ReadLine();

                                         //checks so case isn't null
                                    while (myCase==null)
                                        {
                                            Console.WriteLine("You have not entered an option , please retype ");
                                            Console.WriteLine("ENTER SCRAMBLED WORDS MANUALLY OR ENTER FILE NAME :  F FOR file, M FOR manual");
                                            myCase =Console.ReadLine();

                                        }

                                    //if picks F :  ExecuteScrambledWordsInFileScenario(); 
                                    //if picks M :  ExecuteScrambledWordsManualEntryScenario();
                            switch (myCase.ToUpper())

                            {

                                case "F":

                                    Console.WriteLine("ENTER FILENAME + EXTENSION");
                                    ExecuteScrambledWordsInFileScenario();

                                    check1 = true;
                                    break;

                                case "M":

                                    Console.WriteLine("ENTER WORDS NEEDED -  SEPARATE WITH COMMAS");
                                    ExecuteScrambledWordsManualEntryScenario();

                                    check1 = true;
                                    break;

                            }
                    //second check kicks in 
                    if (check1 == true)
                            {

                                Console.WriteLine("CONTINUE? Y/N");

                        string myCase2 = Console.ReadLine();
                      
                            while (check2 == false)
                                    {
                                        switch (myCase2.ToUpper())

                                    {
                                        case "Y":

                                            check1 = false;
                                            check2 = true;

                                            break;

                                        case "N":

                                            check2 = true;

                                            break;

                                        default:

                                            Console.WriteLine("WRONG CHARACTER ENTRY TYPE :  Y OR N");

                                            break;

                                    }

                                }

                            }
                            
                                             Console.ReadKey();



                        }

                        catch (Exception e)

                        {

                            Console.WriteLine("Sorry an error has occurred.. " + e.Message);

                        }

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
                    string input = Console.ReadLine();
                    //splits variable into array at each comma 
                    string[] scrambledWords = input.Split(',');

                    DisplayMatchedScrambledWords(scrambledWords);


                }



                private static void DisplayMatchedScrambledWords(string[] scrambledWords)

                {

                    string[] wordList = fileReader.Read(@"wordlist.txt"); 



                    List<MatchedWord> matchedWords = wordMatcher.Match(scrambledWords, wordList);

                    if (matchedWords==null)

                    {

                        Console.WriteLine("no words found");
                    }

                    else if(!(matchedWords == null))

                    {

                        foreach (var s in matchedWords)

                        {
                    // String formattingWord= String.Format("MATCH FOUND FOR{0}{1}", s.scrambledWords, wordList);
                   /*String scrambledWordsFormatted = s.ScrambledWord;
                    String wordWordFormatted = s.Word;*/
                            Console.WriteLine("Match found for " + s.ScrambledWord +" "+ s.Word);
                           
                            // Console.WriteLine(formattingWord);
                        }



                    }
          
          

                }

            }

        }