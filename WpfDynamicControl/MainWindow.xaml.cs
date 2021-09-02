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
        double MaxWidth = 0.0;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnADD_Click(object sender, RoutedEventArgs e)
        {
            iCount++;
            if (iCount > 10) return;
            
            DockPanel dp = new DockPanel() 
            { 
                LastChildFill = true
            };

            Button btn = new Button()
            {
                Height = 23,
                Margin = new Thickness(5,5,5,5),
                Content = "Test" + iCount.ToString()
            };
            dp.Children.Add(btn);

            TextBox tb = new TextBox() 
            { 
                Height = 23,
                Margin = new Thickness(5, 5, 5, 5)
            };
            dp.Children.Add(tb);

            spMain.Children.Add(dp);

            Dispatcher.BeginInvoke(new Action(() =>
            {
                tb.Text = btn.ActualWidth.ToString();

                if (btn.ActualWidth > MaxWidth) 
                {
                    MaxWidth = btn.ActualWidth;
                }

                foreach (var childdp in spMain.Children) 
                {
                    if(childdp is DockPanel)
                    foreach (var ccdp in ((DockPanel)childdp).Children) 
                    {
                        if (ccdp is Button) 
                        {
                                ((Button)ccdp).Width = MaxWidth; 
                        }
                    }
                }

            }),
            DispatcherPriority.Loaded);

            
        }
    }
}
