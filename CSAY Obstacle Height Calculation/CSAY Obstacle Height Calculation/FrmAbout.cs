using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSAY_Obstacle_Height_Calculation
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            TxtInstructionToUse.BackColor = Color.White;
            TxtInstructionToUse.ReadOnly = true;


            TxtAbout.BackColor = Color.Thistle;
            TxtAbout.ForeColor = Color.Black;
            TxtAbout.ReadOnly = true;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnDocumentation_Click(object sender, EventArgs e)
        {
            Process.Start("CSAY OCH DOCUMENTATION.pdf");
        }
    }
}
