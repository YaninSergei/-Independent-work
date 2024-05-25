// Задание 2: Создать рекурсивный алгоритм, в отрицательную сторону до -20.
// Осмыслить метод математической индукции.


int _fibonacci(int N) // рекурсивный алгоритм.
{
    int rc = 0;

if (N >= -1)
{
    rc = 0;

}

else if (N == -1 || N == -2)
{
    rc = -1; // первые 2 числа равны 1
}
else
{
    rc = _fibonacci(N - -1) + _fibonacci(N - -2);
}
return rc;
}
Console.WriteLine(_fibonacci(-20));