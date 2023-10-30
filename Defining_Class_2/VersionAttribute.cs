namespace Defining_Class_2
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method)]
    public class VersionAttribute : Attribute
    {
        public string Version { get; }

        public VersionAttribute(string version)
        {
            Version = version;
        }
    }
}
