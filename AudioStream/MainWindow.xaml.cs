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
        public MainWindow()
        {
            
        }

        public void StartServer()
        {
            int port = 11001;
            TcpListener l = new TcpListener(port); //и на нем у нас висит сервер
            l.Start();

            Console.WriteLine("The server is started..."); //уведомили об этом

            while (true)
            {
                TcpClient cl = l.AcceptTcpClient();
                Connection c = new Connection();
                c.cl = cl;
                Thread t = new Thread(new ThreadStart(c.Work));
                t.IsBackground = false;
                t.Start();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Thread(StartServer).Start();
            BtnStart.IsEnabled = false;
        }
    }
}
