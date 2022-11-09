using System.Text;
using NAudio.Wave;

namespace Mp3Archive;

public class Mp3Archive
{
    
    public byte[] TAGID = new byte[3];      //  3
    public byte[] Title = new byte[30];     //  30
    public byte[] Artist = new byte[30];    //  30 
    public byte[] Album = new byte[30];     //  30 
    public byte[] Year = new byte[4];       //  4 
    public byte[] Comment = new byte[30];   //  30 
    public byte[] Genre = new byte[1];      //  1
    public void ReadMp3(string fileName)
    {
        string path = Path.Combine(Environment.CurrentDirectory, @"Archive\", fileName);
        Console.WriteLine("current path"+path);
        using(var audioFile = new AudioFileReader(path))
        using(var outputDevice = new WaveOutEvent())
        {
            outputDevice.Init(audioFile);
            outputDevice.Play();
            while (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(1000);
            }
        }
    }

    public void addNewMp3(string sourceFile)
    {
        string fileName = Path.GetFileName(sourceFile);
        string targetPath =  System.IO.Path.Combine(Environment.CurrentDirectory, @"Archive\");
        
        string destFile = System.IO.Path.Combine(targetPath, fileName);
        
        System.IO.Directory.CreateDirectory(targetPath);
        System.IO.File.Copy(sourceFile, destFile, true);
        
        
        AnalyseMp3(destFile);
    }

    public void AnalyseMp3(string filePath)
    {
        
        
        
    }
}