using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DSConverter.Properties;

namespace DSConverter
{
    public partial class DsConverterForm: Form
    {
        public DsConverterForm()
        {
            this.InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            this.lkavCountTextBox.Text = this.BaseTroopCount.ToString(CultureInfo.InvariantCulture);
            this.urlTextBox.Text = this.Url;
        }

        private string Url
        {
            get => Settings.Default.Url;
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    Settings.Default.Url = value;
                    Settings.Default.Save();
                }
            }
        }

        private string Header { get; set; }

        private decimal BaseTroopCount
        {
            get => Settings.Default.BaseTroopCount;
            set
            {
                if(value > 0)
                {
                    Settings.Default.BaseTroopCount = value;
                    Settings.Default.Save();
                }
            }
        }


        private void convertButton_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = string.Empty;
            var str = this.ProcessConvert();
            this.textBox2.Text = str;
        }

        private void GetParameters()
        {
            this.Header = string.Empty;
            this.Header += "VERSION BUILD=9030808 RECORDER=FX";
            this.Header += Environment.NewLine;
            this.Header += Environment.NewLine + "TAB T = 1";
            this.Header += Environment.NewLine;
            this.Header += Environment.NewLine + $"URL GOTO = {this.urlTextBox.Text}";

            this.Url = this.urlTextBox.Text;
            this.BaseTroopCount = Convert.ToDecimal(this.lkavCountTextBox.Text);
        }

        private string GetScriptFragment(string coordinates, decimal lkavCount)
        {
            var sendTroops = string.Empty;
            sendTroops += Environment.NewLine + $"TAG POS=1 TYPE=INPUT:TEXT FORM=ID:command-data-form ATTR=NAME:input CONTENT={coordinates}";
            sendTroops += Environment.NewLine + $"TAG POS=1 TYPE=INPUT:TEXT FORM=ID:command-data-form ATTR=ID:unit_input_light Content={Math.Round(lkavCount)}";
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
            return sendTroops;
        }

        private string ProcessConvert()
        {
            this.GetParameters();
            var sb = new StringBuilder();

            sb.Append(this.Header);


            var input = this.textBox1.Lines;
            foreach(var s in input)
            {
                if(s.Contains("|"))
                {
                    if(s.Contains(";"))
                    {
                        var strings = s.Split(';');
                        if(strings.Length == 2)
                        {
                            var troopMultiplier = Convert.ToDecimal(strings[1]);
                            sb.AppendLine(this.GetScriptFragment(strings[0], this.BaseTroopCount * troopMultiplier));
                        }
                    }
                    else
                    {
                        sb.AppendLine(this.GetScriptFragment(s, this.BaseTroopCount));
                    }
                }
            }

            return sb.ToString();
        }

        private void saveButton_Click_1(object sender, EventArgs e)
        {
            var savefile = new SaveFileDialog
                           {
                               FileName = "Farm.iim"
                           };


            if(savefile.ShowDialog() == DialogResult.OK)
            {
                using(var sw = new StreamWriter(savefile.FileName))
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

        private void sortButton_Click(object sender, EventArgs e)
        {
            var input = this.textBox1.Lines;
            var toBeSorted = new List<string>();
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
    }
}
