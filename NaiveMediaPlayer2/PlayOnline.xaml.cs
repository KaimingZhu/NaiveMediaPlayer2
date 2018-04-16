using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace NaiveMediaPlayer2
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class PlayOnline : Page
    {
        public PlayOnline()
        {
            this.InitializeComponent();
        }

        private void play_online_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri(URI.Text);
            if(URI.Text != null)
            {
                player.Source = uri;
                player.Play();
            }
        }

        private async void download_online_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var httpClient = new HttpClient();
                if (URI.Text != null)
                {
                    var buffer = await httpClient.GetBufferAsync(new Uri(URI.Text));
                    StorageFile file = await KnownFolders.MusicLibrary.CreateFileAsync(URI.Text + ".mp3", CreationCollisionOption.ReplaceExisting);
                    using (var stream = await file.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        await stream.WriteAsync(buffer);
                        await stream.FlushAsync();
                    }
                    player.Source = new Uri(URI.Text);
                    player.Play();
                }
            }
            catch
            {
                ;
            }
        }
    }
}
