using SylviesMp3s.Commands;
using SylviesMp3s.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SylviesMp3s.ViewModels
{


    class PlayerViewModel : BaseViewModel
    {
        public RelayCommand NextTuneCommand { get; private set; }
        public RelayCommand PreviousTuneCommand { get; private set; }
        public MainContentViewModel mcvm { get; private set; }
        private MainContentViewModel mainContentViewModel;
        private BackgroundWorker worker;
        private bool stopThread = false;

        public PlayerViewModel(MainContentViewModel mainContentViewModel)
        {
            NextTuneCommand = new RelayCommand(NextTune);
            PreviousTuneCommand = new RelayCommand(PreviousTune);
            this.mainContentViewModel = mainContentViewModel;
            ProgressBarInit();
        }

        private void NextTune(object obj)
        {
            worker.CancelAsync();
            stopThread = true;

            ProgressBarInit();

        }
        private void PreviousTune(object obj)
        {
            worker.CancelAsync();

            ProgressBarInit();

        }
        private void ProgressBarInit()
        {

            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;

            worker.RunWorkerAsync();

        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 20 + 1; i++) // song length
            {
                if (stopThread)
                {
                    e.Cancel = true;
                    i = 10;
                }

                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(1000);
            }

        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }
    }


}