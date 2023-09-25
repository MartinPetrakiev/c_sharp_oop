using Lambda_Core.Enumerators;

namespace Lambda_Core
{
    public abstract class Core
    {
        public char Name { get; protected set; }
        public uint Durability { get; set; }
        public int Pressure { get; set; }
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

        public abstract override string ToString();
    }
}
