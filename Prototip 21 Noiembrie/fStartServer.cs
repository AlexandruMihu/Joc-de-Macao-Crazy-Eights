using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Prototip_21_Noiembrie
{
    public partial class fStartServer : Form
    {
        fNumeServer fereastraNume;
        fInstructiuniServer fereastraInstructiuni;

        public fStartServer()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            fereastraNume = new fNumeServer(this);
            fereastraNume.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnInstructiuni_Click(object sender, EventArgs e)
        {
            fereastraInstructiuni = new fInstructiuniServer(this);
            this.Hide();
            fereastraInstructiuni.Show();

        }
    }
}
