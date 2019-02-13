﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DSConverter.Properties;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace DSConverter
{
    public partial class DsConverterForm: Form
    {
        public DsConverterForm()
        {
            this.InitializeComponent();
            Application.EnableVisualStyles();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            this.lkavCountTextBox.Text = this.LKavCount.ToString(CultureInfo.InvariantCulture);
            this.spyCountTextBox.Text = this.SpyCount.ToString(CultureInfo.InvariantCulture);
            this.homeCoordinateTextBox.Text = this.HomeCoordinate[0] + "|" + this.HomeCoordinate[1];
            this.pauseTimeTextBox.Text = this.PauseTime.ToString(CultureInfo.InvariantCulture);

            if(this.TargetDictionary != null&&this.TargetDictionary.Count>0)
            {
                var sb = new StringBuilder();
                foreach(var target in this.TargetDictionary)
                {
                    sb.AppendLine(target.Key);
                }
                this.targetTextBox.Text = sb.ToString();
            }

            this.urlTextBox.Text = this.Url;
        }


        private Dictionary<string, Target> TargetDictionary
        {
            get => JsonConvert.DeserializeObject<Dictionary<string, Target>>(Settings.Default.TargetDictionary);
            set
            {
                if(value != null)
                {
                    var serializeObject = JsonConvert.SerializeObject(value);


                    Settings.Default.TargetDictionary = serializeObject;
                    Settings.Default.Save();
                }
            }
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

        private decimal LKavCount
        {
            get => Settings.Default.LkavCount;
            set
            {
                if(value >= 0)
                {
                    Settings.Default.LkavCount = value;
                    Settings.Default.Save();
                }
            }
        }

        private decimal PauseTime
        {
            get => Settings.Default.PauseTime;
            set
            {
                if(value > 0)
                {
                    Settings.Default.PauseTime = value;
                    Settings.Default.Save();
                }
            }
        }

        private decimal SpyCount
        {
            get => Settings.Default.SpyCount;
            set
            {
                if(value >= 0)
                {
                    Settings.Default.SpyCount = value;
                    Settings.Default.Save();
                }
            }
        }

        private string[] HomeCoordinate
        {
            get => Settings.Default.HomeCoordinate.Split('|');

            set
            {
                Settings.Default.HomeCoordinate = value[0] + "|" + value[1];
                Settings.Default.Save();
            }
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            this.scriptTextBox.Text = string.Empty;
            var str = this.ProcessConvert();
            this.scriptTextBox.Text = str;
        }

        private string GetScriptEnd(decimal pauseTime)
        {
            var end = string.Empty;
            end += Environment.NewLine + "SET !VAR1 EVAL(\"var randomNumber=Math.floor(Math.random()*2*60+" + pauseTime + "*60); randomNumber;\")";
            end += Environment.NewLine + "wait seconds={{!var1}}";
            end += Environment.NewLine + "TAB CLOSE";

            return end;
        }

        private string GetScriptFragment(string coordinates, decimal lkavCount, decimal spyCount)
        {
            var sendTroops = string.Empty;
            sendTroops += Environment.NewLine + $"TAG POS=1 TYPE=INPUT:TEXT FORM=ID:command-data-form ATTR=NAME:input CONTENT={coordinates}";
            sendTroops += Environment.NewLine + $"TAG POS=1 TYPE=INPUT:TEXT FORM=ID:command-data-form ATTR=ID:unit_input_light Content={Math.Round(lkavCount)}";
            if(spyCount > 0)
            {
                sendTroops += Environment.NewLine + $"TAG POS=1 TYPE=INPUT:TEXT FORM=ID:command-data-form ATTR=ID:unit_input_spy Content={Math.Round(spyCount)}";
            }

            sendTroops += this.GetWaitTimer();
            sendTroops += Environment.NewLine + "TAG POS=1 TYPE=INPUT:SUBMIT FORM=ID:command-data-form ATTR=ID:target_attack";
            sendTroops += this.GetWaitTimer();
            sendTroops += Environment.NewLine + "TAG POS=1 TYPE=INPUT:SUBMIT FORM=ID:command-data-form ATTR=ID:troop_confirm_go";
            sendTroops += this.GetWaitTimer();
            return sendTroops;
        }

        private string GetWaitTimer()
        {
            var i = new Random().Next(1, 10);
            return Environment.NewLine + $"wait seconds={{!var{i}}}";
        }

        private string GetScriptHead()
        {
            var header = string.Empty;
            header += "VERSION BUILD=9030808 RECORDER=FX";
            header += Environment.NewLine;

            // header += Environment.NewLine + "TAB T = 1";
            header += Environment.NewLine + "TAB OPEN";
            header += Environment.NewLine;
            header += Environment.NewLine + $"URL GOTO = {this.urlTextBox.Text}";

            for(int i = 1; i < 11; i++)
            {
                header+= Environment.NewLine + $"SET !VAR{i} EVAL(\"var randomNumber=Math.floor(Math.random()*1 ); randomNumber;\")";
            }

            this.Url = this.urlTextBox.Text;
            return header;
        }

        private void ParseTargetLine([NotNull] string line, [NotNull] ref Dictionary<string, Target> targetList)
        {
            var parseString = line;
            if(line.Contains(";"))
            {
                var split = parseString.Split(';');
                if(split.Length == 2)
                {
                    parseString = split[1];
                }
            }

            if(parseString.Contains('|'))
            {
                var coords = parseString.Split('|');
         
                var key = int.Parse(coords[0]) + "|" + int.Parse(coords[1]);
                var target = new Target(new[]
                                        {
                                                int.Parse(coords[0]),
                                                int.Parse(coords[1])
                                        });
                targetList[key]=target;
            }
        }

        private string ProcessConvert()
        {
            this.LKavCount = Convert.ToDecimal(this.lkavCountTextBox.Text);
            this.SpyCount = Convert.ToDecimal(this.spyCountTextBox.Text);
            this.PauseTime = Convert.ToDecimal(this.pauseTimeTextBox.Text);
            this.ReadInputList();
            
            var scriptHead = this.GetScriptHead();

            var sb = new StringBuilder();
            sb.Append(scriptHead);
            
            var input = this.targetTextBox.Lines;
            foreach(var s in input)
            {
                var parseString = s;

                //cut off distance
                if(s.Contains(";"))
                {
                    var strings = s.Split(';');
                    parseString = strings[1];
                }

                if(s.Contains("|"))
                {
                    sb.AppendLine(this.GetScriptFragment(parseString, this.LKavCount, this.SpyCount));
                }
            }

            var end = this.GetScriptEnd(decimal.Parse(this.pauseTimeTextBox.Text));
            sb.Append(end);
            return sb.ToString();
        }

        private void ReadInputList()
        {
            var targetList= new Dictionary<string,Target>();
            foreach(var line in this.targetTextBox.Lines)
            {
                this.ParseTargetLine(line, ref targetList);
            }

            this.TargetDictionary = targetList;
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
                    foreach(var line in this.scriptTextBox.Lines)
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
            this.ReadInputList();


            var input = this.targetTextBox.Lines;
            var toBeSorted = new List<string>();
            foreach(var s in input)
            {
                if(!string.IsNullOrEmpty(s))
                {
                    toBeSorted.Add(s);
                }
            }

            if(this.homeCoordinateTextBox.Text.Contains("|"))
            {
                this.HomeCoordinate = this.homeCoordinateTextBox.Text.TrimStart('(').TrimEnd(')').Split('|');
            }


            //root((559-564)^2+(470-468)^2)
            for(var index = 0; index < toBeSorted.Count; index++)
            {
                var line = toBeSorted[index];
                var coords = line.Split('|');
                var distance = Math.Sqrt(Math.Pow(double.Parse(this.HomeCoordinate[0]) - double.Parse(coords[0]), 2f) + Math.Pow(double.Parse(this.HomeCoordinate[1]) - double.Parse(coords[1]), 2f));
                toBeSorted[index] = Math.Round(distance) + ";" + line;
            }

            var sorted = toBeSorted.ToArray();
            Array.Sort(sorted, StringComparer.Ordinal);

            this.targetTextBox.Lines = sorted;
        }
    }
}
