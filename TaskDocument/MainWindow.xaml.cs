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

namespace TaskDocument
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ObservingWindowViewModel();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if(DataContext is ObservingWindowViewModel vm)
            {
                vm.OpenItemWindow += OpenItemWindow;
            }
        }

        private void OpenItemWindow(Item found_item)
        {
            Window itemWindow = null;

            if (found_item is TaskItem)
            {
                itemWindow = new TaskWindow(found_item);
            }
            else if (found_item is DocumentItem)
            {
                itemWindow = new DocumentWindow(found_item);
            }
            else if (found_item == null)
            {
                throw new Exception("Не найден открываемый объект");
            }
            itemWindow.Owner = this;
            itemWindow.Show();
        }
    }
}
