namespace projectElementalist.Interfaces
{
    partial class Match
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Match));
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lbChoose = new System.Windows.Forms.Label();
            this.pbWater = new System.Windows.Forms.PictureBox();
            this.pbAir = new System.Windows.Forms.PictureBox();
            this.pbEarth = new System.Windows.Forms.PictureBox();
            this.pbFire = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEarth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFire)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.Image = global::projectElementalist.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(192, 45);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(600, 200);
            this.pbLogo.TabIndex = 28;
            this.pbLogo.TabStop = false;
            // 
            // lbChoose
            // 
            this.lbChoose.AutoSize = true;
            this.lbChoose.BackColor = System.Drawing.Color.Transparent;
            this.lbChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChoose.ForeColor = System.Drawing.SystemColors.Control;
            this.lbChoose.Location = new System.Drawing.Point(419, 278);
            this.lbChoose.Name = "lbChoose";
            this.lbChoose.Size = new System.Drawing.Size(159, 24);
            this.lbChoose.TabIndex = 189;
            this.lbChoose.Text = "Elija su elemento:";
            // 
            // pbWater
            // 
            this.pbWater.BackColor = System.Drawing.Color.Transparent;
            this.pbWater.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbWater.Image = global::projectElementalist.Properties.Resources.pjwater;
            this.pbWater.Location = new System.Drawing.Point(183, 327);
            this.pbWater.Name = "pbWater";
            this.pbWater.Size = new System.Drawing.Size(150, 150);
            this.pbWater.TabIndex = 190;
            this.pbWater.TabStop = false;
            this.pbWater.Click += new System.EventHandler(this.pbWater_Click);
            this.pbWater.MouseLeave += new System.EventHandler(this.pbWater_MouseLeave);
            this.pbWater.MouseHover += new System.EventHandler(this.pbWater_MouseHover);
            // 
            // pbAir
            // 
            this.pbAir.BackColor = System.Drawing.Color.Transparent;
            this.pbAir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAir.Image = global::projectElementalist.Properties.Resources.pjair;
            this.pbAir.Location = new System.Drawing.Point(339, 327);
            this.pbAir.Name = "pbAir";
            this.pbAir.Size = new System.Drawing.Size(150, 150);
            this.pbAir.TabIndex = 191;
            this.pbAir.TabStop = false;
            this.pbAir.Click += new System.EventHandler(this.pbAir_Click);
            this.pbAir.MouseLeave += new System.EventHandler(this.pbAir_MouseLeave);
            this.pbAir.MouseHover += new System.EventHandler(this.pbAir_MouseHover);
            // 
            // pbEarth
            // 
            this.pbEarth.BackColor = System.Drawing.Color.Transparent;
            this.pbEarth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbEarth.Image = global::projectElementalist.Properties.Resources.pjearth;
            this.pbEarth.Location = new System.Drawing.Point(495, 327);
            this.pbEarth.Name = "pbEarth";
            this.pbEarth.Size = new System.Drawing.Size(150, 150);
            this.pbEarth.TabIndex = 192;
            this.pbEarth.TabStop = false;
            this.pbEarth.Click += new System.EventHandler(this.pbEarth_Click);
            this.pbEarth.MouseLeave += new System.EventHandler(this.pbEarth_MouseLeave);
            this.pbEarth.MouseHover += new System.EventHandler(this.pbEarth_MouseHover);
            // 
            // pbFire
            // 
            this.pbFire.BackColor = System.Drawing.Color.Transparent;
            this.pbFire.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbFire.Image = global::projectElementalist.Properties.Resources.pjfire;
            this.pbFire.Location = new System.Drawing.Point(651, 327);
            this.pbFire.Name = "pbFire";
            this.pbFire.Size = new System.Drawing.Size(150, 150);
            this.pbFire.TabIndex = 193;
            this.pbFire.TabStop = false;
            this.pbFire.Click += new System.EventHandler(this.pbFire_Click);
            this.pbFire.MouseLeave += new System.EventHandler(this.pbFire_MouseLeave);
            this.pbFire.MouseHover += new System.EventHandler(this.pbFire_MouseHover);
            // 
            // Match
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::projectElementalist.Properties.Resources.fondo;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.pbFire);
            this.Controls.Add(this.pbEarth);
            this.Controls.Add(this.pbAir);
            this.Controls.Add(this.pbWater);
            this.Controls.Add(this.lbChoose);
            this.Controls.Add(this.pbLogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Match";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Match";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWater)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEarth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFire)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lbChoose;
        private System.Windows.Forms.PictureBox pbWater;
        private System.Windows.Forms.PictureBox pbAir;
        private System.Windows.Forms.PictureBox pbEarth;
        private System.Windows.Forms.PictureBox pbFire;
    }
}