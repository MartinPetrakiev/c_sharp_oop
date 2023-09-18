using Lambda_Core.Enumerators;
using Lambda_Core.Exceptions;
using System.Xml.Linq;

namespace Lambda_Core
{
    public class PowerPlant
    {
        public List<Core> cores = new List<Core>();

        public List<Core> Cores 
        { 
            get { return cores; }
        }

        public void CreateCore(char id, string type, int durability)
        {
            bool IdExists = this.Cores.Select(eachCore => eachCore.CoreID).Contains(id);
            char coreID = id;
            
            if (IdExists && coreID == 'Z') 
            {
                throw new LimitExceededException("Failed to create Core!");
            }

            while (IdExists)
            {
                coreID = (char)(((int)coreID) + 1);
                IdExists = this.Cores.Select(eachCore => eachCore.CoreID).Contains(coreID);
            }

            if (durability < 0) 
            {
                throw new NegativeNumberException("Failed to create Core!");
            }

            Core core = null;
            switch (type) 
            {
                case "System":
                    core = new Core(coreID, CoreType.System, (uint)durability); 
                    break;
                case "Para":
                    core = new Core(coreID, CoreType.Para, (uint)durability / 3);
                    break;
                default:
                    throw new Exception("Failed to create Core!");
                    break;
            }

            this.Cores.Add(core);
            Console.WriteLine($"Successfully created Core {coreID}!");
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
    }
}
