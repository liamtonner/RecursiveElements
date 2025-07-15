# 🧪 ElementalWords

This C# console application explores all possible combinations of periodic element symbols that can be used to spell out a given word. 
If a word can be formed by stringing together valid element symbols (like `He` for Helium or `Li` for Lithium), the program 
will return each valid elemental form in the format:
Hydrogen (H), Helium (He), Lithium (Li)

---

## 🛠 Features

- ✅ Case-insensitive matching of element symbols
- ✅ Uses a complete dictionary of periodic elements
- ✅ Recursively generates all valid combinations
- ✅ Returns all "elemental forms" of a given word, or none if not possible

---

## 💡 Example

Input:
Hello

Output:
Hydrogen (H), Erbium (Er), Lawrencium (Lr), Oxygen (O)
Helium (He), Lithium (Li), Oxygen (O)


---

## 🧩 How It Works

1. The program starts at the beginning of the word.
2. It tries every substring of 1 to 3 characters to match an element symbol.
3. If a match is found, it continues recursively with the rest of the word.
4. All successful combinations are collected and displayed.


