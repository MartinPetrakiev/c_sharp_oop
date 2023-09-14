using Range_Exceptions;

class Program
{
    // Get user input int and validate
    public static int ReadNumberInRange(int start, int end)
    {
        Console.Write($"Enter a number in the range [{start} - {end}]: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number < start || number > end)
        {
            throw new InvalidRangeException<int>("Number is out of range.", start, end);
        }

        return number;
    }

    // Get user input date and validate
    public static DateTime ReadDateInRange(DateTime start, DateTime end)
    {
        Console.Write($"Enter a date in the range [{start:dd.MM.yyyy} - {end:dd.MM.yyyy}]: ");
        DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null);

        if (date < start || date > end)
        {
            throw new InvalidRangeException<DateTime>("Date is out of range.", start, end);
        }

        return date;
    }

    public static void Main()
    {
        try
        {
            // Int ragne test
            int number = ReadNumberInRange(1, 100);
            Console.WriteLine($"Entered number: {number}");

            //Date range test
            DateTime date = ReadDateInRange(new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));
            Console.WriteLine($"Entered date: {date:dd.MM.yyyy}");
        }
        catch (InvalidRangeException<int> intEx)
        {
            Console.WriteLine($"Invalid range for number: {intEx.Message}, Range: [{intEx.Start} - {intEx.End}]");
        }
        catch (InvalidRangeException<DateTime> dateEx)
        {
            Console.WriteLine($"Invalid range for date: {dateEx.Message}, Range: [{dateEx.Start:dd.MM.yyyy} - {dateEx.End:dd.MM.yyyy}]");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input format.");
        }
    }
}


/*
3 Range Exceptions

Define a class InvalidRangeException<T> that holds information about an error condition related to invalid range. It should hold error message and a range definition [start … end].

Write a sample application that demonstrates the InvalidRangeException<int> and InvalidRangeException<DateTime> by entering numbers in the range [1..100] and dates in the range [1.1.1980 … 31.12.2013].
*/