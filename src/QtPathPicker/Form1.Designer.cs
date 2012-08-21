namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.pathComboBox_ = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.currentPathLabel_ = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chooseRootButton_ = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // pathComboBox_
            // 
            this.pathComboBox_.FormattingEnabled = true;
            this.pathComboBox_.Location = new System.Drawing.Point(16, 29);
            this.pathComboBox_.Name = "pathComboBox_";
            this.pathComboBox_.Size = new System.Drawing.Size(260, 21);
            this.pathComboBox_.TabIndex = 0;
            this.pathComboBox_.SelectedIndexChanged += new System.EventHandler(this.pathComboBox__SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Qt Path:";
            // 
            // currentPathLabel_
            // 
            this.currentPathLabel_.AutoSize = true;
            this.currentPathLabel_.Location = new System.Drawing.Point(111, 9);
            this.currentPathLabel_.Name = "currentPathLabel_";
            this.currentPathLabel_.Size = new System.Drawing.Size(16, 13);
            this.currentPathLabel_.TabIndex = 2;
            this.currentPathLabel_.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Looking in folder:";
            // 
            // chooseRootButton_
            // 
            this.chooseRootButton_.Location = new System.Drawing.Point(155, 56);
            this.chooseRootButton_.Name = "chooseRootButton_";
            this.chooseRootButton_.Size = new System.Drawing.Size(121, 23);
            this.chooseRootButton_.TabIndex = 4;
            this.chooseRootButton_.Text = "...";
            this.chooseRootButton_.UseVisualStyleBackColor = true;
            this.chooseRootButton_.Click += new System.EventHandler(this.chooseRootButton__Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 87);
            this.Controls.Add(this.chooseRootButton_);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.currentPathLabel_);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathComboBox_);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Qt Path Picker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox pathComboBox_;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label currentPathLabel_;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button chooseRootButton_;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

