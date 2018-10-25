using SD_UN_version1.Controller;
using SD_UN_version1.Model.Connectors;
using SD_UN_version1.Model.Shapes;
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

namespace SD_UN_version1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MouseController pmouse;
        public MainWindow()
        {
            InitializeComponent();
            pmouse = new MouseController(canvas);
            get();
        }
        Box bp;
        public void get()
        {
           //  DiagonalConnector p = new DiagonalConnector(canvas,new Point(20,120), new Point(20+50, 120+50));
            
        }

        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
          
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
           

        }
    }
}