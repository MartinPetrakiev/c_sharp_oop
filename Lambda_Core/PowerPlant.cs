using Lambda_Core.Enumerators;
using Lambda_Core.Exceptions;

namespace Lambda_Core
{
    public class PowerPlant
    {
        public List<Core> cores = new List<Core>();

        public List<Core> Cores 
        { 
            get { return cores; }
        }

        public void CreateCore( string type, uint durability)
        {
            char lastCoreID = this.Cores.Count > 0 ? this.Cores.Last().CoreID : '\0';
            char newCoreID;
            
            if (lastCoreID == 'Z') 
            {
                Console.WriteLine("Failed to create Core!");
                throw new LimitExceededException("Failed to create Core!");
            }

            if (lastCoreID != '\0' && lastCoreID != ' ')
            {
                newCoreID = (char)(((int)lastCoreID) + 1);
            }
            else
            {
                newCoreID = 'A';
            }

            if (durability < 0) 
            {
                Console.WriteLine("Failed to create Core!");
                throw new NegativeNumberException("Failed to create Core!");
            }

            Core core = null;
            switch (type) 
            {
                case "System":
                    core = new Core(newCoreID, CoreType.System, durability); 
                    break;
                case "Para":
                    core = new Core(newCoreID, CoreType.Para, durability / 3);
                    break;
                default:
                    Console.WriteLine("Failed to create Core!");
                    throw new InvalidOperationException("Failed to create Core!");
                    break;
            }

            this.Cores.Add(core);
            Console.WriteLine($"Successfully created Core {newCoreID}!");
        }

        public Core SelectCore(char id)
        {
            var selectedCore = this.Cores.Find(eachCore => eachCore.CoreID == id);
            if (selectedCore != null)
            {
                Console.WriteLine($"Currently selected Core {id}!");
            }
            else
            {
                Console.WriteLine($"Failed to select Core {id}!");
                throw new InvalidOperationException($"Failed to select Core {id}!");
            }

            return selectedCore;
        }

        public void RemoveCore(char id)
        {
            int indexOfCore = this.Cores.FindIndex(eachCore => eachCore.CoreID == id);
            if (indexOfCore != -1) 
            {
                this.Cores.RemoveAt(indexOfCore);
                Console.WriteLine($"Successfully removed Core {id}!");
            }
            else
            {
                Console.WriteLine($"Failed to remove Core {id}!");
                throw new InvalidOperationException($"Failed to remove Core {id}!");
            }
        }

        public void UpdateCoresListWith(Core currentSelectedCore)
        {
            int idnexCoreInPowerPlant = this.Cores.FindIndex(core => core.CoreID == currentSelectedCore.CoreID);

            if (idnexCoreInPowerPlant != -1)
            {
                this.Cores[idnexCoreInPowerPlant] = currentSelectedCore;
            }
        }

        public override string ToString()
        {
            uint totalDurability = (uint)this.Cores.Sum(core => core.Durability);
            uint countOfAllFragments = (uint)this.Cores.Sum(core => core.Fragments.Count);

            string resultString = $"Lambda Core Power Plant Status:\n" +
                                  $"Total Durability: {totalDurability}\n" +
                                  $"Total Cores: {this.Cores.Count}\n" +
                                  $"Total Fragments: {countOfAllFragments}";

            foreach (Core core in this.Cores)
            {
                resultString += "\n" + core.ToString();
            }

            return resultString;
        }
    }
}
