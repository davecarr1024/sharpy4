namespace Sharpy.Core.Containers;

[TestClass]
public class SetTest
{
    [TestMethod]
    public void TestEqual()
    {
        Assert.AreEqual(new Set<int>(), new Set<int>());
        Assert.AreNotEqual(new Set<int>(1), new Set<int>());
        Assert.AreNotEqual(new Set<int>(), new Set<int>(1));
        Assert.AreNotEqual(new Set<int>(1), new Set<int>(2));
        Assert.AreEqual(new Set<int>(1), new Set<int>(1));
        Assert.AreEqual(new Set<int>(1, 1), new Set<int>(1));
        Assert.AreNotEqual(new Set<int>(1), new Set<int>(1, 2));
        Assert.AreNotEqual(new Set<int>(1, 2), new Set<int>(1));
        Assert.AreEqual(new Set<int>(1, 2), new Set<int>(1, 2));
        Assert.AreEqual(new Set<int>(1, 2), new Set<int>(2, 1));
    }

    [TestMethod]
    public void TestOr()
    {
        Assert.AreEqual(new Set<int>() | new Set<int>(), new Set<int>());
        Assert.AreEqual(new Set<int>(1) | new Set<int>(), new Set<int>(1));
        Assert.AreEqual(new Set<int>() | new Set<int>(1), new Set<int>(1));
        Assert.AreEqual(new Set<int>(1) | new Set<int>(1), new Set<int>(1));
        Assert.AreEqual(new Set<int>(1) | new Set<int>(2), new Set<int>(1, 2));
    }
}