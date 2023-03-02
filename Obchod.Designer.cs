namespace nevim
{
    partial class Obchod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Obchod));
            this.buttonPoskozeni = new System.Windows.Forms.Button();
            this.buttonRychlost = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonObtiznost = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // buttonPoskozeni
            // 
            this.buttonPoskozeni.BackColor = System.Drawing.Color.Transparent;
            this.buttonPoskozeni.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPoskozeni.BackgroundImage")));
            this.buttonPoskozeni.Image = ((System.Drawing.Image)(resources.GetObject("buttonPoskozeni.Image")));
            this.buttonPoskozeni.Location = new System.Drawing.Point(34, 198);
            this.buttonPoskozeni.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPoskozeni.Name = "buttonPoskozeni";
            this.buttonPoskozeni.Size = new System.Drawing.Size(165, 81);
            this.buttonPoskozeni.TabIndex = 0;
            this.buttonPoskozeni.UseVisualStyleBackColor = false;
            this.buttonPoskozeni.Click += new System.EventHandler(this.buttonPoskozeni_Click);
            // 
            // buttonRychlost
            // 
            this.buttonRychlost.Image = ((System.Drawing.Image)(resources.GetObject("buttonRychlost.Image")));
            this.buttonRychlost.Location = new System.Drawing.Point(163, 349);
            this.buttonRychlost.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRychlost.Name = "buttonRychlost";
            this.buttonRychlost.Size = new System.Drawing.Size(163, 81);
            this.buttonRychlost.TabIndex = 1;
            this.buttonRychlost.UseVisualStyleBackColor = true;
            this.buttonRychlost.Click += new System.EventHandler(this.buttonRychlost_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Skóré: ";
            // 
            // buttonObtiznost
            // 
            this.buttonObtiznost.Image = global::nevim.Properties.Resources.obtiznost;
            this.buttonObtiznost.Location = new System.Drawing.Point(298, 198);
            this.buttonObtiznost.Margin = new System.Windows.Forms.Padding(0);
            this.buttonObtiznost.Name = "buttonObtiznost";
            this.buttonObtiznost.Size = new System.Drawing.Size(164, 81);
            this.buttonObtiznost.TabIndex = 4;
            this.buttonObtiznost.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.buttonObtiznost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRychlost);
            this.Controls.Add(this.buttonPoskozeni);
            this.DoubleBuffered = true;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Roguelike - obchod";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form3_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonPoskozeni;
        private Button buttonRychlost;
        private Label label1;
        private Button buttonObtiznost;
        private System.Windows.Forms.Timer timer1;
    }
}