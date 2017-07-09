using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//TK
//All threading is hidden and internal. Facade: Hides complexity
//Conseals the thread for the user of the component. Instead Event based interface.
//Limited threading functionality

namespace DesignLibrary
{
    public partial class FacadeBwPanel : Form
    {
        private BackgroundWorker backgroundWorker;

        public FacadeBwPanel()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
        }

        private void InitializeBackgroundWorker()
        {
            backgroundWorker = new BackgroundWorker();

            // Background Process
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;

            // Progress Reporting
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;

            // Cancellation
            backgroundWorker.WorkerSupportsCancellation = true;

        }
        // Runs on Background Thread
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //throw new Exception("Something Bad Happened");

            BackgroundWorker worker = (BackgroundWorker)sender;

            int result = 0;
            int iterations = (int)e.Argument;

            SlowProcessor processor = new SlowProcessor(iterations);
            foreach (var current in processor)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                if (worker.WorkerReportsProgress)
                {
                    int percentageComplete =
                        (int)((float)current / (float)iterations * 100);
                    string progressMessage =
                        string.Format("Iteration {0} of {1}", current, iterations);
                    worker.ReportProgress(percentageComplete, progressMessage);
                }
                result = current;
            }

            e.Result = result;
        }



        // Runs on UI Thread
        private void btnStart_Click(object sender, EventArgs e)
        {
            int iterations = 0;

            if (int.TryParse(txtIterations.Text, out iterations))
            {
                if (!backgroundWorker.IsBusy)
                    backgroundWorker.RunWorkerAsync(iterations);

                btnStart.Enabled = !backgroundWorker.IsBusy;
                btnCancel.Enabled = backgroundWorker.IsBusy;
                txtOutput.Text = string.Empty;
            }
        }

        // Runs on UI Thread
        private void btnCancel_Click(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
        }

        // Runs on UI Thread
        private void backgroundWorker_RunWorkerCompleted(object sender,
            RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                txtOutput.Text = e.Error.Message;
                MessageBox.Show(e.Error.StackTrace);
            }
            else if (e.Cancelled)
            {
                txtOutput.Text = "Cancelled";
            }
            else
            {
                txtOutput.Text = e.Result.ToString();
                progressBar.Value = 0;
            }
            btnStart.Enabled = !backgroundWorker.IsBusy;
            btnCancel.Enabled = backgroundWorker.IsBusy;
        }

        // Runs on UI Thread
        void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            txtOutput.Text = e.UserState.ToString();
        }
    }
}
