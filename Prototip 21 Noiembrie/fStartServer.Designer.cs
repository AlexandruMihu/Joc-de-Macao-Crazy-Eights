namespace Prototip_21_Noiembrie
{
    partial class fStartServer
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
            this.btnInstructiuni = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.labelMacao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnStart.BackColor = System.Drawing.Color.LightPink;
            this.btnStart.Font = new System.Drawing.Font("Gill Sans MT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.Maroon;
            this.btnStart.Location = new System.Drawing.Point(106, 115);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(184, 59);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnInstructiuni
            // 
            this.btnInstructiuni.BackColor = System.Drawing.Color.LightPink;
            this.btnInstructiuni.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstructiuni.ForeColor = System.Drawing.Color.Maroon;
            this.btnInstructiuni.Location = new System.Drawing.Point(141, 180);
            this.btnInstructiuni.Name = "btnInstructiuni";
            this.btnInstructiuni.Size = new System.Drawing.Size(113, 45);
            this.btnInstructiuni.TabIndex = 1;
            this.btnInstructiuni.Text = "Instructiuni";
            this.btnInstructiuni.UseVisualStyleBackColor = false;
            this.btnInstructiuni.Click += new System.EventHandler(this.btnInstructiuni_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.LightPink;
            this.btnExit.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Maroon;
            this.btnExit.Location = new System.Drawing.Point(141, 231);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(113, 45);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // labelMacao
            // 
            this.labelMacao.AutoSize = true;
            this.labelMacao.BackColor = System.Drawing.Color.Pink;
            this.labelMacao.Font = new System.Drawing.Font("Haettenschweiler", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMacao.ForeColor = System.Drawing.Color.Maroon;
            this.labelMacao.Location = new System.Drawing.Point(131, 23);
            this.labelMacao.Name = "labelMacao";
            this.labelMacao.Size = new System.Drawing.Size(131, 56);
            this.labelMacao.TabIndex = 4;
            this.labelMacao.Text = "Macao";
            // 
            // fStartServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(411, 371);
            this.Controls.Add(this.labelMacao);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnInstructiuni);
            this.Controls.Add(this.btnStart);
            this.Name = "fStartServer";
            this.Text = "fStart";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnInstructiuni;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label labelMacao;
    }
}