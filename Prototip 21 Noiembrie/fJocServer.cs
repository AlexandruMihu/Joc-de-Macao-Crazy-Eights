using Prototip_21_Noiembrie.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototip_21_Noiembrie
{
    public partial class fJocServer : Form
    {
        /////////////// Variabile Form1 ////////////////////////

        JocMacaoServer joc;

        /////////////// Initializare Form 1 ////////////////////////
        public fJocServer(string name1)
        {
            InitializeComponent();
            labelTurnPlayer.Text = "Este randul lui " + name1;
            labelPachet1.Text = "Pachetul lui " + name1;
            labelPachet2.Text = "Pachetul lui ";
            joc = new JocMacaoServer(this,name1);
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
            Environment.Exit(0);
        }

    }
}
