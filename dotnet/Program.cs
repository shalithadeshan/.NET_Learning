using System;
// Console.WriteLine("Hello World!");
// int num1;
// int num1 = 10;
// int num2 = 11;

// if(num1 % 2 == 0) {
//    Console.WriteLine("This Number is Even " +num1); 
// } 
// if(num2 % 2 == 1) {
//    Console.WriteLine("This Number is Odd " +num2);  
// }

void CheckEvenOrOdd(string numberString)
{
    if (int.TryParse(numberString, out int num))
    {
        if (num % 2 == 0)
        {
            Console.WriteLine($"{num}This number is Even.");
        }
        else
        {
            Console.WriteLine($@"{num} This number is Odd");
        }
    }
    else
    {
        Console.WriteLine($@"{num} Tnis is not a Number");
    }

}


Console.WriteLine("Enter Integer:- ");
CheckEvenOrOdd(Console.ReadLine());


Console.WriteLine("----------------------------------");

Console.WriteLine("Enter list of integers with , (10, 20, 22) :-");

string temp = Console.ReadLine();

Console.WriteLine("These values come from variable:- " + temp);

// spilt those values

var tempArry = temp.Split(',');

foreach (var item in tempArry)
{
    try
    {
        CheckEvenOrOdd(item);
    }
    catch (System.FormatException)
    {
        // Console.WriteLine(ex.Message);
        // Console.WriteLine(ex);
        Console.WriteLine($"{item} is not a integer pls check...!");
    }
    catch (System.Exception ex)
    {
        // Console.WriteLine(ex.Message);
        Console.WriteLine(ex);
    }
    // Console.WriteLine("lol" +item);

}
