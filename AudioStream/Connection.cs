using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AudioStream
{
    class Connection
    {
        WaveInEvent waveIn;

        public TcpClient cl;

        public void Work()
        {           
            waveIn = new WaveInEvent();
            
            waveIn.WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(44100, 2);
            waveIn.DataAvailable += InputBufferToFileCallback;
            waveIn.StartRecording();
        }

        private void InputBufferToFileCallback(object sender, WaveInEventArgs e)
        {
            cl.Client.SendTo(e.Buffer, cl.Client.RemoteEndPoint);
        }
    }
}
