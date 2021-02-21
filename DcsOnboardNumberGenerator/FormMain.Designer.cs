namespace DcsOnboardNumberGenerator
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.numFirst = new System.Windows.Forms.NumericUpDown();
            this.numLast = new System.Windows.Forms.NumericUpDown();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblMiz = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.grpNumbers = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.numFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLast)).BeginInit();
            this.grpNumbers.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numFirst
            // 
            this.numFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numFirst.Location = new System.Drawing.Point(3, 16);
            this.numFirst.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numFirst.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFirst.Name = "numFirst";
            this.numFirst.Size = new System.Drawing.Size(158, 20);
            this.numFirst.TabIndex = 0;
            this.numFirst.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFirst.ValueChanged += new System.EventHandler(this.numFirst_ValueChanged);
            // 
            // numLast
            // 
            this.numLast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numLast.Location = new System.Drawing.Point(167, 16);
            this.numLast.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numLast.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLast.Name = "numLast";
            this.numLast.Size = new System.Drawing.Size(158, 20);
            this.numLast.TabIndex = 1;
            this.numLast.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLast.ValueChanged += new System.EventHandler(this.numLast_ValueChanged);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(3, 0);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(26, 13);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "first:";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(167, 0);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(26, 13);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "last:";
            // 
            // lblMiz
            // 
            this.lblMiz.AutoSize = true;
            this.lblMiz.Location = new System.Drawing.Point(19, 53);
            this.lblMiz.Name = "lblMiz";
            this.lblMiz.Size = new System.Drawing.Size(80, 13);
            this.lblMiz.TabIndex = 5;
            this.lblMiz.Text = "Filename (*.miz)";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenerate.Location = new System.Drawing.Point(10, 73);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(344, 43);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "GENERATE";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // grpNumbers
            // 
            this.grpNumbers.Controls.Add(this.tableLayoutPanel1);
            this.grpNumbers.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpNumbers.Location = new System.Drawing.Point(10, 5);
            this.grpNumbers.Name = "grpNumbers";
            this.grpNumbers.Padding = new System.Windows.Forms.Padding(8);
            this.grpNumbers.Size = new System.Drawing.Size(344, 68);
            this.grpNumbers.TabIndex = 9;
            this.grpNumbers.TabStop = false;
            this.grpNumbers.Text = "Numbers";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.numLast, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFrom, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.numFirst, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 21);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(328, 39);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 126);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.grpNumbers);
            this.Controls.Add(this.lblMiz);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(287, 165);
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.Text = "DCS - OnBoardNumber Generator";
            ((System.ComponentModel.ISupportInitialize)(this.numFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLast)).EndInit();
            this.grpNumbers.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numFirst;
        private System.Windows.Forms.NumericUpDown numLast;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblMiz;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.GroupBox grpNumbers;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

