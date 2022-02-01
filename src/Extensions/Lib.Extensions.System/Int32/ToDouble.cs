using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    public static double ToDouble(this Int32 intVal)
            => Convert.ToDouble(intVal);
}
