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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPoskozeni
            // 
            this.buttonPoskozeni.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPoskozeni.BackColor = System.Drawing.Color.Transparent;
            this.buttonPoskozeni.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonPoskozeni.FlatAppearance.BorderSize = 0;
            this.buttonPoskozeni.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonPoskozeni.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonPoskozeni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPoskozeni.Image = ((System.Drawing.Image)(resources.GetObject("buttonPoskozeni.Image")));
            this.buttonPoskozeni.Location = new System.Drawing.Point(32, 197);
            this.buttonPoskozeni.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPoskozeni.Name = "buttonPoskozeni";
            this.buttonPoskozeni.Size = new System.Drawing.Size(165, 81);
            this.buttonPoskozeni.TabIndex = 0;
            this.buttonPoskozeni.UseVisualStyleBackColor = false;
            this.buttonPoskozeni.Click += new System.EventHandler(this.buttonPoskozeni_Click);
            // 
            // buttonRychlost
            // 
            this.buttonRychlost.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRychlost.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonRychlost.BackColor = System.Drawing.Color.Transparent;
            this.buttonRychlost.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonRychlost.FlatAppearance.BorderSize = 0;
            this.buttonRychlost.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonRychlost.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonRychlost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRychlost.Image = ((System.Drawing.Image)(resources.GetObject("buttonRychlost.Image")));
            this.buttonRychlost.Location = new System.Drawing.Point(159, 350);
            this.buttonRychlost.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRychlost.Name = "buttonRychlost";
            this.buttonRychlost.Size = new System.Drawing.Size(163, 81);
            this.buttonRychlost.TabIndex = 1;
            this.buttonRychlost.UseVisualStyleBackColor = false;
            this.buttonRychlost.Click += new System.EventHandler(this.buttonRychlost_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(19)))), ((int)(((byte)(47)))));
            this.label1.Font = new System.Drawing.Font("Niagara Solid", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(250, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 23);
            this.label1.TabIndex = 3;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonObtiznost
            // 
            this.buttonObtiznost.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonObtiznost.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonObtiznost.BackColor = System.Drawing.Color.Transparent;
            this.buttonObtiznost.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonObtiznost.FlatAppearance.BorderSize = 0;
            this.buttonObtiznost.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonObtiznost.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonObtiznost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonObtiznost.Image = global::nevim.Properties.Resources.obtiznost;
            this.buttonObtiznost.Location = new System.Drawing.Point(298, 197);
            this.buttonObtiznost.Margin = new System.Windows.Forms.Padding(0);
            this.buttonObtiznost.Name = "buttonObtiznost";
            this.buttonObtiznost.Size = new System.Drawing.Size(164, 81);
            this.buttonObtiznost.TabIndex = 4;
            this.buttonObtiznost.UseVisualStyleBackColor = false;
            this.buttonObtiznost.Click += new System.EventHandler(this.buttonObtiznost_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(159, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Obchod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonObtiznost);
            this.Controls.Add(this.buttonRychlost);
            this.Controls.Add(this.buttonPoskozeni);
            this.DoubleBuffered = true;
            this.Name = "Obchod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Roguelike - obchod";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form3_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonPoskozeni;
        private Button buttonRychlost;
        private Label label1;
        private Button buttonObtiznost;
        private System.Windows.Forms.Timer timer1;
        private PictureBox pictureBox1;
    }
}