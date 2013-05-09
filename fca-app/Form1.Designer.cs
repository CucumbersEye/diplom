namespace fca_app
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSourceDir = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.fldrBrwsDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.txtFinishDir = new System.Windows.Forms.RichTextBox();
            this.btnOpenFinishDirDlg = new System.Windows.Forms.Button();
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.lblSourceDir = new System.Windows.Forms.Label();
            this.lblFinishDir = new System.Windows.Forms.Label();
            this.btnOpenSourceDirDlg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSourceDir
            // 
            this.txtSourceDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSourceDir.Location = new System.Drawing.Point(12, 55);
            this.txtSourceDir.Name = "txtSourceDir";
            this.txtSourceDir.Size = new System.Drawing.Size(403, 27);
            this.txtSourceDir.TabIndex = 0;
            this.txtSourceDir.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(339, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Обработать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fldrBrwsDlg
            // 
            this.fldrBrwsDlg.SelectedPath = "D:\\fca-app";
            // 
            // txtFinishDir
            // 
            this.txtFinishDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtFinishDir.Location = new System.Drawing.Point(12, 115);
            this.txtFinishDir.Name = "txtFinishDir";
            this.txtFinishDir.Size = new System.Drawing.Size(403, 27);
            this.txtFinishDir.TabIndex = 2;
            this.txtFinishDir.Text = "";
            // 
            // btnOpenFinishDirDlg
            // 
            this.btnOpenFinishDirDlg.Location = new System.Drawing.Point(380, 115);
            this.btnOpenFinishDirDlg.Name = "btnOpenFinishDirDlg";
            this.btnOpenFinishDirDlg.Size = new System.Drawing.Size(35, 27);
            this.btnOpenFinishDirDlg.TabIndex = 3;
            this.btnOpenFinishDirDlg.Text = "...";
            this.btnOpenFinishDirDlg.UseVisualStyleBackColor = true;
            this.btnOpenFinishDirDlg.Click += new System.EventHandler(this.btnOpenDirDlg);
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(425, 24);
            this.MainMenuStrip.TabIndex = 4;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // lblSourceDir
            // 
            this.lblSourceDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSourceDir.Location = new System.Drawing.Point(12, 27);
            this.lblSourceDir.Name = "lblSourceDir";
            this.lblSourceDir.Size = new System.Drawing.Size(367, 23);
            this.lblSourceDir.TabIndex = 5;
            this.lblSourceDir.Text = "Исходная директория";
            // 
            // lblFinishDir
            // 
            this.lblFinishDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFinishDir.Location = new System.Drawing.Point(12, 90);
            this.lblFinishDir.Name = "lblFinishDir";
            this.lblFinishDir.Size = new System.Drawing.Size(367, 23);
            this.lblFinishDir.TabIndex = 6;
            this.lblFinishDir.Text = "Директория для сохранения";
            // 
            // btnOpenSourceDirDlg
            // 
            this.btnOpenSourceDirDlg.Location = new System.Drawing.Point(380, 55);
            this.btnOpenSourceDirDlg.Name = "btnOpenSourceDirDlg";
            this.btnOpenSourceDirDlg.Size = new System.Drawing.Size(33, 27);
            this.btnOpenSourceDirDlg.TabIndex = 7;
            this.btnOpenSourceDirDlg.Text = "...";
            this.btnOpenSourceDirDlg.UseVisualStyleBackColor = true;
            this.btnOpenSourceDirDlg.Click += new System.EventHandler(this.btnOpenDirDlg);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 194);
            this.Controls.Add(this.btnOpenSourceDirDlg);
            this.Controls.Add(this.lblFinishDir);
            this.Controls.Add(this.lblSourceDir);
            this.Controls.Add(this.btnOpenFinishDirDlg);
            this.Controls.Add(this.txtFinishDir);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSourceDir);
            this.Controls.Add(this.MainMenuStrip);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Рефакторинг иерархии классов";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtSourceDir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog fldrBrwsDlg;
        private System.Windows.Forms.RichTextBox txtFinishDir;
        private System.Windows.Forms.Button btnOpenFinishDirDlg;
        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.Label lblSourceDir;
        private System.Windows.Forms.Label lblFinishDir;
        private System.Windows.Forms.Button btnOpenSourceDirDlg;
    }
}

