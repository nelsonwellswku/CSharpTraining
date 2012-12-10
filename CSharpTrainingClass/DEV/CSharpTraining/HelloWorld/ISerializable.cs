using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public interface ISerializable<in T>
    {
        bool Serialize(T data);
    }
}
