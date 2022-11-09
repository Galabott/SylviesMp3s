using Microsoft.Win32;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SylviesMp3s
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<String> Songs = new List<string>();
        AudioFileReader reader;
        WaveOut waveOut = new WaveOut();
        int i = 0;
        bool paused = false;
        public MainWindow()
        {
            InitializeComponent();

            Songs.Add("C:\\Users\\G_Bot\\Downloads\\Designer_Babies.mp3");
            Songs.Add("C:\\Users\\G_Bot\\Downloads\\sounds-main\\background_music\\level_3\\60sDance.wav");

        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
		{
            waveOut.Stop();
            reader = new AudioFileReader(Songs[i]);
            // or WaveOutEvent() or Mp3FileReader

            waveOut.Init(reader);
            waveOut.Play();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            waveOut.Stop();
            //i++;

            //reader = new AudioFileReader(Songs[i]);
            //// or WaveOutEvent() or Mp3FileReader

            //waveOut.Init(reader);
            //waveOut.Play();
        }
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            waveOut.Stop();
            i--;
            reader = new AudioFileReader(Songs[i]);
            // or WaveOutEvent() or Mp3FileReader

            waveOut.Init(reader);
            waveOut.Play();
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            waveOut.Stop();
            i++;
            reader = new AudioFileReader(Songs[i]);
            // or WaveOutEvent() or Mp3FileReader

            waveOut.Init(reader);
            waveOut.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            //i++;

            //reader = new AudioFileReader(Songs[i]);
            //// or WaveOutEvent() or Mp3FileReader
            if (!paused)
            {
                waveOut.Pause();
                paused = true;
            }
            else
            {
                paused = false;
                waveOut.Resume();
            }
        }

        private void btnAddSong_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            //example of filter for explorer
            if (openFileDialog.ShowDialog() == true)
            {
                //mediaPlayer.Open(new Uri(openFileDialog.FileName));
                //mediaPlayer.Play();
                //Uri for link with directory
            }
        }
        
    }
}
