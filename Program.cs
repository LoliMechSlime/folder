using ArrayLibrary;

namespace HelloWorld
{
    class Program
    {

        public static void PrintArray(int[] array){
            for(int i = 0; i < array.Length; i++){
                Console.Write(array[i] + " ");
            }
        }

        public static void Main()
        {
            var array = new int[100];
            for(int i = 0; i < array.Length; i++){
                array[i] = new Random().Next(0,100);
            }
            PrintArray(array);
            Console.WriteLine();
            var index = ArrayLibrary.BinarySearch(array, 2);
            PrintArray(index);
        }
    }
}
