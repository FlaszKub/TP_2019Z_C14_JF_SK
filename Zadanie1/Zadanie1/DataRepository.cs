

namespace Zadanie1
{
    public class DataRepository
    {
        private DataContext dataContext;
        private IDataFiller filler;
        public DataRepository(DataContext dataContext, IDataFiller filler) {
            this.dataContext = dataContext;
            this.filler = filler;
            filler.Fill(dataContext);
        }
    }
}
