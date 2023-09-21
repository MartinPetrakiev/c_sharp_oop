using Lambda_Core.Enumerators;

namespace Lambda_Core
{
    public class LambdaCore
    {
        public List<Core> Cores { get; protected set; }

        public LambdaCore() 
        { 
            this.Cores = new List<Core>();
        }

        public bool CreateCore(List<Core> cores, string type, int durability, out Core currentCore)
        {
            bool success = false;
            currentCore = null;

            if ((type == "System" || type == "Para") && durability >= 0)
            {
                char coreName = (char)(cores.Count + 'A');
                Core newCore = (type == "System") ? new SystemCore(coreName, (uint)durability) : new ParaCore(coreName, (uint)durability);
                this.Cores.Add(newCore);
                currentCore = newCore;

                success = true;
            }

            return success;
        }

        public bool RemoveCore(List<Core> cores, string name)
        {
            bool success = false;
            Core coreToRemove = cores.FirstOrDefault(core => core.Name.ToString() == name);

            if (coreToRemove != null)
            {
                this.Cores.Remove(coreToRemove);
                success = true;
            }

            return success;
        }

        public bool SelectCore(List<Core> cores, string name, out Core currentCore)
        {
            bool success = false;
            currentCore = cores.FirstOrDefault(core => core.Name.ToString() == name);

            if (currentCore != null)
            {
                success = true;
            }

            return success;
        }

        public bool AttachFragment(Core core, string type, string name, int pressureAffection)
        {
            bool success = false;
            if ((type == "Nuclear" || type == "Cooling") && pressureAffection >= 0)
            {
                Fragment newFragment = type == "Nuclear"
                    ? new NuclearFragment(name, FragmentType.Nuclear, (uint)pressureAffection)
                    : new CoolingFragment(name, FragmentType.Cooling, (uint)pressureAffection);

                core.AddFragment(newFragment);

                success = true;
            }

            return success;
        }

        public bool DetachFragment(Core core)
        {
            bool success = false;
            if (core.Fragments.Count > 0)
            {
                core.Fragments.RemoveAt(core.Fragments.Count - 1);
                success = true;
            }

            return success;
        }

        public override string ToString()
        {
            uint totalDurability = (uint)this.Cores.Sum(core => core.Durability);
            uint countOfAllFragments = (uint)this.Cores.Sum(core => core.Fragments.Count);

            string resultString = $"Lambda Core Power Plant Status:\n" +
                                  $"Total Durability: {totalDurability}\n" +
                                  $"Total Cores: {this.Cores.Count}\n" +
                                  $"Total Fragments: {countOfAllFragments}\n";

            foreach (Core core in this.Cores)
            {
                resultString += core.ToString() + "\n";
            }

            return resultString;
        }
    }
}
