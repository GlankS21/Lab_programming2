namespace Lap_1;  
  

public class Program
{
    static void Sort(double[] arr){
        var fist = new double[arr.Length];
        var second = new double[arr.Length];
        // ReSharper disable once InconsistentNaming
        var fistIndex = 0;
        var secondIndex = 0;
        for (int i = 0; i < arr.Length; i++){
            if (Math.Abs(arr[i]) < 1) fist[fistIndex++] = arr[i];
            else second[secondIndex++] = arr[i];
        }
        Array.Copy(fist, 0, arr, 0, fistIndex);
        Array.Copy(second, 0, arr, fistIndex, secondIndex);
    }
    static int Min(double[] arr){
        var min_index = 0;
        for (var i = 1; i < arr.Length; ++i){
            if (arr[i] < arr[min_index]) min_index = i;
        }
        return min_index;
    }
    static double sumElements(double[] arr){
        var fistIndex = int.MinValue; // найти первый отрицательный элемент
        for (var i = 0; i < arr.Length; ++i){ //
            if (arr[i] < 0){
                fistIndex = i;
                break;
            }
        }
        if (fistIndex != int.MinValue){ // найти второй отрицательный элемент
            var se_index = int.MinValue;
            for (var i = fistIndex + 1; i < arr.Length; ++i){
                if (arr[i] < 0){
                    se_index = i;
                    break;
                }
            }
            if (se_index != int.MinValue){ // найти сумму 
                var sum = 0.0;
                for (var i = fistIndex + 1; i < se_index; ++i) sum += arr[i];
                return sum;
            }
        } 
        return Double.MinValue;
    }
    static void Main() {
        uint lengthArray; 
        uint.TryParse(Console.ReadLine(), out lengthArray); 
        var arr = new double[lengthArray]; 
        for (var i = 0; i < arr.Length; ++i)
        {
            double elementArray;  
            double.TryParse(Console.ReadLine(), out elementArray); 
            arr[i] = elementArray;   
        }
        // сортировать массив 
        Sort(arr);
        Console.Write("Matrix : ");
        for (var i = 0; i < arr.Length; ++i) Console.Write(arr[i] + " ");
        Console.WriteLine();

        // number of the minimum array element 
        Console.WriteLine("number of the minimum array element: " + Min(arr));

        // сумму элементов массива, расположенных между первым и вторым отрицательными элементами.
        double sum = sumElements(arr);
        Console.WriteLine(sum == Double.MinValue ? "Error":"the sum of the array elements located between the first and second negative elements: " + sum);
    }
}