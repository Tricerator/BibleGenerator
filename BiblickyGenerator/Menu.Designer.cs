namespace BiblickyGenerator
{
    partial class Menu
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
            this.trainNewModelButton = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_help = new System.Windows.Forms.Button();
            this.button_INLINE_W2V = new System.Windows.Forms.Button();
            this.button_W2V_Transform_File = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // trainNewModelButton
            // 
            this.trainNewModelButton.Location = new System.Drawing.Point(357, 114);
            this.trainNewModelButton.Name = "trainNewModelButton";
            this.trainNewModelButton.Size = new System.Drawing.Size(219, 51);
            this.trainNewModelButton.TabIndex = 0;
            this.trainNewModelButton.Text = "Natrénovat nový model";
            this.trainNewModelButton.UseVisualStyleBackColor = true;
            this.trainNewModelButton.Click += new System.EventHandler(this.trainNewModelButton_Click);
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(357, 406);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(219, 48);
            this.button_exit.TabIndex = 1;
            this.button_exit.Text = "Ukončit program";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // button_help
            // 
            this.button_help.Location = new System.Drawing.Point(357, 329);
            this.button_help.Name = "button_help";
            this.button_help.Size = new System.Drawing.Size(219, 43);
            this.button_help.TabIndex = 2;
            this.button_help.Text = "Nápověda";
            this.button_help.UseVisualStyleBackColor = true;
            // 
            // button_INLINE_W2V
            // 
            this.button_INLINE_W2V.Location = new System.Drawing.Point(357, 252);
            this.button_INLINE_W2V.Name = "button_INLINE_W2V";
            this.button_INLINE_W2V.Size = new System.Drawing.Size(219, 43);
            this.button_INLINE_W2V.TabIndex = 3;
            this.button_INLINE_W2V.Text = "In-line parafrázování";
            this.button_INLINE_W2V.UseVisualStyleBackColor = true;
            this.button_INLINE_W2V.Click += new System.EventHandler(this.button_INLINE_W2V_Click);
            // 
            // button_W2V_Transform_File
            // 
            this.button_W2V_Transform_File.Location = new System.Drawing.Point(357, 187);
            this.button_W2V_Transform_File.Name = "button_W2V_Transform_File";
            this.button_W2V_Transform_File.Size = new System.Drawing.Size(218, 40);
            this.button_W2V_Transform_File.TabIndex = 4;
            this.button_W2V_Transform_File.Text = "Parafrázovat soubor";
            this.button_W2V_Transform_File.UseVisualStyleBackColor = true;
            this.button_W2V_Transform_File.Click += new System.EventHandler(this.button_W2V_Transform_File_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 546);
            this.Controls.Add(this.button_W2V_Transform_File);
            this.Controls.Add(this.button_INLINE_W2V);
            this.Controls.Add(this.button_help);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.trainNewModelButton);
            this.Name = "Menu";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button trainNewModelButton;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_help;
        private System.Windows.Forms.Button button_INLINE_W2V;
        private System.Windows.Forms.Button button_W2V_Transform_File;
    }
}

