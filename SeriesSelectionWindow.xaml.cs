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
using System.Windows.Shapes;

namespace LittleDragon
{
    /// <summary>
    /// Логика взаимодействия для SeriesSelectionWindow.xaml
    /// </summary>
    public partial class SeriesSelectionWindow : Window
    {
        public static bool IsFirstSeriesCompleted { get; set; } = false;
        public SeriesSelectionWindow()
        {
            InitializeComponent();
        }
        private void FirstSeriesButton_Click(object sender, RoutedEventArgs e)
        {
            FirstSeriesWindow firstSeriesWindow = new FirstSeriesWindow();
            firstSeriesWindow.Show();
            this.Close();
        }
        private void SecondSeriesButton_Click(object sender, RoutedEventArgs e)
        {
            SecondSeriesWindow secondSeriesWindow = new SecondSeriesWindow();
            secondSeriesWindow.Show();
            this.Close();
        }

    }
}
