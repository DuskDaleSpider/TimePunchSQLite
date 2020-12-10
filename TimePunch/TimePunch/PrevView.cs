using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimePunch
{
    class PrevView
    {
        public MainForm.Views View { get; private set; }
        public int Arg { get; private set; }

        public PrevView(MainForm.Views view, int arg)
        {
            View = view;
            Arg = arg;
        }

    }
}
