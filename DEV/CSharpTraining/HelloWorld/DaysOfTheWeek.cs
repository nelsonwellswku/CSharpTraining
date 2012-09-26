using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1714:FlagsEnumsShouldHavePluralNames",
        Justification="This is plural it is just misidentified by the code analysis rule.")]
    [Flags]
    public enum DaysOfTheWeek : int
    {
        Monday = 1 << 0, 
        Tuesday = 1 << 1,
        Wednesday = 1 << 2,
        Thursday = 1 << 3,
        Friday = 1 << 4,
        Saturday = 1 << 5,
        Sunday = 1 << 6
    }
}
