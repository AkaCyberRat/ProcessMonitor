namespace App.Forms
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this._comboBoxInterval = new System.Windows.Forms.ComboBox();
            this._buttonKill = new System.Windows.Forms.Button();
            this._buttonMore = new System.Windows.Forms.Button();
            this.mainFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._buttonPause = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _dataGridView
            // 
            this._dataGridView.AllowUserToAddRows = false;
            this._dataGridView.AllowUserToDeleteRows = false;
            this._dataGridView.AllowUserToOrderColumns = true;
            this._dataGridView.AllowUserToResizeRows = false;
            this._dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this._dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this._dataGridView.Location = new System.Drawing.Point(12, 39);
            this._dataGridView.MultiSelect = false;
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.ReadOnly = true;
            this._dataGridView.RowHeadersVisible = false;
            this._dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this._dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this._dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dataGridView.Size = new System.Drawing.Size(255, 355);
            this._dataGridView.TabIndex = 0;
            this._dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnTableClick);
            this._dataGridView.Scroll += new System.Windows.Forms.ScrollEventHandler(this.OnTableScroll);
            // 
            // _comboBoxInterval
            // 
            this._comboBoxInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxInterval.Location = new System.Drawing.Point(100, 11);
            this._comboBoxInterval.Name = "_comboBoxInterval";
            this._comboBoxInterval.Size = new System.Drawing.Size(167, 21);
            this._comboBoxInterval.TabIndex = 1;
            this._comboBoxInterval.SelectedIndexChanged += new System.EventHandler(this.OnComboBoxIntervalChange);
            // 
            // _buttonKill
            // 
            this._buttonKill.Enabled = false;
            this._buttonKill.Location = new System.Drawing.Point(146, 399);
            this._buttonKill.Name = "_buttonKill";
            this._buttonKill.Size = new System.Drawing.Size(121, 23);
            this._buttonKill.TabIndex = 2;
            this._buttonKill.Text = "Kill";
            this._buttonKill.UseVisualStyleBackColor = true;
            this._buttonKill.Click += new System.EventHandler(this.OnKillButtonClick);
            // 
            // _buttonMore
            // 
            this._buttonMore.Enabled = false;
            this._buttonMore.Location = new System.Drawing.Point(12, 399);
            this._buttonMore.Name = "_buttonMore";
            this._buttonMore.Size = new System.Drawing.Size(121, 23);
            this._buttonMore.TabIndex = 3;
            this._buttonMore.Text = "More";
            this._buttonMore.UseVisualStyleBackColor = true;
            this._buttonMore.Click += new System.EventHandler(this.OnMoreButtonClick);
            // 
            // mainFormBindingSource
            // 
            this.mainFormBindingSource.DataSource = typeof(App.Forms.MainForm);
            // 
            // _buttonPause
            // 
            this._buttonPause.Location = new System.Drawing.Point(12, 10);
            this._buttonPause.Name = "_buttonPause";
            this._buttonPause.Size = new System.Drawing.Size(75, 23);
            this._buttonPause.TabIndex = 4;
            this._buttonPause.Text = "Pause";
            this._buttonPause.UseVisualStyleBackColor = true;
            this._buttonPause.Click += new System.EventHandler(this.OnPauseButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 432);
            this.Controls.Add(this._buttonPause);
            this.Controls.Add(this._buttonMore);
            this.Controls.Add(this._buttonKill);
            this.Controls.Add(this._comboBoxInterval);
            this.Controls.Add(this._dataGridView);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Process monitor";
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.ComboBox _comboBoxInterval;
        private System.Windows.Forms.BindingSource mainFormBindingSource;
        private System.Windows.Forms.Button _buttonKill;
        private System.Windows.Forms.Button _buttonMore;
        private System.Windows.Forms.Button _buttonPause;
    }
}

