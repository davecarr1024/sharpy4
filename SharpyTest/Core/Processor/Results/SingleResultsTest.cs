namespace Sharpy.Core.Processor.Results;

[TestClass]
public class SingleResultsTest
{
    [TestMethod]
    public void TestNo()
    {
        Assert.AreEqual(
            new SingleResults<int>(1).No(),
            new NoResults<int>()
        );
    }

    [TestMethod]
    public void TestSingle()
    {
        Assert.AreEqual(
            new SingleResults<int>(1).Single(),
            new SingleResults<int>(1)
        );
    }

    [TestMethod]
    public void TestOptional()
    {
        Assert.AreEqual(
            new SingleResults<int>(1).Optional(),
            new OptionalResults<int>(1)
            );
    }

    [TestMethod]
    public void TestMultiple()
    {
        Assert.AreEqual(
            new SingleResults<int>(1).Multiple(),
            new MultipleResults<int>(1)
            );
    }

    [TestMethod]
    public void TestNamed()
    {
        Assert.AreEqual(
            new SingleResults<int>(1).Named(),
            new NamedResults<int>(("", 1))
            );
        Assert.AreEqual(
            new SingleResults<int>(1).Named("a"),
            new NamedResults<int>(("a", 1))
            );
    }
}