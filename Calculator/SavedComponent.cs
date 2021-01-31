using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class SavedComponent//класс для объектов в списках
    {
        public SavedComponent(string currTextResultValue)//конструктор
        {
            ComponentValue = currTextResultValue;
        }
        public string ComponentValue { get; set; }
    }
}
