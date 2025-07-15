namespace RecursiveElements;

public abstract class ElementalWords
{
    private static readonly Dictionary<string, string> Elements = new()
    {
        {"H", "Hydrogen"}, {"He", "Helium"}, {"Li", "Lithium"}, {"Be", "Beryllium"},
        {"B", "Boron"}, {"C", "Carbon"}, {"N", "Nitrogen"}, {"O", "Oxygen"},
        {"F", "Fluorine"}, {"Ne", "Neon"}, {"Na", "Sodium"}, {"Mg", "Magnesium"},
        {"Al", "Aluminium"}, {"Si", "Silicon"}, {"P", "Phosphorus"}, {"S", "Sulfur"},
        {"Cl", "Chlorine"}, {"Ar", "Argon"}, {"K", "Potassium"}, {"Ca", "Calcium"},
        {"Sc", "Scandium"}, {"Ti", "Titanium"}, {"V", "Vanadium"}, {"Cr", "Chromium"},
        {"Mn", "Manganese"}, {"Fe", "Iron"}, {"Co", "Cobalt"}, {"Ni", "Nickel"},
        {"Cu", "Copper"}, {"Zn", "Zinc"}, {"Ga", "Gallium"}, {"Ge", "Germanium"},
        {"As", "Arsenic"}, {"Se", "Selenium"}, {"Br", "Bromine"}, {"Kr", "Krypton"},
        {"Rb", "Rubidium"}, {"Sr", "Strontium"}, {"Y", "Yttrium"}, {"Zr", "Zirconium"},
        {"Nb", "Niobium"}, {"Mo", "Molybdenum"}, {"Tc", "Technetium"}, {"Ru", "Ruthenium"},
        {"Rh", "Rhodium"}, {"Pd", "Palladium"}, {"Ag", "Silver"}, {"Cd", "Cadmium"},
        {"In", "Indium"}, {"Sn", "Tin"}, {"Sb", "Antimony"}, {"Te", "Tellurium"},
        {"I", "Iodine"}, {"Xe", "Xenon"}, {"Cs", "Cesium"}, {"Ba", "Barium"},
        {"La", "Lanthanum"}, {"Ce", "Cerium"}, {"Pr", "Praseodymium"}, {"Nd", "Neodymium"},
        {"Pm", "Promethium"}, {"Sm", "Samarium"}, {"Eu", "Europium"}, {"Gd", "Gadolinium"},
        {"Tb", "Terbium"}, {"Dy", "Dysprosium"}, {"Ho", "Holmium"}, {"Er", "Erbium"},
        {"Tm", "Thulium"}, {"Yb", "Ytterbium"}, {"Lu", "Lutetium"}, {"Hf", "Hafnium"},
        {"Ta", "Tantalum"}, {"W", "Tungsten"}, {"Re", "Rhenium"}, {"Os", "Osmium"},
        {"Ir", "Iridium"}, {"Pt", "Platinum"}, {"Au", "Gold"}, {"Hg", "Mercury"},
        {"Tl", "Thallium"}, {"Pb", "Lead"}, {"Bi", "Bismuth"}, {"Po", "Polonium"},
        {"At", "Astatine"}, {"Rn", "Radon"}, {"Fr", "Francium"}, {"Ra", "Radium"},
        {"Ac", "Actinium"}, {"Th", "Thorium"}, {"Pa", "Protactinium"}, {"U", "Uranium"},
        {"Np", "Neptunium"}, {"Pu", "Plutonium"}, {"Am", "Americium"}, {"Cm", "Curium"},
        {"Bk", "Berkelium"}, {"Cf", "Californium"}, {"Es", "Einsteinium"}, {"Fm", "Fermium"},
        {"Md", "Mendelevium"}, {"No", "Nobelium"}, {"Lr", "Lawrencium"}, {"Rf", "Rutherfordium"},
        {"Db", "Dubnium"}, {"Sg", "Seaborgium"}, {"Bh", "Bohrium"}, {"Hs", "Hassium"},
        {"Mt", "Meitnerium"}, {"Ds", "Darmstadtium"}, {"Rg", "Roentgenium"}, {"Cn", "Copernicium"},
        {"Nh", "Nihonium"}, {"Fl", "Flerovium"}, {"Mc", "Moscovium"}, {"Lv", "Livermorium"},
        {"Ts", "Tennessine"}, {"Og", "Oganesson"}
    };

    public static string[][] ElementalForms(string word)
    {
        var results = new List<List<string>>();
        var lowercaseWord = word.ToLower();

        RecursiveSearch(0, []);

        return results.Select(r => r.ToArray()).ToArray();

        void RecursiveSearch(int index, List<string> currentCombination)
        {
            // if index is at end of word then save current element combination to results array
            if (index == lowercaseWord.Length)
            {
                results.Add([..currentCombination]); 
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
                var sub = lowercaseWord.Substring(index, len);

                // Try to match substring to an element in the table (case-insensitive)
                var symbol = Elements.Keys.FirstOrDefault(k => k.Equals(sub, StringComparison.OrdinalIgnoreCase));
                
                if (symbol == null) continue;
                
                // If found, add to the current list of elements found
                var fullName = Elements[symbol];
                // convert to requested format
                currentCombination.Add($"{fullName} ({symbol})");
                // call recursive function from next letter e.g., Hello -> He found -> len = 2 -> index = 0 + 2 -> start at 'l'
                RecursiveSearch(index + len, currentCombination);
                //Once the recursive call finishes, we undo that last step
                // e.g., we found He, now we can try H
                currentCombination.RemoveAt(currentCombination.Count - 1);
            }
        }
    }
}