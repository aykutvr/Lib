using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    public static Int32 Next(this Int32 intVal)
            => intVal.Next(1);
    public static Int32 Next(this Int32 intVal, Int32 step)
            => intVal + step;
}
