using System.Text.RegularExpressions;

namespace FirstMVCApp.Helpers
{
    public class PalindromeHelper
    {
        public bool IsPalindrome(string inputWord)
        {            
            
            string revWord = ReverseWord(inputWord);            
                                   
            revWord = StripSpecialChars(revWord);
            inputWord = StripSpecialChars(inputWord);

            return (revWord == inputWord);            
        }

        public string ReverseWord(string theWord)
        {            
            string revWord = "";
            
            if (theWord == null) return revWord;
            
            for (int i = theWord.Length - 1; i >= 0; i--)
            {                
                revWord += theWord[i];
            }            
            return revWord;
        }

        public string StripSpecialChars(string theWord)
        {
            return Regex.Replace(theWord.ToLower(), "[^a-zA-Z0-9]+", "");
        }

    }
}
