using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace JapaneseStudyTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    /// Written by Pedro A. Tresgallo, May 2018.
    /// Dedicated to さとこ先生
    /// 
    /// The goal of this application is to help students study Japanese Language
    /// This application will allow users to add wods to their "vocab list",
    /// save the list to a file for later use, and load it automatically in order
    /// to let the user resume quickly.
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {

        public static Word temp = new Word();
        public static Sensei satoko = new Sensei();

        public MainWindow()
        {
            InitializeComponent();

            _NavigationFrame.Navigate(new TitlePage());
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            satoko.SaveVocab();
        }
    }
}
