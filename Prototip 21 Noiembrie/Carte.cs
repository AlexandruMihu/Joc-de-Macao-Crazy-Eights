using Prototip_21_Noiembrie.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototip_21_Noiembrie
{
    public class Carte
    {
        ///////////////Atribute carte////////////////////////

        private SIMBOL simbolCarte;
        private VALOARE valoareCarte;
        private string numeCarte;
        private PictureBox imagineCarte = new PictureBox();

        ///////////////Constructor carte////////////////////////

        public Carte(VALOARE valoareCarte1, SIMBOL simbolCarte1)
        {
            this.valoareCarte = valoareCarte1;
            this.simbolCarte = simbolCarte1;
            this.setNumeCarte();
            this.imagineCarte.Name = this.getNumeCarte();
            this.imagineCarte.Width = 75;
            this.imagineCarte.Height = 112;
            this.imagineCarte.Image = Image.FromFile("E:\\Proiect POO Mihu Alexandru-Ioan\\Prototip 21 Noiembrie\\Resources\\" + numeCarte + ".png");
            this.imagineCarte.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public Carte()
        {
            this.imagineCarte.Width = 180;
            this.imagineCarte.Height = 270;
            this.imagineCarte.SizeMode = PictureBoxSizeMode.StretchImage;
            this.valoareCarte = VALOARE.None;
            this.simbolCarte = SIMBOL.None;
        }

        public Carte(Carte c)
        {
            this.valoareCarte = c.valoareCarte;
            this.simbolCarte = c.simbolCarte;
            this.numeCarte = c.numeCarte;
            this.imagineCarte.Width = 180;
            this.imagineCarte.Height = 270;
            this.imagineCarte.SizeMode = PictureBoxSizeMode.StretchImage;
            this.imagineCarte.Location = new Point(12, 300);
            this.imagineCarte.Image = Image.FromFile("E:\\Proiect POO Mihu Alexandru-Ioan\\Prototip 21 Noiembrie\\Resources\\" + c.numeCarte + ".png");
        }
        

        public Carte(string nume)
        {   
            this.setNumeCarte(nume);
            string[] numeSeparat = nume.Split('_');
            

            switch (numeSeparat[0])
            {
                case "none": this.setValoareCarte(VALOARE.None); break;
                case "ace": this.setValoareCarte(VALOARE.As); break;
                case "2": this.setValoareCarte(VALOARE.Doi); break;
                case "3": this.setValoareCarte(VALOARE.Trei); break;
                case "4": this.setValoareCarte(VALOARE.Patru); break;
                case "5": this.setValoareCarte(VALOARE.Cinci); break;
                case "6": this.setValoareCarte(VALOARE.Sase); break;
                case "7": this.setValoareCarte(VALOARE.Sapte); break;
                case "8": this.setValoareCarte(VALOARE.Opt); break;
                case "9": this.setValoareCarte(VALOARE.Noua); break;
                case "10": this.setValoareCarte(VALOARE.Zece); break;
                case "jack": this.setValoareCarte(VALOARE.Valet); break;
                case "queen": this.setValoareCarte(VALOARE.Dama); break;
                case "king": this.setValoareCarte(VALOARE.Rege); break;
                case "joker": this.setValoareCarte(VALOARE.Joker); break;
            }

            switch (numeSeparat[2])
            {
                case "none": this.setSimbolCarte(SIMBOL.None); break;
                case "clubs": this.setSimbolCarte(SIMBOL.Trefla); break;
                case "diamonds": this.setSimbolCarte(SIMBOL.Romb); break;
                case "hearts": this.setSimbolCarte(SIMBOL.InimaRosie); break;
                case "spades": this.setSimbolCarte(SIMBOL.InimaNeagra); break;
                case "red": this.setSimbolCarte(SIMBOL.Rosu); break;
                case "black": this.setSimbolCarte(SIMBOL.Negru); break;
            }

            this.imagineCarte.Name = nume;
            this.imagineCarte.Width = 75;
            this.imagineCarte.Height = 112;
            this.imagineCarte.Image = Image.FromFile("E:\\Proiect POO Mihu Alexandru-Ioan\\Prototip 21 Noiembrie\\Resources\\" + getNumeCarte() + ".png");
            this.imagineCarte.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        ///////////////Setters atribute////////////////////////

        public void setSimbolCarte(SIMBOL simb)
        {
            this.simbolCarte = simb;
        }
        public void setValoareCarte(VALOARE val)
        {
            this.valoareCarte = val;
        }
        public void setNumeCarte(string numeCarte)
        {
            this.numeCarte = numeCarte;
        }
        public void setNumeCarte()
        {
            this.numeCarte = "";
            switch (this.valoareCarte)
            {
                case VALOARE.Doi: this.numeCarte += "2"; break;
                case VALOARE.Trei: this.numeCarte += "3"; break;
                case VALOARE.Patru: this.numeCarte += "4"; break;
                case VALOARE.Cinci: this.numeCarte += "5"; break;
                case VALOARE.Sase: this.numeCarte += "6"; break;
                case VALOARE.Sapte: this.numeCarte += "7"; break;
                case VALOARE.Opt: this.numeCarte += "8"; break;
                case VALOARE.Noua: this.numeCarte += "9"; break;
                case VALOARE.Zece: this.numeCarte += "10"; break;
                case VALOARE.As: this.numeCarte += "ace"; break;
                case VALOARE.Valet: this.numeCarte += "jack"; break;
                case VALOARE.Dama: this.numeCarte += "queen"; break;
                case VALOARE.Rege: this.numeCarte += "king"; break;
                case VALOARE.Joker: this.numeCarte += "joker"; break;
            }
            this.numeCarte += "_of_";
            switch (this.simbolCarte)
            {
                case SIMBOL.Romb: this.numeCarte += "diamonds"; break;
                case SIMBOL.InimaRosie: this.numeCarte += "hearts"; break;
                case SIMBOL.InimaNeagra: this.numeCarte += "spades"; break;
                case SIMBOL.Trefla: this.numeCarte += "clubs"; break;
                case SIMBOL.Negru: this.numeCarte += "black"; break;
                case SIMBOL.Rosu: this.numeCarte += "red"; break;
            }
        }

        ///////////////Getters atribute////////////////////////

        public SIMBOL getSimbolCarte()
        {
            return this.simbolCarte;
        }
        public VALOARE getValoareCarte()
        {
            return this.valoareCarte;
        }
        public string getNumeCarte()
        {
            return this.numeCarte;
        }
        public PictureBox getImagineCarte()
        {
            return this.imagineCarte;
        }

        /////////////// Verificare compatibilitate ////////////////////////
        public bool verifCompatibilitate(Carte c,int mode)
        {
            if(mode == 1)
            {
                if (c.getSimbolCarte() == this.getSimbolCarte())
                    return true;
                if (c.getValoareCarte() == this.getValoareCarte())
                    return true;
                if (SIMBOL.None == this.getSimbolCarte())
                    return true;

                if(c.getValoareCarte() == VALOARE.Joker && c.getSimbolCarte() == SIMBOL.Rosu&& (this.getSimbolCarte() == SIMBOL.Romb || this.getSimbolCarte() == SIMBOL.InimaRosie))
                    return true; 
                if (c.getValoareCarte() == VALOARE.Joker && c.getSimbolCarte() == SIMBOL.Negru&& (this.getSimbolCarte() == SIMBOL.Trefla || this.getSimbolCarte() == SIMBOL.InimaNeagra))
                    return true;
                if(this.getValoareCarte() == VALOARE.Joker && this.getSimbolCarte() == SIMBOL.Rosu&& (c.getSimbolCarte() == SIMBOL.Romb || c.getSimbolCarte() == SIMBOL.InimaRosie))
                    return true; 
                if (this.getValoareCarte() == VALOARE.Joker && this.getSimbolCarte() == SIMBOL.Negru&& (c.getSimbolCarte() == SIMBOL.Trefla || c.getSimbolCarte() == SIMBOL.InimaNeagra))
                    return true;
                

            }
            else if (mode == 2)          
                 if (c.getValoareCarte() ==VALOARE.Joker ||c.getValoareCarte() == VALOARE.Doi || c.getValoareCarte() == VALOARE.Valet || c.getValoareCarte() == VALOARE.Rege )
                        return true;

            return false;
        }
    }
}
