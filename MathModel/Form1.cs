using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathModel
{
    public partial class Form1 : Form
    {
        MathModel mathModel = new MathModel();
        
        public Form1()
        {
            InitializeComponent();
            trackBar1.Value = (int)mathModel.U;
            mathModel.Calculated();
            Forming_Text();
        }

        private void Forming_Text() 
        {
            label12.Text = mathModel.C[0].ToString();
            label13.Text = mathModel.C[1].ToString();
            label14.Text = mathModel.C[2].ToString();
            label15.Text = mathModel.C[3].ToString();
            label16.Text = mathModel.C[4].ToString();
            label17.Text = mathModel.R.ToString();
            label18.Text = mathModel.E[0].ToString();
            label19.Text = mathModel.E[1].ToString();
            label20.Text = mathModel.E[2].ToString();
            label21.Text = mathModel.E[3].ToString();
            label22.Text = mathModel.E[4].ToString();
                        
            label32.Text = mathModel.U.ToString();

            label39.Text = mathModel.K[0].ToString();
            label40.Text = mathModel.K[1].ToString();
            label41.Text = mathModel.K[2].ToString();
            label42.Text = mathModel.K[3].ToString();
            label43.Text = mathModel.K[4].ToString();
            label44.Text = mathModel.K[5].ToString();
            label51.Text = mathModel.K[6].ToString();
            label52.Text = mathModel.K[7].ToString();
            label49.Text = mathModel.K[8].ToString();
            label50.Text = mathModel.K[9].ToString();

            label27.Text = mathModel.x1[0].ToString();
            label28.Text = mathModel.x2[0].ToString();
            label29.Text = mathModel.x3[0].ToString();

            label30.Text = mathModel.x1[1].ToString();
            label53.Text = mathModel.x2[1].ToString();
            label54.Text = mathModel.x3[1].ToString();

            label59.Text = mathModel.x1[2].ToString();
            label60.Text = mathModel.x2[2].ToString();
            label61.Text = mathModel.x3[2].ToString();

            label66.Text = mathModel.x1[3].ToString();
            label67.Text = mathModel.x2[3].ToString();
            label68.Text = mathModel.x3[3].ToString();

            label73.Text = mathModel.x1[4].ToString();
            label74.Text = mathModel.x2[4].ToString();
            label75.Text = mathModel.x3[4].ToString();

            label80.Text = mathModel.x1[5].ToString();
            label81.Text = mathModel.x2[5].ToString();
            label82.Text = mathModel.x3[5].ToString();

            label87.Text = mathModel.x1[6].ToString();
            label88.Text = mathModel.x2[6].ToString();
            label89.Text = mathModel.x3[6].ToString();

            label94.Text = mathModel.x1[7].ToString();
            label95.Text = mathModel.x2[7].ToString();
            label96.Text = mathModel.x3[7].ToString();

            label101.Text = mathModel.x1[8].ToString();
            label102.Text = mathModel.x2[8].ToString();
            label103.Text = mathModel.x3[8].ToString();

            label108.Text = mathModel.x1[9].ToString();
            label109.Text = mathModel.x2[9].ToString();
            label110.Text = mathModel.x3[9].ToString();

            label115.Text = mathModel.x1[10].ToString();
            label116.Text = mathModel.x2[10].ToString();
            label117.Text = mathModel.x3[10].ToString();

            label125.Text = mathModel.A_coefficient.ToString();
            label127.Text = mathModel.B_coefficient.ToString();
            label129.Text = mathModel.C_coefficient.ToString();

            mathModel.U = trackBar1.Value;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value != mathModel.U) 
            {
                mathModel.U = trackBar1.Value;
                mathModel.Calculated();

                Forming_Text();
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            this.chart1.Series[0].Points.Clear();
            this.chart1.Series[1].Points.Clear();
            this.chart1.Series[2].Points.Clear();
            for (int i = 0; i < mathModel.x1.Length; i++)
            {
                this.chart1.Series[0].Points.AddXY(mathModel.T[i], mathModel.x1[i]);
                this.chart1.Series[1].Points.AddXY(mathModel.T[i], mathModel.x2[i]);
                this.chart1.Series[2].Points.AddXY(mathModel.T[i], mathModel.x3[i]);
            }            
        }
    }
}
