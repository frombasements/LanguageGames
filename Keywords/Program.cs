using Keywords;


class LanguageGame : OutputHandler
{
    static void Main(string[] args)
    {
        C("Welsome to learn Spanish!");
        C("type in Q in order to control setting");

        // Word game
        Words words = new Words();
        words.Start();

        // game ended
        words.End();
        C("Game ended, thank you for playing :) ");
    }
}
