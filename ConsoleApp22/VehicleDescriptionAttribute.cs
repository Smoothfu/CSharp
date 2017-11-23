using System;

namespace ConsoleApp22
{
    [AttributeUsage(AttributeTargets.All)]
    internal class VehicleDescriptionAttribute : Attribute
    {
        public VehicleDescriptionAttribute(string Description)
        {
            this.Description = Description;
        }

        public string Description { get; set; }
    }
}