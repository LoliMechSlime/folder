using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArrayLibrary;

namespace ArrayLibraryTest;

[TestClass]
public class ArraySearchTest
{
    [TestMethod]
    public void TestContain()
    {
        var array = new int[] {1,2,3,4,5};
        var expectedIndex = 2;
        var actualIndex = ArraySearch.BinarySearch(array, 3);
        Assert.AreEqual(expectedIndex, actualIndex);
    }

    [TestMethod]
    public void TestDoesNotContain() {
        var array = new int[] {1,2,3,4,5};
        var expectedIndex = -1;
        var actualIndex = ArraySearch.BinarySearch(array, 8);
        Assert.AreEqual(expectedIndex, actualIndex);
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void TestNullArray() {
        int[]? array = null;
        #pragma warning disable
        var actualIndex = ArraySearch.BinarySearch(array, 1);
    }

    [TestMethod]
    public void TestEmptyArray() {
        int[] array = new int[] {};
        var expectedIndex = -1;
        var actualIndex = ArraySearch.BinarySearch(array, 1);
        Assert.AreEqual(expectedIndex, actualIndex);
    }

    [TestMethod]
    public void TestLeftBorderContainMultiplyTarget(){
        var array = new int[] {2,4,4,6};
        var expectedIndex = 0;
        var actualIndex = ArraySearch.FindLeftBorder(array, 4);
        Assert.AreEqual(expectedIndex, actualIndex);
    }

    [TestMethod]
    public void TestLeftBorderTargetBiggerThenRight(){
        var array = new int[] {2,4,4,6};
        var expectedIndex = 3;
        var actualIndex = ArraySearch.FindLeftBorder(array, 7);
        Assert.AreEqual(expectedIndex, actualIndex);
    }

    [TestMethod]
    public void TestLeftBorderTargetLowerThenLeft(){
        var array = new int[] {2,4,4,6};
        var expectedIndex = -1;
        var actualIndex = ArraySearch.FindLeftBorder(array, 0);
        Assert.AreEqual(expectedIndex, actualIndex);
    }

    [TestMethod]
    public void TestLeftBorderEmptyArray(){
        var array = new int[] {};
        var expectedIndex = -1;
        var actualIndex = ArraySearch.FindLeftBorder(array, 5);
        Assert.AreEqual(expectedIndex, actualIndex);
    }
}
