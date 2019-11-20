using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Zadanie1;

namespace Zadanie2
{
    class CustomSerializer
    {
        string Serialized;
        Dictionary<int, object> refObjectsDict;
        public CustomSerializer(){
            
        }
        public void Serialize(DataContext dataContext, Stream stream) {
            ObjectIDGenerator gen = new ObjectIDGenerator();
            Serialized = serializeToString(dataContext, gen);
        }

        private string serializeToString(DataContext dataContext, ObjectIDGenerator gen)
        {
            String result = "";

            return result;
        }
    }
}
