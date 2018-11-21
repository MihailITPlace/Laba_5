using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Draw();
        }

        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(bmp);
            FunctionDraftsman.Draws(gr);
            pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FunctionGenerator.Init();

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);                       

            textBox1.Text = FunctionGenerator.printFunc();

            if (radioButton1.Checked)
            {
                var lst = FunctionGenerator.getArrayOfUnits(1);
                FunctionGenerator.reduce(lst);
                textBox2.Text = FunctionGenerator.printArrayAsDNF(lst);

                FunctionDraftsman.DrawDNF(g, textBox2.Text);
            }
            else
            {
                var lst = FunctionGenerator.getArrayOfUnits(0);
                FunctionGenerator.reduce(lst);
                textBox2.Text = FunctionGenerator.printArrayAsKNF(lst);

                FunctionDraftsman.DrawKNF(g, textBox2.Text);
            }

            pictureBox1.Image = bmp;
        }

    }
}
