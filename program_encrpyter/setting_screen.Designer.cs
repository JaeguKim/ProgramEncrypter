namespace program_encrpyter
{
    partial class setting_screen
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.hour_list = new System.Windows.Forms.ComboBox();
            this.minute_list = new System.Windows.Forms.ComboBox();
            this.second_list = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.file_list = new System.Windows.Forms.ListBox();
            this.add_btn = new System.Windows.Forms.Button();
            this.delete_btn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.other_user_textbox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15F);
            this.label1.Location = new System.Drawing.Point(245, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Set tIme interval";
            // 
            // hour_list
            // 
            this.hour_list.FormattingEnabled = true;
            this.hour_list.Location = new System.Drawing.Point(291, 73);
            this.hour_list.Name = "hour_list";
            this.hour_list.Size = new System.Drawing.Size(121, 20);
            this.hour_list.TabIndex = 1;
            this.hour_list.Tag = "";
            this.hour_list.SelectionChangeCommitted += new System.EventHandler(this.hour_selected);
            // 
            // minute_list
            // 
            this.minute_list.FormattingEnabled = true;
            this.minute_list.Location = new System.Drawing.Point(291, 115);
            this.minute_list.Name = "minute_list";
            this.minute_list.Size = new System.Drawing.Size(121, 20);
            this.minute_list.TabIndex = 2;
            this.minute_list.SelectionChangeCommitted += new System.EventHandler(this.minute_selected);
            // 
            // second_list
            // 
            this.second_list.FormattingEnabled = true;
            this.second_list.Location = new System.Drawing.Point(291, 161);
            this.second_list.Name = "second_list";
            this.second_list.Size = new System.Drawing.Size(121, 20);
            this.second_list.TabIndex = 3;
            this.second_list.SelectionChangeCommitted += new System.EventHandler(this.second_selected);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 15F);
            this.label2.Location = new System.Drawing.Point(189, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hour :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 15F);
            this.label3.Location = new System.Drawing.Point(172, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Minute :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 15F);
            this.label4.Location = new System.Drawing.Point(161, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Second :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 15F);
            this.label5.Location = new System.Drawing.Point(227, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Add files to encrypt";
            // 
            // file_list
            // 
            this.file_list.FormattingEnabled = true;
            this.file_list.ItemHeight = 12;
            this.file_list.Location = new System.Drawing.Point(130, 272);
            this.file_list.Name = "file_list";
            this.file_list.Size = new System.Drawing.Size(247, 184);
            this.file_list.TabIndex = 8;
            // 
            // add_btn
            // 
            this.add_btn.Location = new System.Drawing.Point(392, 302);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(92, 36);
            this.add_btn.TabIndex = 9;
            this.add_btn.Text = "Add";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_click);
            // 
            // delete_btn
            // 
            this.delete_btn.Location = new System.Drawing.Point(392, 388);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(92, 36);
            this.delete_btn.TabIndex = 10;
            this.delete_btn.Text = "Delete";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_file);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 15F);
            this.label7.Location = new System.Drawing.Point(213, 491);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(190, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Enter Other user\'s ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 15F);
            this.label8.Location = new System.Drawing.Point(227, 535);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "ID : ";
            // 
            // other_user_textbox
            // 
            this.other_user_textbox.Font = new System.Drawing.Font("굴림", 15F);
            this.other_user_textbox.Location = new System.Drawing.Point(291, 532);
            this.other_user_textbox.Name = "other_user_textbox";
            this.other_user_textbox.Size = new System.Drawing.Size(100, 30);
            this.other_user_textbox.TabIndex = 14;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(256, 588);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 36);
            this.button3.TabIndex = 15;
            this.button3.Text = "Confirm";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.confirm_btn_click);
            // 
            // setting_screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 652);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.other_user_textbox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.add_btn);
            this.Controls.Add(this.file_list);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.second_list);
            this.Controls.Add(this.minute_list);
            this.Controls.Add(this.hour_list);
            this.Controls.Add(this.label1);
            this.Name = "setting_screen";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.setting_screen_load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox hour_list;
        private System.Windows.Forms.ComboBox minute_list;
        private System.Windows.Forms.ComboBox second_list;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox file_list;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.Button delete_btn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox other_user_textbox;
        private System.Windows.Forms.Button button3;
    }
}

