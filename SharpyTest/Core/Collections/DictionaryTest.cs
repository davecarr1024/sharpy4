namespace Sharpy.Core.Containers;

[TestClass]
public class TestDictionary
{
    [TestMethod]
    public void TestEqual()
    {
        Assert.AreEqual(new Dictionary<string, int>(), new Dictionary<string, int>());
        Assert.AreNotEqual(
            new Dictionary<string, int>(("a", 1)),
            new Dictionary<string, int>()
        );
        Assert.AreNotEqual(
            new Dictionary<string, int>(),
            new Dictionary<string, int>(("a", 1))
        );
        Assert.AreEqual(
            new Dictionary<string, int>(("a", 1)),
            new Dictionary<string, int>(("a", 1))
        );
        Assert.AreNotEqual(
            new Dictionary<string, int>(("a", 1)),
            new Dictionary<string, int>(("b", 1))
        );
        Assert.AreNotEqual(
            new Dictionary<string, int>(("a", 1)),
            new Dictionary<string, int>(("a", 2))
        );
        Assert.AreEqual(
           new Dictionary<string, int>(("a", 1)),
           new Dictionary<string, int>(("a", 1))
        );
        Assert.AreNotEqual(
          new Dictionary<string, int>(("a", 1)),
          new Dictionary<string, int>(("a", 1), ("b", 2))
        );
        Assert.AreNotEqual(
          new Dictionary<string, int>(("a", 1), ("b", 2)),
          new Dictionary<string, int>(("a", 1))
        );
        Assert.AreEqual(
          new Dictionary<string, int>(("a", 1), ("b", 2)),
          new Dictionary<string, int>(("a", 1), ("b", 2))
        );
        Assert.AreEqual(
          new Dictionary<string, int>(("a", 1), ("b", 2)),
          new Dictionary<string, int>(("b", 2), ("a", 1))
        );
    }

    [TestMethod]
    public void TestOr()
    {
        Assert.AreEqual(
            new Dictionary<string, int>() | new Dictionary<string, int>(),
            new Dictionary<string, int>()
        );
        Assert.AreEqual(
            new Dictionary<string, int>(("a", 1)) | new Dictionary<string, int>(),
            new Dictionary<string, int>(("a", 1))
        );
        Assert.AreEqual(
            new Dictionary<string, int>() | new Dictionary<string, int>(("a", 1)),
            new Dictionary<string, int>(("a", 1))
        );
        Assert.AreEqual(
            new Dictionary<string, int>(("a", 1)) | new Dictionary<string, int>(("a", 1)),
            new Dictionary<string, int>(("a", 1))
        );
        Assert.AreEqual(
            new Dictionary<string, int>(("a", 1)) | new Dictionary<string, int>(("b", 2)),
            new Dictionary<string, int>(("a", 1), ("b", 2))
        );
    }
}