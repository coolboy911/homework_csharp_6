// Напишите программу, которая реализует обход введенного 
// двумерного массива, начиная с крайнего нижнего левого 
// элемента против часовой стрелки.
// 1 2 3
// 4 5 6 -> 7 8 9 6 3 2 1 4 5
// 7 8 9

int[,] GetMatrix(int size1, int size2)
{
    int[,] array = new int[size1, size2];
    int count = 1;
    for (int i = 0; i < size1; i++)
    {
        for (int j = 0; j < size2; j++)
        {
            array[i, j] = count;
            count++;
        }
    }
    return array;
}

void PrintArray(int[,] matr)
{
    for (int rows = 0; rows < matr.GetLength(0); rows++)
    {
        for (int columns = 0; columns < matr.GetLength(1); columns++)
        {
            Console.Write("{0,-2} ", matr[rows, columns]);
        }
        Console.WriteLine("");
    }
}

void UnwrapMatrix(int[,] matrix)
{
    int maxCount = matrix.GetLength(0) * matrix.GetLength(1);
    int downRow = matrix.GetLength(0) - 1;
    int rightColumn = matrix.GetLength(1) - 1;
    int upRow = 0, leftColumn = 0;
    int i = downRow, j = leftColumn;
    int count = 0;

    while (count < maxCount-1)
    {
        for (; j < rightColumn; j++)
        {
            Console.Write($"{matrix[i,j]} ");
            count++;
        }
        downRow--; // вычеркиваем последний ряд

        for (; i > upRow; i--)
        {
            Console.Write($"{matrix[i,j]} ");
            count++;
        }
        rightColumn--;

        for (; j > leftColumn; j--)
        {
            Console.Write($"{matrix[i,j]} ");
            count++;
        }
        upRow++; // вычеркиваем последний ряд
    
        for (; i < downRow; i++)
        {
            Console.Write($"{matrix[i,j]} ");
            count++;
        }
        leftColumn++;
    }
    Console.Write($"{matrix[i,j]} ");
    // проблема в том что в циклах он сначала принтует потом двигается
    // и в конце остается ячейка которая не была выведена. Поэтому эта строчка нужна
}

Console.Clear();
int[,] matrix = GetMatrix(3,2);
PrintArray(matrix);
Console.WriteLine();
UnwrapMatrix(matrix);