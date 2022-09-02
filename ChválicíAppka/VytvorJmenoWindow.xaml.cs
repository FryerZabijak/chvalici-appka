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
    /// Interakční logika pro VytvorJmenoWindow.xaml
    /// </summary>
    public partial class VytvorJmenoWindow : Window
    {
        Clovek c;
        public VytvorJmenoWindow(Clovek c)
        {
            this.c = c;
            InitializeComponent();
        }

        private void vytvorJmenoStornoButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void VytvorJmenoPridejJmenoButton_Click(object sender, RoutedEventArgs e)
        {
            c.Jmeno = VytvoreniJmenaJmenoTextBox.Text;
            this.Close();
        }
    }
}
