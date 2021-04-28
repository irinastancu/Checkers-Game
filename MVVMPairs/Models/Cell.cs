using MVVMPairs.Commands;
using MVVMPairs.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMPairs.Models
{
    
    class Cell : INotifyPropertyChanged
    {
        
        public Cell(int x, int y, string img, Color color, Type type)
        {
            this.X = x;
            this.Y = y;
            this.image = img;
            this.color = color;
            this.type = type;
        }

        public Cell(CellData data)
        {
            this.X = data.x;
            this.Y = data.y;
            this.image = data.image;
            this.color = data.color;
            this.type = data.type;
        }
        private Color color;
        public Color Color
        {
            get => color;
            set
            {
                color = value;
                NotifyPropertyChanged("Color");
            }
        }

       
        private Type type;
        public Type Type
        {
            get => type;
            set
            {
                type = value;
                NotifyPropertyChanged("Type");
            }
        }

        /* Am optat sa fac proprietati notificabile aici; o alta varianta ar fi fost sa lucrez in Services cu obiecte ViewModel
        care sunt notificabile, dar aceasta optiune o gasesc mai potrivita pentru MVVM */
        //public int X { get; set; }
        //public int Y { get; set; }
        //public string DisplayedImage { get; set; }
        //public string HidenImage { get; set; }

        private int x;
        public int X
        {
            get { return x; }
            set
            {
                x = value;
                NotifyPropertyChanged("X");
            }
        }
        private int y;
        public int Y
        {
            get { return y; }
            set
            {
                y = value;
                NotifyPropertyChanged("Y");
            }
        }
      
        private string image;
        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                NotifyPropertyChanged("Image");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void firstClick(object param)
        {
            GameBusinessLogic.ClickAction(this);
       
        }

        private ICommand clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                if (clickCommand == null)
                {
                    clickCommand = new RelayCommand<Cell>(firstClick);
                }
                return clickCommand;
            }
        }

        public CellData Data { get { return new CellData(this.x, this.y, this.image, this.color, this.type); } }

    }
}
