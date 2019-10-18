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

namespace wpf_4._0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private int count;
        private int s1, s2, s3;

        private BitmapImage bi1, bi2, bi3;

        private bool download = true;

        private void BitImage_DownloadProgress(object sender, DownloadProgressEventArgs e)
        {
            if (download)
            {
                ImageProgressBar.Value = e.Progress;
            }
            else
            {
                ImageProgressBar.Value = 0;
            }
           
        }
              

        private void ButtonStart1_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text != "" && TextBox1.Text != "введите URL")
            {
                try
                {
                    download = true;
                    bi1 = new BitmapImage();
                    bi1.CacheOption = BitmapCacheOption.OnDemand;
                    bi1.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                    bi1.DownloadProgress += BitImage_DownloadProgress;
                    bi1.BeginInit();
                    bi1.UriSource = new Uri(TextBox1.Text);
                    bi1.EndInit();
                    Image1.Source = bi1;
                }
                catch
                {
                    TextBox1.Text = ":(";
                }
            }
        }

        private void ButtonStop1_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = String.Empty;
            Image1.Source = null;
            download = false;
            ImageProgressBar.Value = 0;
        }
         
        private void ButtonStart2_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox2.Text != "" && TextBox2.Text != "введите URL")
            {
                try
                {
                    download = true;
                    bi2 = new BitmapImage();
                    bi2.CacheOption = BitmapCacheOption.OnDemand;
                    bi2.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                    bi2.DownloadProgress += BitImage_DownloadProgress;
                    bi2.BeginInit();
                    bi2.UriSource = new Uri(TextBox2.Text);
                    bi2.EndInit();
                    Image2.Source = bi2;
                }
                catch
                {
                    TextBox2.Text = ":(";
                }
            }

        }
        
        private void ButtonStop2_Click(object sender, RoutedEventArgs e)
        {
            TextBox2.Text = String.Empty;
            Image2.Source = null;
            download = false;
            ImageProgressBar.Value = 0;
        }

        private void ButtonStart3_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox3.Text != "" && TextBox3.Text != "введите URL")
            {
                try
                {
                    download = true;
                    bi3 = new BitmapImage();
                    bi3.CacheOption = BitmapCacheOption.OnDemand;
                    bi3.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                    bi3.DownloadProgress += BitImage_DownloadProgress;
                    bi3.BeginInit();
                    bi3.UriSource = new Uri(TextBox3.Text);
                    bi3.EndInit();
                    Image3.Source = bi3;
                }
                catch
                {
                    TextBox3.Text = ":(";
                }
            }

        }

        private void ButtonStop3_Click(object sender, RoutedEventArgs e)
        {
            TextBox3.Text = String.Empty;
            Image3.Source = null;
            download = false;
            ImageProgressBar.Value = 0;
        }
                

        private void ButtonEpic_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text != "" && TextBox1.Text != "введите URL")
            {
                try
                {
                    count = count + 1;
                    bi1 = new BitmapImage();

                    bi1.BeginInit();
                    bi1.UriSource = new Uri(TextBox1.Text);
                    bi1.DownloadProgress += BitImage_EpicDownloadProgress1;
                    bi1.EndInit();
                    Image1.Source = bi1;
                }
                catch
                {
                    TextBox1.Text = "нужно ввести ссылку!";
                }
            }

            if (TextBox2.Text != "" && TextBox2.Text != "введите URL")
            {
                try
                {
                    count = count + 1;
                    bi2 = new BitmapImage();

                    bi2.BeginInit();
                    bi2.UriSource = new Uri(TextBox2.Text);
                    bi2.DownloadProgress += BitImage_EpicDownloadProgress2;
                    bi2.EndInit();
                    Image2.Source = bi2;
                }
                catch
                {
                    TextBox2.Text = "нужно ввести ссылку!";
                }
            }

            if (TextBox3.Text != "" && TextBox3.Text != "введите URL")
                try
                {
                    count = count + 1;
                    bi3 = new BitmapImage();

                    bi3.BeginInit();
                    bi3.UriSource = new Uri(TextBox3.Text);
                    bi3.DownloadProgress += BitImage_EpicDownloadProgress3;
                    bi3.EndInit();
                    Image3.Source = bi3;
                }
                catch
                {
                    TextBox3.Text = "нужно ввести ссылку!";
                }
        }


        private void BitImage_EpicDownloadProgress1(object sender, DownloadProgressEventArgs e)
        {
            s1 = e.Progress;
            if (count > 0)
            {
                ImageProgressBar.Value = (s1 + s2 + s3) / count;
            }
            if (ImageProgressBar.Value >= 100)
            {
                count = 0;
            }
        }
        private void BitImage_EpicDownloadProgress2(object sender, DownloadProgressEventArgs e)
        {
            s2 = e.Progress;
            if (count > 0)
            {
                ImageProgressBar.Value = (s1 + s2 + s3) / count;
            }
            if (ImageProgressBar.Value >= 100)
            {
                count = 0;
            }
        }
        private void BitImage_EpicDownloadProgress3(object sender, DownloadProgressEventArgs e)
        {
            s3 = e.Progress;
            if (count > 0)
            {
                ImageProgressBar.Value = (s1 + s2 + s3) / count;
            }
            if (ImageProgressBar.Value >= 100)
            {
                count = 0;
            }
        }   
    }
}