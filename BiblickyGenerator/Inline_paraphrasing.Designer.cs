namespace BiblickyGenerator
{
    partial class Inline_paraphrasing
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
            this.textBox_input = new System.Windows.Forms.TextBox();
            this.checkBox_useMorphoDiTa = new System.Windows.Forms.CheckBox();
            this.button_paraphrase = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.textBox_output1 = new System.Windows.Forms.TextBox();
            this.textBox_output2 = new System.Windows.Forms.TextBox();
            this.textBox_output4 = new System.Windows.Forms.TextBox();
            this.textBox_output5 = new System.Windows.Forms.TextBox();
            this.textBox_output3 = new System.Windows.Forms.TextBox();
            this.listBox_models = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_output1 = new System.Windows.Forms.Label();
            this.label_output2 = new System.Windows.Forms.Label();
            this.label_output3 = new System.Windows.Forms.Label();
            this.label_output4 = new System.Windows.Forms.Label();
            this.label_output5 = new System.Windows.Forms.Label();
            this.button_saveResults = new System.Windows.Forms.Button();
            this.button_reset = new System.Windows.Forms.Button();
            this.button_help = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_waiting = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_input
            // 
            this.textBox_input.Location = new System.Drawing.Point(53, 59);
            this.textBox_input.Multiline = true;
            this.textBox_input.Name = "textBox_input";
            this.textBox_input.Size = new System.Drawing.Size(292, 194);
            this.textBox_input.TabIndex = 0;
            // 
            // checkBox_useMorphoDiTa
            // 
            this.checkBox_useMorphoDiTa.AutoSize = true;
            this.checkBox_useMorphoDiTa.Location = new System.Drawing.Point(1038, 261);
            this.checkBox_useMorphoDiTa.Name = "checkBox_useMorphoDiTa";
            this.checkBox_useMorphoDiTa.Size = new System.Drawing.Size(170, 24);
            this.checkBox_useMorphoDiTa.TabIndex = 2;
            this.checkBox_useMorphoDiTa.Text = "Použít MorphoDiTu";
            this.checkBox_useMorphoDiTa.UseVisualStyleBackColor = true;
            // 
            // button_paraphrase
            // 
            this.button_paraphrase.Location = new System.Drawing.Point(1094, 359);
            this.button_paraphrase.Name = "button_paraphrase";
            this.button_paraphrase.Size = new System.Drawing.Size(129, 51);
            this.button_paraphrase.TabIndex = 3;
            this.button_paraphrase.Text = "Parafrázovat";
            this.button_paraphrase.UseVisualStyleBackColor = true;
            this.button_paraphrase.Click += new System.EventHandler(this.Button_paraphrase_Click);
            // 
            // button_back
            // 
            this.button_back.Location = new System.Drawing.Point(1094, 521);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(129, 42);
            this.button_back.TabIndex = 4;
            this.button_back.Text = "Zpět";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.Button_back_Click);
            // 
            // textBox_output1
            // 
            this.textBox_output1.Location = new System.Drawing.Point(386, 59);
            this.textBox_output1.Multiline = true;
            this.textBox_output1.Name = "textBox_output1";
            this.textBox_output1.ReadOnly = true;
            this.textBox_output1.Size = new System.Drawing.Size(292, 194);
            this.textBox_output1.TabIndex = 5;
            // 
            // textBox_output2
            // 
            this.textBox_output2.Location = new System.Drawing.Point(718, 59);
            this.textBox_output2.Multiline = true;
            this.textBox_output2.Name = "textBox_output2";
            this.textBox_output2.ReadOnly = true;
            this.textBox_output2.Size = new System.Drawing.Size(292, 194);
            this.textBox_output2.TabIndex = 6;
            // 
            // textBox_output4
            // 
            this.textBox_output4.Location = new System.Drawing.Point(386, 319);
            this.textBox_output4.Multiline = true;
            this.textBox_output4.Name = "textBox_output4";
            this.textBox_output4.ReadOnly = true;
            this.textBox_output4.Size = new System.Drawing.Size(292, 196);
            this.textBox_output4.TabIndex = 7;
            // 
            // textBox_output5
            // 
            this.textBox_output5.Location = new System.Drawing.Point(718, 319);
            this.textBox_output5.Multiline = true;
            this.textBox_output5.Name = "textBox_output5";
            this.textBox_output5.ReadOnly = true;
            this.textBox_output5.Size = new System.Drawing.Size(292, 196);
            this.textBox_output5.TabIndex = 8;
            // 
            // textBox_output3
            // 
            this.textBox_output3.Location = new System.Drawing.Point(53, 319);
            this.textBox_output3.Multiline = true;
            this.textBox_output3.Name = "textBox_output3";
            this.textBox_output3.ReadOnly = true;
            this.textBox_output3.Size = new System.Drawing.Size(292, 196);
            this.textBox_output3.TabIndex = 9;
            // 
            // listBox_models
            // 
            this.listBox_models.FormattingEnabled = true;
            this.listBox_models.HorizontalScrollbar = true;
            this.listBox_models.ItemHeight = 20;
            this.listBox_models.Location = new System.Drawing.Point(1038, 59);
            this.listBox_models.Name = "listBox_models";
            this.listBox_models.Size = new System.Drawing.Size(230, 184);
            this.listBox_models.Sorted = true;
            this.listBox_models.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(137, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Vstupní text";
            // 
            // label_output1
            // 
            this.label_output1.AutoSize = true;
            this.label_output1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_output1.Location = new System.Drawing.Point(495, 22);
            this.label_output1.Name = "label_output1";
            this.label_output1.Size = new System.Drawing.Size(79, 25);
            this.label_output1.TabIndex = 12;
            this.label_output1.Text = "Výtup 1";
            // 
            // label_output2
            // 
            this.label_output2.AutoSize = true;
            this.label_output2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_output2.Location = new System.Drawing.Point(824, 22);
            this.label_output2.Name = "label_output2";
            this.label_output2.Size = new System.Drawing.Size(89, 25);
            this.label_output2.TabIndex = 13;
            this.label_output2.Text = "Výstup 2";
            // 
            // label_output3
            // 
            this.label_output3.AutoSize = true;
            this.label_output3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_output3.Location = new System.Drawing.Point(151, 272);
            this.label_output3.Name = "label_output3";
            this.label_output3.Size = new System.Drawing.Size(79, 25);
            this.label_output3.TabIndex = 14;
            this.label_output3.Text = "Výtup 3";
            // 
            // label_output4
            // 
            this.label_output4.AutoSize = true;
            this.label_output4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_output4.Location = new System.Drawing.Point(495, 272);
            this.label_output4.Name = "label_output4";
            this.label_output4.Size = new System.Drawing.Size(79, 25);
            this.label_output4.TabIndex = 15;
            this.label_output4.Text = "Výtup 4";
            // 
            // label_output5
            // 
            this.label_output5.AutoSize = true;
            this.label_output5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_output5.Location = new System.Drawing.Point(824, 272);
            this.label_output5.Name = "label_output5";
            this.label_output5.Size = new System.Drawing.Size(79, 25);
            this.label_output5.TabIndex = 16;
            this.label_output5.Text = "Výtup 5";
            // 
            // button_saveResults
            // 
            this.button_saveResults.Location = new System.Drawing.Point(1094, 416);
            this.button_saveResults.Name = "button_saveResults";
            this.button_saveResults.Size = new System.Drawing.Size(129, 51);
            this.button_saveResults.TabIndex = 17;
            this.button_saveResults.Text = "Uložit výsledky";
            this.button_saveResults.UseVisualStyleBackColor = true;
            this.button_saveResults.Click += new System.EventHandler(this.Button_saveResults_Click);
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(1094, 308);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(129, 45);
            this.button_reset.TabIndex = 18;
            this.button_reset.Text = "Resetovat";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.Button_reset_Click);
            // 
            // button_help
            // 
            this.button_help.Location = new System.Drawing.Point(1094, 473);
            this.button_help.Name = "button_help";
            this.button_help.Size = new System.Drawing.Size(129, 42);
            this.button_help.TabIndex = 19;
            this.button_help.Text = "Nápověda";
            this.button_help.UseVisualStyleBackColor = true;
            this.button_help.Click += new System.EventHandler(this.button_help_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(1113, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 25);
            this.label2.TabIndex = 22;
            this.label2.Text = "Modely";
            // 
            // textBox_waiting
            // 
            this.textBox_waiting.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_waiting.Location = new System.Drawing.Point(718, 532);
            this.textBox_waiting.Multiline = true;
            this.textBox_waiting.Name = "textBox_waiting";
            this.textBox_waiting.ReadOnly = true;
            this.textBox_waiting.Size = new System.Drawing.Size(292, 83);
            this.textBox_waiting.TabIndex = 23;
            this.textBox_waiting.Text = "Pro velké modely může parafrázování trvat delší dobu";
            this.textBox_waiting.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Inline_paraphrasing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1290, 644);
            this.Controls.Add(this.textBox_waiting);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_help);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.button_saveResults);
            this.Controls.Add(this.label_output5);
            this.Controls.Add(this.label_output4);
            this.Controls.Add(this.label_output3);
            this.Controls.Add(this.label_output2);
            this.Controls.Add(this.label_output1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_models);
            this.Controls.Add(this.textBox_output3);
            this.Controls.Add(this.textBox_output5);
            this.Controls.Add(this.textBox_output4);
            this.Controls.Add(this.textBox_output2);
            this.Controls.Add(this.textBox_output1);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_paraphrase);
            this.Controls.Add(this.checkBox_useMorphoDiTa);
            this.Controls.Add(this.textBox_input);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Name = "Inline_paraphrasing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parafrázování";
            this.Load += new System.EventHandler(this.Inline_paraphrasing_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_input;
        private System.Windows.Forms.CheckBox checkBox_useMorphoDiTa;
        private System.Windows.Forms.Button button_paraphrase;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.TextBox textBox_output1;
        private System.Windows.Forms.TextBox textBox_output2;
        private System.Windows.Forms.TextBox textBox_output4;
        private System.Windows.Forms.TextBox textBox_output5;
        private System.Windows.Forms.TextBox textBox_output3;
        private System.Windows.Forms.ListBox listBox_models;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_output1;
        private System.Windows.Forms.Label label_output2;
        private System.Windows.Forms.Label label_output3;
        private System.Windows.Forms.Label label_output4;
        private System.Windows.Forms.Label label_output5;
        private System.Windows.Forms.Button button_saveResults;
        private System.Windows.Forms.Button button_reset;
        private System.Windows.Forms.Button button_help;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_waiting;
    }
}