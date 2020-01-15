using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using ViewModel;

namespace Tests
{
    [TestClass]
    public class ViewModelTest
    {
        private class Window : IWindow
        {
            public string Message { get; set; }
            public bool CloseFlag { get; set; }
            public bool ShowFlag { get; set; }

            public Window()
            {
                Message = "";
                CloseFlag = false;
                ShowFlag = false;
            }

            public void Close()
            {
                CloseFlag = true;
            }

            public void Show()
            {
                ShowFlag = true;
            }

            public void ShowPopup(string message)
            {
                Message = message;
            }
        }

        MainViewModel mainViewModel = new MainViewModel();


        [TestMethod]
        public void DeleteProducNotSelectedTest()
        {
            Window window = new Window();
            MainViewModel vm = new MainViewModel();
            vm.MainWindow = window;
            vm.SelectedProduct = new Product();
            vm.DeleteCommand.Execute(null);
            Assert.AreEqual("Select a product", window.Message);
        }

        [TestMethod]
        public void EditProducNotSelectedFailTest()
        {
            Window window = new Window();
            MainViewModel vm = new MainViewModel();
            vm.MainWindow = window;
            vm.SelectedProduct = new Product();
            vm.EditCommand.Execute(null);
            Assert.AreEqual("Select a product", window.Message);
        }

        [TestMethod]
        public void EditProductWasSelectedTest()
        {
            Window window = new Window();
            MainViewModel vm = new MainViewModel();
            vm.MainWindow = window;
            vm.SelectedProduct = vm.Products.First();
            vm.EditCommand.Execute(null);
            Assert.AreEqual("", window.Message);
        }

        [TestMethod]
        public void DeleteSelectedProductTest()
        {
            Window window = new Window();
            MainViewModel vm = new MainViewModel();
            vm.MainWindow = window;
            vm.SelectedProduct = vm.Products.Last();
            int beforeDel = vm.Products.Count;
            vm.DeleteCommand.Execute(null);
            Assert.AreEqual("", window.Message);
            vm.ApplyCommand.Execute(null);
            Assert.AreEqual(beforeDel - 1, vm.Products.Count);

        }
    }
}
