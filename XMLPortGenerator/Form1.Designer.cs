namespace XMLPortGenerator
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
            this.label1 = new System.Windows.Forms.Label();
            this.nudSourceTableNo = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudSourceTableNo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source Table Number";
            // 
            // nudSourceTableNo
            // 
            this.nudSourceTableNo.Location = new System.Drawing.Point(129, 7);
            this.nudSourceTableNo.Maximum = new decimal(new int[] {
            2000000130,
            0,
            0,
            0});
            this.nudSourceTableNo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSourceTableNo.Name = "nudSourceTableNo";
            this.nudSourceTableNo.Size = new System.Drawing.Size(120, 20);
            this.nudSourceTableNo.TabIndex = 1;
            this.nudSourceTableNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.nudSourceTableNo);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "XMLPort Generator";
            ((System.ComponentModel.ISupportInitialize)(this.nudSourceTableNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudSourceTableNo;
    }
}

