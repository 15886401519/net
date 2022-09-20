namespace Retrieve
{
    partial class Retrieve
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.searchGB = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchTxtBox = new System.Windows.Forms.TextBox();
            this.ChemNetCheck = new System.Windows.Forms.CheckBox();
            this.GuiDeChemCheck = new System.Windows.Forms.CheckBox();
            this.ChemicalBookCheck = new System.Windows.Forms.CheckBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.resultGB = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.laddimgTxt = new System.Windows.Forms.Label();
            this.resultNum = new System.Windows.Forms.Label();
            this.notificationGpb = new System.Windows.Forms.GroupBox();
            this.notificationListTxt = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CToExcelBtn = new System.Windows.Forms.Button();
            this.searchGB.SuspendLayout();
            this.resultGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.notificationGpb.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchGB
            // 
            this.searchGB.Controls.Add(this.label1);
            this.searchGB.Controls.Add(this.searchTxtBox);
            this.searchGB.Controls.Add(this.ChemNetCheck);
            this.searchGB.Controls.Add(this.GuiDeChemCheck);
            this.searchGB.Controls.Add(this.ChemicalBookCheck);
            this.searchGB.Controls.Add(this.searchBtn);
            this.searchGB.Location = new System.Drawing.Point(12, 12);
            this.searchGB.Name = "searchGB";
            this.searchGB.Size = new System.Drawing.Size(546, 105);
            this.searchGB.TabIndex = 0;
            this.searchGB.TabStop = false;
            this.searchGB.Text = "搜索";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "关键字：";
            // 
            // searchTxtBox
            // 
            this.searchTxtBox.Location = new System.Drawing.Point(194, 39);
            this.searchTxtBox.Name = "searchTxtBox";
            this.searchTxtBox.Size = new System.Drawing.Size(203, 21);
            this.searchTxtBox.TabIndex = 4;
            // 
            // ChemNetCheck
            // 
            this.ChemNetCheck.AutoSize = true;
            this.ChemNetCheck.Checked = true;
            this.ChemNetCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChemNetCheck.Location = new System.Drawing.Point(16, 66);
            this.ChemNetCheck.Name = "ChemNetCheck";
            this.ChemNetCheck.Size = new System.Drawing.Size(66, 16);
            this.ChemNetCheck.TabIndex = 3;
            this.ChemNetCheck.Text = "ChemNet";
            this.ChemNetCheck.UseVisualStyleBackColor = true;
            // 
            // GuiDeChemCheck
            // 
            this.GuiDeChemCheck.AutoSize = true;
            this.GuiDeChemCheck.Checked = true;
            this.GuiDeChemCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GuiDeChemCheck.Location = new System.Drawing.Point(16, 43);
            this.GuiDeChemCheck.Name = "GuiDeChemCheck";
            this.GuiDeChemCheck.Size = new System.Drawing.Size(78, 16);
            this.GuiDeChemCheck.TabIndex = 2;
            this.GuiDeChemCheck.Text = "GuiDeChem";
            this.GuiDeChemCheck.UseVisualStyleBackColor = true;
            // 
            // ChemicalBookCheck
            // 
            this.ChemicalBookCheck.AutoSize = true;
            this.ChemicalBookCheck.Checked = true;
            this.ChemicalBookCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChemicalBookCheck.Location = new System.Drawing.Point(16, 20);
            this.ChemicalBookCheck.Name = "ChemicalBookCheck";
            this.ChemicalBookCheck.Size = new System.Drawing.Size(102, 16);
            this.ChemicalBookCheck.TabIndex = 1;
            this.ChemicalBookCheck.Text = "Chemical Book";
            this.ChemicalBookCheck.UseVisualStyleBackColor = true;
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(403, 38);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 23);
            this.searchBtn.TabIndex = 0;
            this.searchBtn.Text = "搜索";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // resultGB
            // 
            this.resultGB.Controls.Add(this.dataGridView1);
            this.resultGB.Location = new System.Drawing.Point(12, 142);
            this.resultGB.Name = "resultGB";
            this.resultGB.Size = new System.Drawing.Size(1099, 435);
            this.resultGB.TabIndex = 1;
            this.resultGB.TabStop = false;
            this.resultGB.Text = "结果";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1087, 409);
            this.dataGridView1.TabIndex = 0;
            // 
            // laddimgTxt
            // 
            this.laddimgTxt.AutoSize = true;
            this.laddimgTxt.Location = new System.Drawing.Point(529, 127);
            this.laddimgTxt.Name = "laddimgTxt";
            this.laddimgTxt.Size = new System.Drawing.Size(83, 12);
            this.laddimgTxt.TabIndex = 3;
            this.laddimgTxt.Text = "正在查询中...";
            this.laddimgTxt.Visible = false;
            // 
            // resultNum
            // 
            this.resultNum.AutoSize = true;
            this.resultNum.Location = new System.Drawing.Point(26, 120);
            this.resultNum.Name = "resultNum";
            this.resultNum.Size = new System.Drawing.Size(0, 12);
            this.resultNum.TabIndex = 4;
            // 
            // notificationGpb
            // 
            this.notificationGpb.Controls.Add(this.notificationListTxt);
            this.notificationGpb.Location = new System.Drawing.Point(889, 12);
            this.notificationGpb.Name = "notificationGpb";
            this.notificationGpb.Size = new System.Drawing.Size(216, 120);
            this.notificationGpb.TabIndex = 5;
            this.notificationGpb.TabStop = false;
            this.notificationGpb.Text = "消息提示";
            // 
            // notificationListTxt
            // 
            this.notificationListTxt.FormattingEnabled = true;
            this.notificationListTxt.ItemHeight = 12;
            this.notificationListTxt.Location = new System.Drawing.Point(6, 17);
            this.notificationListTxt.Name = "notificationListTxt";
            this.notificationListTxt.Size = new System.Drawing.Size(204, 100);
            this.notificationListTxt.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CToExcelBtn);
            this.groupBox1.Location = new System.Drawing.Point(564, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 112);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "拓展";
            // 
            // CToExcelBtn
            // 
            this.CToExcelBtn.Location = new System.Drawing.Point(47, 66);
            this.CToExcelBtn.Name = "CToExcelBtn";
            this.CToExcelBtn.Size = new System.Drawing.Size(75, 23);
            this.CToExcelBtn.TabIndex = 0;
            this.CToExcelBtn.Text = "导出数据";
            this.CToExcelBtn.UseVisualStyleBackColor = true;
            this.CToExcelBtn.Click += new System.EventHandler(this.CToExcelBtn_Click);
            // 
            // Retrieve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 589);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.notificationGpb);
            this.Controls.Add(this.resultNum);
            this.Controls.Add(this.laddimgTxt);
            this.Controls.Add(this.resultGB);
            this.Controls.Add(this.searchGB);
            this.Name = "Retrieve";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retrieve";
            this.searchGB.ResumeLayout(false);
            this.searchGB.PerformLayout();
            this.resultGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.notificationGpb.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox searchGB;
        private System.Windows.Forms.GroupBox resultGB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchTxtBox;
        private System.Windows.Forms.CheckBox ChemNetCheck;
        private System.Windows.Forms.CheckBox GuiDeChemCheck;
        private System.Windows.Forms.CheckBox ChemicalBookCheck;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Label laddimgTxt;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label resultNum;
        private System.Windows.Forms.GroupBox notificationGpb;
        private System.Windows.Forms.ListBox notificationListTxt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button CToExcelBtn;
    }
}

