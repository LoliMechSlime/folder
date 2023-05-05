using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArrayLibrary;

namespace ArrayLibraryTest;

[TestClass]
public class ArraySortTest {

    [TestMethod]
    public void TestPositive() {
        var array = new int[] {5,4,3,2,1};
        var expectedArray = new int[] {1,2,3,4,5};
        ArraySort.BubbleSort(array);
        for(int i = 0; i < array.Length; i ++)
            Assert.AreEqual(expectedArray[i], array[i]);
    }

    [TestMethod]
    public void TestNegative() {
        var array = new int[] {-5,4,-3,2,1};
        var expectedArray = new int[] {-5,-3,1,2,4};
        ArraySort.BubbleSort(array);
        for(int i = 0; i < array.Length; i ++)
            Assert.AreEqual(expectedArray[i], array[i]);
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void TestNullArray() {
        int[]? array = null;
        #pragma warning disable
        ArraySort.BubbleSort(array);
    }

}
