namespace Lab01
{
    partial class ExchangeRate
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnLoad = new Button();
            DataCurrencyTable = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DataCurrencyTable).BeginInit();
            SuspendLayout();
            // 
            // BtnLoad
            // 
            BtnLoad.Location = new Point(12, 12);
            BtnLoad.Name = "BtnLoad";
            BtnLoad.Size = new Size(132, 38);
            BtnLoad.TabIndex = 0;
            BtnLoad.Text = "Load Data";
            BtnLoad.UseVisualStyleBackColor = true;
            BtnLoad.Click += BtnLoadData_Click;
            // 
            // DataCurrencyTable
            // 
            DataCurrencyTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataCurrencyTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataCurrencyTable.Location = new Point(12, 56);
            DataCurrencyTable.Name = "DataCurrencyTable";
            DataCurrencyTable.RowTemplate.Height = 25;
            DataCurrencyTable.Size = new Size(562, 357);
            DataCurrencyTable.TabIndex = 1;
            // 
            // ExchangeRate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(586, 425);
            Controls.Add(DataCurrencyTable);
            Controls.Add(BtnLoad);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ExchangeRate";
            Text = "Exchange Rates";
            ((System.ComponentModel.ISupportInitialize)DataCurrencyTable).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button BtnLoad;
        private DataGridView DataCurrencyTable;
    }
}