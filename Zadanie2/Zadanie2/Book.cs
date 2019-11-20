using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Zadanie2;

namespace Zadanie1
{
    public class Book : ICSerializable
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int KeyNumber { get; set; }

        public Book() { }

        public Book(string author, string title, int keyNumber)
        {
            this.Author = author;
            this.Title = title;
            this.KeyNumber = keyNumber;
        }

        public Book(string[] data, Dictionary<int, object> refObjectsDict)
        {
            Author = data[2];
            Title = data[3];
            this.KeyNumber = int.Parse(data[4]);
        }

        public override string ToString()
        {
            return this.Author + " " + this.Title + " " + this.KeyNumber;
        }

        public override bool Equals(object obj)
        {
            return obj is Book book &&
                   Author == book.Author &&
                   Title == book.Title &&
                   KeyNumber == book.KeyNumber;
        }

        public override int GetHashCode()
        {
            int hashCode = -802353372;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Author);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + KeyNumber.GetHashCode();
            return hashCode;
        }

        string ICSerializable.Serialize(ObjectIDGenerator gen, char separator)
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().FullName);
            result.Append(separator);
            result.Append(gen.GetId(this, out bool firstTime).ToString());
            result.Append(separator);
            result.Append(Author);
            result.Append(separator);
            result.Append(Title);
            result.Append(separator);
            result.Append(KeyNumber.ToString());
            result.Append(separator);
            return result.ToString();
        }
    }
}
