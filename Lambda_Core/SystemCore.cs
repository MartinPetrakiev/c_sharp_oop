using Lambda_Core.Interfaces;

namespace Lambda_Core
{
    public class SystemCore : Core
    {
        private readonly ICoreService coreService;

        public SystemCore(char name, uint durability, ICoreService coreService) : base(name, durability)
        {
            this.coreService = coreService;
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
