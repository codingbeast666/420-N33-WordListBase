using System;
using System.Collections.Generic;

namespace Lab2WS
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();

            foreach (string scrambledWord in scrambledWords)
            {
                foreach (string word in wordList)
                {
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        //matchedWords.Add(BuildMatchedWord(scrambledWord, word));

                        matchedWords.Add(new MatchedWord() { ScrambledWord = scrambledWord, Word = word });

                    }
                    else
                    {
                        //convert strings into character arrays i.e. ToCharArray()
                        //sort both character arrays
                        //convert sorted character arrays into strings (toString)
                        // 
                        //compare the two sorted strings. If they match, build the MatchWord
                        

                                    char[] scrambledArray = scrambledWord.ToCharArray();
                                    char[] wordArray = word.ToCharArray();

                                            Array.Sort(scrambledArray);
                                            Array.Sort(wordArray);

                                    String scrambledWordSorted=scrambledArray.ToString();
                                   string  wordWordSorted = wordArray.ToString();
                        //new string ?
                        if (scrambledWordSorted.Equals(wordWordSorted))
                        {

                            //struct and add to matchedWords list.
                            matchedWords.Add(new MatchedWord() { ScrambledWord = scrambledWord, Word = word });

                        }


                    }

                }
            }

            return matchedWords;
        }

        MatchedWord BuildMatchedWord(string scrambledWord, string word)
        {
            MatchedWord matchedWord = new MatchedWord()
            {
                ScrambledWord = scrambledWord,
                Word = word
            };

            return matchedWord;
        }



    }
}
