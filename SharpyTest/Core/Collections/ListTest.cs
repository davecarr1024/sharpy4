namespace Sharpy.Core.Containers;

[TestClass]
public class ListTest
{
    [TestMethod]
    public void TestEqual()
    {
        Assert.AreEqual(new List<int>(), new List<int>());
        Assert.AreNotEqual(new List<int>(), new List<int>(1));
        Assert.AreNotEqual(new List<int>(1), new List<int>());
        Assert.AreEqual(new List<int>(1), new List<int>(1));
        Assert.AreNotEqual(new List<int>(1, 2), new List<int>(1));
        Assert.AreNotEqual(new List<int>(1), new List<int>(1, 2));
        Assert.AreEqual(new List<int>(1, 2), new List<int>(1, 2));
        Assert.AreNotEqual(new List<int>(2, 1), new List<int>(1, 2));
    }
}