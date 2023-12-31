﻿using Lambda_Core.Enumerators;
using Lambda_Core.Interfaces;

namespace Lambda_Core
{
    public class LambdaCorePowerPlant : ICoreService, IFragmentService, IPowerPlantStatus
    {
        public List<Core> Cores { get; protected set; }
        public Core CurrentSelectedCore { get; set; }

        public LambdaCorePowerPlant() 
        { 
            this.Cores = new List<Core>();
        }

        public bool CreateCore(string type, int durability)
        {
            bool success = false;

            if (durability >= 0)
            {
                char coreName = (char)(this.Cores.Count + 'A');
                Core newCore = this.HandleCoreCreation(coreName, type, durability);

                if (newCore != null)
                {
                    success = true;
                }
                   
                this.Cores.Add(newCore);
                this.CurrentSelectedCore = newCore;
            }

            return success;
        }

        private Core HandleCoreCreation(char coreName, string type, int durability) 
        {
            Core newCore = null;

            string className = type + "Core";

            Type coreType = Type.GetType("Lambda_Core." + className);

            if (coreType != null)
            {
                newCore = Activator.CreateInstance(coreType, coreName, (uint)durability) as Core;
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

        public bool SelectCore(string name)
        {
            bool success = false;
            this.CurrentSelectedCore = this.Cores.FirstOrDefault(core => core.Name.ToString() == name);

            if (this.CurrentSelectedCore != null)
            {
                success = true;
            }

            return success;
        }

        public bool AttachFragment(string type, string name, int pressureAffection)
        {
            bool success = false;
            Fragment newFragment = null;

            if (pressureAffection >= 0)
            {
                newFragment = CreateFragment(type, name, pressureAffection);
            }

            if (newFragment != null)
            {
                this.CurrentSelectedCore.AddFragment(newFragment);
                success = true;
            }

            return success;
        }

        private Fragment CreateFragment(string type, string name, int pressureAffection)
        {
            Fragment newFragment = null;

            string className = type + "Fragment";

            Type fragmentType = Type.GetType("Lambda_Core." + className);

            if (pressureAffection >= 0 && fragmentType != null)
            {
                newFragment = Activator.CreateInstance(fragmentType, name, Enum.Parse<FragmentType>(type), (uint)pressureAffection) as Fragment;
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

        public string GetStatus()
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
