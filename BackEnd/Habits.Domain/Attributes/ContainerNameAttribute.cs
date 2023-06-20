namespace Habits.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ContainerNameAttribute : Attribute
    {
        public string Name { get; }

        public ContainerNameAttribute(string name)
        {
            Name = name;
        }
    }
}
