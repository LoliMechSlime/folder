namespace ArrayLibrary;

public static class ArraySearch
{
    public static int BinarySearch(int[] array, int target)
    {
        if (array.Length == 0)
            return -1;
        var left = 0;
        var right = array.Length - 1;
        while (left < right)
        {
            var middle = left + (right - left) / 2;
            if (target <= array[middle])
                right = middle;
            else left = middle + 1;
        }
        if (array[right] == target)
            return right;
        return -1;
    }

    public static int FindLeftBorder(int[] array, int target)
    {
        return BinSearchLeftBorder(array, target, -1, array.Length);
    }

    private static int BinSearchLeftBorder(int[] array, int target, int left, int right)
    {
        if (right - left == 1)
            return left;
        int mid = (left + right) / 2;
        if (array[mid] < target)
            return BinSearchLeftBorder(array, target, mid, right);
        return BinSearchLeftBorder(array, target, left, mid);
    }
}
