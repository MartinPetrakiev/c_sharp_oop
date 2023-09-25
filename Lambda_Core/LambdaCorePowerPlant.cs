using Lambda_Core.Enumerators;
using Lambda_Core.Interfaces;

namespace Lambda_Core
{
    public class LambdaCorePowerPlant
    {
        public List<Core> Cores { get; protected set; }

        public LambdaCorePowerPlant() 
        { 
            this.Cores = new List<Core>();
        }

        public bool CreateCore(string type, int durability, ICoreService coreService, out Core currentCore)
        {
            bool success = false;
            currentCore = null;

            if (durability >= 0)
            {
                char coreName = (char)(this.Cores.Count + 'A');
                Core newCore = this.HandleCoreCreation(coreName, type, durability, coreService);
                   
                this.Cores.Add(newCore);
                currentCore = newCore;

                success = true;
            }

            return success;
        }

        public Core HandleCoreCreation(char coreName, string type, int durability, ICoreService coreService) 
        {
            Core newCore = null;

            switch (type)
            {
                case "System":
                    newCore = new SystemCore(coreName, (uint)durability, coreService);
                    break;
                case "Para":
                    newCore = new ParaCore(coreName, (uint)durability, coreService);
                    break;
            }

            return newCore;
        }

        public bool RemoveCore(string name)
        {
            bool success = false;
            Core coreToRemove = this.Cores.FirstOrDefault(core => core.Name.ToString() == name);

            if (coreToRemove != null)
            {
                this.Cores.Remove(coreToRemove);
                success = true;
            }

            return success;
        }

        public bool SelectCore(string name, out Core currentCore)
        {
            bool success = false;
            currentCore = this.Cores.FirstOrDefault(core => core.Name.ToString() == name);

            if (currentCore != null)
            {
                success = true;
            }

            return success;
        }

        public bool AttachFragment(Core core, string type, string name, int pressureAffection)
        {
            bool success = false;
            Fragment newFragment = null;

            if (pressureAffection >= 0)
            {
                newFragment = CreateFragment(type, name, pressureAffection);
            }

            if (newFragment != null)
            {
                core.AddFragment(newFragment);
                success = true;
            }

            return success;
        }

        public Fragment CreateFragment(string type, string name, int pressureAffection)
        {
            Fragment newFragment = null;

            switch (type) 
            {
                case "Nuclear":
                    newFragment = new NuclearFragment(name, FragmentType.Nuclear, (uint)pressureAffection);
                    break;
                case "Cooling":
                    newFragment = new CoolingFragment(name, FragmentType.Cooling, (uint)pressureAffection);
                    break;
            }

            return newFragment;
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
