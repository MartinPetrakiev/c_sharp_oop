using Lambda_Core.Enumerators;

namespace Lambda_Core
{
    public abstract class Core
    {
        public char Name { get; protected set; }
        public uint Durability { get; protected set; }
        public int Pressure { get; protected set; }
        public List<Fragment> Fragments { get; protected set; }

        protected Core(char name, uint durability)
        {
            this.Name = name;
            this.Durability = durability;
            this.Pressure = 0;
            this.Fragments = new List<Fragment>();
        }

        public bool AddFragment(Fragment fragment)
        {
            bool success = true;
            this.Fragments.Add(fragment);

            if (fragment.FragmentType == FragmentType.Cooling)
            {
                this.Pressure -= (int)fragment.PressureAffection;
            }
            else
            {
                this.Pressure += (int)fragment.PressureAffection;
                try
                {
                    this.Durability -= fragment.PressureAffection;
                }
                catch
                {
                    success = false;
                }
            }

            return success;
        }

        public string IsCritical()
        {
            string status = this.Durability > 0 ? "CRITICAL" : "NORMAL";
            return status;
        }

        public override string ToString()
        {
            string resultString = $"Core {this.Name}:\n" +
                                  $"####Durability: {this.Durability}\n" +
                                  $"####Status: {this.IsCritical()}";
            return resultString;
        }
    }
}
