using Lambda_Core.Enumerators;

namespace Lambda_Core
{
    public class CoolingFragment : Fragment
    {
        public CoolingFragment(string name, FragmentType type, uint pressureAffection) : base(name, type, pressureAffection)
        {
            this.PressureAffection = pressureAffection * 3;
        }
    }
}
