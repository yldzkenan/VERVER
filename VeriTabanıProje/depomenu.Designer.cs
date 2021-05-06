namespace VeriTabanıProje
{
    partial class depomenu
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
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonKargo = new System.Windows.Forms.Button();
            this.btnstokdurum = new System.Windows.Forms.Button();
            this.buttonTeslim = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(338, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 20);
            this.label7.TabIndex = 28;
            this.label7.Text = "X";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(316, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 20);
            this.label8.TabIndex = 27;
            this.label8.Text = "<";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // buttonKargo
            // 
            this.buttonKargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonKargo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonKargo.Location = new System.Drawing.Point(135, 35);
            this.buttonKargo.Name = "buttonKargo";
            this.buttonKargo.Size = new System.Drawing.Size(99, 211);
            this.buttonKargo.TabIndex = 26;
            this.buttonKargo.Text = "KARGOYA VER";
            this.buttonKargo.UseVisualStyleBackColor = true;
            this.buttonKargo.Click += new System.EventHandler(this.buttonKargo_Click);
            // 
            // btnstokdurum
            // 
            this.btnstokdurum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnstokdurum.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnstokdurum.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnstokdurum.Location = new System.Drawing.Point(12, 35);
            this.btnstokdurum.Name = "btnstokdurum";
            this.btnstokdurum.Size = new System.Drawing.Size(96, 211);
            this.btnstokdurum.TabIndex = 25;
            this.btnstokdurum.Text = "STOK DURUMLARI";
            this.btnstokdurum.UseVisualStyleBackColor = true;
            this.btnstokdurum.Click += new System.EventHandler(this.btnstokdurum_Click);
            // 
            // buttonTeslim
            // 
            this.buttonTeslim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTeslim.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonTeslim.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonTeslim.Location = new System.Drawing.Point(261, 35);
            this.buttonTeslim.Name = "buttonTeslim";
            this.buttonTeslim.Size = new System.Drawing.Size(96, 211);
            this.buttonTeslim.TabIndex = 29;
            this.buttonTeslim.Text = "TESLİM DURUMU";
            this.buttonTeslim.UseVisualStyleBackColor = true;
            this.buttonTeslim.Click += new System.EventHandler(this.buttonTeslim_Click);
            // 
            // depomenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(377, 258);
            this.Controls.Add(this.buttonTeslim);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonKargo);
            this.Controls.Add(this.btnstokdurum);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "depomenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "depomenu";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.depomenu_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.depomenu_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.depomenu_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonKargo;
        private System.Windows.Forms.Button btnstokdurum;
        private System.Windows.Forms.Button buttonTeslim;
    }
}