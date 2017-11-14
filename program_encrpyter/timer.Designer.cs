namespace program_encrpyter
{
    partial class timer
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
            this.timer_label = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.other_user_textbox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer_label
            // 
            this.timer_label.AutoSize = true;
            this.timer_label.Font = new System.Drawing.Font("굴림", 45F);
            this.timer_label.Location = new System.Drawing.Point(51, 123);
            this.timer_label.Name = "timer_label";
            this.timer_label.Size = new System.Drawing.Size(0, 60);
            this.timer_label.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(169, 367);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 36);
            this.button3.TabIndex = 19;
            this.button3.Text = "Confirm";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // other_user_textbox
            // 
            this.other_user_textbox.Font = new System.Drawing.Font("굴림", 15F);
            this.other_user_textbox.Location = new System.Drawing.Point(231, 313);
            this.other_user_textbox.Name = "other_user_textbox";
            this.other_user_textbox.Size = new System.Drawing.Size(100, 30);
            this.other_user_textbox.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 15F);
            this.label8.Location = new System.Drawing.Point(113, 316);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Password : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 15F);
            this.label7.Location = new System.Drawing.Point(151, 272);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Enter password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15F);
            this.label1.Location = new System.Drawing.Point(151, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Remaining Time";
            // 
            // timer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 466);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.other_user_textbox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.timer_label);
            this.Name = "timer";
            this.Text = "timer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timer_label;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox other_user_textbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
    }
}