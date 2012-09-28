using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    [Serializable]
    //[AttributeUsage(AttributeTargets.Field)]
    sealed public class DisplayNameAttribute : Attribute
    {
        public string Name { get; set; }
        public string FormatString { get; set; }

        //public DisplayNameAttribute()
        //{
        //}

        public DisplayNameAttribute(string name)
        {
            Name = name;
        }

        public static string Format(DaysOfTheWeek day)
        {
            DisplayNameAttribute[] attribute =
                (DisplayNameAttribute[])typeof(DaysOfTheWeek).GetField(
                    day.ToString())
                .GetCustomAttributes(typeof(DisplayNameAttribute), false);
            return attribute.Count() == 0 ?
                day.ToString() : attribute.FirstOrDefault().Name;
        }
    }
}
