using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ChválicíAppka
{
    [Serializable]
    public class Hlaska
    {
        public string Text { get; set; }
        public bool Pochvala { get; set; }

        public override string ToString()
        {
            return (Pochvala ? "Pochvala" : "Urážka") + ": " + Text;
        }
    }

}
