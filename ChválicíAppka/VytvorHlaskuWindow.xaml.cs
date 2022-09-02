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

namespace ChválicíAppka
{
    /// <summary>
    /// Interakční logika pro VytvorHlaskuWindow.xaml
    /// </summary>
    public partial class VytvorHlaskuWindow : Window
    {
        Hlaska h;
        public VytvorHlaskuWindow(Hlaska h)
        {
            this.h = h;
            InitializeComponent();
        }

        private void vytvorHlaskuStornoButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void vytvorHlaskuPridatButton_Click(object sender, RoutedEventArgs e)
        {
            if (vytvoreniHlaskyHlaskaTextBox.Text != "" && vytvoreniHlaskyHlaskaTextBox != null) {
                h.Text = vytvoreniHlaskyHlaskaTextBox.Text;
                h.Pochvala = (bool)vytvorHlaskuPochavalaRadio.IsChecked ? true : false;
                this.Close();
            }
        }
    }
}
