
namespace WindowsFormsClient.Windows
{
    partial class FormProduct
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCansel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCategoryName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudPriceSell = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriceSell)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(152, 344);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(112, 31);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "Apply";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCansel
            // 
            this.btnCansel.Location = new System.Drawing.Point(270, 344);
            this.btnCansel.Name = "btnCansel";
            this.btnCansel.Size = new System.Drawing.Size(112, 31);
            this.btnCansel.TabIndex = 1;
            this.btnCansel.Text = "Cancel";
            this.btnCansel.UseVisualStyleBackColor = true;
            this.btnCansel.Click += new System.EventHandler(this.btnCansel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "id";
            // 
            // tbId
            // 
            this.tbId.Enabled = false;
            this.tbId.Location = new System.Drawing.Point(12, 52);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(370, 27);
            this.tbId.TabIndex = 4;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(12, 125);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(370, 27);
            this.tbName.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Name";
            // 
            // tbCategoryName
            // 
            this.tbCategoryName.Enabled = false;
            this.tbCategoryName.Location = new System.Drawing.Point(12, 271);
            this.tbCategoryName.Name = "tbCategoryName";
            this.tbCategoryName.Size = new System.Drawing.Size(370, 27);
            this.tbCategoryName.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 248);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 20);
            this.label12.TabIndex = 17;
            this.label12.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Price Sell";
            // 
            // nudPriceSell
            // 
            this.nudPriceSell.DecimalPlaces = 2;
            this.nudPriceSell.Location = new System.Drawing.Point(12, 198);
            this.nudPriceSell.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudPriceSell.Name = "nudPriceSell";
            this.nudPriceSell.Size = new System.Drawing.Size(120, 27);
            this.nudPriceSell.TabIndex = 22;
            // 
            // FormProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 393);
            this.Controls.Add(this.nudPriceSell);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCategoryName);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCansel);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProduct";
            this.Load += new System.EventHandler(this.FormEditUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPriceSell)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCansel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCategoryName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudPriceSell;
    }
}