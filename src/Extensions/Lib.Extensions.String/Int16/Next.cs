using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    public static Int16 Next(this Int16 intVal)
            => intVal.Next(1);
    public static Int16 Next(this Int16 intVal, Int16 step)
            => Convert.ToInt16(intVal + step);
}
