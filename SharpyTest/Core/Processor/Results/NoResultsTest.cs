namespace Sharpy.Core.Processor.Results;

[TestClass]
public class NoResultsTest
{
    [TestMethod]
    public void TestNo()
    {
        Assert.AreEqual(
            new NoResults<int>().No(),
            new NoResults<int>()
        );
    }

    [TestMethod]
    public void TestSingle()
    {
        Assert.ThrowsException<Error<int>>(() => new NoResults<int>().Single());
    }

    [TestMethod]
    public void TestOptional()
    {
        Assert.AreEqual(new NoResults<int>().Optional(), new OptionalResults<int>());
    }

    [TestMethod]
    public void TestMultiple()
    {
        Assert.AreEqual(new NoResults<int>().Multiple(), new MultipleResults<int>());
    }

    [TestMethod]
    public void TestNamed()
    {
        Assert.AreEqual(new NoResults<int>().Named(), new NamedResults<int>());
        Assert.AreEqual(new NoResults<int>().Named("a"), new NamedResults<int>());
    }
}