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

                            Console.WriteLine(Constants.askInput);


                                    //reads case that user inputs
                            string myCase = Console.ReadLine();

                                         //checks so case isn't null
                                    while (myCase==null)
                                        {
                                            Console.WriteLine(Constants.noEnteredOption);
                                            Console.WriteLine(Constants.askInput);
                                            myCase =Console.ReadLine();

                                        }

                                    //if picks F :  ExecuteScrambledWordsInFileScenario(); 
                                    //if picks M :  ExecuteScrambledWordsManualEntryScenario();
                            switch (myCase.ToUpper())

                            {

                                case "F":

                                    Console.WriteLine(Constants.enterFileName);
                                    ExecuteScrambledWordsInFileScenario();

                                    check1 = true;
                                    break;

                                case "M":

                                    Console.WriteLine(Constants.manualWordEntry);
                                    ExecuteScrambledWordsManualEntryScenario();

                                    check1 = true;
                                    break;

                            }
                    //second check kicks in 
                    if (check1 == true)
                            {

                                    Console.WriteLine(Constants.askToContinue);

                      
                                while (check2 == false)
                                        {
                            string myCase2 = Console.ReadLine();
                                            switch (myCase2.ToUpper())

                                    {
                                        case "Y":
                                    //allows loop (first while loop) to re-iterate
                                            check1 = false;
                                            check2 = true;

                                            break;

                                        case "N":

                                            check2 = true;

                                            break;

                                        default:

                                            Console.WriteLine(Constants.wrongCharacter);

                                            break;

                                    }

                                }

                            }
                            
                                             Console.ReadKey();



                        }
                //exception handling
                        catch (Exception e)

                        {

                            Console.WriteLine(Constants.errorOccured + e.Message);

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

                    string[] wordList = fileReader.Read(@Constants.fileName); 



                    List<MatchedWord> matchedWords = wordMatcher.Match(scrambledWords, wordList);

                    if (matchedWords==null)

                    {

                        Console.WriteLine(Constants.noWordsError);
                    }

                    else if(!(matchedWords == null))

                    {

                        foreach (var s in matchedWords)

                        {
                    // String formattingWord= String.Format("MATCH FOUND FOR{0}{1}", s.scrambledWords, wordList);
                   /*String scrambledWordsFormatted = s.ScrambledWord;
                    String wordWordFormatted = s.Word;*/
                            Console.WriteLine(Constants.matchFound + s.ScrambledWord +" "+ s.Word);
                           
                            // Console.WriteLine(formattingWord);
                        }



                    }
          
          

                }

            }

        }