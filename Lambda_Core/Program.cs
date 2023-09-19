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
            char coreName = ' ';

            while (input != "System Shutdown!")
            {
                string[] rowSplit = input.Split(':');
                string command = rowSplit[0];
                string arguments = input.Length > 1 ? rowSplit[1] : null;

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
                            throw new Exception($"Failed to create Core!");
                        }
                        LambdaCoreSystem.CreateCore(coreType, durability);
                        break;
                    case "RemoveCore":
                        try
                        {
                            coreName = Convert.ToChar(arguments.Substring(1));
                        }
                        catch
                        {
                            throw new Exception($"Failed to remove Core {arguments.Substring(1)}!");
                        }
                        LambdaCoreSystem.RemoveCore(coreName);
                        break;
                    case "SelectCore":
                        try
                        {
                            coreName = Convert.ToChar(arguments.Substring(1));
                        }
                        catch
                        {
                            throw new Exception($"Failed to select Core {arguments.Substring(1)}!");
                        }
                        LambdaCoreSystem.SelectCore(coreName);
                        break;
                    case "AttachFragment":
                        argumentsSplit = arguments.Split('@');
                        string fragmentType = argumentsSplit[1];
                        string fragmentName = argumentsSplit[2];
                        int fragmentPressureAffection = Convert.ToInt32(argumentsSplit[3]);
                        
                        if (currentSelectedCore.Fragments.Count >= 0)
                        {
                            currentSelectedCore.AttachFragment(fragmentType, fragmentName, fragmentPressureAffection);
                        }
                        else
                        {
                            throw new Exception($"Failed to attach Fragment {fragmentName}!");
                        }
                        break;
                    case "DetachFragment":
                        if (!object.Equals(currentSelectedCore, null))
                        {
                            currentSelectedCore.DetachFragment();
                        }
                        else
                        {
                            throw new Exception($"Failed to attach Fragment!");
                        }
                        break;
                    case "Status":
                        Console.WriteLine(LambdaCoreSystem.ToString());
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
