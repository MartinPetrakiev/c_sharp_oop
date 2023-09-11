using System.Diagnostics;

namespace Defining_Class
{   
    interface IPhone4S
    {
        string manufacturer 
        {
            get { return "Apple"; }
        }
        string model
        {
            get { return "iPhone 4S";  }
        }

    }

    public class MobilePhone
    {
        private string manufacturer;
        private string model;
        private decimal price;
        private Battery phoneBattery;
        private Display phoneDisplay;
        private List<Call> CallHistory = new List<Call>();
        public static MobilePhone IPhone4S = new MobilePhone("Apple", "iPhone 4S", (decimal)399.99, new Battery("XYZ789", BatteryType.LiIon, 48, 8), new Display(3.5, 16000000));

        public string Model 
        {
            get { return model; }
            set { model = value; }
        }

        public string Manufacturer 
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                if (value >= 0)
                    price = (decimal)value;
                else
                    throw new ArgumentException("Price cannot be negative.");
            }
        }

        public Battery PhoneBattery 
        {
            get { return phoneBattery; }
            set { phoneBattery = value; }
        }

        public Display PhoneDisplay 
        {
            get { return phoneDisplay; }
            set { phoneDisplay = value; }
        }

        public MobilePhone(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
        }

        public MobilePhone(string manufacturer, string model, decimal price, Battery battery, Display display)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.PhoneBattery = battery;
            this.PhoneDisplay = display;
        }

        public void AddCall(Call currentCall)
        {
            this.CallHistory.Add(currentCall);
        }

        public void RemoveCall(Call currentCall) 
        {
            this.CallHistory.Remove(currentCall);
        }

        public void ViewCallHistory()
        {
            foreach (Call call in this.CallHistory)
            {
                Console.WriteLine(
                    $"Dialled phone number: {call.DialledPhoneNumber}\n" +
                    $"Date: {call.Date}\n" +
                    $"Call duration: {call.CallDuration / 60} min and {call.CallDuration % 60} sec\n" +
                    $"Call price: ${call.CallPrice:F2}\n"
                    );
                Console.WriteLine(new string('-', 50));
            }
        }

        public void ClearCallHistory()
        {
            this.CallHistory.Clear();
        }

        public void StartCall(Call currentCall)
        {
            Console.WriteLine($"Calling {currentCall.DialledPhoneNumber}...");
            Thread.Sleep(1000);
        }

        public void EndCall(Call currentCall)
        {
            DateTime endTime = DateTime.Now;
            currentCall.CallDuration = (int)(endTime - currentCall.Date).Seconds;
            currentCall.CallPrice = Decimal.Divide(currentCall.CallDuration, 60) * (decimal)0.37;
            Console.WriteLine($"Call ended after {currentCall.CallDuration} seconds.");
            this.AddCall(currentCall);
        }

        public void PhoneBill()
        {
            decimal totalPrice = 0;
            foreach (Call call in this.CallHistory)
            {
                totalPrice += call.CallPrice;
            }
            Console.WriteLine($"Phone bill: ${totalPrice:F2}");
        }

        public void PhoneBasicSpec()
        {
            Console.WriteLine($"Manufacturer: {Manufacturer}");
            Console.WriteLine($"Model: {Model}");
            if (Price > 0)
            {
                Console.WriteLine($"Price: {Price:F2}$");
            }
        }

        public override string ToString()
        {
            return $"Phone: {Manufacturer} {Model}\n" +
                   $"Price: {Price:F2}$\n" +
                   $"- Display\n" +
                   $"  Size: {PhoneDisplay.Size:F1}\"\n" +
                   $"  Number of Colors: {PhoneDisplay.NumberOfColors}\n" +
                   $"- Battery\n" +
                   $"  Battery Model: {PhoneBattery.Model}\n" +
                   $"  Battery Type: {PhoneBattery.Type}\n" +
                   $"  Battery Hours Idel: {PhoneBattery.HoursIdle} hours\n" +
                   $"  Battery Hours Talk: {PhoneBattery.HoursTalk} hours\n";
        }
    }
}
