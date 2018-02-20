namespace ParseLogForm
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonDirectory = new System.Windows.Forms.Button();
            this.ButtonRun = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.StringConnection = new System.Windows.Forms.Button();
            this.State = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonDirectory
            // 
            this.ButtonDirectory.Location = new System.Drawing.Point(12, 12);
            this.ButtonDirectory.Name = "ButtonDirectory";
            this.ButtonDirectory.Size = new System.Drawing.Size(142, 23);
            this.ButtonDirectory.TabIndex = 0;
            this.ButtonDirectory.Text = "Directory";
            this.ButtonDirectory.UseVisualStyleBackColor = true;
            this.ButtonDirectory.Click += new System.EventHandler(this.ButtonDirectory_Click);
            // 
            // ButtonRun
            // 
            this.ButtonRun.Location = new System.Drawing.Point(170, 12);
            this.ButtonRun.Name = "ButtonRun";
            this.ButtonRun.Size = new System.Drawing.Size(142, 23);
            this.ButtonRun.TabIndex = 1;
            this.ButtonRun.Text = "Run";
            this.ButtonRun.UseVisualStyleBackColor = true;
            this.ButtonRun.Click += new System.EventHandler(this.ButtonRun_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(12, 99);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(300, 23);
            this.ProgressBar.TabIndex = 3;
            this.ProgressBar.Click += new System.EventHandler(this.ProgressBar_Click);
            // 
            // StringConnection
            // 
            this.StringConnection.Location = new System.Drawing.Point(13, 41);
            this.StringConnection.Name = "StringConnection";
            this.StringConnection.Size = new System.Drawing.Size(300, 23);
            this.StringConnection.TabIndex = 4;
            this.StringConnection.Text = "String connection";
            this.StringConnection.UseVisualStyleBackColor = true;
            this.StringConnection.Click += new System.EventHandler(this.StringConnection_Click);
            // 
            // State
            // 
            this.State.AutoSize = true;
            this.State.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.State.Location = new System.Drawing.Point(12, 75);
            this.State.Name = "State";
            this.State.Size = new System.Drawing.Size(11, 16);
            this.State.TabIndex = 5;
            this.State.Text = " ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 134);
            this.Controls.Add(this.State);
            this.Controls.Add(this.StringConnection);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.ButtonRun);
            this.Controls.Add(this.ButtonDirectory);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonDirectory;
        private System.Windows.Forms.Button ButtonRun;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Button StringConnection;
        private System.Windows.Forms.Label State;
    }
}

