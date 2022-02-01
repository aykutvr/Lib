using System;

namespace Lib.DapperORM.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class IdentityAttribute : Attribute
    {
        public bool Identity { get; set; } = true;
        public int Seed { get; set; } = 1;
        public int Increment { get; set; } = 1;

    }
}
