
namespace VeriTabanıProje
{
    partial class istek
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
            this.components = new System.ComponentModel.Container();
            
            this.ıstekBindingSource = new System.Windows.Forms.BindingSource(this.components);
          
            this.ileti = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
       
            this.ıstekBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
           
            this.istekcombo = new System.Windows.Forms.ComboBox();
          
            this.ıstekBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
          
            this.label1 = new System.Windows.Forms.Label();
          
            ((System.ComponentModel.ISupportInitialize)(this.ıstekBindingSource)).BeginInit();
          
            ((System.ComponentModel.ISupportInitialize)(this.ıstekBindingSource1)).BeginInit();
            
            ((System.ComponentModel.ISupportInitialize)(this.ıstekBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // fabrikavtDataSet5
            // 
           
            // 
         
            // 
            // ileti
            // 
            this.ileti.Location = new System.Drawing.Point(12, 48);
            this.ileti.Multiline = true;
            this.ileti.Name = "ileti";
            this.ileti.Size = new System.Drawing.Size(512, 106);
            this.ileti.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(418, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "İsteği İlet";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fabrikavtDataSet6
            // 
          
            // istekcombo
            // 
            this.istekcombo.FormattingEnabled = true;
            this.istekcombo.Items.AddRange(new object[] {
            "Satış Departmanı",
            "Satın Alma Departmanı",
            "Üretim Departmanı",
            "Finans Departmanı",
            "İnsan Kaynakları Departmanı"});
            this.istekcombo.Location = new System.Drawing.Point(12, 12);
            this.istekcombo.Name = "istekcombo";
            this.istekcombo.Size = new System.Drawing.Size(215, 24);
            this.istekcombo.TabIndex = 3;
            this.istekcombo.SelectedIndexChanged += new System.EventHandler(this.istekcombo_SelectedIndexChanged);
            // 
            // fabrikavtDataSet7
            // 
           
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(504, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // istek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(531, 197);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.istekcombo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ileti);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "istek";
            this.Text = "istek";
            this.Load += new System.EventHandler(this.istek_Load);
          
            ((System.ComponentModel.ISupportInitialize)(this.ıstekBindingSource)).EndInit();
        
            ((System.ComponentModel.ISupportInitialize)(this.ıstekBindingSource1)).EndInit();
           
            ((System.ComponentModel.ISupportInitialize)(this.ıstekBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
       
        private System.Windows.Forms.BindingSource ıstekBindingSource;
     
        private System.Windows.Forms.TextBox ileti;
        private System.Windows.Forms.Button button1;
  
        private System.Windows.Forms.BindingSource ıstekBindingSource1;
       
        private System.Windows.Forms.ComboBox istekcombo;
       
        private System.Windows.Forms.BindingSource ıstekBindingSource2;
       
        private System.Windows.Forms.Label label1;
    }
}