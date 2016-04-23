using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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


namespace AudioStream
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Thread audioStream;
        WasapiLoopbackCapture capture;
        Socket outputSocket;
        IPEndPoint ep;
        byte[] buffer;
        int bytesRecorded;
        public MainWindow()
        {
            //outputSocket = new Socket(AddressFamily.InterNetwork, );
            IPAddress broadcast = IPAddress.Parse("192.168.0.101");
            ep = new IPEndPoint(broadcast, 11001);

            audioStream = new Thread(SendUdp);
            capture = new WasapiLoopbackCapture();
            capture.WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(44100, 2);
            capture.DataAvailable += InputBufferToFileCallback;
            capture.ShareMode = NAudio.CoreAudioApi.AudioClientShareMode.Shared;
            
            capture.StartRecording();
            InitializeComponent();
            GetAudio();
        }

        public async void GetAudio()
        {

            

            //WasapiOut wsout = new WasapiOut()
        }

        private void InputBufferToFileCallback(object sender, WaveInEventArgs e)
        {
            outputSocket.SendTo(e.Buffer, ep);
            
            //audioStream.Start();
        }

        public void SendUdp()
        {
            

            

            //Console.WriteLine("Message sent to the broadcast address");
            //audioStream.Suspend();
        }

        public void soc()
        {
            


        }

    }
}
