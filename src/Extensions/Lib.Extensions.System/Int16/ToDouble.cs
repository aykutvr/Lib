using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    public static double ToDouble(this Int16 intVal)
            => Convert.ToDouble(intVal);
}
