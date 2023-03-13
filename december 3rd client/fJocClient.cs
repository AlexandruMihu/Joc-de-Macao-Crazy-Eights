using december_3rd_client.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace december_3rd_client
{
    public partial class fJocClient : Form
    {
        /////////////// Variabile Form1 ////////////////////////

        JocMacaoClient joc;

        /////////////// Initializare Form 1 ////////////////////////
        public fJocClient(string name2)
        {
            InitializeComponent();
            labelTurnPlayer.Text = "Este randul lui ";
            labelPachet1.Text = "Pachetul lui ";
            labelPachet2.Text = "Pachetul lui " + name2;
            joc = new JocMacaoClient(this,name2);
        }

        /////////////// Event Click Buton Ia Carte ////////////////////////

       private void btnIaCarte_Click(object sender, EventArgs e)
        {
            joc.Event_btnIaCarte();
        }
           
        /////////////// Event Click Buton Pune Carte ////////////////////////
        private void btnPuneCarte_Click(object sender, EventArgs e)
        {
            joc.Event_btnPuneCarte(); 
        }

        private void fJoc_FormClosed(object sender, FormClosedEventArgs e)
        {
            joc.intrerupeRetea();
            Environment.Exit(0);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            joc.Event_btnConnect();

        }
    }
}
