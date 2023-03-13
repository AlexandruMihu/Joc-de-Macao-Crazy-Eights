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
    public partial class fNumeServer : Form
    {
        fJocServer fereastraJoc;
        fStartServer fereastraStart;
        public fNumeServer(fStartServer fereastraStart)
        {
            InitializeComponent();
            this.fereastraStart = fereastraStart;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            fereastraJoc = new fJocServer(textBoxNume1.Text);
            fereastraJoc.Show();
            this.Hide();
        }

        private void textBoxNume1_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNume1.Text.Trim().Length > 0)
            {
                btnOk.Enabled = true;
            }
        }

        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            fereastraStart.Show();
        }
    }
}
