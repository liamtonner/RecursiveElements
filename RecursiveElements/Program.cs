namespace RecursiveElements;



public static class Program
{
    public static void Main()
    {
        const string word = "Snack";
        var results = ElementalWords.ElementalForms(word);
        
        if(results.Length <= 0)
        {
            Console.WriteLine("No elemental forms found.");
            return;
        }

        foreach (var result in results)
        {
            Console.WriteLine(string.Join(", ", result));
        }
    }
}