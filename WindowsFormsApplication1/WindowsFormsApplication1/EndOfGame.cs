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

namespace WindowsFormsApplication1
{
    public partial class EndOfGame : Form
    {
        List<string> scores;
        //Form1 f;
        public EndOfGame()
        {
            InitializeComponent();
            scores = new List<string>();
            scores = File.ReadAllLines("Scores.txt").ToList();
            label3.Text = scores.First();
            //f = new Form1();
        }

        public void UpdateCurrentScore(string score)
        {
            label4.Text = score;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Close();
        }

        private void EndOfGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
