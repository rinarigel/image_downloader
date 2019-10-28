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

        private int count = 0;
        private bool d1, d2, d3;
        private int s1 = 0, s2 = 0, s3 = 0;
        private BitmapImage bi1, bi2, bi3;

        private void Progress(int si, DownloadProgressEventArgs e)
        {
                if (si == 1 && d1)
                {
                    s1 = e.Progress;
                }
                else if (si == 2 && d2)
                {
                    s2 = e.Progress;
                }
                else if (si == 3 && d3)
                {
                    s3 = e.Progress;
                }
                count = 0;
                if (s1 > 0)
                {
                    count = count + 1;
                }
                if (s2 > 0)
                {
                    count = count + 1;
                }
                if (s3 > 0)
                {
                    count = count + 1;
                }             

            if (count > 0) ImageProgressBar.Value = (s1 + s2 + s3) / count;
            else ImageProgressBar.Value = 0;
           
            if (ImageProgressBar.Value >= 100) 
            {
                ImageProgressBar.Value = 0;
                s1 = 0;
                s2 = 0;
                s3 = 0;
                count = 0;
            }
        }

        private void ButtonStart(string Text, int si)
        {
            if (Text != "" && Text != "введите URL")
            {
                try
                {
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.CacheOption = BitmapCacheOption.OnDemand;
                    bi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                    if (si == 1)
                    {
                        bi.DownloadProgress += BitImage_DownloadProgress1;
                        bi.UriSource = new Uri(TextBox1.Text);
                        bi.EndInit();
                        Image1.Source = bi;
                    }
                    else if (si == 2)
                    {
                        bi.DownloadProgress += BitImage_DownloadProgress2;
                        bi.UriSource = new Uri(TextBox2.Text);
                        bi.EndInit();
                        Image2.Source = bi;
                    }
                    else if (si == 3)
                    {
                        bi.DownloadProgress += BitImage_DownloadProgress3;
                        bi.UriSource = new Uri(TextBox3.Text);
                        bi.EndInit();
                        Image3.Source = bi;
                    }                         
                }
                catch
                {
                    if (si == 1)
                    {
                        TextBox1.Text = "нет ссылки";
                    }
                    else if (si == 2)
                    {
                        TextBox2.Text = "нет ссылки";
                    }
                    else if (si == 3)
                    {
                        TextBox3.Text = "нет ссылки";
                    }                    
                }
            }
        }

        private void ButtonStop(int si)
        {
            if (si == 1)
            {
                TextBox1.Text = String.Empty;
                Image1.Source = null;
                s1 = 0;
            }
            else if (si == 2)
            {
                TextBox2.Text = String.Empty;
                Image2.Source = null;
                s2 = 0;
            }
            else if (si == 3)
            {
                TextBox3.Text = String.Empty;
                Image3.Source = null;
                s3 = 0;
            }            
        }

        private void BitImage_DownloadProgress1(object sender, DownloadProgressEventArgs e)
        {
            Progress(1, e);
        }

        private void ButtonStart1_Click(object sender, RoutedEventArgs e)
        {
            d1 = true;
            ButtonStart(TextBox1.Text, 1);
        }      

        private void ButtonStop1_Click(object sender, RoutedEventArgs e)
        {
            d1 = false;
            ButtonStop(1);
        }

        private void BitImage_DownloadProgress2(object sender, DownloadProgressEventArgs e)
        {
            Progress(2, e);
        }

        private void ButtonStart2_Click(object sender, RoutedEventArgs e)
        {
            d2 = true;
            ButtonStart(TextBox2.Text, 2);
        }

        private void ButtonStop2_Click(object sender, RoutedEventArgs e)
        {
            d2 = false;
            ButtonStop(2);
        }

        private void BitImage_DownloadProgress3(object sender, DownloadProgressEventArgs e)
        {
            Progress(3, e);
        }

        private void ButtonStart3_Click(object sender, RoutedEventArgs e)
        {
            d3 = true;
            ButtonStart(TextBox3.Text, 3);
        }

        private void ButtonStop3_Click(object sender, RoutedEventArgs e)
        {
            d3 = false;
            ButtonStop(3);
        }

        private void ButtonEpic_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text != "" && TextBox1.Text != "введите URL")
            {
                try
                {
                    d1 = true;                  
                    bi1 = new BitmapImage();
                    bi1.BeginInit();
                    bi1.CacheOption = BitmapCacheOption.OnDemand;
                    bi1.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                    bi1.DownloadProgress += BitImage_EpicDownloadProgress1;
                    bi1.UriSource = new Uri(TextBox1.Text);
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
                    d2 = true;
                    bi2 = new BitmapImage();
                    bi2.BeginInit();
                    bi2.CacheOption = BitmapCacheOption.OnDemand;
                    bi2.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                    bi2.DownloadProgress += BitImage_EpicDownloadProgress2;
                    bi2.UriSource = new Uri(TextBox2.Text);
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
                    d3 = true;
                    bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.CacheOption = BitmapCacheOption.OnDemand;
                    bi3.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                    bi3.DownloadProgress += BitImage_EpicDownloadProgress3;
                    bi3.UriSource = new Uri(TextBox3.Text);
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
            Progress(1, e);
        }
        private void BitImage_EpicDownloadProgress2(object sender, DownloadProgressEventArgs e)
        {
            Progress(2, e);
        }
        private void BitImage_EpicDownloadProgress3(object sender, DownloadProgressEventArgs e)
        {
            Progress(3, e);
        }   
    }
}