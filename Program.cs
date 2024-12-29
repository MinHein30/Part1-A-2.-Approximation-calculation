// See https://aka.ms/new-console-template for more information
using System;

Console.Write("Enter precision (epsilon): ");
if (!double.TryParse(Console.ReadLine(), out double epsilon) || epsilon <= 0)
{
    Console.WriteLine("Invalid precision. Please enter a positive number.");
    return;
}

double pi = CalculatePi(epsilon);
Console.WriteLine($"  Approximation of pi: {pi}");

Console.Write("Enter x (in radians) for sin(x): ");
if (!double.TryParse(Console.ReadLine(), out double x))
{
    Console.WriteLine("Invalid input. Please enter a number.");
    return;
}
double sinX = CalculateSin(x, epsilon);
Console.WriteLine($"  Approximation of sin({x}): {sinX}");

Console.Write("Enter x for ln(1 + x): ");
if (!double.TryParse(Console.ReadLine(), out double lnX))
{
    Console.WriteLine("Invalid input. Please enter a number.");
    return;
}
double lnValue = CalculateLn(lnX, epsilon);
Console.WriteLine($"  Approximation of ln(1 + {lnX}): {lnValue}");

double cosX = CalculateCos(x, epsilon);
Console.WriteLine($"  Approximation of cos({x}): {cosX}");
double CalculatePi(double epsilon)
{
    double pi = 0;
    double term;
    int n = 0;

    do
    {
        term = Math.Pow(-1, n) / (2 * n + 1);
        pi += term;
        n++;
    } while (Math.Abs(term) >= epsilon);

    return pi * 4;
}

double CalculateSin(double x, double epsilon)
{
    double sinX = 0;
    double term;
    int n = 0;

    do
    {
        term = Math.Pow(-1, n) * Math.Pow(x, 2 * n + 1) / Factorial(2 * n + 1);
        sinX += term;
        n++;
    } while (Math.Abs(term) >= epsilon);

    return sinX;
}

double CalculateLn(double x, double epsilon)
{
    if (x <= -1)
    {
        Console.WriteLine("ln(1 + x) is not defined for x <= -1.");
        return double.NaN;
    }

    double lnValue = 0;
    double term;
    int n = 1;

    do
    {
        term = Math.Pow(-1, n - 1) * Math.Pow(x, n) / n;
        lnValue += term;
        n++;
    } while (Math.Abs(term) >= epsilon);

    return lnValue;
}

double CalculateCos(double x, double epsilon)
{
    double cosX = 0;
    double term;
    int n = 0;

    do
    {
        term = Math.Pow(-1, n) * Math.Pow(x, 2 * n) / Factorial(2 * n);
        cosX += term;
        n++;
    } while (Math.Abs(term) >= epsilon);

    return cosX;
}

double Factorial(int n)
{
    double result = 1;
    for (int i = 1; i <= n; i++)
    {
        result *= i;
    }
    return result;
}
