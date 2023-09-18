using Lambda_Core.Enumerators;
using Lambda_Core.Exceptions;
using Lambda_Core.Interfaces;

namespace Lambda_Core
{
    public class Core : ICore
    {
        public char CoreID { get; set; }
        public CoreType CoreType { get; set; }
        public uint Durability { get; set; }
        public List<Fragment> Fragments { get; set; }

        public Core() { }

        public Core(char coreID, CoreType coreType, uint durability) 
        {
            this.CoreID = coreID;
            this.CoreType = coreType;
            this.Durability = durability;
        }

        public void AttachFragment(string fragmentType, string name, int pressureAffection)
        {
            Fragment newFragment = new Fragment() { Name = name };
            switch (fragmentType)
            {
                case "Nuclear":
                    newFragment.FragmentType = FragmentType.Nuclear;
                    break;
                case "Cooling":
                    newFragment.FragmentType = FragmentType.Cooling;
                    break;
                default:
                    throw new Exception($"Failed to attach Fragment {name}!");
                    break;
            }

            if (pressureAffection < 0)
            {
                throw new NegativeNumberException($"Failed to attach Fragment {name}!");
            }
            else
            {
                newFragment.PressureAffection = newFragment.FragmentType == FragmentType.Nuclear ? (uint)pressureAffection * 2 : (uint)pressureAffection * 3;
            }

            this.Fragments.Add(newFragment);
        }
    }
}
