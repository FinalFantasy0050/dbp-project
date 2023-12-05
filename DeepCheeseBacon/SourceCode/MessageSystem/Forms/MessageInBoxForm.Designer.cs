namespace deepcheesebacon.SourceCode.MessageSystem.Forms
{
    partial class MessageInBoxForm
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
            listBoxMessage = new ListBox();
            buttonSearchByContent = new Customizing.CustomButtonStyle();
            textBoxEmail = new Customizing.CustomTextBox();
            textBoxContent = new Customizing.CustomTextBox();
            textBoxTitle = new Customizing.CustomTextBox();
            SuspendLayout();
            // 
            // listBoxMessage
            // 
            listBoxMessage.FormattingEnabled = true;
            listBoxMessage.ItemHeight = 15;
            listBoxMessage.Location = new Point(12, 87);
            listBoxMessage.Name = "listBoxMessage";
            listBoxMessage.Size = new Size(482, 304);
            listBoxMessage.TabIndex = 0;
            // 
            // buttonSearchByContent
            // 
            buttonSearchByContent.BackColor = Color.FromArgb(50, 122, 217);
            buttonSearchByContent.BackgroundColor = Color.FromArgb(50, 122, 217);
            buttonSearchByContent.BorderColor = Color.FromArgb(4, 96, 217);
            buttonSearchByContent.BorderRadius = 20;
            buttonSearchByContent.BorderSize = 0;
            buttonSearchByContent.FlatStyle = FlatStyle.Flat;
            buttonSearchByContent.ForeColor = Color.White;
            buttonSearchByContent.Location = new Point(425, 16);
            buttonSearchByContent.Name = "buttonSearchByContent";
            buttonSearchByContent.Size = new Size(68, 65);
            buttonSearchByContent.TabIndex = 8;
            buttonSearchByContent.Text = "검색";
            buttonSearchByContent.TextColor = Color.White;
            buttonSearchByContent.UseVisualStyleBackColor = false;
            buttonSearchByContent.Click += buttonSearchByContent_Click;
            // 
            // textBoxEmail
            // 
            textBoxEmail.BackColor = SystemColors.Window;
            textBoxEmail.BorderColor = Color.FromArgb(50, 122, 217);
            textBoxEmail.BorderFocusColor = Color.FromArgb(4, 96, 217);
            textBoxEmail.BorderRadius = 0;
            textBoxEmail.BorderSize = 2;
            textBoxEmail.Font = new Font("맑은 고딕", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxEmail.ForeColor = Color.DimGray;
            textBoxEmail.Location = new Point(31, 53);
            textBoxEmail.Margin = new Padding(2);
            textBoxEmail.Multiline = false;
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Padding = new Padding(8, 5, 8, 5);
            textBoxEmail.PasswordChar = false;
            textBoxEmail.PlaceholderColor = Color.DarkGray;
            textBoxEmail.PlaceholderText = "보낸사람의 이메일을 입력하세요.";
            textBoxEmail.Size = new Size(388, 28);
            textBoxEmail.TabIndex = 9;
            textBoxEmail.Texts = "";
            textBoxEmail.UnderlinedStyle = true;
            // 
            // textBoxContent
            // 
            textBoxContent.BackColor = SystemColors.Window;
            textBoxContent.BorderColor = Color.FromArgb(50, 122, 217);
            textBoxContent.BorderFocusColor = Color.FromArgb(4, 96, 217);
            textBoxContent.BorderRadius = 0;
            textBoxContent.BorderSize = 2;
            textBoxContent.Font = new Font("맑은 고딕", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxContent.ForeColor = Color.DimGray;
            textBoxContent.Location = new Point(227, 16);
            textBoxContent.Margin = new Padding(2);
            textBoxContent.Multiline = false;
            textBoxContent.Name = "textBoxContent";
            textBoxContent.Padding = new Padding(8, 5, 8, 5);
            textBoxContent.PasswordChar = false;
            textBoxContent.PlaceholderColor = Color.DarkGray;
            textBoxContent.PlaceholderText = "내용을 입력하세요.";
            textBoxContent.Size = new Size(192, 28);
            textBoxContent.TabIndex = 10;
            textBoxContent.Texts = "";
            textBoxContent.UnderlinedStyle = true;
            // 
            // textBoxTitle
            // 
            textBoxTitle.BackColor = SystemColors.Window;
            textBoxTitle.BorderColor = Color.FromArgb(50, 122, 217);
            textBoxTitle.BorderFocusColor = Color.FromArgb(4, 96, 217);
            textBoxTitle.BorderRadius = 0;
            textBoxTitle.BorderSize = 2;
            textBoxTitle.Font = new Font("맑은 고딕", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxTitle.ForeColor = Color.DimGray;
            textBoxTitle.Location = new Point(31, 16);
            textBoxTitle.Margin = new Padding(2);
            textBoxTitle.Multiline = false;
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Padding = new Padding(8, 5, 8, 5);
            textBoxTitle.PasswordChar = false;
            textBoxTitle.PlaceholderColor = Color.DarkGray;
            textBoxTitle.PlaceholderText = "제목을 입력하세요.";
            textBoxTitle.Size = new Size(192, 28);
            textBoxTitle.TabIndex = 11;
            textBoxTitle.Texts = "";
            textBoxTitle.UnderlinedStyle = true;
            // 
            // MessageInBoxForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 400);
            Controls.Add(textBoxTitle);
            Controls.Add(textBoxContent);
            Controls.Add(textBoxEmail);
            Controls.Add(buttonSearchByContent);
            Controls.Add(listBoxMessage);
            Name = "MessageInBoxForm";
            Text = "MessageInBoxForm";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxMessage;
        private Customizing.CustomButtonStyle buttonSearchByContent;
        private Customizing.CustomTextBox textBoxEmail;
        private Customizing.CustomTextBox textBoxContent;
        private Customizing.CustomTextBox textBoxTitle;
    }
}