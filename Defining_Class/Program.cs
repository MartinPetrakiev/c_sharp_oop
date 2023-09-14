using System.Threading;

namespace Defining_Class
{
    class Program
    {

        public static void Main(string[] args)
        {
            Battery phoneBattery = new Battery("LC-C230", BatteryType.LiIon, 71,35);
            Display phoneDisplay = new Display(6.6, 16000000);

            MobilePhone phoneMobilePhone = new MobilePhone("Samsung", "Galaxy S23", (decimal)789.99, phoneBattery, phoneDisplay);

            phoneMobilePhone.PhoneBasicSpec();

            Console.WriteLine();

            Console.WriteLine(phoneMobilePhone.ToString());

            Console.WriteLine();

            MobilePhone iphone4s = MobilePhone.IPhone4S;
            Console.WriteLine(iphone4s.ToString());

            //GSM test
            MobilePhone[] mobilePhonesArray = new MobilePhone[]
            {   
                new MobilePhone("Galaxy S21", "Samsung", (decimal)799.99, new Battery("ABC123",  BatteryType.LiIon, 48, 8), new Display(5.0, 16000000)),
                new MobilePhone("iPhone X", "Apple", (decimal)999.99, new Battery("XYZ456", BatteryType.LiIon, 36, 10), new Display(5.8, 16000000)),
                new MobilePhone("Pixel 5", "Google", (decimal)699.99, new Battery("LMN789", BatteryType.LiIon, 48, 9), new Display(6.0, 16000000))
            };

            //Print phones array
            for (int i = 0; i < mobilePhonesArray.Length; i++)
            {
                Console.WriteLine($"Mobile Phone {i + 1}:\n");
                Console.WriteLine(mobilePhonesArray[i].ToString());
                Console.WriteLine(new string('-', 50));
            }

            Console.WriteLine(MobilePhone.IPhone4S);

            var firstCall = new Call("+35988787878");
            var secondCall = new Call("+35922887878");
            var galaxyPhone = mobilePhonesArray[0];

            galaxyPhone.StartCall(firstCall);
            galaxyPhone.EndCall(firstCall);

            galaxyPhone.StartCall(secondCall);
            galaxyPhone.EndCall(secondCall);

            Console.WriteLine(new string('-', 50));

            //Call history
            galaxyPhone.ViewCallHistory();

            //Phone bill
            galaxyPhone.PhoneBill();

            galaxyPhone.ClearCallHistory();

            Console.WriteLine(new string('-', 50));

            //Phone bill after "paying/clearing history"
            galaxyPhone.PhoneBill();

            Console.ReadKey();
        }
    }
}

/*
1 Define Class
Define a class that holds information about a mobile phone device: 
model, manufacturer, price, owner, battery characteristics (model, hours idle and hours talk) and display characteristics (size and number of colors).
Define 3 separate classes (class GSM holding instances of the classes Battery and Display)

2 Constructors
Define several constructors for the defined classes that take different sets of arguments (the full information for the class or part of it).
Assume that model and manufacturer are mandatory (the others are optional). All unknown data fill with null.

3 Enumeration
Add an enumeration BatteryType (Li-Ion, NiMH, NiCd, …) and use it as a new field for the batteries.

4 ToString
Add a method in the GSM class for displaying all information about it.
Try to override ToString().

5 Properties
Use properties to encapsulate the data fields inside the GSM, Battery and Display classes.
Ensure all fields hold correct data at any given time.

6 Static field
Add a static field and a property IPhone4S in the GSM class to hold the information about iPhone 4S.

7 GSM test
Write a class GSMTest to test the GSM class:
Create an array of few instances of the GSM class.
Display the information about the GSMs in the array.
Display the information about the static property IPhone4S.

8 Calls
Create a class Call to hold a call performed through a GSM.
It should contain date, time, dialled phone number and duration (in seconds).

9 Call history
Add a property CallHistory in the GSM class to hold a list of the performed calls.
Try to use the system class List<Call>.

10 Add/Delete calls
Add methods in the GSM class for adding and deleting calls from the calls history.
Add a method to clear the call history.

11 Call price
Add a method that calculates the total price of the calls in the call history.
Assume the price per minute is fixed and is provided as a parameter.

12 Call history test
Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
Create an instance of the GSM class.
Add a few calls.
Display the information about the calls.
Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
Remove the longest call from the history and calculate the total price again.
Finally clear the call history and print it.
*/