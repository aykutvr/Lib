using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    public static Int16 Prev(this Int16 intVal)
           => intVal.Prev(1);
    public static Int16 Prev(this Int16 intVal, Int16 step)
        => Convert.ToInt16(intVal - step);
}
