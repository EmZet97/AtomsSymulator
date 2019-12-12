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

namespace AtomsSymulator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TimeFrameManager framer;
        bool started = true;
        public MainWindow()
        {
            
            InitializeComponent();
            Scene scene = new Scene(400, new Vector2D(0, 0));
            framer = new TimeFrameManager(0.03, PlainCanvas, scene, this);
            framer.Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            double sx = r.Next(-50, 50) / 10;
            double sy = r.Next(-50, 50) / 10;
            double sr = r.Next(50, 200) / 10;
            Point p = new Point(new Vector2D(200, 200), new Vector2D(sx, sy), sr);
            framer.AddPointToRenderer(p);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (started)
                framer.Stop();
            else
                framer.Start();

            started = !started;
        }
    }
}
