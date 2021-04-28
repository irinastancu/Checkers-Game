using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMPairs.Models
{
    class Player : INotifyPropertyChanged
    {

        private Color playerColor;
        public Color PlayerColor
        {
            get => playerColor;
            set
            {
                playerColor = value;
                NotifyPropertyChanged("Color");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public int PiecesTaken { get; set; }

        public Player(Color color, int pieces)
        {
            this.playerColor = color;
            this.PiecesTaken = pieces;
        }

        public override string ToString()
        {
            return $"{playerColor}\n" +
                $"{PiecesTaken} pieces taken"; 
        }
        public void UpdateTurn(Color color)
        {
            playerColor = color;
        }
    }
}
