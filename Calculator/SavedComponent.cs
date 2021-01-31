using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class SavedComponent
    {
        public SavedComponent(string currTextResultValue)
        {
            ComponentValue = currTextResultValue;
        }
        public string ComponentValue { get; set; }
    }
}
