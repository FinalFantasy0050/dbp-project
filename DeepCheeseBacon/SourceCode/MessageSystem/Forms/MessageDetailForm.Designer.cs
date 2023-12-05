using deepcheesebacon.Customizing;

namespace deepcheesebacon
{
    partial class MessageDetailForm
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
            customGroupBox1 = new CustomGroupBox();
            label1 = new Label();
            textBoxTitle = new TextBox();
            textBoxInputMessage = new TextBox();
            buttonRefresh = new ImageButton();
            buttonSendMessage = new CustomButtonStyle();
            listBoxChatBox = new ListBox();
            customGroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // customGroupBox1
            // 
            customGroupBox1.BackColor = Color.Transparent;
            customGroupBox1.Controls.Add(label1);
            customGroupBox1.Controls.Add(textBoxTitle);
            customGroupBox1.Controls.Add(textBoxInputMessage);
            customGroupBox1.Controls.Add(buttonRefresh);
            customGroupBox1.Controls.Add(buttonSendMessage);
            customGroupBox1.Controls.Add(listBoxChatBox);
            customGroupBox1.Location = new Point(26, 20);
            customGroupBox1.Name = "customGroupBox1";
            customGroupBox1.Radious = 25;
            customGroupBox1.Size = new Size(741, 410);
            customGroupBox1.TabIndex = 28;
            customGroupBox1.TabStop = false;
            customGroupBox1.Text = "Message";
            customGroupBox1.TitleBackColor = Color.FromArgb(94, 159, 242);
            customGroupBox1.TitleFont = new Font("맑은 고딕", 17F, FontStyle.Bold, GraphicsUnit.Point);
            customGroupBox1.TitleForeColor = Color.White;
            customGroupBox1.TitleHatchStyle = System.Drawing.Drawing2D.HatchStyle.Percent60;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 336);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 32;
            label1.Text = "제목";
            // 
            // textBoxTitle
            // 
            textBoxTitle.Location = new Point(46, 333);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(290, 23);
            textBoxTitle.TabIndex = 31;
            // 
            // textBoxInputMessage
            // 
            textBoxInputMessage.BorderStyle = BorderStyle.None;
            textBoxInputMessage.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxInputMessage.Location = new Point(9, 375);
            textBoxInputMessage.Margin = new Padding(2);
            textBoxInputMessage.Multiline = true;
            textBoxInputMessage.Name = "textBoxInputMessage";
            textBoxInputMessage.PlaceholderText = "채팅을 입력해주세요!";
            textBoxInputMessage.Size = new Size(646, 27);
            textBoxInputMessage.TabIndex = 30;
            textBoxInputMessage.TextChanged += textBoxInputMessage_TextChanged;
            // 
            // buttonRefresh
            // 
            buttonRefresh.BackgroundImage = Properties.Resources.refresh;
            buttonRefresh.BackgroundImageLayout = ImageLayout.Zoom;
            buttonRefresh.Image_01 = Properties.Resources.refresh;
            buttonRefresh.Image_02 = Properties.Resources.refreshoption;
            buttonRefresh.Location = new Point(712, 4);
            buttonRefresh.Margin = new Padding(2);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(23, 24);
            buttonRefresh.TabIndex = 29;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // buttonSendMessage
            // 
            buttonSendMessage.BackColor = SystemColors.Window;
            buttonSendMessage.BackgroundColor = SystemColors.Window;
            buttonSendMessage.BorderColor = Color.FromArgb(4, 96, 217);
            buttonSendMessage.BorderRadius = 10;
            buttonSendMessage.BorderSize = 2;
            buttonSendMessage.FlatStyle = FlatStyle.Flat;
            buttonSendMessage.ForeColor = Color.DarkBlue;
            buttonSendMessage.Location = new Point(656, 375);
            buttonSendMessage.Name = "buttonSendMessage";
            buttonSendMessage.Size = new Size(79, 27);
            buttonSendMessage.TabIndex = 8;
            buttonSendMessage.Text = "전송";
            buttonSendMessage.TextColor = Color.DarkBlue;
            buttonSendMessage.UseVisualStyleBackColor = false;
            buttonSendMessage.Click += buttonSendMessage_Click;
            // 
            // listBoxChatBox
            // 
            listBoxChatBox.FormattingEnabled = true;
            listBoxChatBox.ItemHeight = 15;
            listBoxChatBox.Location = new Point(9, 39);
            listBoxChatBox.Name = "listBoxChatBox";
            listBoxChatBox.Size = new Size(727, 274);
            listBoxChatBox.TabIndex = 6;
            // 
            // MessageDetailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(customGroupBox1);
            Name = "MessageDetailForm";
            customGroupBox1.ResumeLayout(false);
            customGroupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private CustomGroupBox customGroupBox1;
        private CustomButtonStyle buttonSendMessage;
        private TextBox textBoxInputMessage;
        private ListBox listBoxChatBox;
        private ImageButton buttonRefresh;
        private Label label1;
        private TextBox textBoxTitle;
    }
}