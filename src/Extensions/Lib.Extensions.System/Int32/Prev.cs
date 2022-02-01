using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    public static Int32 Prev(this Int32 intVal)
           => intVal.Prev(1);
    public static Int32 Prev(this Int32 intVal, Int32 step)
        => intVal - step;
}
