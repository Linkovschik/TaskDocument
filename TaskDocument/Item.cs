using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDocument
{
    public abstract class Item : INotifyPropertyChanged
    {
        //счётчик объектов
        private static int GlobalId = 0;

        //Имя
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        //Тело
        private string body;
        public string Body
        {
            get { return body; }
            set
            {
                body = value;
                OnPropertyChanged("Body");
            }
        }

        //Идентификатор
        private int id;
        public int Id
        {
            get { return id; }
            private set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        //Тип объекта
        public virtual string ItemType
        {
            get
            {
                return "Неопределённый тип объекта";
            }
        }

        public Item()
        {
            //увеличение счётчика объектов (присваивание идентификатора)
            Id = ++GlobalId;
            //установка значения по умолчанию
            Name = "Без имени";
            Body = "Без тела";
        }

        public Item(string name, string body) : this()
        {
            Name = name;
            Body = body;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }

    public abstract class ItemFactory
    {
        abstract public Item CreateItem();
    }
}
