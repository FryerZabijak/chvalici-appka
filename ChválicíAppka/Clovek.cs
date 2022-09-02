using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ChválicíAppka
{
    [Serializable]
    public class Clovek
    {
        public string Jmeno { get; set; }
        public ObservableCollection<Hlaska> seznamHlasek { get; set; } = new ObservableCollection<Hlaska>();

        public override string ToString()
        {
            return Jmeno;
        }
    }
}
