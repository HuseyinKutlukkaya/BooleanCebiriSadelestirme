namespace odev1_son
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
            this.btn_coz = new System.Windows.Forms.Button();
            this.tb_denklem = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb2 = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_coz
            // 
            this.btn_coz.Location = new System.Drawing.Point(30, 71);
            this.btn_coz.Name = "btn_coz";
            this.btn_coz.Size = new System.Drawing.Size(99, 23);
            this.btn_coz.TabIndex = 0;
            this.btn_coz.Text = "Çöz";
            this.btn_coz.UseVisualStyleBackColor = true;
            this.btn_coz.Click += new System.EventHandler(this.btn_coz_Click);
            // 
            // tb_denklem
            // 
            this.tb_denklem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_denklem.Location = new System.Drawing.Point(30, 29);
            this.tb_denklem.Name = "tb_denklem";
            this.tb_denklem.Size = new System.Drawing.Size(1074, 36);
            this.tb_denklem.TabIndex = 1;
            this.tb_denklem.Text = "(a+c)(v+d)";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lb2);
            this.panel1.Controls.Add(this.lb1);
            this.panel1.Location = new System.Drawing.Point(12, 154);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1167, 459);
            this.panel1.TabIndex = 2;
            // 
            // lb2
            // 
            this.lb2.AutoSize = true;
            this.lb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lb2.Location = new System.Drawing.Point(414, 49);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(89, 29);
            this.lb2.TabIndex = 1;
            this.lb2.Text = "İŞLEM";
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lb1.Location = new System.Drawing.Point(27, 49);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(96, 29);
            this.lb1.TabIndex = 0;
            this.lb1.Text = "KURAL";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 625);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tb_denklem);
            this.Controls.Add(this.btn_coz);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_coz;
        private System.Windows.Forms.TextBox tb_denklem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb2;
        private System.Windows.Forms.Label lb1;
    }
}

