using System;

namespace Lib.DapperORM.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class MaskedWithAttribute : Attribute
    {
        public string FunctionName { get; set; }
        public MaskedWithAttribute(string functionName)
        {
            FunctionName = functionName;
        }
    }
}
