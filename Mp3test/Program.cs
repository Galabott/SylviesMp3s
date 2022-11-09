using Mp3Archive;

namespace Mp3Test;

public class Program
{
    
    static void Main(string[] args)
    {
        Mp3Archive.Mp3Archive mp3Archive = new Mp3Archive.Mp3Archive();
        
        
       /*Console.WriteLine("enter the new mp3 path:");

       string result = Console.ReadLine();
       
       mp3Archive.addNewMp3(result);
       mp3Archive.ReadMp3(Path.GetFileName(result));*/


       mp3Archive.ReadMp3("Thomas_the_dank_engine.mp3");
    }




}