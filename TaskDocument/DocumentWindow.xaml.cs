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
using System.Windows.Shapes;

namespace TaskDocument
{
    /// <summary>
    /// Логика взаимодействия для DocumentWindow.xaml
    /// </summary>
    public partial class DocumentWindow : Window
    {
        public DocumentWindow(Item item_to_show)
        {
            InitializeComponent();

            DataContext = new DocumentViewModel(item_to_show);
            BindingExpression be = DocumentGuidField.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();
        }
    }
}
