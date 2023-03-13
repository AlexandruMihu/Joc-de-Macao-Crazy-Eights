using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Prototip_21_Noiembrie
{
    public class Player : Pachet
    {
        /////////////// Atribute player ////////////////////////
        
        private string numePlayer;

        /////////////// Constructor player ////////////////////////

        public Player(string nume,JocMacaoServer j)
        {
            this.numePlayer = nume;

            for (int i = 0; i < 5; i++)
                iaCarte(j.getPachetOriginal());
            this.nrCarti = 5;
        }
        public Player(string nume)
        {
            this.numePlayer = nume;
            this.nrCarti = 0;
        }


        /////////////// Metoda luare o singura carte din pachet ///////////////////////

        public void iaCarte(Pachet pachetOriginal)
        {
            Carte c = new Carte();
            c = pachetOriginal.getCarteDinPachet(pachetOriginal.getNrCarti()-1);
            pachetOriginal.getDeck().Remove(c);
            pachetOriginal.decrementNrCarti();
            this.getDeck().Add(c);
            this.nrCarti++;
        }
        
        ///////////////////// Metoda luat mai multe carti din pachet //////////////////////
        ///
        public void infuleca(int stackInfulecat,Pachet pachetOriginal,JocMacaoServer joc,int d)
        {
            for (int i = 1; i <= stackInfulecat; i++)
               this.iaCarte(pachetOriginal); 
            this.afisarePachetForm(joc, d);    
        }

        /////////////// Metoda pune jos carte din mana ///////////////////////
        
        public void puneJos(JocMacaoServer j)
        {
            j.carteaDeJos =new Carte(j.getCarteaSelectata());
            j.getForm().Controls.Add(j.carteaDeJos.getImagineCarte());
            this.getDeck().Remove(j.getCarteaSelectata());
            j.getForm().Controls.Remove(j.getCarteaSelectata().getImagineCarte());
        }

        ///////////////////// Afisare carti Player //////////////////////
       override public void afisarePachetForm(JocMacaoServer joc,int d)
        {
            int j = 0;
            foreach (Carte c in this.getDeck())
            {
                c.getImagineCarte().Location = new Point(175 + 50*d + (c.getImagineCarte().Width + 10) * (j % 2), 100 + (c.getImagineCarte().Height + 5) * (j / 2));
                joc.getForm().Controls.Add(c.getImagineCarte());
                j++;
            }
        }
        ///////////////////// Getter Player Name //////////////////////
        public string getNumePlayer()
        {
            return this.numePlayer;
        }

    }
}
