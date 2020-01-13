﻿using GigeVision.Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

namespace GigeVisionLibrary.Test.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PixelFormat pixelFormat = PixelFormats.Gray8;
        private Camera camera;
        private Gvcp gvcp;

        private BitmapSource image;
        private int fpsCount;

        private int width = 1024;

        private int height = 728;

        private int bytesPerPixel;

        public MainWindow()
        {
            InitializeComponent();
            Setup();
        }

        public BitmapSource Image
        {
            get => image;
            set => image = value;
        }

        private void Setup()
        {
            camera = new Camera
            {
                IP = "192.168.10.197"
            };
            camera.FrameReady += FrameReady;
            camera.Gvcp.ElapsedOneSecond += UpdateFps;
        }

        private void UpdateFps(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
           Fps.Text = fpsCount.ToString(), System.Windows.Threading.DispatcherPriority.ApplicationIdle);
            fpsCount = 0;
        }

        private void FrameReady(object sender, byte[] e)
        {
            Dispatcher.Invoke(() =>
            {
                lightControl.ImagePtr = (IntPtr)sender;
            }, System.Windows.Threading.DispatcherPriority.Render
            );
            fpsCount++;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (camera.IsStreaming)
            {
                await camera.StopStream().ConfigureAwait(false);
            }
            else
            {
                width = (int)camera.Width;
                height = (int)camera.Height;
                lightControl.WidthImage = width;
                lightControl.HeightImage = height;
                lightControl.IsColored = camera.PixelFormat.ToString().Contains("Bayer");
                await camera.StartStreamAsync().ConfigureAwait(false);
            }
        }
    }
}