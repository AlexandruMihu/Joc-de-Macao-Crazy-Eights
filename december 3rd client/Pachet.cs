using december_3rd_client.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace december_3rd_client
{
    public class Pachet
    {
        /////////////// Atribute pachet ////////////////////////

        protected int nrCarti;
        private List<Carte> deck = new List<Carte>();

        /////////////// Constructor pachet ////////////////////////
        
        public Pachet(int nrC)
        {
            this.nrCarti = nrC;
            this.initializarePachet1();
            this.shufflePachet();
        }
        public Pachet()
        {
            this.nrCarti = 0;
        }

        ///////////// Initializarea pachetului cu toate cartile ////////////

        private void initializarePachet1()
        {
            for(SIMBOL s = SIMBOL.Romb; s <= SIMBOL.Trefla; s++)
            {
                for (VALOARE v = VALOARE.Doi; v <= VALOARE.Rege; v++)
                    this.deck.Add(new Carte(v, s));
            }
            this.deck.Add(new Carte(VALOARE.Joker,SIMBOL.Negru));
            this.deck.Add(new Carte(VALOARE.Joker,SIMBOL.Rosu));
        }

        ///////////// Mutare carti dintr-un pachet in altul ////////////
        public void mutareCarti(Pachet pachetOriginal)
        {
            foreach (Carte c in this.deck)
            {
                pachetOriginal.deck.Add(c);
            }
            pachetOriginal.nrCarti = pachetOriginal.deck.Count;
            
            this.deck.Clear();
            this.nrCarti = 0;
            pachetOriginal.shufflePachet();
        }

        ///////////////////// Afisare carti din pachet //////////////////////

        virtual public void afisarePachetForm(JocMacaoClient joc,int d)
        {
                int j = 0;
                for(int i = this.nrCarti-1;i >= 0; i--)
                {
                    Carte c = getCarteDinPachet(i);
                    c.getImagineCarte().Location = new Point(175 + 50 * d + (c.getImagineCarte().Width + 10) * (j % 2), 100 + (c.getImagineCarte().Height + 5) * (j / 2));
                    joc.getForm().Controls.Add(c.getImagineCarte());
                    j++;
                } 
        }

        //////////////////////// Shuffle pachet //////////////////////////////
        
        private void shufflePachet()
        {
            Random rand = new Random();
            Carte c;
            for (int shuffleTime = 0; shuffleTime < 1000; shuffleTime++)
                for (int i = 0; i < this.deck.Count; i++)
                {
                    int index = rand.Next(this.deck.Count-1);
                    c = deck[i];
                    deck[i] = deck[index];
                    deck[index] = c;
                }
        }
        
        /////////////////////// Getter Deck //////////////////////////

        public List<Carte> getDeck()
        {
            return this.deck;
        }
        
        public Carte getCarteDinPachet(int i)
        {
            return this.deck[i];
        }
        public int getNrCarti()
        {
            return this.nrCarti;
        }
        public void setNrCarti(int i)
        {
            this.nrCarti = i;
        }
        /////////////////////// Decrementare numar carti //////////////////////////
        public void decrementNrCarti()
        {
            this.nrCarti--;
        }
        public void incrementNrCarti()
        {
            this.nrCarti++;
        }

    }
}
