using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Televisio_Harj02_Pv01
{
    public class Televisio
    {
        public Televisio(int k)
        { Kanava = k; }  //itsetehty muodostin, jolla kanava-propertyn oletusarvo = 1
        public string Merkki { get; set; }

        public string RuudunKoko { get; set; }


        public bool OnOff { get; set; } = false;  // TV päälle / pois
    


        private int kanava;

        public int Kanava
        {
            get
            {
                return kanava;
            }
            set
            {
                if (value >= 1 && value <= 25)
                {
                    kanava = value;
                }
                else
                {
                    MessageBox.Show("Tee kanavavalinta väliltä 1-25");
                }
            }
                
        } 


        private int äänenVoimakkuus;
        public int ÄänenVoimakkuus
        {
            get
            {
                return äänenVoimakkuus;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    äänenVoimakkuus = value;
                }
                else
                {
                    //EI OLE HYVÄ TEHDÄ LUOKASSA ASIOITA; JOTKA VAIKUTTAVAT KÄYTTÖLIITTYMÄÄN (MessageBox etc)
                    //Tämä käytäntö rikkoo luokan kapseloinnin
                    //MessageBox.Show("Äänenvoimakkuuden tulee olla väliltä 0-100");
                    throw new ArgumentOutOfRangeException();
                    //throw new Exception();  Tälläkin ohjelma toimisi, koska syy on selvä eli äänenvoimakkuuden arvo
                }
            }
        }

        private int kirkkaus;
        public int Kirkkaus
        {
            get
            {
                return kirkkaus;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    kirkkaus = value;
                }
                else
                {
                    //MessageBox.Show("Kirkkauden tulee olla väliltä 0-100");
                    throw new ArgumentOutOfRangeException();  //Tämä esimerkkinä valmiista virheilmoitusproseduurista!
                }
            }
        }


        public void TelkkariPäälle()
        {
            OnOff = true;
        }

        public void SammutaTelkkari()
        {
            OnOff = false;
        }

        public void Äänestä()
        {
            MessageBox.Show("Äänestys käynnissä!");
        }
    }
}
