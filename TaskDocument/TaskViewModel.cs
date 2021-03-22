using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDocument
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        //выбранная и обозреваемая задача
        public TaskItem SelectedTask { get; private set; }

        public TaskViewModel(Item _item)
        {
            if (_item is TaskItem)
                SelectedTask = (_item as TaskItem);
            else throw new Exception("Тип переданного объекта не соответствует TaskItem");
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
