namespace Prototip_21_Noiembrie
{
    partial class fNumeServer
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.labelNume1 = new System.Windows.Forms.Label();
            this.labelEnterNume = new System.Windows.Forms.Label();
            this.textBoxNume1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightPink;
            this.btnCancel.Font = new System.Drawing.Font("Gill Sans MT", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Maroon;
            this.btnCancel.Location = new System.Drawing.Point(114, 104);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(67, 28);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.LightPink;
            this.btnOk.Enabled = false;
            this.btnOk.Font = new System.Drawing.Font("Gill Sans MT", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.Maroon;
            this.btnOk.Location = new System.Drawing.Point(43, 104);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(65, 28);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // labelNume1
            // 
            this.labelNume1.AutoSize = true;
            this.labelNume1.Font = new System.Drawing.Font("Gill Sans MT", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNume1.ForeColor = System.Drawing.Color.Maroon;
            this.labelNume1.Location = new System.Drawing.Point(3, 62);
            this.labelNume1.Name = "labelNume1";
            this.labelNume1.Size = new System.Drawing.Size(63, 21);
            this.labelNume1.TabIndex = 2;
            this.labelNume1.Text = "Player 1";
            // 
            // labelEnterNume
            // 
            this.labelEnterNume.AutoSize = true;
            this.labelEnterNume.Font = new System.Drawing.Font("Gill Sans MT", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnterNume.ForeColor = System.Drawing.Color.Maroon;
            this.labelEnterNume.Location = new System.Drawing.Point(47, 9);
            this.labelEnterNume.Name = "labelEnterNume";
            this.labelEnterNume.Size = new System.Drawing.Size(134, 29);
            this.labelEnterNume.TabIndex = 4;
            this.labelEnterNume.Text = "Enter names";
            // 
            // textBoxNume1
            // 
            this.textBoxNume1.Location = new System.Drawing.Point(72, 62);
            this.textBoxNume1.Name = "textBoxNume1";
            this.textBoxNume1.Size = new System.Drawing.Size(132, 20);
            this.textBoxNume1.TabIndex = 5;
            this.textBoxNume1.TextChanged += new System.EventHandler(this.textBoxNume1_TextChanged);
            // 
            // fNumeServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(219, 179);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxNume1);
            this.Controls.Add(this.labelEnterNume);
            this.Controls.Add(this.labelNume1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Name = "fNumeServer";
            this.Text = "fNume";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label labelNume1;
        private System.Windows.Forms.Label labelEnterNume;
        private System.Windows.Forms.TextBox textBoxNume1;
    }
}