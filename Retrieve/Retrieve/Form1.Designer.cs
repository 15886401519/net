namespace Retrieve
{
    partial class Form1
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
            this.resultNum = new System.Windows.Forms.Label();
            this.laddimgTxt = new System.Windows.Forms.Label();
            this.resultTxt = new System.Windows.Forms.Label();
            this.searchGB.SuspendLayout();
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
            this.searchGB.Size = new System.Drawing.Size(577, 97);
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
            this.resultGB.Location = new System.Drawing.Point(12, 142);
            this.resultGB.Name = "resultGB";
            this.resultGB.Size = new System.Drawing.Size(577, 271);
            this.resultGB.TabIndex = 1;
            this.resultGB.TabStop = false;
            this.resultGB.Text = "结果";
            // 
            // resultNum
            // 
            this.resultNum.AutoSize = true;
            this.resultNum.Location = new System.Drawing.Point(28, 116);
            this.resultNum.Name = "resultNum";
            this.resultNum.Size = new System.Drawing.Size(0, 12);
            this.resultNum.TabIndex = 2;
            // 
            // laddimgTxt
            // 
            this.laddimgTxt.AutoSize = true;
            this.laddimgTxt.Location = new System.Drawing.Point(244, 122);
            this.laddimgTxt.Name = "laddimgTxt";
            this.laddimgTxt.Size = new System.Drawing.Size(83, 12);
            this.laddimgTxt.TabIndex = 3;
            this.laddimgTxt.Text = "正在查询中...";
            // 
            // resultTxt
            // 
            this.resultTxt.AutoSize = true;
            this.resultTxt.Location = new System.Drawing.Point(28, 116);
            this.resultTxt.Name = "resultTxt";
            this.resultTxt.Size = new System.Drawing.Size(0, 12);
            this.resultTxt.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 425);
            this.Controls.Add(this.resultTxt);
            this.Controls.Add(this.laddimgTxt);
            this.Controls.Add(this.resultNum);
            this.Controls.Add(this.resultGB);
            this.Controls.Add(this.searchGB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.searchGB.ResumeLayout(false);
            this.searchGB.PerformLayout();
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
        private System.Windows.Forms.Label resultNum;
        private System.Windows.Forms.Label laddimgTxt;
        private System.Windows.Forms.Label resultTxt;
    }
}

