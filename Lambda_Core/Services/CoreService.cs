using Lambda_Core.Enumerators;
using Lambda_Core.Interfaces;

namespace Lambda_Core.Services
{
    public class CoreService : ICoreService
    {
        public bool AddFragment(Core core, Fragment fragment)
        {
            core.Fragments.Add(fragment);
            return this.HandlePressureAndDurability(core, fragment);
        }

        public bool HandlePressureAndDurability(Core core, Fragment fragment)
        {
            bool success = true;
            if (fragment.FragmentType == FragmentType.Cooling)
            {
                core.Pressure -= (int)fragment.PressureAffection;
            }
            else
            {
                core.Pressure += (int)fragment.PressureAffection;
                try
                {
                    checked
                    {
                        core.Durability -= fragment.PressureAffection;
                    }
                }
                catch
                {
                    success = false;
                }
            }

            return success;
        }

        public string IsCritical(Core core)
        {
            return core.Durability > 0 ? "CRITICAL" : "NORMAL";
        }

        public string ToString(Core core)
        {
            string resultString = $"Core {core.Name}:\n" +
                                  $"####Durability: {core.Durability}\n" +
                                  $"####Status: {IsCritical(core)}";
            return resultString;
        }
    }
}
