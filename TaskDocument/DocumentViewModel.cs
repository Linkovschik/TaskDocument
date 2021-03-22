using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace TaskDocument
{
    class DocumentViewModel : INotifyPropertyChanged
    {
        //обёртка над свойством "подписанный" документа
        //подписанный документ - неизменяемый
        public bool SelectedDocumentChangable
        {
            get { return !SelectedDocument.Signed; }
            set
            {
                SelectedDocument.Signed = !value;
                OnPropertyChanged("SelectedDocumentChangable");
            }
        }

        //выбранный и обозреваемый документ
        public DocumentItem SelectedDocument { get; private set; }

        public RelayCommand SignDocumentCommand { get; private set; }

        public DocumentViewModel(Item _item)
        {
            if (_item is DocumentItem)
                SelectedDocument = (_item as DocumentItem);
            else throw new Exception("Тип переданного объекта не соответствует TaskItem");
            SignDocumentCommand = new RelayCommand(SignDocument, CanSignDocument);
        }

        private void SignDocument(object _guid)
        {
            SelectedDocumentChangable = false;
        }

        private bool CanSignDocument(object parameter)
        {
            if (SelectedDocument.DigitalSignature == null || !SelectedDocumentChangable)
                return false;
            return true;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
