namespace Lambda_Core
{
    public class ParaCore : Core
    {
        public ParaCore(char name, uint durability) : base(name, (uint)durability / 3)
        {
        }
    }
}
