using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csgocheats
{
    public partial class main : Form
    {
        private WallVis walls;



        public main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void GhostHackButton_Click(object sender, EventArgs e)
        {
            backgroundWorker1.WorkerSupportsCancellation = true;
            if (!backgroundWorker1.IsBusy)
            {
                wallHacksDeactivate.Enabled = true;
                ghostHackButton.Enabled = false;
                cheatStatus.Text = "Status: wall hacks enabled";

                backgroundWorker1.RunWorkerAsync();


            } else
            {
                MessageBox.Show("Wall hacks already running.");
            }





        }

        private void WallHacksDeactivate_Click(object sender, EventArgs e)
        {

            //walls.disableWalling();
            if (backgroundWorker1.IsBusy)
            {
                wallHacksDeactivate.Enabled = false;
                ghostHackButton.Enabled = true;
                cheatStatus.Text = "Status: wall hacks disabled";
                walls.disableWalling();
                backgroundWorker1.CancelAsync();
            } else
            {
                MessageBox.Show("Walls are not enabled. Nothing to stop.");
            }

        }



        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                wallHacksDeactivate.Enabled = true;
                ghostHackButton.Enabled = false;
                cheatStatus.Text = "Status: wall hacks enabled";

                walls = new WallVis();
                walls.enableWalling();
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Inside exception");
                Console.WriteLine(ex.Message);
                backgroundWorker1.CancelAsync();

               // wallHacksDeactivate.Enabled = false;
                //ghostHackButton.Enabled = true;
                //cheatStatus.Text = "Status: " + ex.Message;

            }

        }
    }
}
