using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace NaiveMediaPlayer2
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void MyViewTry_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var i = args.SelectedItem as NavigationViewItem;
            switch (i.Tag)
            {
                /**坑：必须得先生成再引用，可能与机制有关**/
                case "Player":
                    MyViewTry.Header = "Media Player";
                    context_frame.Navigate(typeof(PlayLocal));
                    break;

                case "FileGet":
                    MyViewTry.Header = "Get the File";
                    context_frame.Navigate(typeof(PlayOnline));
                    break;

                case "AboutProuducer":
                    MyViewTry.Header = "Welcome to the NaiveMediaPlayer2.0";
                    context_frame.Navigate(typeof(AboutTheProducer));
                    break;
            }
        }

        private void MyViewTry_Loaded(object sender, RoutedEventArgs e)
        {
            context_frame.Navigate(typeof(AboutTheProducer));
        }
    }
}
