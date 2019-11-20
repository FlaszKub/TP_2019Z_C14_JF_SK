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

        public void Serialize(ICSerializable serializable, Stream stream)
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
                string line = sr.ReadLine();
                string[] splitedObj = line.Split('>');

                GenerateTempObj(splitedObj, refObjectsDict);

                for (int index = 0; index < splitedObj.Length; index++)
                {
                    if (index < splitedObj.Length - 1)
                    {
                        string[] detailsFirstObj = splitedObj[index].Split(separator);
                        string[] detailsRefObj = splitedObj[index + 1].Split(separator);

                        switch (detailsFirstObj[0])
                        {
                            case "UnitTestZadanie2.ClassA":
                                ClassA a = (ClassA)refObjectsDict[int.Parse(detailsFirstObj[1])];
                                a.Deserialize(detailsFirstObj, refObjectsDict);
                                ((ClassB)refObjectsDict[int.Parse(detailsFirstObj[4])]).Deserialize(detailsRefObj, refObjectsDict);
                                temp = a;
                                break;

                            case "UnitTestZadanie2.ClassB":
                                ClassB b = (ClassB)refObjectsDict[int.Parse(detailsFirstObj[1])];
                                b.Deserialize(detailsFirstObj, refObjectsDict);
                                ((ClassA)refObjectsDict[int.Parse(detailsFirstObj[3])]).Deserialize(detailsRefObj, refObjectsDict);
                                temp = b;
                                break;
                        }
                    }
                }
                return temp;
            }
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
