void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            System.Console.Write($"{matrix[i, j]} ");
        }
        System.Console.WriteLine();
    }
}

// 63. Сформировать трехмерный массив не повторяющимися двузначными числами 
// показать его построчно на экран выводя индексы соответствующего элемента
int[,,] UniqueTwoDigitNumbersArray(int a, int b, int c)
{
    int[,,] matrix = new int[a, b, c];
    if (a * b * c > 90)
    {
        System.Console.WriteLine("Массив такого размера невозможно заполнить уникальными двузначными числами.");
        return matrix;
    }
    int currentNumber = 10;
    for (int k = 0; k < a; k++)
    {
        for (int i = 0; i < b; i++)
        {
            for (int j = 0; j < c; j++)
            {
                matrix[i, j, k] = currentNumber;
                currentNumber++;
            }
        }
    }
    return matrix;
}

void Print3DWithIndex(int[,,] matrix)
{
    for (int k = 0; k < matrix.GetLength(2); k++)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                System.Console.WriteLine($"Indices:{i},{j},{k} Element:{matrix[i, j, k]} ");
            }
        }
    }
}

// 64. Показать треугольник Паскаля
void ShowPascalsTriangle(int stopString)
{
    if (stopString > 0)
    {
        int[] currentString = new int[stopString + 2];
        int[] bufferString = new int[stopString + 2];
        bufferString[1] = 1;
        for (int lengthString = 1; lengthString <= stopString; lengthString++)
        {
            for (int k = 0; k < (stopString - lengthString); k++)     // Косметическая часть
            {                                                         //
                System.Console.Write(" ");                            //
            }                                                         //
            for (int j = 1; j < lengthString + 1; j++)
            {
                currentString[j] = bufferString[j - 1] + bufferString[j];
                System.Console.Write($"{currentString[j]} ");
            }
            for (int i = 1; i < lengthString + 1; i++)
            {
                bufferString[i] = currentString[i];
            }
            System.Console.WriteLine();
        }
    }
}

// 65. Спирально заполнить двумерный массив
void SpiralFilling(int[,] matrix)
{
    int currentNumber = 1;
    int minSide = 0;
    if (matrix.GetLength(0) <= matrix.GetLength(1)) minSide = matrix.GetLength(0);
    else minSide = matrix.GetLength(1);
    int externalI = 0;
    int externalJ = matrix.GetLength(1) - 1;
    for (int c = 0; c < (minSide / 2) + (minSide % 2); c++)
    {
        for (int j = c; j < matrix.GetLength(1) - c; j++)
        {
            matrix[externalI, j] = currentNumber;
            currentNumber++;
        }
        externalI = matrix.GetLength(0) - c - 1;
        for (int i = c + 1; i < matrix.GetLength(0) - c; i++)
        {
            matrix[i, externalJ] = currentNumber;
            currentNumber++;
        }
        externalJ = c;
        if (c < (minSide / 2) + (minSide % 2) - 1 || matrix.GetLength(0) % 2 == 0 
                 || (matrix.GetLength(1) % 2 == 0 && matrix.GetLength(0) > matrix.GetLength(1)))
        {
            for (int j = matrix.GetLength(1) - c - 2; j > c - 1; j--)
            {
                matrix[externalI, j] = currentNumber;
                currentNumber++;
            }
        }
        externalI = c + 1;
        if (c < (minSide / 2) + (minSide % 2) - 1 || matrix.GetLength(1) % 2 == 0)
        {
            for (int i = matrix.GetLength(0) - c - 2; i > c; i--)
            {
                matrix[i, externalJ] = currentNumber;
                currentNumber++;
            }
        }
        externalJ = matrix.GetLength(1) - c - 2;
    }
}

// int[,,] matrix1 = UniqueTwoDigitNumbersArray(3,3,3);
// Print3DWithIndex(matrix1);
// ShowPascalsTriangle(5);
int[,] spiral = new int[4, 4];
SpiralFilling(spiral);
PrintMatrix(spiral);