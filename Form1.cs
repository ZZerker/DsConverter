using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSConverter
{
    public partial class Form1 : Form
    {
        private const string header = @"VERSION BUILD=9030808 RECORDER=FX
        TAB T = 1

        URL GOTO = https://de141.die-staemme.de/game.php?village=5665&screen=place";

        private const int troupCount = 9;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var input = this.textBox1.Lines;
            Array.Sort(input, StringComparer.Ordinal);
            this.textBox1.Lines = input;
            string sendTroops = "";
            sendTroops += Environment.NewLine+$"TAG POS=1 TYPE=INPUT:TEXT FORM=ID:command-data-form ATTR=NAME:input CONTENT=XYZ";
            sendTroops += Environment.NewLine+$"TAG POS=1 TYPE=INPUT:TEXT FORM=ID:command-data-form ATTR=ID:unit_input_light Content={troupCount}";
            sendTroops += Environment.NewLine+"";
            sendTroops += Environment.NewLine+"SET !VAR1 EVAL(\"var randomNumber=Math.floor(Math.random()*1 +2); randomNumber;\")";
            sendTroops += Environment.NewLine+"wait seconds={{!var1}}";
            sendTroops += Environment.NewLine+"";
            sendTroops += Environment.NewLine+"TAG POS=1 TYPE=INPUT:SUBMIT FORM=ID:command-data-form ATTR=ID:target_attack";
            sendTroops += Environment.NewLine+"";
            sendTroops += Environment.NewLine+"SET !VAR1 EVAL(\"var randomNumber=Math.floor(Math.random()*1 +2); randomNumber;\")";
            sendTroops += Environment.NewLine+"wait seconds={{!var1}}";
            sendTroops += Environment.NewLine+"";
            sendTroops += Environment.NewLine+"TAG POS=1 TYPE=INPUT:SUBMIT FORM=ID:command-data-form ATTR=ID:troop_confirm_go";
            sendTroops += Environment.NewLine+"";
            sendTroops += Environment.NewLine+"SET !VAR1 EVAL(\"var randomNumber=Math.floor(Math.random()*1 +2); randomNumber;\")";
            sendTroops += Environment.NewLine+"wait seconds={{!var1}}";

            this.textBox2.Text = "";
            this.textBox2.Text += header;
       
         
            
            foreach(var s in input)
            {
                if(s.Contains("|"))
                {
                    this.textBox2.Text += sendTroops.Replace("XYZ", s);
                }
            }
        }
    }
}
