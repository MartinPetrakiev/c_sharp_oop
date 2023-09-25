namespace Lambda_Core.Dictionaries
{
    public class PowerPlantDictionaries
    {
        public Dictionary<string, Type> fragmentTypeMap;
        public Dictionary<string, Type> coreTypeMap;

        public PowerPlantDictionaries()
        {
            fragmentTypeMap = new Dictionary<string, Type>
            {
                { "Nuclear", typeof(NuclearFragment) },
                { "Cooling", typeof(CoolingFragment) }
            };

            coreTypeMap = new Dictionary<string, Type>
            {
                { "System", typeof(SystemCore) },
                { "Para", typeof(ParaCore) }
            };
        }
    }
}
