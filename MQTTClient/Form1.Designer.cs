namespace MQTTClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonPublish = new Button();
            labelStatus = new Label();
            textBoxMessage = new TextBox();
            SuspendLayout();
            // 
            // buttonPublish
            // 
            buttonPublish.Location = new Point(226, 185);
            buttonPublish.Name = "buttonPublish";
            buttonPublish.Size = new Size(94, 29);
            buttonPublish.TabIndex = 0;
            buttonPublish.Text = "button1";
            buttonPublish.UseVisualStyleBackColor = true;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(226, 27);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(50, 20);
            labelStatus.TabIndex = 1;
            labelStatus.Text = "label1";
            // 
            // textBoxMessage
            // 
            textBoxMessage.Location = new Point(226, 63);
            textBoxMessage.Multiline = true;
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.Size = new Size(242, 83);
            textBoxMessage.TabIndex = 2;
            textBoxMessage.TextChanged += textBox1_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxMessage);
            Controls.Add(labelStatus);
            Controls.Add(buttonPublish);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonPublish;
        private Label labelStatus;
        private TextBox textBoxMessage;
    }
}
