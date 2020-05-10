using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiblickyGenerator
{
    class Window
    {
        private TextBox txtb;
        public TextBox Txtb { get => txtb; set => txtb = value; }

        private string input;
        public string Input { get => input; set => input = value; }

        private string output;
        public string Output { get => output; set => output = value; }


        private string model;
        public string Model { get => model; set => model = value; }

        private bool usedMorphodita;
        public bool UsedMorphodita { get => usedMorphodita; set => usedMorphodita = value; }

        public Window()
        {
            input = "";
            model = "";
            output = "";
            txtb = null;
            usedMorphodita = false;
        }
        public void clear()
        {
            txtb.Text = "";
            output = "";
        }
    }
}

