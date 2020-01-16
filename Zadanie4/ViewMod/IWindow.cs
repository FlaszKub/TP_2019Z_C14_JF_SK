using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public interface IWindow
    {
        void Show();
        void Close();
        void ShowPopup(string message);
    }
}
