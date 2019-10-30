using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie1;

namespace UnitTestZadanie1
{
    class RandomDataFiller : IDataFiller
    {
        private int bookCount;
        private int clientCount;
        private int eventCount;
        private Random rand;
        public RandomDataFiller(int clientCount,int bookCount, int eventCount)
        {
            this.bookCount = bookCount;
            this.eventCount = eventCount;
            this.clientCount = clientCount;
            this.rand = new Random();
        }

        public void Fill(DataContext context)
        {

            for (int i = 0; i < clientCount; i++)
            {
                context.clients.Add(new Client(randomStringGenerator(7), randomStringGenerator(9), rand.Next(200000, 450000).ToString()));
            }

            for (int i = 0; i < bookCount; i++)
            {
                int key = rand.Next(i * 200, (i + 1) * 200);
                context.books.Add(key, new Book(randomStringGenerator(10), randomStringGenerator(5) + " " + randomStringGenerator(5), key));
                context.bookStates.Add(new BookState(context.books[key], rand.Next(10, 20), (float)(10 + rand.NextDouble() * 30), rand.Next(15, 24), rand.Next((i+1)*100, (i+2)*100).ToString())); 
            }

            for (int i = 0; i < eventCount/2; i++)
            {
                context.events.Add(new Purchase(context.clients[rand.Next(context.clients.Count())], context.bookStates[rand.Next(context.bookStates.Count())], dateGenerator(), rand.Next(1,5)));
                context.events.Add(new Sale(context.clients[rand.Next(context.clients.Count())], context.bookStates[rand.Next(context.bookStates.Count())], dateGenerator(), rand.Next(1,5)));
            }


        }

        private string randomStringGenerator(int numberOfSigns) {
            string alfabet = "aąbcćdeęfghijklłmnńoóprstuwxyz";
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < numberOfSigns; i++) {
                stringBuilder.Append(alfabet[rand.Next(alfabet.Length)]);
            }
            return stringBuilder.ToString();
        }

        private DateTimeOffset dateGenerator() {
            return new DateTime(2019, rand.Next(1,13), rand.Next(1,29));
        }
    }
}
