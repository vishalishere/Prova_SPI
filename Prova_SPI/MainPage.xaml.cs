using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Diagnostics;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Enumeration;
using Windows.Devices.Spi;
using Windows.Devices.Gpio;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Prova_SPI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private SpiDevice SPI;
        
        
        public MainPage()
        {
            this.InitializeComponent();
            InitAll();
        }

        private async void InitAll()
        {
            try
            {
                await InitSpi();
            }
            catch
            {
                
            }
        }

       
        private async Task InitSpi()
        {
            try
            {
                var settingsSPI = new SpiConnectionSettings(0);
                settingsSPI.ClockFrequency = 10000000;
                settingsSPI.Mode = SpiMode.Mode3;

                string SPIController = SpiDevice.GetDeviceSelector("SPI0");
                var deviceInfo = await DeviceInformation.FindAllAsync(SPIController);
                SPI = await SpiDevice.FromIdAsync(deviceInfo[0].Id, settingsSPI);
            } 
            catch (Exception ex)
            {
                throw new Exception("SPI Initialization Failed", ex);
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if ((string)SetFrequencyRange.SelectionBoxItem == "Hz")
            {
                Debug.Write("Hz\n");
            }

            if ((string)SetFrequencyRange.SelectionBoxItem == "KHz")
            {
                Debug.Write("KHz\n");
            }

            if ((string)SetFrequencyRange.SelectionBoxItem == "MHz")
            {
                Debug.Write("MHz\n");
            }
        }

        private void SetSinWave_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void SetTriWave_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void SetSqrWave_Checked(object sender, RoutedEventArgs e)
        {

        }

    }
}
