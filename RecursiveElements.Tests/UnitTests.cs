namespace RecursiveElements.Tests;

[TestFixture]
public class RecursiveElementWordSolverTests
{
    [Test]
    public void Should_Return_Empty_When_Word_Has_No_Valid_Combination()
    {
        var result = ElementalWordSolver.GetElementalForms("xyz");
        Assert.That(result, Has.Length.EqualTo(0));

    }

    [Test]
    public void Should_Match_Single_Element()
    {
        var result = ElementalWordSolver.GetElementalForms("H");
        Assert.That(result.Length, Is.EqualTo(1));
        Assert.That(result[0], Is.EquivalentTo(new[] { "Hydrogen (H)" }));
    }

    [Test]
    public void Should_Match_Case_Insensitive()
    {
        var lower = ElementalWordSolver.GetElementalForms("na");
        var upper = ElementalWordSolver.GetElementalForms("NA");

        Assert.That(lower.Length, Is.GreaterThan(0));
        Assert.That(upper.Length, Is.EqualTo(lower.Length));
    }

    [Test]
    public void Should_Find_All_Combinations_For_Snack()
    {
        var result = ElementalWordSolver.GetElementalForms("snack");

        var expected1 = new[] { "Sulfur (S)", "Nitrogen (N)", "Actinium (Ac)", "Potassium (K)" };
        var expected2 = new[] { "Sulfur (S)", "Sodium (Na)", "Carbon (C)", "Potassium (K)" };
        var expected3 = new[] { "Tin (Sn)", "Actinium (Ac)", "Potassium (K)" };

        Assert.That(result, Has.Exactly(3).Items);
        Assert.That(result, Has.One.EqualTo(expected1));
        Assert.That(result, Has.One.EqualTo(expected2));
        Assert.That(result, Has.One.EqualTo(expected3));
    }

    [Test]
    public void Should_Handle_Empty_String()
    {
        var result = ElementalWordSolver.GetElementalForms("");
        Assert.That(result, Has.Length.EqualTo(0));

    }
}