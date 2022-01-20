using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    public static Int64 Next(this Int64 intVal)
            => intVal.Next(1);
    public static Int64 Next(this Int64 intVal, Int64 step)
            => intVal + step;
}
