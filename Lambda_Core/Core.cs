using Lambda_Core.Enumerators;

namespace Lambda_Core
{
    public abstract class Core
    {
        public char Name { get; protected set; }
        public uint Durability { get; protected set; }
        public int Pressure { get; protected set; }
        public StatusType CoreStatus { get; protected set; }
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
            this.Fragments.Add(fragment);
            bool success = true;
            success = this.AdjustPressure(fragment);
            
            if (fragment.FragmentType == FragmentType.Nuclear)
            {
                success = this.ReduceDurability(fragment);
            }

            return success;
        }

        public string IsCritical()
        {
            if (this.Pressure > 0)
            {
                this.CoreStatus = StatusType.CRITICAL;
            }
            else
            {
                this.CoreStatus = StatusType.NORMAL;
            }

            return this.CoreStatus.ToString("g");
        }

        private bool AdjustPressure(Fragment fragment)
        {
            bool success = true;

            if (fragment.FragmentType == FragmentType.Cooling)
            {
                this.Pressure -= (int)fragment.PressureAffection;
            }
            else
            {
                this.Pressure += (int)fragment.PressureAffection;
            }

            return success;
        }

        private bool ReduceDurability(Fragment fragment)
        {
            bool success = true;
            try
            {
                checked
                {
                    this.Durability -= fragment.PressureAffection;
                }
            }
            catch
            {
                success = false;
            }

            return success;
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
