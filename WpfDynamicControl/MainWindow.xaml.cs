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

namespace WpfDynamicControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int iCount = 0;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnADD_Click(object sender, RoutedEventArgs e)
        {
            iCount++;
            if (iCount > 10) return;

            gridMain.RowDefinitions.Add(new RowDefinition());

            Button btn = new Button()
            {
                Height = 23,
                Margin = new Thickness(5, 5, 5, 5),
                Content = "Test" + iCount.ToString(),
            };
            gridMain.Children.Add(btn);
            Grid.SetColumn(btn, 0);
            Grid.SetRow(btn, iCount - 1);

            TextBox tb = new TextBox()
            {
                Height = 23,
                Margin = new Thickness(5, 5, 5, 5)
            };
            gridMain.Children.Add(tb);
            Grid.SetColumn(tb, 1);
            Grid.SetRow(tb, iCount - 1);
        }            
        
    }
}
