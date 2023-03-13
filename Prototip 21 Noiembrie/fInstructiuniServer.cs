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
    public partial class fInstructiuniServer : Form
    {
        fStartServer fereastraStart;
        public fInstructiuniServer(fStartServer fereastraStart)
        {
            InitializeComponent();
            this.fereastraStart = fereastraStart;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            fereastraStart.Show();
        }
    }
}
