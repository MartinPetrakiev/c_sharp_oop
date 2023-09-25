using Lambda_Core.Interfaces;

namespace Lambda_Core
{
    public class ParaCore : Core
    {
        private readonly ICoreService coreService;

        public ParaCore(char name, uint durability, ICoreService coreService) : base(name, durability)
        {
            this.coreService = coreService;
            this.Durability = durability / 3;
        }

        public override bool AddFragment(Fragment fragment)
        {
            return coreService.AddFragment(this, fragment);
        }

        public override string IsCritical()
        {
            return coreService.IsCritical(this);
        }

        public override string ToString()
        {
            return coreService.ToString(this);
        }
    }
}
