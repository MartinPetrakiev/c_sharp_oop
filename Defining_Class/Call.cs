using System.Text.RegularExpressions;
using System.Threading;

namespace Defining_Class
{
    public class Call
    {
        private DateTime date;
        private string dialledPhoneNumber;
        private int callDuration;

        public DateTime Date
        {
            get { return date; }
            set
            {
                DateTime currentDateTime = DateTime.Now;
                if (DateTime.Compare(value, currentDateTime) > 0)
                {
                    throw new ArgumentException("Date cannot be later than current time.");
                }
                else
                {
                    date = value;
                }
            }
        }

        public string DialledPhoneNumber
        {
            get { return dialledPhoneNumber; }
            set
            {
                Regex patternPhoneNumber = new Regex(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$");
                Match matchedNumber = patternPhoneNumber.Match(value);
                if (matchedNumber.Success)
                {
                    dialledPhoneNumber = value;
                }
                else
                {
                    throw new ArgumentException("Invalid phone number.");
                }
            }
        }

        public double CallDuration
        {
            get { return callDuration; }
            private set { }
        }

        public Call(string phoneNumber)
        {
            this.Date = DateTime.Now;
            this.DialledPhoneNumber = phoneNumber;
            this.callDuration = 0;
        }

        public void StartCall()
        {
            Console.WriteLine($"Calling {DialledPhoneNumber}...");
            Thread.Sleep( 10000 );
        }

        public void EndCall()
        {
            DateTime endTime = DateTime.Now;
            CallDuration = (int)(endTime - Date).Seconds;
            Console.WriteLine($"Call ended after {CallDuration} seconds.");
        }
    }
}
