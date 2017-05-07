using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DSConverter
{
    public partial class DsConverterForm: Form
    {
        private string header = string.Empty;

        private string troopCount = "9";

        public DsConverterForm()
        {
            this.InitializeComponent();
            this.urlTextBox.Text = "https://de141.die-staemme.de/game.php?village=123123&screen=place";

            this.lkavCountTextBox.Text = this.troopCount;
        }

        


        private void convertButton_Click(object sender, EventArgs e)
        {
            this.GetParameters();

            var input = this.textBox1.Lines;
            var sendTroops = "";
            sendTroops += Environment.NewLine + $"TAG POS=1 TYPE=INPUT:TEXT FORM=ID:command-data-form ATTR=NAME:input CONTENT=XYZ";
            sendTroops += Environment.NewLine + $"TAG POS=1 TYPE=INPUT:TEXT FORM=ID:command-data-form ATTR=ID:unit_input_light Content={this.troopCount}";
            sendTroops += Environment.NewLine + "";
            sendTroops += Environment.NewLine + "SET !VAR1 EVAL(\"var randomNumber=Math.floor(Math.random()*1 +2); randomNumber;\")";
            sendTroops += Environment.NewLine + "wait seconds={{!var1}}";
            sendTroops += Environment.NewLine + "";
            sendTroops += Environment.NewLine + "TAG POS=1 TYPE=INPUT:SUBMIT FORM=ID:command-data-form ATTR=ID:target_attack";
            sendTroops += Environment.NewLine + "";
            sendTroops += Environment.NewLine + "SET !VAR1 EVAL(\"var randomNumber=Math.floor(Math.random()*1 +2); randomNumber;\")";
            sendTroops += Environment.NewLine + "wait seconds={{!var1}}";
            sendTroops += Environment.NewLine + "";
            sendTroops += Environment.NewLine + "TAG POS=1 TYPE=INPUT:SUBMIT FORM=ID:command-data-form ATTR=ID:troop_confirm_go";
            sendTroops += Environment.NewLine + "";
            sendTroops += Environment.NewLine + "SET !VAR1 EVAL(\"var randomNumber=Math.floor(Math.random()*1 +2); randomNumber;\")";
            sendTroops += Environment.NewLine + "wait seconds={{!var1}}";

            this.textBox2.Text = "";
            this.textBox2.Text += this.header;


            foreach (var s in input)
            {
                if (s.Contains("|"))
                {
                    this.textBox2.Text += sendTroops.Replace("XYZ", s);
                }
            }
        }

        private void GetParameters()
        {
            this.header = string.Empty;
            this.header += "VERSION BUILD=9030808 RECORDER=FX";
            this.header += Environment.NewLine;
            this.header += Environment.NewLine + "TAB T = 1";
            this.header += Environment.NewLine;
            this.header += Environment.NewLine + $"URL GOTO = {this.urlTextBox.Text}";

            this.troopCount = this.lkavCountTextBox.Text;
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            var input = this.textBox1.Lines;
            var toBeSorted = new List<string>{};
            foreach(var s in input)
            {
                if(!string.IsNullOrEmpty(s))
                {
                    toBeSorted.Add(s);
                }
            }
            var sorted = toBeSorted.ToArray();

            Array.Sort(sorted, StringComparer.Ordinal);
            this.textBox1.Lines = sorted;
        }

        private void saveButton_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog
                                      {
                                          FileName = "Farm.iim"
                                      };



            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using(StreamWriter sw = new StreamWriter(savefile.FileName))
                {
                    foreach(var line in this.textBox2.Lines)
                    {
                        sw.WriteLine(line);
                    }
                    sw.Flush();
                    sw.Dispose();
                    
                }
                 
            }
        }
    }
}
