﻿namespace december_3rd_client
{
    partial class fJocClient
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
            this.btnIaCarte = new System.Windows.Forms.Button();
            this.btnPuneCarte = new System.Windows.Forms.Button();
            this.labelCarteCurenta = new System.Windows.Forms.Label();
            this.labelCarteSelectata = new System.Windows.Forms.Label();
            this.labelTurnPlayer = new System.Windows.Forms.Label();
            this.labelPachet1 = new System.Windows.Forms.Label();
            this.labelPachet2 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.labelip = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.labelPachetOriginal = new System.Windows.Forms.Label();
            this.labelPachetDeJos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnIaCarte
            // 
            this.btnIaCarte.BackColor = System.Drawing.Color.LightPink;
            this.btnIaCarte.Font = new System.Drawing.Font("Gill Sans MT", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIaCarte.ForeColor = System.Drawing.Color.Maroon;
            this.btnIaCarte.Location = new System.Drawing.Point(7, 86);
            this.btnIaCarte.Name = "btnIaCarte";
            this.btnIaCarte.Size = new System.Drawing.Size(183, 77);
            this.btnIaCarte.TabIndex = 0;
            this.btnIaCarte.Text = "ia carte din pachet";
            this.btnIaCarte.UseVisualStyleBackColor = false;
            this.btnIaCarte.Visible = false;
            this.btnIaCarte.Click += new System.EventHandler(this.btnIaCarte_Click);
            // 
            // btnPuneCarte
            // 
            this.btnPuneCarte.BackColor = System.Drawing.Color.LightPink;
            this.btnPuneCarte.Font = new System.Drawing.Font("Gill Sans MT", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPuneCarte.ForeColor = System.Drawing.Color.Maroon;
            this.btnPuneCarte.Location = new System.Drawing.Point(7, 169);
            this.btnPuneCarte.Name = "btnPuneCarte";
            this.btnPuneCarte.Size = new System.Drawing.Size(183, 77);
            this.btnPuneCarte.TabIndex = 1;
            this.btnPuneCarte.Text = "pune carte jos";
            this.btnPuneCarte.UseVisualStyleBackColor = false;
            this.btnPuneCarte.Visible = false;
            this.btnPuneCarte.Click += new System.EventHandler(this.btnPuneCarte_Click);
            // 
            // labelCarteCurenta
            // 
            this.labelCarteCurenta.AutoSize = true;
            this.labelCarteCurenta.Font = new System.Drawing.Font("Gill Sans MT", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCarteCurenta.ForeColor = System.Drawing.Color.Maroon;
            this.labelCarteCurenta.Location = new System.Drawing.Point(52, 267);
            this.labelCarteCurenta.Name = "labelCarteCurenta";
            this.labelCarteCurenta.Size = new System.Drawing.Size(102, 21);
            this.labelCarteCurenta.TabIndex = 2;
            this.labelCarteCurenta.Text = "Carte curenta";
            this.labelCarteCurenta.Visible = false;
            // 
            // labelCarteSelectata
            // 
            this.labelCarteSelectata.AutoSize = true;
            this.labelCarteSelectata.Font = new System.Drawing.Font("Gill Sans MT", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCarteSelectata.ForeColor = System.Drawing.Color.Maroon;
            this.labelCarteSelectata.Location = new System.Drawing.Point(12, 49);
            this.labelCarteSelectata.Name = "labelCarteSelectata";
            this.labelCarteSelectata.Size = new System.Drawing.Size(174, 21);
            this.labelCarteSelectata.TabIndex = 3;
            this.labelCarteSelectata.Text = "Nu ai selectat nicio carte";
            this.labelCarteSelectata.Visible = false;
            // 
            // labelTurnPlayer
            // 
            this.labelTurnPlayer.AutoSize = true;
            this.labelTurnPlayer.Font = new System.Drawing.Font("Gill Sans MT", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTurnPlayer.ForeColor = System.Drawing.Color.Maroon;
            this.labelTurnPlayer.Location = new System.Drawing.Point(592, 19);
            this.labelTurnPlayer.Name = "labelTurnPlayer";
            this.labelTurnPlayer.Size = new System.Drawing.Size(134, 29);
            this.labelTurnPlayer.TabIndex = 4;
            this.labelTurnPlayer.Text = "Este tura lui ";
            this.labelTurnPlayer.Visible = false;
            // 
            // labelPachet1
            // 
            this.labelPachet1.AutoSize = true;
            this.labelPachet1.Font = new System.Drawing.Font("Gill Sans MT", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPachet1.ForeColor = System.Drawing.Color.Maroon;
            this.labelPachet1.Location = new System.Drawing.Point(225, 73);
            this.labelPachet1.Name = "labelPachet1";
            this.labelPachet1.Size = new System.Drawing.Size(75, 21);
            this.labelPachet1.TabIndex = 5;
            this.labelPachet1.Text = "Pachet lui";
            this.labelPachet1.Visible = false;
            // 
            // labelPachet2
            // 
            this.labelPachet2.AutoSize = true;
            this.labelPachet2.Font = new System.Drawing.Font("Gill Sans MT", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPachet2.ForeColor = System.Drawing.Color.Maroon;
            this.labelPachet2.Location = new System.Drawing.Point(416, 73);
            this.labelPachet2.Name = "labelPachet2";
            this.labelPachet2.Size = new System.Drawing.Size(75, 21);
            this.labelPachet2.TabIndex = 6;
            this.labelPachet2.Text = "Pachet lui";
            this.labelPachet2.Visible = false;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.LightPink;
            this.btnConnect.Font = new System.Drawing.Font("Gill Sans MT", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnConnect.ForeColor = System.Drawing.Color.Maroon;
            this.btnConnect.Location = new System.Drawing.Point(6, 11);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(81, 31);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // labelip
            // 
            this.labelip.AutoSize = true;
            this.labelip.Location = new System.Drawing.Point(93, 19);
            this.labelip.Name = "labelip";
            this.labelip.Size = new System.Drawing.Size(61, 13);
            this.labelip.TabIndex = 8;
            this.labelip.Text = "IP Address:";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(156, 16);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(144, 20);
            this.textBoxIP.TabIndex = 9;
            this.textBoxIP.Text = "127.0.0.1";
            // 
            // labelPachetOriginal
            // 
            this.labelPachetOriginal.AutoSize = true;
            this.labelPachetOriginal.Font = new System.Drawing.Font("Gill Sans MT", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPachetOriginal.ForeColor = System.Drawing.Color.Maroon;
            this.labelPachetOriginal.Location = new System.Drawing.Point(618, 73);
            this.labelPachetOriginal.Name = "labelPachetOriginal";
            this.labelPachetOriginal.Size = new System.Drawing.Size(108, 21);
            this.labelPachetOriginal.TabIndex = 10;
            this.labelPachetOriginal.Text = "Pachet original";
            this.labelPachetOriginal.Visible = false;
            // 
            // labelPachetDeJos
            // 
            this.labelPachetDeJos.AutoSize = true;
            this.labelPachetDeJos.Font = new System.Drawing.Font("Gill Sans MT", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPachetDeJos.ForeColor = System.Drawing.Color.Maroon;
            this.labelPachetDeJos.Location = new System.Drawing.Point(815, 73);
            this.labelPachetDeJos.Name = "labelPachetDeJos";
            this.labelPachetDeJos.Size = new System.Drawing.Size(97, 21);
            this.labelPachetDeJos.TabIndex = 11;
            this.labelPachetDeJos.Text = "Pachet de jos";
            this.labelPachetDeJos.Visible = false;
            // 
            // fJocClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(1164, 985);
            this.Controls.Add(this.labelPachetDeJos);
            this.Controls.Add(this.labelPachetOriginal);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.labelip);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.labelPachet2);
            this.Controls.Add(this.labelPachet1);
            this.Controls.Add(this.labelTurnPlayer);
            this.Controls.Add(this.labelCarteSelectata);
            this.Controls.Add(this.labelCarteCurenta);
            this.Controls.Add(this.btnPuneCarte);
            this.Controls.Add(this.btnIaCarte);
            this.Name = "fJocClient";
            this.Text = "Fereastra Joc";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fJoc_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnIaCarte;
        public System.Windows.Forms.Button btnPuneCarte;
        public System.Windows.Forms.Label labelCarteCurenta;
        public System.Windows.Forms.Label labelCarteSelectata;
        public System.Windows.Forms.Label labelTurnPlayer;
        public System.Windows.Forms.Label labelPachet1;
        public System.Windows.Forms.Label labelPachet2;
        public System.Windows.Forms.Button btnConnect;
        public System.Windows.Forms.Label labelip;
        public System.Windows.Forms.TextBox textBoxIP;
        public System.Windows.Forms.Label labelPachetOriginal;
        public System.Windows.Forms.Label labelPachetDeJos;
    }
}

