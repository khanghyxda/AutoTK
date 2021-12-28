
namespace AutoHK
{
    partial class Main
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
            this.btnGetBlood = new System.Windows.Forms.Button();
            this.lbBlood = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGetBlood
            // 
            this.btnGetBlood.Location = new System.Drawing.Point(43, 66);
            this.btnGetBlood.Name = "btnGetBlood";
            this.btnGetBlood.Size = new System.Drawing.Size(75, 23);
            this.btnGetBlood.TabIndex = 0;
            this.btnGetBlood.Text = "GetBlood";
            this.btnGetBlood.UseVisualStyleBackColor = true;
            this.btnGetBlood.Click += new System.EventHandler(this.btnGetBlood_Click);
            // 
            // lbBlood
            // 
            this.lbBlood.AutoSize = true;
            this.lbBlood.Location = new System.Drawing.Point(161, 70);
            this.lbBlood.Name = "lbBlood";
            this.lbBlood.Size = new System.Drawing.Size(0, 15);
            this.lbBlood.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 450);
            this.Controls.Add(this.lbBlood);
            this.Controls.Add(this.btnGetBlood);
            this.Name = "Main";
            this.Text = "AutoHK";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetBlood;
        private System.Windows.Forms.Label lbBlood;
    }
}

