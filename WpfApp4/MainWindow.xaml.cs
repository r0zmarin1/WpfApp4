using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private Rezume selectedRezumes;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Rezume SelectedRezumes
        {
            get => SelectedRezumes;
            set
            {
                SelectedRezumes = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(SelectedRezumes)));
            }
        }
        public class Rezume
        {
            public string FIO { get; set; } = "";
            public string Info { get; set; } = "";
            public int Age { get; set; } = 0;
            public byte[] Img { get; set; }
        }
        private void Save_Button(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("спасибо что оформили подписку на онлифанс");
            PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(SelectedRezumes)));
        }

        //private void Button_Image(object sender, RoutedEventArgs e)
        //{
        //    if (SelectedRezumes != null)
        //    {
        //        OpenFileDialog openFileDialog = new OpenFileDialog();
        //        openFileDialog.ShowDialog();
        //        string path = openFileDialog.FileName;
        //        SelectedRezumes.Img = File.ReadAllBytes(path);
        //        PropertyChanged?.Invoke(this,
        //            new PropertyChangedEventArgs(nameof(SelectedRezumes)));
        //    }
        //}

        private void Button_Image(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedImage = openFileDialog.FileName;
                BitmapImage bitmap = new BitmapImage(new Uri(selectedImage));
                imageControl.Source = bitmap;
            }
        }
    }
}
