/*
 Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение
  этого элемента или же указание, что такого элемента нет.
Например, задан массив:

1 4 7 2

5 9 2 3

8 4 2 4

17 -> такого числа в массиве нет
[0][1][2][3]
1 4 7 2
[4][5][6][7]
5 9 2 3                            
[8][9][10][11]                     
                                   
8 4 2 4                          

9 -> 4
5 -> 9
*/

int[,] generate2DArray(int lengthRow, int lengthCol, int deviation)
{
    int[,] array = new int[lengthRow, lengthCol];
    for (int i = 0; i < lengthRow; i++)
    {
        for (int j = 0; j < lengthCol; j++)
        {
            array[i, j] = new Random().Next(-deviation, deviation + 1);
        }
    }
    return array;
}

int getElementValueFrom2DArray(int position, int[,] array)
{
    int i = position / array.GetLength(1);
    int j = position % array.GetLength(1);
    return array[i, j];
}

void printColor(string message, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.Write(message);
    Console.ResetColor();
}

int getNumberFromUser(string message)
{
    Console.Write(message);
    return Convert.ToInt32(Console.ReadLine());
}

void print2DArray(int[,] array)
{
    Console.Write("\t");
    for (int i = 0; i < array.GetLength(1); i++)
    {
        printColor(i + "\t", ConsoleColor.Red);
    }
    Console.WriteLine();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        printColor(i + "\t", ConsoleColor.Red);
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + "\t");
        }
        Console.WriteLine();
    }
}
int[,] array = generate2DArray(5, 8, 55);
print2DArray(array);
int position = getNumberFromUser("Введите позицию: ");
if (position > (array.GetLength(0) * array.GetLength(1) - 1) || position < 0)
{
    Console.WriteLine($"Значение с позицией {position} не существует");
}
else
{
    int value = getElementValueFrom2DArray(position, array);
    Console.WriteLine($"Значение в позиции {position}: {value}");
}
