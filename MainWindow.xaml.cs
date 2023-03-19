using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static String? cnt;
        private static String? textBlock="";

        public MainWindow()
        {
            InitializeComponent();
            PreviewKeyDown += Window_KeyDown;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button) sender;
            cnt = button.Content?.ToString();
            textBlock += cnt;
            tBlock.Text = textBlock;
        }
        private void CalculateAndDisplayResult()
        {
            try
            {
                DataTable dataTable = new DataTable();
                var result = dataTable.Compute(textBlock, null);
                tBlock.Text = result.ToString();
                textBlock = result.ToString();
            }
            catch (Exception ex)
            {
                // 處理異常情況
                tBlock.Text = "Error";
                textBlock = "";
            }
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CalculateAndDisplayResult();
                e.Handled = true;
            }
            //else if (e.key == key.system || e.key == e.imeprocessedkey)
            //{
            //    int number = -1;
            //    if (e.systemkey >= key.numpad0 && e.systemkey <= key.numpad9)
            //    {
            //        number = e.systemkey - key.numpad0;
            //    }
            //    else if (e.imeprocessedkey >= key.numpad0 && e.imeprocessedkey <= key.numpad9)
            //    {
            //        number = e.imeprocessedkey - key.numpad0;
            //    }
            //    if (number != -1)
            //    {
            //        textblock += number.tostring();
            //        tblock.text = textblock;
            //        e.handled = true;
            //    }
            //}
        }
        //private void Window_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter)
        //    {
        //        CalculateAndDisplayResult();
        //        e.Handled = true;
        //    }
        //    else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
        //    {
        //        int number = e.Key - Key.NumPad0;
        //        textBlock += number.ToString();
        //        tBlock.Text = textBlock;
        //        e.Handled = true;
        //    }
        //}
    }
}
