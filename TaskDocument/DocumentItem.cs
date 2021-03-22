using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDocument
{
    public class DocumentItem : Item
    {
        //состояние "подписанный"
        private bool signed = false;
        public bool Signed
        {
            get { return signed; }
            set
            {
                signed = value;
                OnPropertyChanged("Signed");
            }
        }

        private Guid? digitalSignature = null;
        public Guid? DigitalSignature
        {
            get { return digitalSignature; }
            set
            {
                digitalSignature = value;
                OnPropertyChanged("DigitalSignature");
            }
        }

        public override string ItemType
        {
            get
            {
                return "Документ";
            }

        }

        public DocumentItem() : base()
        {
            DigitalSignature = null;
        }

        public DocumentItem(string _name, string _body, Guid _guid) : base(_name, _body)
        {
            DigitalSignature = _guid;
        }
    }

    public class DocumentItemFactory : ItemFactory
    {
        public override Item CreateItem()
        {
            return new DocumentItem();
        }
    }
}
