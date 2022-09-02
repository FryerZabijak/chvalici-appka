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
using System.Collections.ObjectModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;



namespace ChválicíAppka
{
    [Serializable]
    /// <summary>
    /// Interakční logika pro NastaveniWindow.xaml
    /// </summary>
    public partial class NastaveniWindow : Window
    {
        ObservableCollection<Clovek> seznamLidi = new ObservableCollection<Clovek>();
        ObservableCollection<Hlaska> vsechnyHlasky = new ObservableCollection<Hlaska>();
        Clovek c;
        Hlaska vybranaHlaska;

        public NastaveniWindow(ObservableCollection<Clovek> lidiAll, ObservableCollection<Hlaska> hlaskyAll)
        {
            InitializeComponent();

            seznamLidi = lidiAll;
            vsechnyHlasky = hlaskyAll;
            

            nastaveniSeznamJmenListBox.ItemsSource = seznamLidi;
            nastaveniSeznamHlasekListBox.ItemsSource = vsechnyHlasky;
        }

        private void nastaveniPridatJmenoButton_Click(object sender, RoutedEventArgs e)
        {
            c = new Clovek();
            var VytoreniJmenaWindow = new VytvorJmenoWindow(c);
            VytoreniJmenaWindow.ShowDialog();
            
            if(c.Jmeno!=null && c.Jmeno!="") seznamLidi.Add(c);
        }

        private void nastaveniOdebratJmenoButton_Click(object sender, RoutedEventArgs e)
        {
            seznamLidi.Remove((Clovek)nastaveniSeznamJmenListBox.SelectedItem);
        }

        private void nastaveniPridatHlaskuButton_Click(object sender, RoutedEventArgs e)
        {
            Hlaska h = new Hlaska();
            var hlaskaWindow = new VytvorHlaskuWindow(h);
            hlaskaWindow.ShowDialog();
            
            if(h.Text!=null && h.Text!="") vsechnyHlasky.Add(h);
        }

        private void nastaveniOdebratHlaskuButton_Click(object sender, RoutedEventArgs e)
        {
            vsechnyHlasky.Remove((Hlaska)nastaveniSeznamHlasekListBox.SelectedItem);
        }

        private void nastaveniSeznamJmenListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            c = (Clovek)nastaveniSeznamJmenListBox.SelectedItem;
            if(c!=null && c.Jmeno!="") AktualizujHlasky(c);
        }

        public void AktualizujHlasky(Clovek clovek)
        {
            nastaveniSeznamUrazlivychHlasekListBox.Items.Clear();
            nastaveniSeznamChvalicichHlasekListBox.Items.Clear();

            foreach(Hlaska hlaska in clovek.seznamHlasek)
            {
                if (hlaska.Pochvala) nastaveniSeznamChvalicichHlasekListBox.Items.Add(hlaska);
                else nastaveniSeznamUrazlivychHlasekListBox.Items.Add(hlaska);
            }
        }

        private void nastaveniPridatHlaskuClovekuButton_Click(object sender, RoutedEventArgs e)
        {
            Hlaska hlaskaKPridani = (Hlaska)nastaveniSeznamHlasekListBox.SelectedItem;

            if (c != null && c.Jmeno != "")
            {
                if (hlaskaKPridani != null)
                {
                    if (!c.seznamHlasek.Contains(hlaskaKPridani))
                    {
                        c.seznamHlasek.Add(hlaskaKPridani);
                        AktualizujHlasky(c);
                    }
                    else MessageBox.Show("Nemůžeš přidat tuto hlášku, protože už přidaná je.");
                }
                else MessageBox.Show("Nebyla vybrána žádná hláška.");
            }
            else MessageBox.Show("Nebyl vybrán žádný člověk ke kterému by se hláška měla přidat.");

        }

        private void nastaveniOdebratHlaskuClovekuButton_Click(object sender, RoutedEventArgs e)
        {
            Hlaska hlaskaKOdebrani = vybranaHlaska;

            if (hlaskaKOdebrani != null && hlaskaKOdebrani.Text != "")
            {
                c.seznamHlasek.Remove(hlaskaKOdebrani);
                AktualizujHlasky(c);
            }
            else MessageBox.Show("Nebyla vybrána hláška k odebrání.");
        }

        private void nastaveniSeznamUrazlivychHlasekListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vybranaHlaska = (Hlaska)nastaveniSeznamUrazlivychHlasekListBox.SelectedItem;
        }

        private void nastaveniSeznamChvalicichHlasekListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vybranaHlaska = (Hlaska)nastaveniSeznamChvalicichHlasekListBox.SelectedItem;
        }

        private void nastaveniStornoButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ulozitButton_Click(object sender, RoutedEventArgs e)
        {
            if (vsechnyHlasky.Count > 0)
            {
                FileStream fs = new FileStream("jmena.bin", FileMode.OpenOrCreate);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, seznamLidi);
                fs.Close();

                fs = new FileStream("hlasky.bin", FileMode.OpenOrCreate);
                bf.Serialize(fs, vsechnyHlasky);
                fs.Close();

                this.Close();
            }
            else MessageBox.Show("Vytvořte, prosím, alespoň jednu hlášku.");
        }
    }
}
