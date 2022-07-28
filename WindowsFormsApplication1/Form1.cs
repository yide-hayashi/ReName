using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace ReName
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            BigInteger xBig =0,yBig=0,ikoru=0;
            xBig = BigInteger.Parse(textBox1.Text);
            yBig = BigInteger.Parse(textBox2.Text);
            if(radioButton1.Checked)
            ikoru = BigInteger.Add(xBig, yBig);
            if (radioButton2.Checked)
            ikoru = BigInteger.Subtract(xBig, yBig);

            label1.Text = ikoru.ToString();
        }
    }
}
