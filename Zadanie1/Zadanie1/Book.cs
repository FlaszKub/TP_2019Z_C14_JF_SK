

namespace Zadanie1
{
    public class Book
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int KeyNumber { get; set; }

        public Book(string author, string title, int keyNumber)
        {
            this.Author = author;
            this.Title = title;
            this.KeyNumber = keyNumber;
        }
    }
}
