namespace AutoClicker
{
    partial class ghostForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.keyPressedlbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.clickstxb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Press control+F1 to start or stop autoclicker";
            // 
            // keyPressedlbl
            // 
            this.keyPressedlbl.AutoSize = true;
            this.keyPressedlbl.Location = new System.Drawing.Point(86, 9);
            this.keyPressedlbl.Name = "keyPressedlbl";
            this.keyPressedlbl.Size = new System.Drawing.Size(0, 13);
            this.keyPressedlbl.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Clicks per second:";
            // 
            // clickstxb
            // 
            this.clickstxb.Location = new System.Drawing.Point(112, 30);
            this.clickstxb.MaxLength = 3;
            this.clickstxb.Name = "clickstxb";
            this.clickstxb.Size = new System.Drawing.Size(29, 20);
            this.clickstxb.TabIndex = 3;
            this.clickstxb.Text = "25";
            this.clickstxb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ghostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 65);
            this.Controls.Add(this.clickstxb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.keyPressedlbl);
            this.Controls.Add(this.label1);
            this.Name = "ghostForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ghostForm_FormClosing);
            this.Load += new System.EventHandler(this.ghostForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label keyPressedlbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox clickstxb;
    }
}

