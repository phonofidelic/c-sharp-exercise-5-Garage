using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.UI
{
    public class FormSelection
    {
        public int Option { get; private init; }
        public FormListItem? Item { get; private init; }
        public FormSelection(int option, FormListItem item)
        {
            Option = option;
            Item = item;
        }
        public FormSelection(int option)
        {
            Option = option;
            Item = null;
        }
    }
}
