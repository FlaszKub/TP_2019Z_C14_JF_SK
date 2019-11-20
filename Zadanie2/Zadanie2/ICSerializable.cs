using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Zadanie2
{
    public interface ICSerializable
    {
        string Serialize(ObjectIDGenerator gen);
        void Deserialize(string[] data, Dictionary<int, object> refObjectsDict);
    }
}
