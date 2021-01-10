namespace TinYard.BootstrapSettings.Tests.TestClasses
{
    public class Environment
    {
        public string Name { get; set; }
        public string OS { get; set; }
        public bool Deployed { get; set; }

        public override bool Equals(object obj)
        {
            if(!(obj is Environment))
            {
                return false;
            }

            var env = obj as Environment;
            return Name == env.Name && OS == env.OS && Deployed == env.Deployed;
        }
    }
}
