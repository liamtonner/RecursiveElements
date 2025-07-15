namespace RecursiveElements;



public static class Program
{
    public static void Main()
    {
        const string word = "Snack";
        var forms = ElementalWordSolver.GetElementalForms(word);
        
        if(forms.Length <= 0)
        {
            Console.WriteLine("No elemental forms found.");
            return;
        }

        foreach (var result in forms)
        {
            Console.WriteLine(string.Join(", ", result));
        }
    }
}