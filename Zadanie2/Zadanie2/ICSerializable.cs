using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Zadanie2
{
    interface ICSerializable
    {
        string Serialize(ObjectIDGenerator gen, char separator);
    }
}
