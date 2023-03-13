using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Prototip_21_Noiembrie
{
    public class JocMacaoServer
    {
        /////////////// Variabile Form1 ////////////////////////
        

        //variabile pentru retea
        public TcpListener server;
        public string dateServer;
        Thread t;
        bool workThread;
        NetworkStream streamServer;

        //variabile pentru joc
        private Pachet pachetOriginal;
        private  Pachet pachetJos;
        public   Carte carteaDeJos;
        private  Player Player1;
        private  Player Player2;
        private  Carte carteaSelectata;
        private  int turnPlayer;
        private  int mode;
        private  int stackInfulecat;
        private string name2;
        public fJocServer Form1;
        
        
        /// Mode
        /// 1 = Normal Mode
        /// 2 = Infulecat Mode

        /////////////// Initializare JocMacao ////////////////////////

        public JocMacaoServer(fJocServer Form1, string name1)
        {
            server = new TcpListener(System.Net.IPAddress.Any, 3000);
            server.Start();
            t = new Thread(new ThreadStart(Asculta_Server));
            workThread = true;
            t.Start();

            this.Form1 = Form1;
            pachetOriginal = new Pachet();
            pachetJos = new Pachet();
            Player1 = new Player(name1);
            carteaSelectata = new Carte();

            turnPlayer = 1;
            mode = 1;
            stackInfulecat = 1;

            Form1.btnPuneCarte.Enabled = false;
        }

        //////////////// Asculta server //////////////////
        public void Asculta_Server()
        {

            while (workThread)
            {

                Socket socketServer = server.AcceptSocket();
                try
                {

                    streamServer = new NetworkStream(socketServer);
                    StreamReader citireServer = new StreamReader(streamServer);

                    while (workThread)
                    {

                        dateServer = citireServer.ReadLine();
                        if (dateServer == null) break;//primesc nimic - clientul a plecat
                        if (dateServer == "#Gata") //ca sa pot sa inchid serverul
                            workThread = false;
                        MethodInvoker m = new MethodInvoker(
                            () =>
                            { 
                                string[] mesaj = dateServer.Split('*');

                                switch(mesaj[0])
                                {
                                    case "#":
                                        {

                                            Form1.labelTurnPlayer.Visible = true;
                                            Form1.labelPachet1.Visible = true;
                                            Form1.labelPachet2.Visible = true;
                                            Form1.labelPachetOriginal.Visible = true;
                                            Form1.labelPachetDeJos.Visible = true;
                                            Form1.labelCarteSelectata.Visible = true;
                                            Form1.labelCarteCurenta.Visible = true;
                                            Form1.btnPuneCarte.Visible = true;
                                            Form1.btnIaCarte.Visible = true;
                                            Form1.labelAsteptare.Visible = false;

                                            name2 = mesaj[1];
                                            Player2 = new Player(name2);
                                            Form1.labelPachet2.Text += name2;

                                            StreamWriter scriere = new StreamWriter(streamServer);
                                            scriere.AutoFlush = true; // enable automatic flushing
                                            scriere.WriteLine("#*" + Player1.getNumePlayer()); //playerul 1 ii trimite numele sau ca sa il stie si clientul

                                        }
                                        break;

                                    case "0": //aici playerul 2 a trimis mesaj ca s-a conectat
                                        {
                                            if (pachetOriginal.getDeck().Count == 0)
                                            {
                                                pachetJos.getDeck().Clear();
                                                pachetJos.setNrCarti(0);
                                            }

                                            Carte c = new Carte(mesaj[1]);
                                            c.getImagineCarte().MouseClick += ImagineCarte_MouseClick;
                                            pachetOriginal.getDeck().Add(c);
                                            pachetOriginal.incrementNrCarti();
                                        }
                                        break;

                                    case "1": //aici se primesc cartile lui Player1 prima data
                                        {
                                            Carte c = new Carte(mesaj[1]);
                                            Player1.getDeck().Add(c);
                                            Player1.incrementNrCarti();

                                            if (Player1.getNrCarti() == 5)
                                            {
                                                Player1.afisarePachetForm(this, 1);
                                                eventClickPictureBoxes(Player1);
                                            }
                                        }
                                        break; 

                                    case "2": //aici se primesc cartile lui Player2 prima data
                                        {
                                            Carte c = new Carte(mesaj[1]);
                                            Player2.getDeck().Add(c);
                                            Player2.incrementNrCarti();

                                            if (Player2.getNrCarti() == 5)
                                            {
                                                Player2.afisarePachetForm(this, 5);
                                                eventClickPictureBoxes(Player2);
                                            }
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

                                            foreach (Carte c in Player2.getDeck())
                                            {
                                                if (c.getNumeCarte() == carteaDeJos.getNumeCarte())
                                                {

                                                    Form1.Controls.Remove(c.getImagineCarte());
                                                    Player2.getDeck().Remove(c);
                                                    Player2.decrementNrCarti();
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
                                                Player2.getDeck().Add(c);
                                                Player2.incrementNrCarti();
                                                pachetOriginal.getDeck().Remove(c);
                                                pachetOriginal.decrementNrCarti();
                                            }

                                            pachetOriginal.afisarePachetForm(this, 9);
                                            Player2.afisarePachetForm(this, 5);
                                            Player1.afisarePachetForm(this, 1);
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

                                //de fiecare data cand trimitem prin retea se si blocheaza/activeaza butonul iaCarte pentru Player1
                                if (turnPlayer == 1)
                                {
                                    Form1.btnIaCarte.Enabled = true;
                                    this.Form1.labelTurnPlayer.Text = "Este randul lui " + Player1.getNumePlayer();
                                }
                                else
                                {
                                    Form1.btnIaCarte.Enabled = false;
                                    this.Form1.labelTurnPlayer.Text = "Este randul lui " + Player2.getNumePlayer();
                                }
                                    

                            }
                        );
                        Form1.Invoke(m);
                    }
                    streamServer.Close();
                }
                catch (Exception e)
                {
#if LOG
                    Console.WriteLine(e.Message);
#endif
                }
                socketServer.Close();
            }

        }

        /////////////// Ce se intampla cand apesi pe butonul de Ia Carte ////////////////////////

        public void Event_btnIaCarte()
        {   
            StreamWriter scriere = new StreamWriter(streamServer);
            
            //verific daca mai sunt carti in cele doua pachete
            if (pachetOriginal.getNrCarti() == 0 && pachetJos.getNrCarti() == 0)//nu mai sunt carti =>oprim jocul
            {                
                MessageBox.Show("Nu mai exista carti in pachet. Remiza!");
                Environment.Exit(0);
            }
            else if (pachetOriginal.getNrCarti() == 0 && pachetJos.getNrCarti() != 0)//mai sunt in pachet de jos => mutare carti
            {
                
                pachetOriginal.getDeck().Clear();
                pachetJos.mutareCarti(pachetOriginal);
                eventClickPictureBoxes(pachetOriginal);
                scriere.WriteLine("7*"); //pregatim terenul la client si stergem tot din pachete
                string mesaj2 = "";

                foreach (Carte c in pachetOriginal.getDeck())
                    mesaj2  += c.getNumeCarte() + "%";

                mesaj2 += "*" + pachetOriginal.getNrCarti().ToString();//lista cu carti trimise sa fie mutate
                scriere.AutoFlush = true; // enable automatic flushing
                scriere.WriteLine("6*" + mesaj2);
            }

            if (mode == 2)//atunci cand vrei sa iei si mode=2 si nu mai sunt destule carti in pachet se opreste jocul
            {
                stackInfulecat -= 1;
                if (stackInfulecat > pachetOriginal.getNrCarti())
                {
                    MessageBox.Show("Nu mai exista carti in pachet. Remiza!");
                    Environment.Exit(0);
                }    
            }

            //the actual umflat of the cards
            Player1.infuleca(stackInfulecat, pachetOriginal, this, 1);
            Form1.labelTurnPlayer.Text = "Este randul lui " + Player2.getNumePlayer();
            turnPlayer = 2;
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
            
            Player1.puneJos(this);
            Player1.afisarePachetForm(this, 1);

            if (Player1.getDeck().Count == 0)
            {
                MessageBox.Show("Ai castigat");
                Environment.Exit(0);
            }

            if (carteaDeJos.getValoareCarte() != VALOARE.As)
            {
                Form1.btnIaCarte.Enabled = false;
                turnPlayer = 2;
                Form1.labelTurnPlayer.Text = "Este tura lui " + Player2.getNumePlayer();
            }
            else
            {
                turnPlayer = 1;
                Form1.labelTurnPlayer.Text = "Este tura lui " + Player1.getNumePlayer();
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

            StreamWriter scriere = new StreamWriter(streamServer);
            scriere.AutoFlush = true; // enable automatic flushing
            scriere.WriteLine("4*" + carteaDeJos.getNumeCarte() + "*" + mode.ToString() + "*" + stackInfulecat.ToString() + "*" + turnPlayer.ToString());
        }

        /////////////// Event Click Orice PictureBox ////////////////////////

        public void ImagineCarte_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox p = (PictureBox)sender;

            foreach (Carte c in Player1.getDeck())
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
