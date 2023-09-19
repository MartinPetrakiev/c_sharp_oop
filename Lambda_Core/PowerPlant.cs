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
            char lastCoreID = this.Cores.Count > 0 ? this.Cores.Last().CoreID : ' ';
            char newCoreID;
            
            if (lastCoreID == 'Z') 
            {
                throw new LimitExceededException("Failed to create Core!");
            }

            if (lastCoreID != ' ')
            {
                newCoreID = (char)(((int)lastCoreID) + 1);
            }
            else
            {
                newCoreID = 'A';
            }

            if (durability < 0) 
            {
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
                    throw new Exception("Failed to create Core!");
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
                throw new Exception($"Failed to select Core {id}!");
            }

            return selectedCore;
        }

        public void RemoveCore(char id)
        {
            bool IdExists = this.Cores.Select(eachCore => eachCore.CoreID).Contains(id);
            if (IdExists) 
            {
                this.Cores.Remove(new Core() { CoreID = id });
                Console.WriteLine($"Successfully removed Core {id}!");
            }
            else
            {
                throw new Exception($"Failed to remove Core {id}!");
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
