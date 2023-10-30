namespace Defining_Class
{
    public enum BatteryType
    {
        LiIon, NiMH, NiCd, Other
    }
 
    public class Battery
    {
        private string model;
        private double hoursIdle;
        private double hoursTalk;
        private BatteryType type;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double HoursIdle
        {
            get { return hoursIdle; }
            set
            {
                if (value >= 0)
                    hoursIdle = value;
                else
                    throw new ArgumentException("HoursIdle cannot be negative.");
            }
        }

        public double HoursTalk
        {
            get { return hoursTalk; }
            set
            {
                if (value >= 0)
                    hoursTalk = value;
                else
                    throw new ArgumentException("HoursTalk cannot be negative.");
            }
        }

        public BatteryType Type
        {
            get { return type; }
            set { type = value; }
        }

        public Battery(string model, BatteryType type)
        {
            this.Model = model;
            this.Type = type;
        }

        public Battery(string model, BatteryType type, double hoursIdle, double hoursTalk) 
        {
            this.Model = model;
            this.Type = type;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
        }
    }
}
