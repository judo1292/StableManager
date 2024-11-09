
namespace StableManager.View
{
    partial class SearchPromptPanel
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewPrompt = new System.Windows.Forms.DataGridView();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSearchWords = new System.Windows.Forms.TextBox();
            this.dataGridViewCategory = new System.Windows.Forms.DataGridView();
            this.checkBoxIsNegative = new System.Windows.Forms.CheckBox();
            this.radioButtonPositive = new System.Windows.Forms.RadioButton();
            this.radioButtonNegative = new System.Windows.Forms.RadioButton();
            this.checkBoxIsBookmarkOnly = new System.Windows.Forms.CheckBox();
            this.radioButtonAddPresetPositive = new System.Windows.Forms.RadioButton();
            this.dataGridViewPresetDetailPositive = new System.Windows.Forms.DataGridView();
            this.dataGridViewPresetDetailNegative = new System.Windows.Forms.DataGridView();
            this.buttonPresetSave = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.textBoxPresetName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonAddMain = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrompt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPresetDetailPositive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPresetDetailNegative)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPrompt
            // 
            this.dataGridViewPrompt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPrompt.Location = new System.Drawing.Point(12, 51);
            this.dataGridViewPrompt.Name = "dataGridViewPrompt";
            this.dataGridViewPrompt.RowTemplate.Height = 21;
            this.dataGridViewPrompt.Size = new System.Drawing.Size(739, 358);
            this.dataGridViewPrompt.TabIndex = 1;
            this.dataGridViewPrompt.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPrompt_CellClick);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(403, 18);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "LOAD";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "含む";
            // 
            // textBoxSearchWords
            // 
            this.textBoxSearchWords.Location = new System.Drawing.Point(45, 26);
            this.textBoxSearchWords.Name = "textBoxSearchWords";
            this.textBoxSearchWords.Size = new System.Drawing.Size(100, 19);
            this.textBoxSearchWords.TabIndex = 7;
            this.textBoxSearchWords.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // dataGridViewCategory
            // 
            this.dataGridViewCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCategory.Location = new System.Drawing.Point(757, 51);
            this.dataGridViewCategory.Name = "dataGridViewCategory";
            this.dataGridViewCategory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewCategory.RowTemplate.Height = 21;
            this.dataGridViewCategory.Size = new System.Drawing.Size(257, 358);
            this.dataGridViewCategory.TabIndex = 8;
            // 
            // checkBoxIsNegative
            // 
            this.checkBoxIsNegative.AutoSize = true;
            this.checkBoxIsNegative.Location = new System.Drawing.Point(171, 29);
            this.checkBoxIsNegative.Name = "checkBoxIsNegative";
            this.checkBoxIsNegative.Size = new System.Drawing.Size(69, 16);
            this.checkBoxIsNegative.TabIndex = 10;
            this.checkBoxIsNegative.Text = "ネガティブ";
            this.checkBoxIsNegative.UseVisualStyleBackColor = true;
            this.checkBoxIsNegative.CheckedChanged += new System.EventHandler(this.checkBoxIsNegative_CheckedChanged);
            // 
            // radioButtonPositive
            // 
            this.radioButtonPositive.AutoSize = true;
            this.radioButtonPositive.Checked = true;
            this.radioButtonPositive.Location = new System.Drawing.Point(29, 426);
            this.radioButtonPositive.Name = "radioButtonPositive";
            this.radioButtonPositive.Size = new System.Drawing.Size(68, 16);
            this.radioButtonPositive.TabIndex = 18;
            this.radioButtonPositive.TabStop = true;
            this.radioButtonPositive.Text = "ポジティブ";
            this.radioButtonPositive.UseVisualStyleBackColor = true;
            // 
            // radioButtonNegative
            // 
            this.radioButtonNegative.AutoSize = true;
            this.radioButtonNegative.Location = new System.Drawing.Point(29, 448);
            this.radioButtonNegative.Name = "radioButtonNegative";
            this.radioButtonNegative.Size = new System.Drawing.Size(68, 16);
            this.radioButtonNegative.TabIndex = 19;
            this.radioButtonNegative.Text = "ネガティブ";
            this.radioButtonNegative.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsBookmarkOnly
            // 
            this.checkBoxIsBookmarkOnly.AutoSize = true;
            this.checkBoxIsBookmarkOnly.Location = new System.Drawing.Point(171, 7);
            this.checkBoxIsBookmarkOnly.Name = "checkBoxIsBookmarkOnly";
            this.checkBoxIsBookmarkOnly.Size = new System.Drawing.Size(96, 16);
            this.checkBoxIsBookmarkOnly.TabIndex = 20;
            this.checkBoxIsBookmarkOnly.Text = "ブックマークのみ";
            this.checkBoxIsBookmarkOnly.UseVisualStyleBackColor = true;
            this.checkBoxIsBookmarkOnly.CheckedChanged += new System.EventHandler(this.checkBoxIsBookmarkOnly_CheckedChanged);
            // 
            // radioButtonAddPresetPositive
            // 
            this.radioButtonAddPresetPositive.AutoSize = true;
            this.radioButtonAddPresetPositive.Location = new System.Drawing.Point(122, 445);
            this.radioButtonAddPresetPositive.Name = "radioButtonAddPresetPositive";
            this.radioButtonAddPresetPositive.Size = new System.Drawing.Size(64, 16);
            this.radioButtonAddPresetPositive.TabIndex = 21;
            this.radioButtonAddPresetPositive.Text = "プリセット";
            this.radioButtonAddPresetPositive.UseVisualStyleBackColor = true;
            // 
            // dataGridViewPresetDetailPositive
            // 
            this.dataGridViewPresetDetailPositive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPresetDetailPositive.Location = new System.Drawing.Point(14, 492);
            this.dataGridViewPresetDetailPositive.Name = "dataGridViewPresetDetailPositive";
            this.dataGridViewPresetDetailPositive.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewPresetDetailPositive.RowTemplate.Height = 21;
            this.dataGridViewPresetDetailPositive.Size = new System.Drawing.Size(257, 145);
            this.dataGridViewPresetDetailPositive.TabIndex = 22;
            // 
            // dataGridViewPresetDetailNegative
            // 
            this.dataGridViewPresetDetailNegative.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPresetDetailNegative.Location = new System.Drawing.Point(277, 493);
            this.dataGridViewPresetDetailNegative.Name = "dataGridViewPresetDetailNegative";
            this.dataGridViewPresetDetailNegative.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewPresetDetailNegative.RowTemplate.Height = 21;
            this.dataGridViewPresetDetailNegative.Size = new System.Drawing.Size(257, 145);
            this.dataGridViewPresetDetailNegative.TabIndex = 23;
            // 
            // buttonPresetSave
            // 
            this.buttonPresetSave.Location = new System.Drawing.Point(99, 467);
            this.buttonPresetSave.Name = "buttonPresetSave";
            this.buttonPresetSave.Size = new System.Drawing.Size(75, 23);
            this.buttonPresetSave.TabIndex = 24;
            this.buttonPresetSave.Text = "Save";
            this.buttonPresetSave.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(757, 433);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView3.RowTemplate.Height = 21;
            this.dataGridView3.Size = new System.Drawing.Size(257, 205);
            this.dataGridView3.TabIndex = 25;
            // 
            // textBoxPresetName
            // 
            this.textBoxPresetName.Location = new System.Drawing.Point(277, 467);
            this.textBoxPresetName.Name = "textBoxPresetName";
            this.textBoxPresetName.Size = new System.Drawing.Size(257, 19);
            this.textBoxPresetName.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 472);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "プリセット名";
            // 
            // radioButtonAddMain
            // 
            this.radioButtonAddMain.AutoSize = true;
            this.radioButtonAddMain.Location = new System.Drawing.Point(122, 426);
            this.radioButtonAddMain.Name = "radioButtonAddMain";
            this.radioButtonAddMain.Size = new System.Drawing.Size(47, 16);
            this.radioButtonAddMain.TabIndex = 28;
            this.radioButtonAddMain.Text = "mein";
            this.radioButtonAddMain.UseVisualStyleBackColor = true;
            // 
            // SearchPromptPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 643);
            this.Controls.Add(this.radioButtonAddMain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPresetName);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.buttonPresetSave);
            this.Controls.Add(this.dataGridViewPresetDetailNegative);
            this.Controls.Add(this.dataGridViewPresetDetailPositive);
            this.Controls.Add(this.radioButtonAddPresetPositive);
            this.Controls.Add(this.checkBoxIsBookmarkOnly);
            this.Controls.Add(this.radioButtonNegative);
            this.Controls.Add(this.radioButtonPositive);
            this.Controls.Add(this.checkBoxIsNegative);
            this.Controls.Add(this.dataGridViewCategory);
            this.Controls.Add(this.textBoxSearchWords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.dataGridViewPrompt);
            this.Name = "SearchPromptPanel";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrompt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPresetDetailPositive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPresetDetailNegative)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewPrompt;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSearchWords;
        private System.Windows.Forms.DataGridView dataGridViewCategory;
        private System.Windows.Forms.CheckBox checkBoxIsNegative;
        private System.Windows.Forms.RadioButton radioButtonPositive;
        private System.Windows.Forms.RadioButton radioButtonNegative;
        private System.Windows.Forms.CheckBox checkBoxIsBookmarkOnly;
        private System.Windows.Forms.RadioButton radioButtonAddPresetPositive;
        private System.Windows.Forms.DataGridView dataGridViewPresetDetailPositive;
        private System.Windows.Forms.DataGridView dataGridViewPresetDetailNegative;
        private System.Windows.Forms.Button buttonPresetSave;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.TextBox textBoxPresetName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonAddMain;
    }
}

