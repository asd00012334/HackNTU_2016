namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.switcherButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.dialog = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.diagBox = new System.Windows.Forms.TextBox();
            this.diagnal = new System.Windows.Forms.Label();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // switcherButton
            // 
            this.switcherButton.BackColor = System.Drawing.Color.Black;
            this.switcherButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.switcherButton.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.switcherButton.ForeColor = System.Drawing.Color.White;
            this.switcherButton.Location = new System.Drawing.Point(173, 315);
            this.switcherButton.Name = "switcherButton";
            this.switcherButton.Size = new System.Drawing.Size(99, 41);
            this.switcherButton.TabIndex = 0;
            this.switcherButton.Text = "Start";
            this.switcherButton.UseVisualStyleBackColor = false;
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.Black;
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetButton.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.resetButton.ForeColor = System.Drawing.Color.White;
            this.resetButton.Location = new System.Drawing.Point(293, 315);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(99, 41);
            this.resetButton.TabIndex = 1;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = false;
            // 
            // dialog
            // 
            this.dialog.BackColor = System.Drawing.SystemColors.InfoText;
            this.dialog.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialog.ForeColor = System.Drawing.Color.White;
            this.dialog.Location = new System.Drawing.Point(12, 315);
            this.dialog.Multiline = true;
            this.dialog.Name = "dialog";
            this.dialog.Size = new System.Drawing.Size(155, 141);
            this.dialog.TabIndex = 2;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(380, 292);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // diagBox
            // 
            this.diagBox.BackColor = System.Drawing.Color.Black;
            this.diagBox.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.diagBox.ForeColor = System.Drawing.Color.White;
            this.diagBox.Location = new System.Drawing.Point(273, 429);
            this.diagBox.Name = "diagBox";
            this.diagBox.Size = new System.Drawing.Size(119, 29);
            this.diagBox.TabIndex = 4;
            // 
            // diagnal
            // 
            this.diagnal.AutoSize = true;
            this.diagnal.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.diagnal.ForeColor = System.Drawing.SystemColors.Control;
            this.diagnal.Location = new System.Drawing.Point(173, 431);
            this.diagnal.Name = "diagnal";
            this.diagnal.Size = new System.Drawing.Size(94, 20);
            this.diagnal.TabIndex = 5;
            this.diagnal.Text = "Screen Size";
            // 
            // loadButton
            // 
            this.loadButton.BackColor = System.Drawing.Color.Black;
            this.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadButton.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.loadButton.ForeColor = System.Drawing.Color.White;
            this.loadButton.Location = new System.Drawing.Point(173, 374);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(99, 41);
            this.loadButton.TabIndex = 6;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = false;
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Black;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(293, 374);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(99, 41);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(405, 468);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.diagnal);
            this.Controls.Add(this.diagBox);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.dialog);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.switcherButton);
            this.Name = "Form1";
            this.Text = "Intelligent Eye-Screen Protector";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button switcherButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.TextBox dialog;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox diagBox;
        private System.Windows.Forms.Label diagnal;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
    }
}

