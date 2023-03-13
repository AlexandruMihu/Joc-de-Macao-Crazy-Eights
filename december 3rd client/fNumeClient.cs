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
    public partial class fNumeClient : Form
    {
        fJocClient fereastraJoc;
        fStartClient fereastraStart;
        public fNumeClient(fStartClient fereastraStart)
        {
            InitializeComponent();
            this.fereastraStart = fereastraStart;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            fereastraJoc = new fJocClient( textBoxNume2.Text);
            fereastraJoc.Show();
            this.Hide();
        }

        

        private void textBoxNume2_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNume2.Text.Trim().Length > 0)
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
