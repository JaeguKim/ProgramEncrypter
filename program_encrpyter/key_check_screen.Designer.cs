namespace program_encrpyter
{
    partial class key_check_screen
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
            this.label1 = new System.Windows.Forms.Label();
            this.key_text_label = new System.Windows.Forms.Label();
            this.menu_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 18F);
            this.label1.Location = new System.Drawing.Point(137, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key";
            // 
            // key_text_label
            // 
            this.key_text_label.AutoSize = true;
            this.key_text_label.Font = new System.Drawing.Font("굴림", 14F);
            this.key_text_label.Location = new System.Drawing.Point(30, 156);
            this.key_text_label.Name = "key_text_label";
            this.key_text_label.Size = new System.Drawing.Size(0, 19);
            this.key_text_label.TabIndex = 1;
            // 
            // menu_btn
            // 
            this.menu_btn.Font = new System.Drawing.Font("굴림", 15F);
            this.menu_btn.Location = new System.Drawing.Point(96, 233);
            this.menu_btn.Name = "menu_btn";
            this.menu_btn.Size = new System.Drawing.Size(132, 49);
            this.menu_btn.TabIndex = 2;
            this.menu_btn.Text = "메뉴로 이동";
            this.menu_btn.UseVisualStyleBackColor = true;
            this.menu_btn.Click += new System.EventHandler(this.moveToMenu_btn);
            // 
            // key_check_screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 316);
            this.Controls.Add(this.menu_btn);
            this.Controls.Add(this.key_text_label);
            this.Controls.Add(this.label1);
            this.Name = "key_check_screen";
            this.Text = "key_check_screen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label key_text_label;
        private System.Windows.Forms.Button menu_btn;
    }
}