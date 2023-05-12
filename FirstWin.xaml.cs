using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace LocalWeb
{
    public partial class FirstWin : Window
    {
        public static List<string> users = new List<string>();
        private Socket socket;
        public FirstWin()
        {
            InitializeComponent();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(/*"26.33.75.123"*/MainWindow.Ipi, 8888);
            RecieveMessage();
        }
        private async Task RecieveMessage()
        {
            while (true)
            {
                byte[] bytes = new byte[1024];
                await socket.ReceiveAsync(bytes, SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);
                MessageListBox.Items.Add(message);
            }
        }
        private async Task sendnudes(string msg)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(msg);
            await socket.SendAsync(bytes, SocketFlags.None);

        }

        private void SendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageTextBox.Text == "/disconnect")
            {
                MainWindow qwe = new MainWindow();
                qwe.Show();
                Close();
            }
            sendnudes(MessageTextBox.Text);
            
        }

        private void MessageTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {

            MainWindow qwe = new MainWindow();
            qwe.Show();
            Close();
        }

        private void MessageListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



        private void UsersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
    

