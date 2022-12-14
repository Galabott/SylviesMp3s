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
        public PlayerView view { get; private set; }
        private string[] songs;
        private int index = 1;
        private MainContentViewModel mainContentViewModel;
        private BackgroundWorker worker;
        private bool stopThread = false;

        public PlayerViewModel(PlayerView view)
        {
            NextTuneCommand = new RelayCommand(NextTune);
            PreviousTuneCommand = new RelayCommand(PreviousTune);
            this.view = view;
            songs = new string[] { "The Previous Axolotl Song", "The Current Axolotl Song", "The Next Axolotl Song"};
            ProgressBarInit();
        }

        public PlayerViewModel(MainContentViewModel mainContentViewModel)
        {
            this.mainContentViewModel = mainContentViewModel;
        }

        private void NextTune(object obj)
        {
            worker.CancelAsync();
            stopThread = true;

            index++;

            if(index == songs.Length) { index = 0;}

            view.songNameLabel.Content = songs[index];

            ProgressBarInit();

        }
        private void PreviousTune(object obj)
        {
            worker.CancelAsync();

            index--;

            if (index == -1) { index = songs.Length-1; }

            view.songNameLabel.Content = songs[index];

            ProgressBarInit();

        }
        private void ProgressBarInit()
        {
            view.songProgessBar.Maximum = 10; // song length

            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;

            worker.RunWorkerAsync();

        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 10 + 1; i++) // song length
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
            view.songProgessBar.Value = e.ProgressPercentage;
        }
    }


}