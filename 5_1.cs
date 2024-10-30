using System;

class MyMatrix
{
    private int[,] matrix;
    private int rows;
    private int cols;
    private int minValue;
    private int maxValue;
    private Random random;

    // Конструктор, принимающий число строк и столбцов, и диапазон случайных чисел
    public MyMatrix(int rows, int cols, int minValue, int maxValue)
    {
        this.rows = rows;
        this.cols = cols;
        this.minValue = minValue;
        this.maxValue = maxValue;
        this.random = new Random();

        matrix = new int[rows, cols];
        Fill();
    }

    // Метод для заполнения матрицы случайными числами
    public void Fill()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = random.Next(minValue, maxValue + 1);
            }
        }
    }

    // Метод для изменения размера матрицы с копированием значений
    public void ChangeSize(int newRows, int newCols)
    {
        int[,] newMatrix = new int[newRows, newCols];

        // Копирование значений из старой матрицы в новую
        for (int i = 0; i < Math.Min(rows, newRows); i++)
        {
            for (int j = 0; j < Math.Min(cols, newCols); j++)
            {
                newMatrix[i, j] = matrix[i, j];
            }
        }

        // Заполнение новых элементов случайными числами
        for (int i = 0; i < newRows; i++)
        {
            for (int j = 0; j < newCols; j++)
            {
                if (i >= rows || j >= cols)
                {
                    newMatrix[i, j] = random.Next(minValue, maxValue + 1);
                }
            }
        }

        matrix = newMatrix;
        rows = newRows;
        cols = newCols;
    }

    // Метод для вывода части матрицы на консоль
    public void ShowPartialy(int startRow, int endRow, int startCol, int endCol)
    {
        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = startCol; j <= endCol; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    // Метод для вывода всей матрицы на консоль
    public void Show()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    // Индексатор для доступа к элементам матрицы
    public int this[int index1, int index2]
    {
        get
        {
            if (index1 >= 0 && index1 < rows && index2 >= 0 && index2 < cols)
            {
                return matrix[index1, index2];
            }
            else
            {
                throw new IndexOutOfRangeException("Индексы выходят за пределы матрицы.");
            }
        }
        set
        {
            if (index1 >= 0 && index1 < rows && index2 >= 0 && index2 < cols)
            {
                matrix[index1, index2] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Индексы выходят за пределы матрицы.");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите минимальное значение для случайных чисел:");
        int minValue = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите максимальное значение для случайных чисел:");
        int maxValue = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите количество строк матрицы:");
        int rows = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите количество столбцов матрицы:");
        int cols = int.Parse(Console.ReadLine());

        MyMatrix matrix = new MyMatrix(rows, cols, minValue, maxValue);

        Console.WriteLine("Исходная матрица:");
        matrix.Show();

        Console.WriteLine("Изменение размера матрицы:");
        matrix.ChangeSize(5, 5);
        matrix.Show();

        Console.WriteLine("Частичный вывод матрицы:");
        matrix.ShowPartialy(1, 3, 1, 3);


        Console.WriteLine("Изменение элемента матрицы через индексатор:");
        matrix[0, 0] = 99;
        matrix.Show();
    }
}
