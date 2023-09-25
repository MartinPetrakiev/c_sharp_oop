using Lambda_Core.Interfaces;
using Lambda_Core.Services;

namespace Lambda_Core
{
    class Program
    {
        public static void Main(string[] args) 
        {
            LambdaCorePowerPlant lambdaCore = new LambdaCorePowerPlant();

            Core currentCore = null;
            CoreService coreService = new CoreService();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "System Shutdown!")
                {
                    break;
                }

                string[] commandArguments = command.Split(':');
                string operation = commandArguments[0];

                bool success;

                switch (operation)
                {
                    case "CreateCore":
                        Core newCore = null;
                        string[] coreParams = commandArguments[1].Split('@');

                        string coreType = coreParams[1];
                        int coreDurability;
                        try
                        {
                            coreDurability = Convert.ToInt32(coreParams[2]);
                        }
                        catch
                        {
                            Console.WriteLine("Failed to create Core!");
                            break;
                        }

                        success = lambdaCore.CreateCore(coreType, coreDurability, coreService, out newCore);

                        Console.WriteLine(success ? $"Successfully created Core {newCore.Name}!" : "Failed to create Core!");
                        break;

                    case "RemoveCore":
                        string coreNameToRemove = commandArguments[1].Substring(1);
                        success = lambdaCore.RemoveCore(coreNameToRemove);
                        Console.WriteLine(success ? $"Successfully removed Core {coreNameToRemove}!" : $"Failed to remove Core {coreNameToRemove}!");
                        break;

                    case "SelectCore":
                        string coreNameToSelect = commandArguments[1].Substring(1);
                        success = lambdaCore.SelectCore(coreNameToSelect, out currentCore);
                        Console.WriteLine(success ? $"Currently selected Core {coreNameToSelect}!" : $"Failed to select Core {coreNameToSelect}!");
                        break;

                    case "AttachFragment":
                        if (currentCore == null)
                        {
                            Console.WriteLine("Failed to attach Fragment!");
                        }
                        else
                        {
                            string[] fragmentParams = commandArguments[1].Split('@');
                            string fragmentType = fragmentParams[1];
                            string fragmentName = fragmentParams[2];
                            int pressureAffection;
                            try
                            {
                                pressureAffection = Convert.ToInt32(fragmentParams[3]);
                            }
                            catch
                            {
                                Console.WriteLine("Failed to attach Fragment!");
                                break;
                            }

                            success = lambdaCore.AttachFragment(currentCore, fragmentType, fragmentName, pressureAffection);

                            Console.WriteLine(success
                                ? $"Successfully attached Fragment {fragmentName} to Core {currentCore.Name}!"
                                : "Failed to attach Fragment!");
                        }
                        break;

                    case "DetachFragment":
                        if (currentCore == null)
                        {
                            Console.WriteLine("Failed to detach Fragment!");
                        }
                        else
                        {
                            success = lambdaCore.DetachFragment(currentCore);
                            Console.WriteLine(success
                                ? $"Successfully detached Fragment {currentCore.Fragments.Last().Name} from Core {currentCore.Name}!"
                                : "Failed to detach Fragment!");
                        }
                        break;

                    case "Status":
                        Console.Write(lambdaCore.ToString());
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        throw new InvalidOperationException("Invalid command line provided!");
                        break;
                }
            }
        }
    }
}
