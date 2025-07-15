namespace RecursiveElements;

using System.Collections.Generic;
using System.Linq;

public static class ElementalWordSolver
{
    public static string[][] GetElementalForms(string word)
    {
        // return an empty array if the word is null or empty
        if (string.IsNullOrWhiteSpace(word))
            return [];
        
        var results = new List<List<string>>();
        var lowercaseWord = word.ToLowerInvariant();

        Search(0, []);
        
        return results.Select(r => r.ToArray()).ToArray();

        void Search(int index, List<string> currentForm)
        {
            // if index is at end of word then save the current element combination to results array
            if (index == lowercaseWord.Length)
            {
                results.Add([..currentForm]);
                return;
            }

            // check for matching combinations for lengths 1-3 eg, (HELLO) H, HE, HEL
            for (var len = 1; len <= 3 && index + len <= lowercaseWord.Length; len++)
            {
                // take the substring for the current length e.g.:
                // word = hello
                // len = 1 substring = h
                // len = 2 substring = he
                // len = 3 substring = hel
                var substring = lowercaseWord.Substring(index, len);

                // Try to match substring to an element in the table (case-insensitive)
                if (!ElementDictionary.TryGetElement(substring, out var formatted)) continue;
                
                // If found, add to the current list of elements found
                currentForm.Add(formatted);
                // call recursive function from next letter e.g., Hello -> He found -> len = 2 -> index = 0 + 2 -> start at 'l'
                Search(index + len, currentForm);
                //Once the recursive call finishes, we undo that last step
                // e.g., we found He, now we can try H
                currentForm.RemoveAt(currentForm.Count - 1);
            }
        }
    }
}
