public static class Prompt
{
    //Returns command string
    public static string prompt
    {
        get
        {
            string? line;
            while (true)
            {
                line = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                    break;
            }
            return line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];
        }
    }
}