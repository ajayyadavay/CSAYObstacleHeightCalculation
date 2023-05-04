using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSAY_Obstacle_Height_Calculation
{
    public partial class FrmDMS : Form
    {
        public FrmDMS()
        {
            InitializeComponent();
        }

        private void FrmDMS_Load(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            for(int i = 0; i <=1; i++)
            {
                dataGridView1.Rows.Add();
            }

            dataGridView1.Rows[0].Cells[0].Value = "Latitude";
            dataGridView1.Rows[1].Cells[0].Value = "Longitude";
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void BtnCalculate_Click(object sender, EventArgs e)
        {
            double[] Lat = new double[3];
            double[] Long = new double[3];

            //taking input from datagrid
            for(int i = 0; i <= 2; i++)
            {
                Lat[i] = Convert.ToDouble(dataGridView1.Rows[0].Cells[i+1].Value);
                Long[i] = Convert.ToDouble(dataGridView1.Rows[1].Cells[i+1].Value);
            }

            //calculate
            double lat_dd = Lat[0] + Lat[1] / 60.0 + Lat[2] / 3600.0;
            double long_dd = Long[0] + Long[1] / 60.0 + Long[2] / 3600.0;

            TxtLatitude.Text = lat_dd.ToString();
            TxtLongitude.Text = long_dd.ToString();

            //send DMS to main form
            if(ChkSendDMS.Checked == true)
            {
                //this code sends data to opened form
                FrmObstacleHeightCalculation fols = (FrmObstacleHeightCalculation)Application.OpenForms["FrmObstacleHeightCalculation"];

                //this code sends data to a form which has to be newly opened usgin code fols.show();
                //FrmObstacleHeightCalculation fols = new FrmObstacleHeightCalculation();
                fols.TxtLat2.Text = lat_dd.ToString();
                fols.TxtLong2.Text = long_dd.ToString();
                //fols.Show();
                
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i <= 1; i++)
            {
                dataGridView1.Rows.Add();
            }

            dataGridView1.Rows[0].Cells[0].Value = "Latitude";
            dataGridView1.Rows[1].Cells[0].Value = "Longitude";

            TxtLatitude.Text = "";
            TxtLongitude.Text = "";
        }
    }
}
