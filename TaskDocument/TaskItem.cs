using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDocument
{
    //перечисление возможных состояний задачи
    public enum TaskStates
    {
        InProcess,
        Completed
    }

    public class TaskItem : Item
    {
        //состояние задачи
        private Enum taskState;
        public virtual Enum TaskState
        {
            get { return taskState; }
            set
            {
                taskState = value;
                OnPropertyChanged("TaskState");
            }
        }

        //тип объекта
        public override string ItemType
        {
            get
            {
                return "Задача";
            }

        }

        public TaskItem() : base()
        {
            //установка значения по умолчанию
            TaskState = TaskStates.InProcess;
        }

        public TaskItem(string name, string body, Enum taskState) : base(name, body)
        {
            TaskState = taskState;
        }
    }

    public class TaskItemFactory : ItemFactory
    {
        public override Item CreateItem()
        {
            return new TaskItem();
        }
    }
}
