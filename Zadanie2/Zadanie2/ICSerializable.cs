using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Zadanie2
{
    public interface ICSerializable
    {
        string Serialize(ObjectIDGenerator gen, char separator);
    }
}
