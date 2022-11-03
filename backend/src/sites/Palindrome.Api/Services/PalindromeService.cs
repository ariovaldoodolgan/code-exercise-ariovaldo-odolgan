using System.Text.RegularExpressions;

namespace Palindrome.Api.Services
{
    public class PalindromeService : IPalindromeService
    {
        public bool IsPalindrome(string input)
        {
            try
            {
                if (string.IsNullOrEmpty(input))
                {
                    return false;
                }

                Regex rgx = new Regex("[^0-9a-zA-Z]+");
                string inputWithoutSpecialCharacters = rgx.Replace(input, "");
                var result = true;

                var arrayOfChar = inputWithoutSpecialCharacters.ToLower().ToCharArray();
                var indexRegressivePosition = arrayOfChar.Length - 1;

                for (int i = 0; i <= indexRegressivePosition; i++, indexRegressivePosition--)
                {
                    if (arrayOfChar[i] != arrayOfChar[indexRegressivePosition])
                    {
                        result = false;
                        break;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}