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