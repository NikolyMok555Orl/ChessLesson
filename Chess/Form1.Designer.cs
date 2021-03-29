namespace Chess
{
    partial class FormChess
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanelChess = new System.Windows.Forms.TableLayoutPanel();
            this.btbRestart = new System.Windows.Forms.Button();
            this.labalTurn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tableLayoutPanelChess
            // 
            this.tableLayoutPanelChess.ColumnCount = 8;
            this.tableLayoutPanelChess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelChess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelChess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelChess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelChess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelChess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelChess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelChess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelChess.Location = new System.Drawing.Point(13, 13);
            this.tableLayoutPanelChess.Name = "tableLayoutPanelChess";
            this.tableLayoutPanelChess.RowCount = 8;
            this.tableLayoutPanelChess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelChess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelChess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelChess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelChess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelChess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelChess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelChess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelChess.Size = new System.Drawing.Size(500, 500);
            this.tableLayoutPanelChess.TabIndex = 0;
            // 
            // btbRestart
            // 
            this.btbRestart.BackColor = System.Drawing.Color.Chocolate;
            this.btbRestart.Cursor = System.Windows.Forms.Cursors.Default;
            this.btbRestart.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btbRestart.FlatAppearance.BorderSize = 3;
            this.btbRestart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btbRestart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btbRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btbRestart.Location = new System.Drawing.Point(519, 13);
            this.btbRestart.Name = "btbRestart";
            this.btbRestart.Size = new System.Drawing.Size(173, 64);
            this.btbRestart.TabIndex = 1;
            this.btbRestart.Text = "Заново";
            this.btbRestart.UseVisualStyleBackColor = false;
            this.btbRestart.Click += new System.EventHandler(this.btbStart_Click);
            // 
            // labalTurn
            // 
            this.labalTurn.AutoSize = true;
            this.labalTurn.Location = new System.Drawing.Point(519, 84);
            this.labalTurn.Name = "labalTurn";
            this.labalTurn.Size = new System.Drawing.Size(26, 13);
            this.labalTurn.TabIndex = 2;
            this.labalTurn.Text = "Ход";
            // 
            // FormChess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 531);
            this.Controls.Add(this.labalTurn);
            this.Controls.Add(this.btbRestart);
            this.Controls.Add(this.tableLayoutPanelChess);
            this.Name = "FormChess";
            this.Text = "Шахматы";
            this.Load += new System.EventHandler(this.FormChess_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelChess;
        private System.Windows.Forms.Button btbRestart;
        private System.Windows.Forms.Label labalTurn;
    }
}

