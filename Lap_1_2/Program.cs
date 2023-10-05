namespace  Lap_1_2;

/*
 * Характеристикой столбца целочисленной матрицы назовем сумму модулей его отрицательных нечетных элементов.
 * Переставляя столбцы заданной матрицы, расположить их в соответствии с ростом характеристик.
 * Найти сумму элементов в тех столбцах, которые содержат хотя бы один отрицательный элемент
 */

public class Program
{
    // Поменяйте местами два столбца массива
    static void swap(int[,] arr, int a, int b) {
        for (var i = 0; i < arr.GetLength(0); ++i) {
            var temp = arr[i, a];
            arr[i, a] = arr[i, b];
            arr[i, b] = temp;
        }
    }
    // Вычислить сумму отрицательных элементов столбцов
    static int[] sub_sum_arr(int[,] arr) {
        var sum = new int[arr.GetLength(1)];
        for (var j = 0; j < arr.GetLength(1); ++j) {
            for (var i = 0; i < arr.GetLength(0); ++i) {
                sum[j] += (arr[i, j] < 0) ? Math.Abs(arr[i, j]) : 0;
            }
        }
        return sum;
    }
    // сортировать массив 
    static void sort_array(int[,] arr)
    {
        // найти сумму 
        var sum = sub_sum_arr(arr);
        // сортировать массив 
        for (var i = 0; i < sum.Length; ++i) {
            for (var j = i; j < sum.Length; ++j) {
                if (sum[i] > sum[j]) {
                    swap(arr, i, j);
                    var temp = sum[i];
                    sum[i] = sum[j];
                    sum[j] = temp;
                }
            }
            
            
            
            
        }
    }

    static int sum_array(int[,] arr)
    {
        var sum_arr = sub_sum_arr(arr);
        var sum = 0;
        for (var j = 0; j < arr.GetLength(1); ++j) {
            if (sum_arr[j] != 0) {
                for (var i = 0; i < arr.GetLength(0); ++i) {
                    sum += arr[i, j];
                }
            }
        }
        return sum;
    }
    // print
    static void print_array(int[,] arr) {
        for (var i = 0; i < arr.GetLength(0); ++i){
            for (var j = 0; j < arr.GetLength(1); ++j){
                Console.Write($"{arr[i,j],5:D}");
            }
            Console.WriteLine();
        }
    }
    static void Main(String[] args)
    {
        // создать массив 
        var n = int.Parse(Console.ReadLine());
        var m = int.Parse(Console.ReadLine());
        var arr = new int[n,m];
        Random r = new Random();
        for (var i = 0; i < n; ++i) {
            for (var j = 0; j < m; ++j){
                arr[i, j] = r.Next(-100,100);
            }
        }
        Console.WriteLine("original array");
        print_array(arr);
        // сортировать 
        sort_array(arr);
        Console.WriteLine("array after sorting");
        print_array(arr);
        // найти сумму 
        Console.WriteLine("sum of columns with at least 1 negative element: " + sum_array(arr));

    }
}

