// Пользователь вводит с клавиатуры M чисел. 
// Посчитайте, сколько чисел больше 0 ввёл пользователь.
// 0, 7, 8, -2, -2 -> 2
// 1, -7, 567, 89, 223-> 3

// Я сделал сложно но с вводом элементов не через Enter
// пример ввода: 5... -3 5   32 /,,, -5 (он это прожуёт)
int[] GetEmptyArray(string text)
{
    int count = 0;
    for (int i = 0; i < text.Length - 1; i++)
    {
        // если элемент i цифра и следующий элемент НЕ цифра, то count++
        if ((char.IsDigit(text[i])) && !char.IsDigit(text[i + 1])) count++;
    }
    if (char.IsDigit(text[text.Length - 1])) count++;
    int[] array = new int[count];
    return array;
}

int[] FillArray(string text)
{
    int[] array = GetEmptyArray(text);
    int count = 0;
    string temp = "";

    for (int i = 0; i < text.Length - 1; i++)
    {
        if (char.IsNumber(text[i]) || text[i] == '-')
        {
            temp += text[i];
        }
        else if (char.IsNumber(text[i + 1]) || text[i + 1] == '-')
        {
            array[count] = int.Parse(temp);
            temp = "";
            count++;
        }
    }
    if (char.IsNumber(text[text.Length - 1])) temp += text[text.Length - 1];
    // дописываем в temp последний элемент если это цифра
    array[count] = int.Parse(temp);
    return array;
}

int CountBiggerThenZero(int[] array)
{
    int count = 0;
    foreach (int el in array)
    {
        if (el > 0) count++;
    }
    return count;
}

Console.Clear();
Console.Write("Введите последовательность чисел: ");
string numbers = Console.ReadLine()!;
int[] array = FillArray(numbers);  
// да мы все введенное преобразовали в массив только из чисел
Console.WriteLine(CountBiggerThenZero(array));