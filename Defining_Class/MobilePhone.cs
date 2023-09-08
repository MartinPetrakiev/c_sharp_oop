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
        private List<Call> CallHistory;
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
