namespace AutoColor
{
    partial class MainAuto
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.cbPos = new System.Windows.Forms.ComboBox();
            this.chbParty = new System.Windows.Forms.CheckBox();
            this.pictureScreen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 108);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(98, 45);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(131, 108);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(102, 45);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl1.Location = new System.Drawing.Point(9, 30);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(79, 15);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "Vị Trí Truy Nã";
            // 
            // cbPos
            // 
            this.cbPos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbPos.FormattingEnabled = true;
            this.cbPos.Location = new System.Drawing.Point(12, 59);
            this.cbPos.Name = "cbPos";
            this.cbPos.Size = new System.Drawing.Size(98, 23);
            this.cbPos.TabIndex = 3;
            // 
            // chbParty
            // 
            this.chbParty.AutoSize = true;
            this.chbParty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chbParty.Location = new System.Drawing.Point(131, 63);
            this.chbParty.Name = "chbParty";
            this.chbParty.Size = new System.Drawing.Size(100, 19);
            this.chbParty.TabIndex = 4;
            this.chbParty.Text = "Chạy theo đội";
            this.chbParty.UseVisualStyleBackColor = true;
            // 
            // pictureScreen
            // 
            this.pictureScreen.Location = new System.Drawing.Point(13, 169);
            this.pictureScreen.Name = "pictureScreen";
            this.pictureScreen.Size = new System.Drawing.Size(220, 120);
            this.pictureScreen.TabIndex = 5;
            this.pictureScreen.TabStop = false;
            // 
            // MainAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 301);
            this.Controls.Add(this.pictureScreen);
            this.Controls.Add(this.chbParty);
            this.Controls.Add(this.cbPos);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "MainAuto";
            this.Text = "AutoTK";
            ((System.ComponentModel.ISupportInitialize)(this.pictureScreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.ComboBox cbPos;
        private System.Windows.Forms.CheckBox chbParty;
        private System.Windows.Forms.PictureBox pictureScreen;
    }
}

