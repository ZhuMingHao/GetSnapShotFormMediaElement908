using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Editing;
using Windows.Media.Effects;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ExampleVideoEffect;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Graphics.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GetSnapShotFormMediaElement908
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        

        private async void VideoPlayer_Loaded(object sender, RoutedEventArgs e)
        {
            var videoFile = await Package.Current.InstalledLocation.GetFileAsync("big_buck_bunny.mp4");  
            MediaClip clip = await MediaClip.CreateFromFileAsync(videoFile);

            var videoEffectDefinition = new VideoEffectDefinition(typeof(RExampleVidoEffect).FullName);
            clip.VideoEffectDefinitions.Add(videoEffectDefinition);

            MediaComposition compositor = new MediaComposition();
            compositor.Clips.Add(clip);

            this.VideoPlayer.SetMediaStreamSource(compositor.GenerateMediaStreamSource());

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var btimap = RExampleVidoEffect.GetSnapShot();

            if (btimap.BitmapPixelFormat != BitmapPixelFormat.Bgra8 ||
                 btimap.BitmapAlphaMode == BitmapAlphaMode.Straight)
            {
                btimap = SoftwareBitmap.Convert(btimap, BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied);
            }
            var source = new SoftwareBitmapSource();
            await source.SetBitmapAsync(btimap);
            img.Source = source;
        }
    }
}
