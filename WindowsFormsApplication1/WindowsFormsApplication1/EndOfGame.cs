using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class EndOfGame : Form
    {
        List<string> scores;
        public EndOfGame()
        {
            InitializeComponent();
        }

        public void UpdateCurrentScore(string score)
        {
            scores = new List<string>();
            scores = File.ReadAllLines("Scores.txt").ToList();
            label3.Text = scores.Last();
            label4.Text = score;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void EndOfGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
