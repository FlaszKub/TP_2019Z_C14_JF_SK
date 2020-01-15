
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel;

namespace Tests
{
    [TestClass]
    public class CommandTest
    {
        [TestMethod]
        public void ExecuteTest()
        {
            int counter = 0;
            OwnCommand command = new OwnCommand(() => counter++);
            command.Execute(null);
            Assert.AreEqual(1, counter);
            command.Execute(null);
            Assert.AreEqual(2, counter);
        }

        private void doNothing(){}

        [TestMethod]
        public void CanExecuteTest()
        {
            OwnCommand command = new OwnCommand(doNothing);
            command.Execute(null);
            Assert.IsTrue(command.CanExecute(null));
            command = new OwnCommand(doNothing, () => false);
        }
    }
}
