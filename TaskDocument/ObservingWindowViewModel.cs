using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TaskDocument
{
    public class ObservingWindowViewModel : INotifyPropertyChanged
    {
        //перечисление доступных в представлении типов объектов
        public enum ItemType
        {
            Task,
            Document
        }

        //коллекция элементов
        public ObservableCollection<Item> Items { get; private set; }

        //команды
        public ICommand AddItemCommand { get; private set; }            //добавить новый элемент в коллекцию объектов
        public ICommand OpenItemCommand { get; private set; }           //открыть окно элемента

        public ObservingWindowViewModel()
        {
            Items = new ObservableCollection<Item>
            {
                new TaskItem("Задача_1", "БИП-БИП", TaskStates.Completed),
                new TaskItem("Задача_2", "Проверка", TaskStates.InProcess),
                new DocumentItem("Документ_1", "Что тут происходит?", new Guid())
            };
            AddItemCommand = new RelayCommand(AddItem);
            OpenItemCommand = new RelayCommand(OpenItem);
        }

        //функция добавления элемента в коллекцию по указанному типу typeName из Enum ItemType
        private void AddItem(object typeName)
        {
            ItemType type;
            ItemFactory factory;
            try
            {
                type = (ItemType)Enum.Parse(typeof(ItemType), typeName.ToString());
            }
            catch (Exception e)
            {
                type = ItemType.Task;
            }

            switch (type)
            {
                case ItemType.Task:
                    factory = new TaskItemFactory();
                    Items.Add(factory.CreateItem());
                    break;
                case ItemType.Document:
                    factory = new DocumentItemFactory();
                    Items.Add(factory.CreateItem());
                    break;
            }
        }

        //делегат открытия окна - определяется в интерфейсе основного окна, в событии Loaded
        public Action<Item> OpenItemWindow { get; set; }
        //найти открываемый элемент по Id и открыть его окно (если открытие окна определено)
        public void OpenItem(object itemToOpen)
        {
            //MessageBox.Show("Это предмет с Id = " + itemToOpen.ToString());
            int search_id;
            if (itemToOpen is int)
                search_id = (int)(itemToOpen);
            else
                throw new Exception("Передан некорректный индекс объекта");

            Item found_item = Items.First(x => x.Id == search_id);

            OpenItemWindow?.Invoke(found_item);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
