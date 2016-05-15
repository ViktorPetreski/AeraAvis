using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AeraAvis
{
    public partial class StartupForm : Form
    {
    
        public StartupForm()
        {
            InitializeComponent();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] scores = File.ReadAllLines("Scores.txt");
            StringBuilder sb = new StringBuilder();
            sb.Append("Top three scores:\n");
            foreach(string s in scores)
            {
                sb.Append(s + "\n");
            }
            MessageBox.Show(sb.ToString());
        }


        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
