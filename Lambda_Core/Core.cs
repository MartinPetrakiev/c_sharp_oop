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

        public abstract bool AddFragment(Fragment fragment);

        public abstract string IsCritical();

        public bool HandlePressureAndDurability(Fragment fragment)
        {
            bool success = true;
            if (fragment.FragmentType == FragmentType.Cooling)
            {
                this.Pressure -= (int)fragment.PressureAffection;
            }
            else
            {
                this.Pressure += (int)fragment.PressureAffection;
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
            }

            return success;
        }

        public abstract override string ToString();
    }
}
