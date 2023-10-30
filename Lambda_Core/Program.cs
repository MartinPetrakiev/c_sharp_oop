namespace Lambda_Core
{
    class Program
    {
        public static void Main(string[] args) 
        {
            LambdaCorePowerPlant lambdaCore = new LambdaCorePowerPlant();

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

                        success = lambdaCore.CreateCore(coreType, coreDurability);

                        Console.WriteLine(success ? $"Successfully created Core {lambdaCore.CurrentSelectedCore.Name}!" : "Failed to create Core!");
                        break;

                    case "RemoveCore":
                        string coreNameToRemove = commandArguments[1].Substring(1);
                        success = lambdaCore.RemoveCore(coreNameToRemove);
                        Console.WriteLine(success ? $"Successfully removed Core {coreNameToRemove}!" : $"Failed to remove Core {coreNameToRemove}!");
                        break;

                    case "SelectCore":
                        string coreNameToSelect = commandArguments[1].Substring(1);
                        success = lambdaCore.SelectCore(coreNameToSelect);
                        Console.WriteLine(success ? $"Currently selected Core {coreNameToSelect}!" : $"Failed to select Core {coreNameToSelect}!");
                        break;

                    case "AttachFragment":
                        if (lambdaCore.CurrentSelectedCore == null)
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

                            success = lambdaCore.AttachFragment(fragmentType, fragmentName, pressureAffection);

                            Console.WriteLine(success
                                ? $"Successfully attached Fragment {fragmentName} to Core {lambdaCore.CurrentSelectedCore.Name}!"
                                : "Failed to attach Fragment!");
                        }
                        break;

                    case "DetachFragment":
                        if (lambdaCore.CurrentSelectedCore == null)
                        {
                            Console.WriteLine("Failed to detach Fragment!");
                        }
                        else
                        {
                            success = lambdaCore.DetachFragment(lambdaCore.CurrentSelectedCore);
                            Console.WriteLine(success
                                ? $"Successfully detached Fragment {lambdaCore.CurrentSelectedCore.Fragments.Last().Name} from Core {lambdaCore.CurrentSelectedCore.Name}!"
                                : "Failed to detach Fragment!");
                        }
                        break;

                    case "Status":
                        Console.Write(lambdaCore.GetStatus());
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
