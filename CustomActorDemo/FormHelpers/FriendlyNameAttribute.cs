using System;

namespace CustomActorDemo.FormHelpers
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FriendlyNameAttribute : Attribute
    {
        public string Name { get; }

        public FriendlyNameAttribute(string name)
        {
            Name = name;
        }
    }
}