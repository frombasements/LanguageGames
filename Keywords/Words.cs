using Newtonsoft.Json;
using System.Reflection;

namespace Keywords
{
    public class Words
    {
        IEnumerable<Word> words;

        
        /// <summary>
        /// Returns the word with the least points from translation list 
        /// </summary>
        /// <returns></returns>
        public Word GetWord()
        {
            if (words is null) {
                return new Word("", "");
            }
            return words.OrderBy(_ => _.Points).FirstOrDefault();
        }


        public void Start()
        {
            words = DataHandler.LoadJson();
            var word = GetWord();

            //The game
            while (true)
            {
                C(String.Empty);
                C("Get a new word? (Y/N)");
                var key = Console.ReadKey();
                if (key.KeyChar == 'N') break;
                else if (key.KeyChar != 'Y') continue;

                C(String.Empty);
                C("Translate the following word");
                var r = AskUserToTranslate(word);
                if (r == 'E')
                {
                    C("Error");
                    break;
                }
                if (r == 'N') word = GetWord();
                if (r == 'Q') break;

            }
        }

        /// <summary>
        /// Writes text to command line
        /// </summary>
        /// <param name="v"></param>
        private static void C(string v)
        {
            Console.WriteLine(v);
        }



        private static char AskUserToTranslate(Word word, string revealed = "")
        {
            if (String.IsNullOrEmpty(word.SP)) return 'E'; 

            //User got so many hints that the word is revealed
            if (word.SP == revealed)
            {
                C($"Correct answer was: {word.SP}");
                return 'N';
            }

            C(String.Empty);
            C(word.EN);

            //Hint was asked 
            if (revealed.Length > 0) C($"Hint: {revealed}");

            var answer = Console.ReadLine();

            //Wrong answer
            if (answer.ToLower() != word.SP.ToLower())
            {
                word.Points -= 1;
                C("Incorrect. Want to try again (A), get a hint (H) Or get Answer (G) or quit by (Q)");
                var key = Console.ReadKey();
                C(String.Empty);

                switch (key.KeyChar)
                {
                    case 'A': AskUserToTranslate(word); break;
                    case 'H': AskUserToTranslate(word, revealed = revealed + word.SP[revealed.Length]); break;
                    case 'G': AskUserToTranslate(word, revealed = word.SP.ToString()); break;
                    case 'Q': return 'Q';
                }
                return 'N';
            }

            //right answer
            else
            {
                word.Points += 1;
                C(String.Empty);
                C("Correct!");
                return 'N';
            }
        }

        /// <summary>
        /// Ends the game
        /// </summary>
        public void End()
        {
            DataHandler.StorePoints(words);
        }
    }
}
