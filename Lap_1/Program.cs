namespace Lap_1;  
  
public class Program
{
    static void Sort(double[] arr){
        var fist = new double[arr.Length];
        var second = new double[arr.Length];
        // ReSharper disable once InconsistentNaming
        var fi_index = 0;
        var se_index = 0;
        for (int i = 0; i < arr.Length; i++){
            if (Math.Abs(arr[i]) < 1) fist[fi_index++] = arr[i];
            else second[se_index++] = arr[i];
        }
        Array.Copy(fist, 0, arr, 0, fi_index);
        Array.Copy(second, 0, arr, fi_index, se_index);
    }
    static int Min(double[] arr){
        var min_index = 0;
        for (var i = 1; i < arr.Length; ++i){
            if (arr[i] < arr[min_index]) min_index = i;
        }
        return min_index;
    }
    static double sum_elements(double[] arr){
        var fi_index = int.MinValue; // найти первый отрицательный элемент
        for (var i = 0; i < arr.Length; ++i){ //
            if (arr[i] < 0){
                fi_index = i;
                break;
            }
        }
        if (fi_index != int.MinValue){ // найти второй отрицательный элемент
            var se_index = int.MinValue;
            for (var i = fi_index + 1; i < arr.Length; ++i){
                if (arr[i] < 0){
                    se_index = i;
                    break;
                }
            }
            if (se_index != int.MinValue){ // найти сумму 
                var sum = 0.0;
                for (var i = fi_index + 1; i < se_index; ++i) sum += arr[i];
                return sum;
            }
        } 
        return Double.MinValue;
    }
    static void Main(){
        var n = int.Parse(Console.ReadLine());
        var arr = new double[n];
        for (var i = 0; i < arr.Length; ++i)
            arr[i] = double.Parse(Console.ReadLine());
        // сортировать массив 
        Sort(arr);
        Console.Write("Matrix : ");
        for (var i = 0; i < arr.Length; ++i) Console.Write(arr[i] + " ");
        Console.WriteLine();

        // number of the minimum array element 
        Console.WriteLine("number of the minimum array element: " + Min(arr));

        // сумму элементов массива, расположенных между первым и вторым отрицательными элементами.
        double sum = sum_elements(arr);
        Console.WriteLine(((sum == Double.MinValue) ? "Error":"the sum of the array elements located between the first and second negative elements: " + sum));
    }
}