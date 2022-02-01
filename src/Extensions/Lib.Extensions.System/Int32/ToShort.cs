using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    public static Int16 ToShort(this Int32 intVal)
            => Convert.ToInt16(intVal);
}
