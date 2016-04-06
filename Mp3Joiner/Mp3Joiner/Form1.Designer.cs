namespace Mp3Joiner
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
            this.txtFileOne = new System.Windows.Forms.TextBox();
            this.txtFileTwo = new System.Windows.Forms.TextBox();
            this.btnSearchOne = new System.Windows.Forms.Button();
            this.btnSearchTwo = new System.Windows.Forms.Button();
            this.btnMerge = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFileOne
            // 
            this.txtFileOne.Location = new System.Drawing.Point(63, 45);
            this.txtFileOne.Name = "txtFileOne";
            this.txtFileOne.Size = new System.Drawing.Size(1075, 31);
            this.txtFileOne.TabIndex = 0;
            // 
            // txtFileTwo
            // 
            this.txtFileTwo.Location = new System.Drawing.Point(63, 142);
            this.txtFileTwo.Name = "txtFileTwo";
            this.txtFileTwo.Size = new System.Drawing.Size(1075, 31);
            this.txtFileTwo.TabIndex = 1;
            // 
            // btnSearchOne
            // 
            this.btnSearchOne.Location = new System.Drawing.Point(1158, 45);
            this.btnSearchOne.Name = "btnSearchOne";
            this.btnSearchOne.Size = new System.Drawing.Size(98, 31);
            this.btnSearchOne.TabIndex = 2;
            this.btnSearchOne.Text = "Search";
            this.btnSearchOne.UseVisualStyleBackColor = true;
            this.btnSearchOne.Click += new System.EventHandler(this.btnSearchOne_Click);
            // 
            // btnSearchTwo
            // 
            this.btnSearchTwo.Location = new System.Drawing.Point(1158, 142);
            this.btnSearchTwo.Name = "btnSearchTwo";
            this.btnSearchTwo.Size = new System.Drawing.Size(98, 30);
            this.btnSearchTwo.TabIndex = 3;
            this.btnSearchTwo.Text = "Search";
            this.btnSearchTwo.UseVisualStyleBackColor = true;
            this.btnSearchTwo.Click += new System.EventHandler(this.btnSearchTwo_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(474, 333);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(251, 84);
            this.btnMerge.TabIndex = 4;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 558);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.btnSearchTwo);
            this.Controls.Add(this.btnSearchOne);
            this.Controls.Add(this.txtFileTwo);
            this.Controls.Add(this.txtFileOne);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFileOne;
        private System.Windows.Forms.TextBox txtFileTwo;
        private System.Windows.Forms.Button btnSearchOne;
        private System.Windows.Forms.Button btnSearchTwo;
        private System.Windows.Forms.Button btnMerge;
    }
}

