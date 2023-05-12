using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Interop;

namespace LocalWeb
{
    /// <summary>
    /// Логика взаимодействия для theserver.xaml
    /// </summary>
    public partial class theserver : Window
    {
        private List<Socket> arbusers = new List<Socket>();
        private Socket socket;

        public theserver()
        {
            InitializeComponent();

            UserssListBox.ItemsSource = FirstWin.users;
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, 8888);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipPoint);
            socket.Listen(1000);

            ListenToClients();
        }

        private async Task ListenToClients()
        {
            while (true)
            {
                var client = await socket.AcceptAsync();
                arbusers.Add(client);
                RecieveMessage(client);
            }
        }

        private async Task RecieveMessage(Socket client)
        {
           
            while (true)
            {

                byte[] bytes = new byte[1024];
                await client.ReceiveAsync(bytes, SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);
                if (message != null)
                {


                    if (message != "/disconnect")
                    {
                        MessageeListBox.Items.Add($"[Сообщение от {MainWindow.vimya}]: {message}");

                    }
                    else
                    {

                        Logs.Items.Add($"[Сообщение от {client.RemoteEndPoint}]: {message}");
                        Logs.Items.Add($"[{client.RemoteEndPoint}] вышел");
                    }
                }
                else
                {
                    MessageBox.Show("Введите какое то сообщение!");
                }

                foreach (var item in arbusers)
                {
                    SendMessage(item, message);
                }
            }

        }

        private async Task SendMessage(Socket client, string message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            await client.SendAsync(bytes, SocketFlags.None);
        }
        private void sendBtn_Click_1(object sender, RoutedEventArgs e)
        {
          
            string msg = $"[{DateTime.Now}]: {MessageeTextBox.Text}";
            foreach (var item in arbusers)
            {
                SendMessage(item, msg);
            }
            if (msg != "/disconnect")
            {
                MessageeListBox.Items.Add(msg);
            }
            else
            {
                Logs.Items.Add(msg); 
            }
        }
        private void UserssListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private async Task sendnudes(string msg)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(msg);
            await socket.SendAsync(bytes, SocketFlags.None);

        }
        private void MessageeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MessageeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ExittButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow qwerth = new MainWindow();
            qwerth.Show();
            Close();
        }

        private void Logs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            
        }

        private void SenddMessageButton_Click_1(object sender, RoutedEventArgs e)
        {
            sendnudes(MessageeTextBox.Text);
        }
    }
}
