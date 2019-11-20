using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Zadanie2;

namespace UnitTestZadanie2
{
    class CircleSerializer
    {
        ObjectIDGenerator gen = new ObjectIDGenerator();
        char separator = ',';

        public void Serialize(ICSerializable serializable,  Stream stream)
        {
            StreamWriter outputFile = new StreamWriter(stream);
            outputFile.WriteLine(serializable.Serialize(gen));
            outputFile.Flush();
        }

        public ICSerializable Deserialize(Stream stream)
        {
            Dictionary<int, object> refObjectsDict = new Dictionary<int, object>();
            ICSerializable temp = null;
            using (StreamReader sr = new StreamReader(stream))
            {
                string line;
                line = sr.ReadLine();
                string[] splitedObj = line.Split('>');
                GenerateTempObj(splitedObj, refObjectsDict);
                string[] firstObjDetails = splitedObj[0].Split(separator);

                switch (firstObjDetails[0])
                {
                    case "UnitTestZadanie2.ClassA":
                        ClassA a = (ClassA)refObjectsDict[int.Parse(firstObjDetails[1])];
                        a.Deserialize(firstObjDetails, refObjectsDict);
                        ((ClassB)refObjectsDict[int.Parse(firstObjDetails[4])]).Deserialize(splitedObj[1].Split(separator), refObjectsDict);
                        temp = a;
                        break;
                    case "UnitTestZadanie2.ClassB":
                        ClassB b = (ClassB)refObjectsDict[int.Parse(firstObjDetails[1])];
                        b.Deserialize(firstObjDetails, refObjectsDict);
                        ((ClassA)refObjectsDict[int.Parse(firstObjDetails[3])]).Deserialize(splitedObj[1].Split(separator), refObjectsDict);
                        temp = b;
                        break;
                }

            }
            return temp;
        }

        private void GenerateTempObj(string[] splitedObj, Dictionary<int, object> refObjectsDict)
        {
            foreach (string obj in splitedObj)
            {
                string[] details = obj.Split(separator);
                string dataType = details[0];
                switch (dataType)
                {
                    case "UnitTestZadanie2.ClassA":
                        ClassA a = new ClassA();
                        refObjectsDict.Add(int.Parse(details[1]), a);
                        break;
                    case "UnitTestZadanie2.ClassB":
                        ClassB b = new ClassB();
                        refObjectsDict.Add(int.Parse(details[1]), b);
                        break;
                }

            }
        }


    }
}
