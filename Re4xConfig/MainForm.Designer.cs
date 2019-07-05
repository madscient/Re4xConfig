namespace Re4xConfig
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Apply = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Interfaces = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Slots = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_module0 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_clock0 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_location0 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_module1 = new System.Windows.Forms.ComboBox();
            this.comboBox_clock1 = new System.Windows.Forms.ComboBox();
            this.comboBox_location1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox_module2 = new System.Windows.Forms.ComboBox();
            this.comboBox_clock2 = new System.Windows.Forms.ComboBox();
            this.comboBox_location2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox_module3 = new System.Windows.Forms.ComboBox();
            this.comboBox_clock3 = new System.Windows.Forms.ComboBox();
            this.comboBox_location3 = new System.Windows.Forms.ComboBox();
            this.button_Reload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Apply
            // 
            this.button_Apply.Location = new System.Drawing.Point(232, 183);
            this.button_Apply.Name = "button_Apply";
            this.button_Apply.Size = new System.Drawing.Size(75, 23);
            this.button_Apply.TabIndex = 0;
            this.button_Apply.Text = "Apply";
            this.button_Apply.UseVisualStyleBackColor = true;
            this.button_Apply.Click += new System.EventHandler(this.button_Apply_Click);
            // 
            // button_Close
            // 
            this.button_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Close.Location = new System.Drawing.Point(313, 183);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 0;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Interface";
            // 
            // comboBox_Interfaces
            // 
            this.comboBox_Interfaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Interfaces.Location = new System.Drawing.Point(62, 12);
            this.comboBox_Interfaces.Name = "comboBox_Interfaces";
            this.comboBox_Interfaces.Size = new System.Drawing.Size(242, 20);
            this.comboBox_Interfaces.TabIndex = 2;
            this.comboBox_Interfaces.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Interfaces_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Slots";
            // 
            // comboBox_Slots
            // 
            this.comboBox_Slots.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Slots.FormattingEnabled = true;
            this.comboBox_Slots.Items.AddRange(new object[] {
            "0",
            "1",
            "4"});
            this.comboBox_Slots.Location = new System.Drawing.Point(347, 12);
            this.comboBox_Slots.Name = "comboBox_Slots";
            this.comboBox_Slots.Size = new System.Drawing.Size(41, 20);
            this.comboBox_Slots.TabIndex = 4;
            this.comboBox_Slots.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Slots_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Slot 0";
            // 
            // comboBox_module0
            // 
            this.comboBox_module0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_module0.FormattingEnabled = true;
            this.comboBox_module0.Location = new System.Drawing.Point(62, 66);
            this.comboBox_module0.Name = "comboBox_module0";
            this.comboBox_module0.Size = new System.Drawing.Size(155, 20);
            this.comboBox_module0.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Module";
            // 
            // comboBox_clock0
            // 
            this.comboBox_clock0.FormattingEnabled = true;
            this.comboBox_clock0.Items.AddRange(new object[] {
            "3579545",
            "3993600",
            "4000000",
            "7159090",
            "7670454",
            "7987200",
            "8000000",
            "14318180",
            "15974400",
            "16000000",
            "16934400",
            "33868800"});
            this.comboBox_clock0.Location = new System.Drawing.Point(223, 66);
            this.comboBox_clock0.Name = "comboBox_clock0";
            this.comboBox_clock0.Size = new System.Drawing.Size(105, 20);
            this.comboBox_clock0.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(221, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "Clock(Hz)";
            // 
            // comboBox_location0
            // 
            this.comboBox_location0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_location0.FormattingEnabled = true;
            this.comboBox_location0.Items.AddRange(new object[] {
            "NONE",
            "LEFT",
            "RIGHT",
            "BOTH",
            "DUAL"});
            this.comboBox_location0.Location = new System.Drawing.Point(334, 66);
            this.comboBox_location0.Name = "comboBox_location0";
            this.comboBox_location0.Size = new System.Drawing.Size(54, 20);
            this.comboBox_location0.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(331, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "Location";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "Slot 1";
            // 
            // comboBox_module1
            // 
            this.comboBox_module1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_module1.FormattingEnabled = true;
            this.comboBox_module1.Location = new System.Drawing.Point(62, 92);
            this.comboBox_module1.Name = "comboBox_module1";
            this.comboBox_module1.Size = new System.Drawing.Size(155, 20);
            this.comboBox_module1.TabIndex = 6;
            // 
            // comboBox_clock1
            // 
            this.comboBox_clock1.FormattingEnabled = true;
            this.comboBox_clock1.Items.AddRange(new object[] {
            "3579545",
            "3993600",
            "4000000",
            "7159090",
            "7670454",
            "7987200",
            "8000000",
            "14318180",
            "15974400",
            "16000000",
            "16934400",
            "33868800"});
            this.comboBox_clock1.Location = new System.Drawing.Point(223, 92);
            this.comboBox_clock1.Name = "comboBox_clock1";
            this.comboBox_clock1.Size = new System.Drawing.Size(105, 20);
            this.comboBox_clock1.TabIndex = 6;
            // 
            // comboBox_location1
            // 
            this.comboBox_location1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_location1.FormattingEnabled = true;
            this.comboBox_location1.Items.AddRange(new object[] {
            "NONE",
            "LEFT",
            "RIGHT",
            "BOTH",
            "DUAL"});
            this.comboBox_location1.Location = new System.Drawing.Point(334, 92);
            this.comboBox_location1.Name = "comboBox_location1";
            this.comboBox_location1.Size = new System.Drawing.Size(54, 20);
            this.comboBox_location1.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "Slot 2";
            // 
            // comboBox_module2
            // 
            this.comboBox_module2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_module2.FormattingEnabled = true;
            this.comboBox_module2.Location = new System.Drawing.Point(62, 118);
            this.comboBox_module2.Name = "comboBox_module2";
            this.comboBox_module2.Size = new System.Drawing.Size(155, 20);
            this.comboBox_module2.TabIndex = 6;
            // 
            // comboBox_clock2
            // 
            this.comboBox_clock2.FormattingEnabled = true;
            this.comboBox_clock2.Items.AddRange(new object[] {
            "3579545",
            "3993600",
            "4000000",
            "7159090",
            "7670454",
            "7987200",
            "8000000",
            "14318180",
            "15974400",
            "16000000",
            "16934400",
            "33868800"});
            this.comboBox_clock2.Location = new System.Drawing.Point(223, 118);
            this.comboBox_clock2.Name = "comboBox_clock2";
            this.comboBox_clock2.Size = new System.Drawing.Size(105, 20);
            this.comboBox_clock2.TabIndex = 6;
            // 
            // comboBox_location2
            // 
            this.comboBox_location2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_location2.FormattingEnabled = true;
            this.comboBox_location2.Items.AddRange(new object[] {
            "NONE",
            "LEFT",
            "RIGHT",
            "BOTH",
            "DUAL"});
            this.comboBox_location2.Location = new System.Drawing.Point(334, 118);
            this.comboBox_location2.Name = "comboBox_location2";
            this.comboBox_location2.Size = new System.Drawing.Size(54, 20);
            this.comboBox_location2.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 147);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "Slot 3";
            // 
            // comboBox_module3
            // 
            this.comboBox_module3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_module3.FormattingEnabled = true;
            this.comboBox_module3.Location = new System.Drawing.Point(62, 144);
            this.comboBox_module3.Name = "comboBox_module3";
            this.comboBox_module3.Size = new System.Drawing.Size(155, 20);
            this.comboBox_module3.TabIndex = 6;
            // 
            // comboBox_clock3
            // 
            this.comboBox_clock3.FormattingEnabled = true;
            this.comboBox_clock3.Items.AddRange(new object[] {
            "3579545",
            "3993600",
            "4000000",
            "7159090",
            "7670454",
            "7987200",
            "8000000",
            "14318180",
            "15974400",
            "16000000",
            "16934400",
            "33868800"});
            this.comboBox_clock3.Location = new System.Drawing.Point(223, 144);
            this.comboBox_clock3.Name = "comboBox_clock3";
            this.comboBox_clock3.Size = new System.Drawing.Size(105, 20);
            this.comboBox_clock3.TabIndex = 6;
            // 
            // comboBox_location3
            // 
            this.comboBox_location3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_location3.FormattingEnabled = true;
            this.comboBox_location3.Items.AddRange(new object[] {
            "NONE",
            "LEFT",
            "RIGHT",
            "BOTH",
            "DUAL"});
            this.comboBox_location3.Location = new System.Drawing.Point(334, 144);
            this.comboBox_location3.Name = "comboBox_location3";
            this.comboBox_location3.Size = new System.Drawing.Size(54, 20);
            this.comboBox_location3.TabIndex = 6;
            // 
            // button_Reload
            // 
            this.button_Reload.Location = new System.Drawing.Point(151, 183);
            this.button_Reload.Name = "button_Reload";
            this.button_Reload.Size = new System.Drawing.Size(75, 23);
            this.button_Reload.TabIndex = 0;
            this.button_Reload.Text = "Reload";
            this.button_Reload.UseVisualStyleBackColor = true;
            this.button_Reload.Click += new System.EventHandler(this.button_Reload_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 219);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_location3);
            this.Controls.Add(this.comboBox_clock3);
            this.Controls.Add(this.comboBox_location2);
            this.Controls.Add(this.comboBox_clock2);
            this.Controls.Add(this.comboBox_location1);
            this.Controls.Add(this.comboBox_module3);
            this.Controls.Add(this.comboBox_clock1);
            this.Controls.Add(this.comboBox_module2);
            this.Controls.Add(this.comboBox_location0);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox_module1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox_clock0);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox_module0);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_Slots);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_Interfaces);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_Reload);
            this.Controls.Add(this.button_Apply);
            this.Name = "MainForm";
            this.Text = "Re:inforce 4x Configurer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Apply;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Interfaces;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Slots;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_module0;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_clock0;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_location0;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_module1;
        private System.Windows.Forms.ComboBox comboBox_clock1;
        private System.Windows.Forms.ComboBox comboBox_location1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox_module2;
        private System.Windows.Forms.ComboBox comboBox_clock2;
        private System.Windows.Forms.ComboBox comboBox_location2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox_module3;
        private System.Windows.Forms.ComboBox comboBox_clock3;
        private System.Windows.Forms.ComboBox comboBox_location3;
        private System.Windows.Forms.Button button_Reload;
    }
}

