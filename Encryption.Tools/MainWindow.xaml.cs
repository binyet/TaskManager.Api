using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using TaskManager.Utility;

namespace Encryption.Tools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string key = "binyet1234567890binyet1234567890";
        private readonly string IV = "binyet";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Encryp_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tb_decryp.Text.Trim()))
            {
                return;
            }
            tb_encryp.Text = AESEncrypHelper.AesEncrypt(tb_decryp.Text, key);
        }

        private void Decryp_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tb_encryp.Text.Trim()))
            {
                return;
            }
            tb_decryp.Text = AESEncrypHelper.AesDecrypt(tb_encryp.Text, key);
        }

    }
}
