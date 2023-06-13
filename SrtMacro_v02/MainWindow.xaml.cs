using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace SrtMacro_v02
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 프레임 전환
        /// </summary>
        public static Frame frame = new Frame();

        Color SelectColor = (Color)ColorConverter.ConvertFromString("#ff0000");
        Color OriginalColor = (Color)ColorConverter.ConvertFromString("#ffffff");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            frame = frame_content;
            frame.Source = new Uri("PageSRT.xaml", UriKind.Relative);
            btnSRT.Background = new SolidColorBrush(SelectColor);
            txtSelectTitle.Content = "SRT 예약 매크로 프로그램";
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Name)
            {
                case "btnSRT":
                    frame.Source = new Uri("PageSRT.xaml", UriKind.Relative);
                    
                    btnSRT.Background = new SolidColorBrush(SelectColor);
                    btnKTX.Background = new SolidColorBrush(OriginalColor);
                    txtSelectTitle.Content = "SRT 예약 매크로 프로그램";
                    break;
                case "btnKTX":
                    frame.Source = new Uri("PageKTX.xaml", UriKind.Relative);

                    btnSRT.Background = new SolidColorBrush(OriginalColor);
                    btnKTX.Background = new SolidColorBrush(SelectColor);
                    txtSelectTitle.Content = "KTX 예약 매크로 프로그램";
                    break;
            }

        }
    }
}
