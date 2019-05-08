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
using System.Windows.Forms;
using SearchLib;
using System.ComponentModel;

namespace Filesearch
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btChoseDirectory_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            DialogResult directory = dialog.ShowDialog();
            tbxDirectory.Text = dialog.SelectedPath;
        }

        private void btStartSearch_Click(object sender, RoutedEventArgs e)
        {
            tbcDirectoryError.Visibility = Visibility.Collapsed;
            tbcSearchError.Visibility = Visibility.Collapsed;

            pbSearch.Visibility = Visibility.Visible;
            string dir = tbxDirectory.Text;
            string filter = tbxFilter.Text;

            Task task = Task.Factory.StartNew(() => StartSearch(dir, filter));
        }
        
        private void StartSearch(string path, string filter)
        {
            DirectorySearch directory = new DirectorySearch(path, filter);
            int state = directory.FindFiles();
            switch (state)
            {
                case 0:
                    Dispatcher.Invoke(() =>
                    {
                        lvFindings.Items.Clear();
                        foreach (var p in directory.Findings)
                        {
                            lvFindings.Items.Add(new DisplayOfFindings { Path = p });
                        }
                    });
                    break;
                case 1:
                    Dispatcher.Invoke(() =>
                    {
                        tbcSearchError.Visibility = Visibility.Visible;
                    });
                    break;
                case 2:
                    Dispatcher.Invoke(() =>
                    {
                        tbcDirectoryError.Visibility = Visibility.Visible;
                    });
                    break;
            }
            Dispatcher.Invoke(() =>
            {
                pbSearch.Visibility = Visibility.Collapsed;
            });
        }

        private struct DisplayOfFindings
        {
            public DisplayOfFindings(string _path)
            {
                path = _path;
            }

            string path;
            public string Path
            {
                get { return path; }
                set { path = value; }
            }
        }
    }
}
