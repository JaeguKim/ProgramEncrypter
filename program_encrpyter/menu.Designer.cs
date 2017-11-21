namespace program_encrpyter
{
    partial class menu
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.exit_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("굴림", 15F);
            this.button1.Location = new System.Drawing.Point(108, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 66);
            this.button1.TabIndex = 0;
            this.button1.Text = "파일 암호화";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.file_encrypt_btn);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("굴림", 15F);
            this.button2.Location = new System.Drawing.Point(108, 169);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 69);
            this.button2.TabIndex = 1;
            this.button2.Text = "키확인";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.key_check_btn);
            // 
            // exit_btn
            // 
            this.exit_btn.Font = new System.Drawing.Font("굴림", 15F);
            this.exit_btn.Location = new System.Drawing.Point(108, 278);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(137, 69);
            this.exit_btn.TabIndex = 2;
            this.exit_btn.Text = "종료";
            this.exit_btn.UseVisualStyleBackColor = true;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_click);
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 406);
            this.Controls.Add(this.exit_btn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "menu";
            this.Text = "menu_screen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.menu_closed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button exit_btn;
    }
}