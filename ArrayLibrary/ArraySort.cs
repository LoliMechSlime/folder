namespace ArrayLibrary;

public static class ArraySort {
    public static void BubbleSort(int[] array){
        for (int i = 0; i < array.Length; i++) {
            for (int j = 0; j < array.Length; j++){
                if(array[i] < array[j]){
                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }
}
