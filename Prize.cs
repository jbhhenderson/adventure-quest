using Quest;

public class Prize 
{
    private string _text;

    public Prize(string text)
    {
        _text = text;
    }

    public void ShowPrize(Adventurer adventurer)
    {
        if (adventurer.Awesomeness > 0)
        {
            for (int i = 0; i < adventurer.Awesomeness; i++)
            {
                Console.WriteLine(_text);
            }
        }
        else
        {
            Console.WriteLine("What is an adventurer, but a miserable pile of failures.");
        }
    }
}