using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace december_3rd_client
{
    public class JocMacaoClient
    {
        /////////////// Variabile Form1 ////////////////////////
         
        public TcpClient client;
        public NetworkStream clientStream;
        public bool ascult;
        public Thread t;
        
        private  Pachet pachetOriginal;
        private  Pachet pachetJos;
        public   Carte carteaDeJos;
        private  Player Player1;
        private  Player Player2;
        private  Carte carteaSelectata;
        private  int turnPlayer;
        private  int mode;
        private  int stackInfulecat;

        public fJocClient Form1;

        //string mesajCarti = "";
        string name1, name2;

        /// Mode
        /// 1 = Normal Mode
        /// 2 = Infulecat Mode

        /////////////// Initializare JocMacao ////////////////////////

        public JocMacaoClient(fJocClient Form1,string name2)
        {
            this.Form1 = Form1;
           
            this.name1 = "Player 1";
            this.name2 = name2;
           
            

            carteaSelectata = new Carte();
            pachetJos = new Pachet();

            turnPlayer = 1;
            mode = 1;
            stackInfulecat = 1;

            Form1.btnPuneCarte.Enabled = false;
        }

        //////////////// Asculta client //////////////////
        private void Asculta_client()
        {
            StreamReader citire = new StreamReader(clientStream);
            String dateClient;
            while (ascult)
            {
                dateClient = citire.ReadLine();
                
                MethodInvoker m = new MethodInvoker(() => {
                    
                    
                    string[] mesaj = dateClient.Split('*');

                    switch (mesaj[0])
                    {
                        case "#":
                            {
                                name1 = mesaj[1];
                                Form1.labelPachet1.Text += name1;
                                Player1.setNumePlayer(name1);
                            }
                            break;

                        case "3": //aici se trimite Cartea de jos prin retea
                            {
                                carteaDeJos = new Carte(mesaj[1]);
                                carteaDeJos.getImagineCarte().Width = 180;
                                carteaDeJos.getImagineCarte().Height = 270;
                                carteaDeJos.getImagineCarte().Location = new Point(12, 300);
                                Form1.Controls.Add(carteaDeJos.getImagineCarte());
                                pachetOriginal.getDeck().Remove(carteaDeJos);
                                pachetOriginal.decrementNrCarti();

                                pachetOriginal.afisarePachetForm(this, 9);
                            }
                            break;

                        case "4": //aici s-a pus jos o carte
                            {
                                pachetJos.getDeck().Add(carteaDeJos);
                                pachetJos.getDeck()[pachetJos.getNrCarti()].getImagineCarte().Width = 75;
                                pachetJos.getDeck()[pachetJos.getNrCarti()].getImagineCarte().Height = 112;
                                pachetJos.incrementNrCarti();
                                pachetJos.afisarePachetForm(this, 13);
                                
                                carteaDeJos = new Carte(mesaj[1]);
                                carteaDeJos.getImagineCarte().Width = 180;
                                carteaDeJos.getImagineCarte().Height = 270;
                                carteaDeJos.getImagineCarte().Location = new Point(12, 300);
                                Form1.Controls.Add(carteaDeJos.getImagineCarte());

                                foreach (Carte c in Player1.getDeck())
                                {
                                    if (c.getNumeCarte() == carteaDeJos.getNumeCarte())
                                    {
                                        Form1.Controls.Remove(c.getImagineCarte());
                                        Player1.getDeck().Remove(c);
                                        Player1.decrementNrCarti();
                                        break;
                                    }
                                }
                                Player1.afisarePachetForm(this, 1);
                                Player2.afisarePachetForm(this, 5);

                                mode = int.Parse(mesaj[2]);
                                stackInfulecat = int.Parse(mesaj[3]);
                                turnPlayer = int.Parse(mesaj[4]);
                            }
                            break;

                        case "5": //aici s-a tras o carte din pachet
                            {
                                mode = int.Parse(mesaj[1]);
                                stackInfulecat = int.Parse(mesaj[2]);
                                turnPlayer = int.Parse(mesaj[3]);

                                for (int i = 0; i < stackInfulecat; i++)
                                {
                                    Carte c = pachetOriginal.getCarteDinPachet(pachetOriginal.getNrCarti() - 1);
                                    Player1.getDeck().Add(c);
                                    Player1.incrementNrCarti();
                                    pachetOriginal.getDeck().Remove(c);
                                    pachetOriginal.decrementNrCarti();
                                }
                                Player1.afisarePachetForm(this, 1);
                                Player2.afisarePachetForm(this, 5);
                                pachetOriginal.afisarePachetForm(this, 9);
                                stackInfulecat = 1;

                                
                            }
                            break;

                        case "6"://mutarea cartilor din Pachet de jos in Pachet Original
                            {
                                string[] listaCarti = mesaj[1].Split('%');
                                int n = int.Parse(mesaj[2]);

                                for (int i = 0; i < n; i++)
                                {
                                    pachetOriginal.getDeck().Add(new Carte(listaCarti[i]));
                                    pachetOriginal.incrementNrCarti();
                                }
                                eventClickPictureBoxes(pachetOriginal);

                                pachetOriginal.afisarePachetForm(this, 9);
                                pachetJos.afisarePachetForm(this, 13);
                            }
                            break;

                        case "7": // golire Pachet de Jos si Pachet Original
                            {
                                foreach (Carte c in pachetJos.getDeck())
                                {
                                    Form1.Controls.Remove(c.getImagineCarte());
                                }
                                pachetJos.getDeck().Clear();
                                pachetJos.setNrCarti(0);
                                pachetOriginal.getDeck().Clear();
                                pachetOriginal.setNrCarti(0);
                            }
                            break;
                    }
                    
                   
                    if (turnPlayer == 1)
                    {
                        Form1.btnIaCarte.Enabled = false;
                        this.Form1.labelTurnPlayer.Text = "Este randul lui " + Player1.getNumePlayer(); 
                    }
                    else
                    {
                        Form1.btnIaCarte.Enabled = true;
                        this.Form1.labelTurnPlayer.Text = "Este randul lui " + Player2.getNumePlayer();
                    }
                       

                });

                Form1.Invoke(m);
               
            }
        }
        /////////////// Intrerupe Retea ////////////////////////
        public void intrerupeRetea()
        {
            ascult = false;
            t.Abort();
            clientStream.Close();
            client.Close();
        }

        /////////////// Ce se intampla cand apesi pe butonul de Connect ////////////////////////

        public void Event_btnConnect()
        {
            if (Form1.btnConnect.Text == "Connect")
            {
                if (Form1.textBoxIP.Text.Length > 0)
                {
                    client = new TcpClient(Form1.textBoxIP.Text, 3000);
                    ascult = true;
                    t = new Thread(new ThreadStart(Asculta_client));
                    t.Start();
                    clientStream = client.GetStream();
                    
                    Form1.labelip.Visible = false;
                    Form1.textBoxIP.Visible = false;
                    Form1.btnConnect.Text = "Disconect";

                    Form1.labelTurnPlayer.Visible = true;
                    Form1.labelPachet1.Visible = true;
                    Form1.labelPachet2.Visible = true;
                    Form1.labelPachetOriginal.Visible = true;
                    Form1.labelPachetDeJos.Visible = true;
                    Form1.labelCarteSelectata.Visible = true;
                    Form1.labelCarteCurenta.Visible = true;
                    Form1.btnPuneCarte.Visible = true;
                    Form1.btnIaCarte.Visible = true;


                    StreamWriter scriere = new StreamWriter(clientStream);
                    scriere.AutoFlush = true; // enable automatic flushing
                    scriere.WriteLine("#*" + name2);


                    pachetOriginal = new Pachet(54);
                    eventClickPictureBoxes(pachetOriginal);

                    Player1 = new Player(name1, this);
                    Player2 = new Player(name2, this);
                    
                    Player1.afisarePachetForm(this, 1);
                    Player2.afisarePachetForm(this, 5);
 
                    scriere.AutoFlush = true; // enable automatic flushing

                    foreach (Carte c in pachetOriginal.getDeck()) 
                        scriere.WriteLine("0*"+c.getNumeCarte());
                    
                    foreach (Carte c in Player1.getDeck())
                        scriere.WriteLine("1*" + c.getNumeCarte());
                    
                    foreach (Carte c in Player2.getDeck())                     
                        scriere.WriteLine("2*" + c.getNumeCarte());
                    
                    carteaDeJos = new Carte(pachetOriginal.getCarteDinPachet(pachetOriginal.getNrCarti() - 1));
                    carteaDeJos.getImagineCarte().Width = 180;
                    carteaDeJos.getImagineCarte().Height = 270;
                    carteaDeJos.getImagineCarte().Location = new Point(12, 300);
                    Form1.Controls.Add(carteaDeJos.getImagineCarte());

                    pachetOriginal.getDeck().Remove(carteaDeJos);
                    pachetOriginal.decrementNrCarti();
                    pachetOriginal.afisarePachetForm(this, 9);

                    scriere.WriteLine("3*" + carteaDeJos.getNumeCarte());
                }
                else
                {
                    MessageBox.Show("Specificati adresa de IP");
                }
            }
            else
            {
                ascult = false;
                t.Abort();
                StreamWriter scriere = new StreamWriter(clientStream);
                scriere.AutoFlush = true; // enable automatic flushing
                scriere.WriteLine("#Gata");
            }
        }

        /////////////// Ce se intampla cand apesi pe butonul de Ia Carte ////////////////////////

        public void Event_btnIaCarte()
        {   
           
            StreamWriter scriere = new StreamWriter(clientStream);
            if (pachetOriginal.getNrCarti() == 0)
                if (pachetJos.getNrCarti() == 0)
                {
                    intrerupeRetea();
                    MessageBox.Show("Nu mai exista carti in pachet. Remiza!");
                    Environment.Exit(0);    
                }
                else
                {
                    pachetOriginal.getDeck().Clear();
                    pachetJos.mutareCarti(pachetOriginal);
                    scriere.AutoFlush = true; // enable automatic flushing
                    scriere.WriteLine("7*");
                    eventClickPictureBoxes(pachetOriginal);

                    string mesaj2 = "";

                    foreach (Carte c in pachetOriginal.getDeck())
                    {
                        mesaj2 += c.getNumeCarte() + "%";
                    }
                    mesaj2 += "*" + pachetOriginal.getNrCarti().ToString();
                    scriere.AutoFlush = true; // enable automatic flushing
                    scriere.WriteLine("6*" + mesaj2);

                }

            if (mode == 2)
            {
                stackInfulecat -= 1;
                if (stackInfulecat > pachetOriginal.getNrCarti())
                {
                    intrerupeRetea();
                    MessageBox.Show("Nu mai exista carti in pachet. Remiza!");
                    Environment.Exit(0);
                }     
            }

            
            Player2.infuleca(stackInfulecat, pachetOriginal, this, 5);
            Form1.labelTurnPlayer.Text = "Este randul lui " + Player1.getNumePlayer();
            turnPlayer = 1;
            Form1.btnIaCarte.Enabled = false;

            pachetOriginal.afisarePachetForm(this, 9);
            mode = 1;

            scriere.AutoFlush = true; // enable automatic flushing
           
            scriere.WriteLine("5*" + mode.ToString() + "*" + stackInfulecat.ToString() + "*" + turnPlayer.ToString());
            stackInfulecat = 1;
            
        }

        /////////////// Ce se intampla cand apesi pe butonul de Pune Carte ////////////////////////

        public void Event_btnPuneCarte()
        {
            ///Se adauga cartea de jos in pachetul de jos  
            pachetJos.getDeck().Add(carteaDeJos);
            pachetJos.getDeck()[pachetJos.getNrCarti()].getImagineCarte().Width = 75;
            pachetJos.getDeck()[pachetJos.getNrCarti()].getImagineCarte().Height = 112;
            pachetJos.incrementNrCarti();
           
            ////Se pune cartea selectata peste cartea de jos 
            
            Player2.puneJos(this);
            Player2.afisarePachetForm(this, 5);

            if (Player2.getDeck().Count == 0)
            {
                intrerupeRetea();
                MessageBox.Show("Ai castigat");
                Environment.Exit(0);
            }


            ////Se schimba tura
            
            if (carteaDeJos.getValoareCarte() != VALOARE.As)
            {   Form1.btnIaCarte.Enabled = false;
                turnPlayer = 1; 
                Form1.labelTurnPlayer.Text = "Este tura lui " + Player1.getNumePlayer();
            }
            else 
            {
                turnPlayer = 2;
                Form1.labelTurnPlayer.Text = "Este tura lui " + Player2.getNumePlayer();
            }


             ////Daca cartea de jos stopeaza
            if (carteaDeJos.getValoareCarte() == VALOARE.Rege && mode == 2)
            {
                mode = 1;
                stackInfulecat = 1;
            }

            ////Daca cartea de jos umfla
            if (carteaDeJos.getValoareCarte() == VALOARE.Doi || carteaDeJos.getValoareCarte() == VALOARE.Valet || carteaDeJos.getValoareCarte() == VALOARE.Joker)
            {
                mode = 2;
                if (carteaDeJos.getValoareCarte() == VALOARE.Joker && carteaDeJos.getSimbolCarte() == SIMBOL.Rosu)
                    stackInfulecat += 10;
                else if (carteaDeJos.getValoareCarte() == VALOARE.Joker && carteaDeJos.getSimbolCarte() == SIMBOL.Negru)
                    stackInfulecat += 5;
                else
                if (carteaDeJos.getSimbolCarte() == SIMBOL.InimaRosie)
                    stackInfulecat += 3;
                else
                    stackInfulecat += 2;
            }

            pachetJos.afisarePachetForm(this, 13);
            Form1.btnPuneCarte.Enabled = false;
            
            Form1.labelCarteCurenta.Text = carteaDeJos.getNumeCarte();

            StreamWriter scriere = new StreamWriter(clientStream);
            scriere.AutoFlush = true; // enable automatic flushing
            scriere.WriteLine("4*" + carteaDeJos.getNumeCarte() + "*" + mode.ToString() + "*" + stackInfulecat.ToString() + "*" + turnPlayer.ToString());

        }

        /////////////// Event Click Orice PictureBox ////////////////////////

        public void ImagineCarte_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox p = (PictureBox)sender;

                foreach (Carte c in Player2.getDeck())
                {
                    if (c.getImagineCarte().Name == p.Name)
                    {
                        carteaSelectata = c;
                        break;
                    }
                }

            if (carteaDeJos.verifCompatibilitate(carteaSelectata, mode) == true)
            { 
                Form1.btnPuneCarte.Enabled = true;
                Form1.labelCarteSelectata.Text = "Ai selectat " + carteaSelectata.getNumeCarte();
            }
            else
            {
                Form1.btnPuneCarte.Enabled = false;
                Form1.labelCarteSelectata.Text = "Selecteaza alta carte!";
            }
        }

        /////////////// Make All PictureBoxes Clickable ////////////////////////
        public void eventClickPictureBoxes(Pachet p)
        {
            foreach (Carte c in p.getDeck())
            {
                c.getImagineCarte().MouseClick += ImagineCarte_MouseClick;
            }
        }

        ////////////////////// Getters /////////////////////////////
        public int getMode()
        {
            return this.mode;
        }

        public Pachet getPachetOriginal()
        {
            return this.pachetOriginal;
        }
        public Carte getCarteaSelectata()
        {
            return this.carteaSelectata;
        }
        public Form getForm()
        {
            return this.Form1;
        }
    }
}
