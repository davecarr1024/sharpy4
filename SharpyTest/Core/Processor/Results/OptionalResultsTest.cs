namespace Sharpy.Core.Processor.Results;

[TestClass]
public class OptionalResultsTest
{
    [TestMethod]
    public void TestNo()
    {
        Assert.AreEqual(
            new OptionalResults<int?>().No(),
            new NoResults<int?>()
        );
        Assert.AreEqual(
            new OptionalResults<int?>(1).No(),
            new NoResults<int?>()
        );
    }

    [TestMethod]
    public void TestSingle()
    {
        Assert.ThrowsException<Error<int?>>(() => new OptionalResults<int?>().Single());
        Assert.AreEqual(
            new OptionalResults<int?>(1).Single(),
            new SingleResults<int?>(1)
        );
    }

    [TestMethod]
    public void TestOptional()
    {
        Assert.AreEqual(
            new OptionalResults<int?>().Optional(),
            new OptionalResults<int?>()
            );
        Assert.AreEqual(
            new OptionalResults<int?>(1).Optional(),
            new OptionalResults<int?>(1)
            );
    }

    [TestMethod]
    public void TestMultiple()
    {
        Assert.AreEqual(
            new OptionalResults<int?>().Multiple(),
            new MultipleResults<int?>()
            );
        Assert.AreEqual(
            new OptionalResults<int?>(1).Multiple(),
            new MultipleResults<int?>(1)
            );
    }

    [TestMethod]
    public void TestNamed()
    {
        Assert.AreEqual(
            new OptionalResults<int?>().Named(),
            new NamedResults<int?>()
            );
        Assert.AreEqual(
            new OptionalResults<int?>().Named("a"),
            new NamedResults<int?>()
            );
        Assert.AreEqual(
            new OptionalResults<int?>(1).Named(),
            new NamedResults<int?>(("", 1))
            );
        Assert.AreEqual(
            new OptionalResults<int?>(1).Named("a"),
            new NamedResults<int?>(("a", 1))
            );
    }
}