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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.ObjectModel;

namespace ChválicíAppka
{
    [Serializable]
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Clovek> seznamVsechLidi = new ObservableCollection<Clovek>();
        ObservableCollection<Hlaska> seznamVsechHlasek = new ObservableCollection<Hlaska>();

        
        Random rd = new Random();
        public MainWindow()
        {
            InitializeComponent();

            bool nacteno = NactiSave();
            if (!nacteno)
            {
                var nastaveniOkno = new NastaveniWindow(seznamVsechLidi, seznamVsechHlasek);
                nastaveniOkno.ShowDialog();
            }
        }

        private void nastaveniButton_Click(object sender, RoutedEventArgs e)
        {
            var nastaveniWindow = new NastaveniWindow(seznamVsechLidi, seznamVsechHlasek);
            nastaveniWindow.ShowDialog();
        }

        private void vykonejButton_Click(object sender, RoutedEventArgs e)
        {
            //1. pochvala
            //2. urážka
            //3. random
            var odpoved=3;

            if ((bool)pochvalaRadio.IsChecked) odpoved = 1;
            else if ((bool)urazkaRadio.IsChecked) odpoved = 2;
            if (odpoved == 3) odpoved = rd.Next(1, 3);  //Pokud je random, vygeneruje náhodně jednu ze dvou

            bool pochvala = (odpoved == 1) ? true : false;

            var jmeno = jmenoTextBox.Text;
            if (jmeno != "")
            {
                Clovek nalezenyClovek = new Clovek();
                foreach (Clovek c in seznamVsechLidi)
                {
                    if (c.Jmeno == jmeno) nalezenyClovek = c;
                }

                int chvalici = VratTypyHlasek(nalezenyClovek.seznamHlasek)[0], urazlive = VratTypyHlasek(nalezenyClovek.seznamHlasek)[1];

                if (nalezenyClovek != null && nalezenyClovek.Jmeno != "" && nalezenyClovek.seznamHlasek.Count > 0)  //Pokud jméno je v seznamu a zároveň má nějaké hlášky
                {
                    if ((bool)randomRadio.IsChecked)
                    {
                        if (pochvala == true && chvalici <= 0) pochvala = false;
                        else if (pochvala == false && urazlive <= 0) pochvala = true;
                    }
                    if (pochvala && chvalici > 0)//Pokud existuje u člověka v seznamu alespoň jedna chválicí hláška
                    {
                        MessageBox.Show(vyberHlasku(jmeno, pochvala));
                    }
                    else if (!pochvala && urazlive > 0) //Pokud existuje u člověka v seznamu alespoň jedna urážlivá hláška
                    {
                        MessageBox.Show(vyberHlasku(jmeno, pochvala));
                    }
                    else
                    {
                        VypisNahodnouHlasku(pochvala);
                    }
                }
                else
                {
                    //POKUD SI UŽIVATEL VYBERE NÁHODNOU HLÁŠKU, TAK PROGRAM VYBERE TYP HLÁŠKY
                    //POKUD U JMÉNA, KTERÝ UŽIVATEL ZADAL NENÍ ŽÁDNÁ HLÁŠKA, TAK ZKONTROLUJE, JESTLI TENTO TYP HLÁŠKY EXISTUJE
                    //POKUD NE PŘEHODÍ TYP HLÁŠKY NA DRUHÝ TYP
                    if ((bool)randomRadio.IsChecked)
                    {
                        chvalici = VratTypyHlasek(seznamVsechHlasek)[0];
                        urazlive = VratTypyHlasek(seznamVsechHlasek)[1];
                        if (pochvala == true && chvalici <= 0) pochvala = false;
                        else if (pochvala == false && urazlive <= 0) pochvala = true;
                    }
                    VypisNahodnouHlasku(pochvala);
                }
            }
            else MessageBox.Show("Zadejte, prosím, jméno.");
        }

        public int[] VratTypyHlasek(ObservableCollection<Hlaska> hlasky)
        {
            int chvalici = 0;
            int urazlive = 0;
            foreach (Hlaska h in hlasky)
            {
                if (h.Pochvala) chvalici++;
                else urazlive++;
            }
            int[] array1 = { chvalici, urazlive};
            return array1;
        }

        public void VypisNahodnouHlasku(bool pochvala)
        {
            Hlaska NahodnaHlaska = VyberNahodnouHlaskuPodleTypu(pochvala);

            //if (NahodnaHlaska == null) NahodnaHlaska = VyberUplneNahodnouHlasku();
            //AKTIVOVAT TOTO, POKUD CHCETE, ABY PŘI ABSENCI HLÁŠKY PODLE TYPU NEBUDE BRÁT OHLED NA TYP HLÁŠKY
            //(TZN. NAPŘ. POKUD UŽIVATEL BUDE POŽADOVAT CHVÁLICÍ HLÁŠKU A ŽÁDNÁ CHVÁLÍCÍ HLÁŠKA NEBUDE (A URÁŽLIVÁ BUDE ALESPOŇ 1),
            //NEVYHODÍ ERROR, ALE TU URÁŽLIVOU.

            if(NahodnaHlaska != null) MessageBox.Show(NahodnaHlaska.ToString()); 

            else MessageBox.Show("Nebyla nalezena žádná hláška, prosím, nakonfigurujte si nějakou.");
        }

        public Hlaska VyberUplneNahodnouHlasku()
        {
            if (seznamVsechHlasek.Count > 0)
            {
                Hlaska NahodnaHlaska = seznamVsechHlasek[rd.Next(0, seznamVsechHlasek.Count)];

                return NahodnaHlaska;
            }

            return null;
        }

        public Hlaska VyberNahodnouHlaskuPodleTypu(bool typ)
        {
            if (seznamVsechHlasek.Count > 0)
            {
                Hlaska NahodnaHlaska;
                var spravnyTyp = false;
                foreach (Hlaska h in seznamVsechHlasek) if (h.Pochvala.Equals(typ)) { spravnyTyp |= true; break; }
                if (spravnyTyp)
                    do
                    {
                        NahodnaHlaska = seznamVsechHlasek[rd.Next(0, seznamVsechHlasek.Count)];
                    } while (NahodnaHlaska.Pochvala != typ);
                else return null;

                return NahodnaHlaska;
            }

            return null;
        }

        public string vyberHlasku(string jmeno, bool pochvala)
        {
            Clovek hledanyClovek = new Clovek();

            foreach(Clovek c in seznamVsechLidi)
            {
                if (c.Jmeno.ToLower() == jmeno.ToLower())
                {
                    hledanyClovek = c;
                    break;
                }
            }

            ObservableCollection<Hlaska> losovaciHlasky = new ObservableCollection<Hlaska>();
            foreach(Hlaska h in hledanyClovek.seznamHlasek)
            {
                if(h.Pochvala==pochvala)
                {
                    losovaciHlasky.Add(h);
                }
            }

            string vyslednaHlaska = losovaciHlasky[rd.Next(0, losovaciHlasky.Count)].ToString();
            return vyslednaHlaska;
        }

        public bool NactiSave()
        {
            bool jmenaSave = false;
            //  NAČTENÍ JMEN
            try
            {
                FileStream fs = new FileStream("jmena.bin", FileMode.OpenOrCreate);
                BinaryFormatter bf = new BinaryFormatter();
                seznamVsechLidi = (ObservableCollection<Clovek>)bf.Deserialize(fs);
                fs.Close();
                jmenaSave = true;
            }
            catch
            {
                MessageBox.Show("Nepodařilo se načíst jména.");
            }

            bool hlaskySave = false;

            //NAČTENÍ HLÁŠEK
            try
            {
                FileStream fs = new FileStream("hlasky.bin", FileMode.OpenOrCreate);
                BinaryFormatter bf = new BinaryFormatter();
                seznamVsechHlasek = (ObservableCollection<Hlaska>)bf.Deserialize(fs);
                hlaskySave = true;
            }
            catch
            {
                MessageBox.Show("Nepodařilo se načíst hlášky.");
            }

            return (jmenaSave && hlaskySave);
        }
    }
}
