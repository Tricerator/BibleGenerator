namespace BiblickyGenerator
{
    partial class TrainNewModel
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
            this.button3 = new System.Windows.Forms.Button();
            this.button_change_TXT = new System.Windows.Forms.Button();
            this.button_Word2Vec_Model_train = new System.Windows.Forms.Button();
            this.textbox_warning = new System.Windows.Forms.TextBox();
            this.textBox_result = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(370, 275);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(194, 46);
            this.button3.TabIndex = 2;
            this.button3.Text = "Zpět do menu";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // button_change_TXT
            // 
            this.button_change_TXT.Location = new System.Drawing.Point(370, 102);
            this.button_change_TXT.Name = "button_change_TXT";
            this.button_change_TXT.Size = new System.Drawing.Size(194, 45);
            this.button_change_TXT.TabIndex = 3;
            this.button_change_TXT.Text = "Uprav soubor .txt";
            this.button_change_TXT.UseVisualStyleBackColor = true;
            this.button_change_TXT.Click += new System.EventHandler(this.button_change_TXT_Click);
            // 
            // button_Word2Vec_Model_train
            // 
            this.button_Word2Vec_Model_train.Location = new System.Drawing.Point(370, 183);
            this.button_Word2Vec_Model_train.Name = "button_Word2Vec_Model_train";
            this.button_Word2Vec_Model_train.Size = new System.Drawing.Size(194, 45);
            this.button_Word2Vec_Model_train.TabIndex = 4;
            this.button_Word2Vec_Model_train.Text = "Natrénuj z .txt model";
            this.button_Word2Vec_Model_train.UseVisualStyleBackColor = true;
            this.button_Word2Vec_Model_train.Click += new System.EventHandler(this.button_Word2Vec_Model_train_Click);
            // 
            // textbox_warning
            // 
            this.textbox_warning.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_warning.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textbox_warning.Location = new System.Drawing.Point(43, 256);
            this.textbox_warning.Multiline = true;
            this.textbox_warning.Name = "textbox_warning";
            this.textbox_warning.ReadOnly = true;
            this.textbox_warning.Size = new System.Drawing.Size(300, 101);
            this.textbox_warning.TabIndex = 6;
            this.textbox_warning.Text = "Soubor musí mít příponu .txt!";
            this.textbox_warning.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_warning.Visible = false;
            this.textbox_warning.TextChanged += new System.EventHandler(this.textbox_warning_TextChanged);
            // 
            // textBox_result
            // 
            this.textBox_result.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_result.Location = new System.Drawing.Point(76, 256);
            this.textBox_result.Multiline = true;
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.ReadOnly = true;
            this.textBox_result.Size = new System.Drawing.Size(229, 176);
            this.textBox_result.TabIndex = 7;
            this.textBox_result.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_result.Visible = false;
            // 
            // TrainNewModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 450);
            this.Controls.Add(this.textBox_result);
            this.Controls.Add(this.textbox_warning);
            this.Controls.Add(this.button_Word2Vec_Model_train);
            this.Controls.Add(this.button_change_TXT);
            this.Controls.Add(this.button3);
            this.Name = "TrainNewModel";
            this.Text = "TrainNewModel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button_change_TXT;
        private System.Windows.Forms.Button button_Word2Vec_Model_train;
        private System.Windows.Forms.TextBox textbox_warning;
        private System.Windows.Forms.TextBox textBox_result;
    }
}