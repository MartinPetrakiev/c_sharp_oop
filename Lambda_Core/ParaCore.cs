using Lambda_Core.Interfaces;

namespace Lambda_Core
{
    public class ParaCore : Core
    {
        public ParaCore(char name, uint durability) : base(name, durability)
        {
            this.Durability = durability / 3;
        }
    }
}
