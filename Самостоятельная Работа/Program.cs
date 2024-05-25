// Задание 1: Сделать чтоб работал на всех положительных значениях. 0, 1, 1, 2, 3, 5, 8, 13, 21..
// Решение: 
int fibonacci(int Xn)
{
    int A = 0;
    int B = 0;
    int X = 0;

    for (int i = 0; i <= Xn; i++)
    {
        X = A + B;
        A = B;
        B = X;

        if (i == 1 || i == 2)
        {
            A = 1;
            X = 1;
        }
        Console.WriteLine($"i ={i}, число равно:{X}");
    }
    return X;
}
fibonacci(20);
//Сonsole.WriteLine(fibonacci(20));