namespace Sharpy.Core.Processor.Results;

[TestClass]
public class NamedResultsTest
{
    [TestMethod]
    public void TestNo()
    {
        Assert.AreEqual(
            new NamedResults<int?>().No(),
            new NoResults<int?>()
        );
        Assert.AreEqual(
            new NamedResults<int?>(("a", 1)).No(),
            new NoResults<int?>()
        );
        Assert.AreEqual(
            new NamedResults<int?>(("a", 1), ("b", 2)).No(),
            new NoResults<int?>()
        );
    }

    [TestMethod]
    public void TestSingle()
    {
        Assert.ThrowsException<Error<int?>>(() => new NamedResults<int?>().Single());
        Assert.AreEqual(
            new NamedResults<int?>(("a", 1)).Single(),
            new SingleResults<int?>(1)
        );
        Assert.ThrowsException<Error<int?>>(() => new NamedResults<int?>(("a", 1), ("b", 2)).Single());
    }

    [TestMethod]
    public void TestOptional()
    {
        Assert.AreEqual(
            new NamedResults<int?>().Optional(),
            new OptionalResults<int?>()
            );
        Assert.AreEqual(
            new NamedResults<int?>(("a", 1)).Optional(),
            new OptionalResults<int?>(1)
            );
        Assert.ThrowsException<Error<int?>>(() => new NamedResults<int?>(("a", 1), ("b", 2)).Optional());
    }

    [TestMethod]
    public void TestMultiple()
    {
        Assert.AreEqual(
            new NamedResults<int?>().Multiple(),
            new MultipleResults<int?>()
            );
        Assert.AreEqual(
            new NamedResults<int?>(("a", 1)).Multiple(),
            new MultipleResults<int?>(1)
            );
        Assert.AreEqual(
            new NamedResults<int?>(("a", 1), ("b", 2)).Multiple(),
            new MultipleResults<int?>(1, 2)
            );
    }

    [TestMethod]
    public void TestNamed()
    {
        Assert.AreEqual(
            new NamedResults<int?>().Named(),
            new NamedResults<int?>()
            );
        Assert.AreEqual(
            new NamedResults<int?>().Named("a"),
            new NamedResults<int?>()
            );
        Assert.AreEqual(
            new NamedResults<int?>(("a", 1)).Named(),
            new NamedResults<int?>(("a", 1))
            );
        Assert.AreEqual(
            new NamedResults<int?>(("a", 1)).Named("a"),
            new NamedResults<int?>(("a", 1))
            );
        Assert.AreEqual(
            new NamedResults<int?>(("a", 1), ("b", 2)).Named(),
            new NamedResults<int?>(("a", 1), ("b", 2))
            );
        Assert.AreEqual(
            new NamedResults<int?>(("a", 1), ("b", 2)).Named("a"),
            new NamedResults<int?>(("a", 1), ("b", 2))
            );
    }
}