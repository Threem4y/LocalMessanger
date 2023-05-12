using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LocalWeb
{
    public partial class MainWindow : Window
    {
        public static string Ipi;
        public static string vimya;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            if (Ipi != null)
            {
                Ipi = IpAdress.Text;
                FirstWin server = new FirstWin();
                server.Show();
                Close();
            }


            else
            {
                MessageBox.Show("Введите айпишник");
            }
            
          
        }

        private void HostButton_Click(object sender, RoutedEventArgs e)
        {

                vimya = NameUser.Text;
                theserver tyuio = new theserver();
                tyuio.Show();
                Close();
            

        }

        private void NameUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void IpAdress_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }
    }
}



