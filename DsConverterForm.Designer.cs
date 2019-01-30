using System.Windows.Forms;

namespace DSConverter
{
    partial class DsConverterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.targetTextBox = new System.Windows.Forms.TextBox();
            this.scriptTextBox = new System.Windows.Forms.RichTextBox();
            this.topTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.urlLabel = new System.Windows.Forms.Label();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.troopCountLabel = new System.Windows.Forms.Label();
            this.lkavCountTextBox = new System.Windows.Forms.TextBox();
            this.convertButton = new System.Windows.Forms.Button();
            this.buttonTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.sortButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.spyLabel = new System.Windows.Forms.Label();
            this.spyCountTextBox = new System.Windows.Forms.TextBox();
            this.homeCoordinateLabel = new System.Windows.Forms.Label();
            this.homeCoordinateTextBox = new System.Windows.Forms.TextBox();
            this.pauseTimeLabel = new System.Windows.Forms.Label();
            this.pauseTimeTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.topTableLayoutPanel.SuspendLayout();
            this.buttonTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.targetTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.scriptTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.topTableLayoutPanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1275, 700);
            this.tableLayoutPanel1.TabIndex = 0;
            
            // 
            // targetTextBox
            // 
            this.targetTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetTextBox.Location = new System.Drawing.Point(3, 153);
            this.targetTextBox.Multiline = true;
            this.targetTextBox.Name = "targetTextBox";
            this.targetTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.targetTextBox.Size = new System.Drawing.Size(631, 544);
            this.targetTextBox.TabIndex = 0;
            // 
            // scriptTextBox
            // 
            this.scriptTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptTextBox.Location = new System.Drawing.Point(640, 153);
            this.scriptTextBox.Name = "scriptTextBox";
            this.scriptTextBox.Size = new System.Drawing.Size(632, 544);
            this.scriptTextBox.TabIndex = 2;
            this.scriptTextBox.Text = "";
            // 
            // topTableLayoutPanel
            // 
            this.topTableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.topTableLayoutPanel, 2);
            this.topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topTableLayoutPanel.Controls.Add(this.urlLabel, 0, 0);
            this.topTableLayoutPanel.Controls.Add(this.urlTextBox, 1, 0);
            this.topTableLayoutPanel.Controls.Add(this.troopCountLabel, 0, 3);
            this.topTableLayoutPanel.Controls.Add(this.lkavCountTextBox, 1, 3);
            this.topTableLayoutPanel.Controls.Add(this.convertButton, 0, 5);
            this.topTableLayoutPanel.Controls.Add(this.buttonTableLayoutPanel, 1, 5);
            this.topTableLayoutPanel.Controls.Add(this.spyLabel, 0, 2);
            this.topTableLayoutPanel.Controls.Add(this.spyCountTextBox, 1, 2);
            this.topTableLayoutPanel.Controls.Add(this.homeCoordinateLabel, 0, 1);
            this.topTableLayoutPanel.Controls.Add(this.homeCoordinateTextBox, 1, 1);
            this.topTableLayoutPanel.Controls.Add(this.pauseTimeLabel, 0, 4);
            this.topTableLayoutPanel.Controls.Add(this.pauseTimeTextBox, 1, 4);
            this.topTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.topTableLayoutPanel.Name = "topTableLayoutPanel";
            this.topTableLayoutPanel.RowCount = 6;
            this.topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.topTableLayoutPanel.Size = new System.Drawing.Size(1269, 144);
            this.topTableLayoutPanel.TabIndex = 2;
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urlLabel.Location = new System.Drawing.Point(3, 0);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(194, 21);
            this.urlLabel.TabIndex = 0;
            this.urlLabel.Text = "Sammelplatz Url";
            this.urlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // urlTextBox
            // 
            this.urlTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urlTextBox.Location = new System.Drawing.Point(203, 3);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(1063, 20);
            this.urlTextBox.TabIndex = 1;
            // 
            // troopCountLabel
            // 
            this.troopCountLabel.AutoSize = true;
            this.troopCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.troopCountLabel.Location = new System.Drawing.Point(3, 63);
            this.troopCountLabel.Name = "troopCountLabel";
            this.troopCountLabel.Size = new System.Drawing.Size(194, 21);
            this.troopCountLabel.TabIndex = 2;
            this.troopCountLabel.Text = "Anzahl LKav";
            this.troopCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lkavCountTextBox
            // 
            this.lkavCountTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lkavCountTextBox.Location = new System.Drawing.Point(203, 66);
            this.lkavCountTextBox.Name = "lkavCountTextBox";
            this.lkavCountTextBox.Size = new System.Drawing.Size(1063, 20);
            this.lkavCountTextBox.TabIndex = 3;
            // 
            // convertButton
            // 
            this.convertButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.convertButton.Location = new System.Drawing.Point(3, 108);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(194, 33);
            this.convertButton.TabIndex = 4;
            this.convertButton.Text = "Konvertieren  >>";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // buttonTableLayoutPanel
            // 
            this.buttonTableLayoutPanel.ColumnCount = 3;
            this.buttonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.buttonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.buttonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonTableLayoutPanel.Controls.Add(this.sortButton, 0, 0);
            this.buttonTableLayoutPanel.Controls.Add(this.saveButton, 1, 0);
            this.buttonTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTableLayoutPanel.Location = new System.Drawing.Point(203, 108);
            this.buttonTableLayoutPanel.Name = "buttonTableLayoutPanel";
            this.buttonTableLayoutPanel.RowCount = 1;
            this.buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.buttonTableLayoutPanel.Size = new System.Drawing.Size(1063, 33);
            this.buttonTableLayoutPanel.TabIndex = 5;
            // 
            // sortButton
            // 
            this.sortButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sortButton.Location = new System.Drawing.Point(3, 3);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(144, 27);
            this.sortButton.TabIndex = 0;
            this.sortButton.Text = "Koordinaten Sortieren";
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveButton.Location = new System.Drawing.Point(153, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(144, 27);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Speichern Unter";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click_1);
            // 
            // spyLabel
            // 
            this.spyLabel.AutoSize = true;
            this.spyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spyLabel.Location = new System.Drawing.Point(3, 42);
            this.spyLabel.Name = "spyLabel";
            this.spyLabel.Size = new System.Drawing.Size(194, 21);
            this.spyLabel.TabIndex = 6;
            this.spyLabel.Text = "Anzahl Späher";
            this.spyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spyCountTextBox
            // 
            this.spyCountTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spyCountTextBox.Location = new System.Drawing.Point(203, 45);
            this.spyCountTextBox.Name = "spyCountTextBox";
            this.spyCountTextBox.Size = new System.Drawing.Size(1063, 20);
            this.spyCountTextBox.TabIndex = 7;
            // 
            // homeCoordinateLabel
            // 
            this.homeCoordinateLabel.AutoSize = true;
            this.homeCoordinateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.homeCoordinateLabel.Location = new System.Drawing.Point(3, 21);
            this.homeCoordinateLabel.Name = "homeCoordinateLabel";
            this.homeCoordinateLabel.Size = new System.Drawing.Size(194, 21);
            this.homeCoordinateLabel.TabIndex = 8;
            this.homeCoordinateLabel.Text = "eigene Koordinate";
            this.homeCoordinateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // homeCoordinateTextBox
            // 
            this.homeCoordinateTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.homeCoordinateTextBox.Location = new System.Drawing.Point(203, 24);
            this.homeCoordinateTextBox.Name = "homeCoordinateTextBox";
            this.homeCoordinateTextBox.Size = new System.Drawing.Size(1063, 20);
            this.homeCoordinateTextBox.TabIndex = 9;
            // 
            // pauseTimeLabel
            // 
            this.pauseTimeLabel.AutoSize = true;
            this.pauseTimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pauseTimeLabel.Location = new System.Drawing.Point(3, 84);
            this.pauseTimeLabel.Name = "pauseTimeLabel";
            this.pauseTimeLabel.Size = new System.Drawing.Size(194, 21);
            this.pauseTimeLabel.TabIndex = 10;
            this.pauseTimeLabel.Text = "Wartezeit in Minuten";
            this.pauseTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pauseTimeTextBox
            // 
            this.pauseTimeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pauseTimeTextBox.Location = new System.Drawing.Point(203, 87);
            this.pauseTimeTextBox.Name = "pauseTimeTextBox";
            this.pauseTimeTextBox.Size = new System.Drawing.Size(1063, 20);
            this.pauseTimeTextBox.TabIndex = 11;
            // 
            // DsConverterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 700);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DsConverterForm";
            this.Text = "DS Konverter";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.topTableLayoutPanel.ResumeLayout(false);
            this.topTableLayoutPanel.PerformLayout();
            this.buttonTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox targetTextBox;
        private System.Windows.Forms.TableLayoutPanel topTableLayoutPanel;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label troopCountLabel;
        private System.Windows.Forms.TextBox lkavCountTextBox;
        private System.Windows.Forms.Button convertButton;
        private TableLayoutPanel buttonTableLayoutPanel;
        private Button sortButton;
        private Button saveButton;
        private Label spyLabel;
        private TextBox spyCountTextBox;
        private RichTextBox scriptTextBox;
        private Label homeCoordinateLabel;
        private TextBox homeCoordinateTextBox;
        private Label pauseTimeLabel;
        private TextBox pauseTimeTextBox;
    }
}

