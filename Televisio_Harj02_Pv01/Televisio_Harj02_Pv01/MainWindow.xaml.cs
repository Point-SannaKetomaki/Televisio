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

namespace Televisio_Harj02_Pv01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TelkkuOnOffInfo();
            LblVaroitus.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        }

        Televisio omaTV = new Televisio(1);


        private void BtnOnOff_Click(object sender, RoutedEventArgs e)
        {

            omaTV.Merkki = "Sony";
            omaTV.RuudunKoko = "55 tuumaa";

            if (omaTV.OnOff == false)
            {
                omaTV.TelkkariPäälle();
                TelkkuOnOffInfo();
                LblTelkkuInfo.Content = "Tietoja TV:stä" + "\n" + "Merkki: " + omaTV.Merkki + "\n" + "Ruudun koko: " + omaTV.RuudunKoko;
                LblKanavaNäyttö.Content = "Kanava " + omaTV.Kanava; 
            }
            else
            {
                omaTV.SammutaTelkkari();
                TelkkuOnOffInfo();
                LblKanavaNäyttö.Content = "";
                LblTelkkuInfo.Content = "";
                LblVolyymi.Content = "";
                LblKirkkaus1.Content = "";
                SldVolyymi.Value = 0;
                SldKirkkaus.Value = 0;
            }
        }

        private void TelkkuOnOffInfo()
        {
            LblTelkkuOnOff.Content = "TV on päällä: " + omaTV.OnOff;
        }


        private void BtnAsetaKanava_Click(object sender, RoutedEventArgs e)
        {
            int kanava = int.Parse(TxtKanava.Text);
            if (omaTV.OnOff == true)
            {
                omaTV.Kanava = kanava;
                TxtKanava.Clear();
                LblKanavaNäyttö.Content = "Kanava " + kanava;

                if (kanava < 0 || kanava > 25)
                {
                    LblKanavaNäyttö.Content = "";
                }
            }
            else
            {
                MessageBox.Show("Laita ensin TV päälle ja valitse sitten vasta kanava");
                TxtKanava.Clear();
            }


        }

        

        private void BtnAsetaKirkkaus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (omaTV.OnOff == true)
                {
                    int kirkkaus = int.Parse(TxtKirkkaus.Text);
                    omaTV.Kirkkaus = kirkkaus;
                    LblKirkkaus1.Content = kirkkaus;

                    //slider liikkuu sen mukaan, mikä arvo talletetaan txt-boxiin
                    double arvo = double.Parse(TxtKirkkaus.Text);
                    SldKirkkaus.Value = arvo;

                    if (kirkkaus < 0 || kirkkaus > 100)
                    {
                        SldKirkkaus.Value = 0;
                        LblKirkkaus1.Content = "";
                    }

                    TxtKirkkaus.Clear();

                    if (LblKanavaNäyttö.Content == "")
                    {
                        LblKirkkaus1.Content = "";
                        MessageBox.Show("Valitse ensin kavana ja sitten vasta näytön kirkkaus");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("TV:n tulee olla päällä ennen kuin voit säätää kirkkautta. Laita TV päälle.");
                TxtKirkkaus.Clear();
            }
            
            
        }
        private void BtnÄänestä_Click(object sender, RoutedEventArgs e)
        {
            if (omaTV.OnOff == true)
            {
                if (LblKanavaNäyttö.Content == "")
                {
                    MessageBox.Show("Valitse ensin kavana, jotta voit äänestää");
                }
                else
                {
                    omaTV.Äänestä();
                }
            }
            else
            {
                MessageBox.Show("TV:n tulee olla päällä ennen kuin voit äänestää. Laita TV päälle.");
            }

        }

        private void BtnPoistu_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SldVolyymi_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            if (omaTV.OnOff == true)
            {
                int äänenVoimakkuus = (int)SldVolyymi.Value;
                omaTV.ÄänenVoimakkuus = äänenVoimakkuus;
                int arvo = (int)Math.Round(SldVolyymi.Value);
                LblVolyymi.Content = arvo;

                if (LblKanavaNäyttö.Content == "")
                {
                    LblVolyymi.Content = "";
                    MessageBox.Show("Valitse ensin kavana ja sitten vasta äänenvoimakkuus");
                }
                string r = (SldVolyymi.Value * 2.55).ToString("0");
                int i = int.Parse(r);
                byte p = (byte)(255 - i);
                LblVaroitus.Background = new SolidColorBrush(Color.FromArgb((byte)i,255, 0, 0));
            }

            else
            {
                SldVolyymi.Value = 0;
            }


            //MessageBox.Show("TV:n tulee olla päällä ennen kuin voit säätää äänenvoimakkuutta. Laita TV päälle.");



        }

        private void SldKirkkaus_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (omaTV.OnOff == true)
            {

                int arvo = (int)Math.Round(SldKirkkaus.Value);
                LblKirkkaus1.Content = arvo;

                if (LblKanavaNäyttö.Content == "")
                {
                    LblKirkkaus1.Content = "";
                    MessageBox.Show("Valitse ensin kavana ja sitten vasta näytön kirkkaus");
                }
            }
            else if (omaTV.OnOff == false)
            {
                SldKirkkaus.Value = 0;
            }
            else
            {
                MessageBox.Show("TV:n tulee olla päällä ennen kuin voit säätää kirkkautta. Laita TV päälle.");
            }
        }
    }
}

    

