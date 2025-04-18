namespace deepcheesebacon
{
    partial class AttendanceReg
    {
        {
            dateTimePicker1 = new DateTimePicker();
            GoWorkBtn = new Button();
            OffWorkBtn = new Button();
            dataGridView2 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(197, 173);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(231, 27);
            dateTimePicker1.TabIndex = 40;
            // 
            // GoWorkBtn
            // 
            GoWorkBtn.Location = new Point(197, 418);
            GoWorkBtn.Name = "GoWorkBtn";
            GoWorkBtn.Size = new Size(102, 43);
            GoWorkBtn.TabIndex = 41;
            GoWorkBtn.Text = "출근";
            GoWorkBtn.UseVisualStyleBackColor = true;
            GoWorkBtn.Click += GoWorkBtn_Click;
            // 
            // OffWorkBtn
            // 
            OffWorkBtn.Location = new Point(306, 418);
            OffWorkBtn.Name = "OffWorkBtn";
            OffWorkBtn.Size = new Size(102, 43);
            OffWorkBtn.TabIndex = 44;
            OffWorkBtn.Text = "퇴근";
            OffWorkBtn.UseVisualStyleBackColor = true;
            OffWorkBtn.Click += OffWorkBtn_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(197, 224);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(481, 176);
            dataGridView2.TabIndex = 45;
            // 
            // AttendanceReg
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView2);
            Controls.Add(OffWorkBtn);
            Controls.Add(GoWorkBtn);
            Controls.Add(dateTimePicker1);
            Name = "AttendanceReg";
            Size = new Size(879, 653);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DateTimePicker dateTimePicker1;
        private Button GoWorkBtn;
        private Button OffWorkBtn;
        private DataGridView dataGridView2;
    }
}
