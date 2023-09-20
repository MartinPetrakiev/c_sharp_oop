using Lambda_Core.Enumerators;
using System.Collections.Generic;

namespace Lambda_Core
{
    class Program
    {
        public static void Main(string[] args) 
        {
            /*
                "CreateCore:@System@2000",
                "CreateCore:@System@1000",
                "AttachFragment:@Cooling@A32@100",
                "SelectCore:@A",
                "AttachFragment:@Cooling@A64@200",
                "AttachFragment:@Cooling@A72@300",
                "Status:",
                "SelectCore:@B",
                "AttachFragment:@Nuclear@B12@250",
                "Status:",
                "System Shutdown!"
            */

            string input = Console.ReadLine();
            PowerPlant LambdaCoreSystem = new PowerPlant();
            Core currentSelectedCore = new Core();

            while (input != "System Shutdown!")
            {
                string[] rowSplit = input.Split(':');
                string command = rowSplit[0];
                string arguments = input.Length > 1 ? rowSplit[1] : "";

                switch (command)
                {
                    case "CreateCore":
                        string[] argumentsSplit = arguments.Split('@',' ');
                        string coreType = argumentsSplit[1];
                        uint durability = 0;
                        try
                        {
                            durability = Convert.ToUInt32(argumentsSplit[2]);
                        }
                        catch
                        {
                            throw new InvalidCastException($"Failed to create Core!");
                        }
                        LambdaCoreSystem.CreateCore(coreType, durability);
                        break;
                    case "RemoveCore":
                        char idToBeRemoved;
                        try
                        {
                            idToBeRemoved = Convert.ToChar(arguments.Substring(1));
                        }
                        catch
                        {
                            throw new InvalidCastException($"Failed to remove Core {arguments.Substring(1)}!");
                        }
                        LambdaCoreSystem.RemoveCore(idToBeRemoved);
                        break;
                    case "SelectCore":
                        try
                        {
                            currentSelectedCore.CoreID = Convert.ToChar(arguments.Substring(1));
                        }
                        catch
                        {
                            throw new InvalidCastException($"Failed to select Core {arguments.Substring(1)}!");
                        }
                        LambdaCoreSystem.SelectCore(currentSelectedCore.CoreID);
                        break;
                    case "AttachFragment":
                        argumentsSplit = arguments.Split('@');
                        string fragmentType = argumentsSplit[1];
                        string fragmentName = argumentsSplit[2];
                        int fragmentPressureAffection = Convert.ToInt32(argumentsSplit[3]);

                        currentSelectedCore.AttachFragment(fragmentType, fragmentName, fragmentPressureAffection);

                        LambdaCoreSystem.UpdateCoresListWith(currentSelectedCore);

                        break;
                    case "DetachFragment":
                        if (currentSelectedCore.CoreID == '\0' || currentSelectedCore.CoreID == ' ')
                        {
                            currentSelectedCore.DetachFragment();

                            LambdaCoreSystem.UpdateCoresListWith(currentSelectedCore);
                        }
                        else
                        {
                            throw new InvalidOperationException($"Failed to attach Fragment!");
                        }

                        break;
                    case "Status":
                        Console.WriteLine(LambdaCoreSystem.ToString());
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        throw new InvalidOperationException("Invalid command line provided!");
                        break;

                }

                input = Console.ReadLine();
            }
        }
    }
}
