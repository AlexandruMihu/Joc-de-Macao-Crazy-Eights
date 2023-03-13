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

namespace december_3rd_client
{
    public partial class fStartClient : Form
    {
        
        fNumeClient fereastraNume;
        fInstructiuniClient fereastraInstructiuni;

        public fStartClient()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            fereastraNume = new fNumeClient(this);
            fereastraNume.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnInstructiuni_Click(object sender, EventArgs e)
        {
            fereastraInstructiuni = new fInstructiuniClient(this);
            this.Hide();
            fereastraInstructiuni.Show();

        }
    }
}
