using Lambda_Core.Enumerators;
using Lambda_Core.Exceptions;
using Lambda_Core.Interfaces;

namespace Lambda_Core
{
    public class Core : ICore
    {
        public char CoreID { get; set; }
        public CoreType CoreType { get; }
        public uint Durability { get; set; }
        public int Pressure { get; protected set; }
        public List<Fragment> Fragments { get; }

        public Core() 
        {
            this.Fragments = new List<Fragment>();
        }

        public Core(char coreID, CoreType coreType, uint durability) 
        {
            this.CoreID = coreID;
            this.CoreType = coreType;
            this.Durability = durability;
            this.Fragments = new List<Fragment>();
        }

        public void AttachFragment(string fragmentType, string name, int pressureAffection)
        {
            if (this.CoreID == '\0' || this.CoreID == ' ')
            {
                Console.WriteLine($"Failed to attach Fragment {name}!");
                throw new InvalidOperationException($"Failed to attach Fragment {name}!");
            }

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
                    Console.WriteLine($"Failed to attach Fragment {name}!");
                    throw new InvalidOperationException($"Failed to attach Fragment {name}!");
                    break;
            }

            if (pressureAffection < 0)
            {
                Console.WriteLine($"Failed to attach Fragment {name}!");
                throw new NegativeNumberException($"Failed to attach Fragment {name}!");
            }
            else
            {
                newFragment.PressureAffection = newFragment.FragmentType == FragmentType.Nuclear ? (uint)pressureAffection * 2 : (uint)pressureAffection * 3;
            }

            if (newFragment.FragmentType == FragmentType.Nuclear)
            {
                this.Pressure += (int)newFragment.PressureAffection;
                if (this.Pressure > 0)
                {
                    try
                    {
                        this.Durability -= newFragment.PressureAffection;
                    }
                    catch
                    {
                        Console.WriteLine($"Failed to attach Fragment {name}!");
                        throw new InvalidOperationException($"Failed to attach Fragment {name}!");
                    }
                }
            }
            else
            {
                this.Pressure -= (int)newFragment.PressureAffection;
                this.Durability += newFragment.PressureAffection;
            }

            this.Fragments.Add(newFragment);
            Console.WriteLine($"Successfully attached Fragment {newFragment.Name} to Core {this.CoreID}!");
        }

        public void DetachFragment()
        {
            if (this.Fragments.Count == 0)
            {
                Console.WriteLine("Failed to detach Fragment!");
            }
            else
            {
                Fragment lastFragment = this.Fragments[this.Fragments.Count - 1];
                this.Fragments.Remove(lastFragment);

                if (lastFragment.FragmentType == FragmentType.Nuclear)
                {
                    this.Pressure -= (int)lastFragment.PressureAffection;
                    this.Durability += lastFragment.PressureAffection;
                }
                else
                {
                    this.Pressure += (int)lastFragment.PressureAffection;

                    try
                    {
                        this.Durability -= lastFragment.PressureAffection;
                    }
                    catch
                    {
                        Console.WriteLine("Failed to detach Fragment!");
                        throw new InvalidOperationException("Failed to detach Fragment!");
                    }
                }

                Console.WriteLine($"Successfully detached Fragment {lastFragment.Name} from Core {this.CoreID}!");
            }
        }

        public override string ToString()
        {
            string status = this.Pressure > 0 ? "CRITICAL" : "NORMAL";

            string resultString = $"Core {this.CoreID}:\n" +
                                  $"####Durability: {this.Durability}\n" +
                                  $"####Status: {status}";

            return resultString;
        }
    }
}
