namespace nevim
{
    partial class Form3
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
            this.buttonRychlost = new System.Windows.Forms.Button();
            this.buttonPoskozeni = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonRychlost
            // 
            this.buttonRychlost.Location = new System.Drawing.Point(113, 297);
            this.buttonRychlost.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonRychlost.Name = "buttonRychlost";
            this.buttonRychlost.Size = new System.Drawing.Size(106, 107);
            this.buttonRychlost.TabIndex = 0;
            this.buttonRychlost.Text = "Zvyš rychlost!";
            this.buttonRychlost.UseVisualStyleBackColor = true;
            this.buttonRychlost.Click += new System.EventHandler(this.buttonRychlost_Click);
            // 
            // buttonPoskozeni
            // 
            this.buttonPoskozeni.Location = new System.Drawing.Point(352, 297);
            this.buttonPoskozeni.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonPoskozeni.Name = "buttonPoskozeni";
            this.buttonPoskozeni.Size = new System.Drawing.Size(106, 107);
            this.buttonPoskozeni.TabIndex = 1;
            this.buttonPoskozeni.Text = "Zvyš poškození!";
            this.buttonPoskozeni.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Skóré: ";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 615);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonPoskozeni);
            this.Controls.Add(this.buttonRychlost);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form3";
            this.Text = "Roguelike - obchod";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form3_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonRychlost;
        private Button buttonPoskozeni;
        private Label label1;
    }
}