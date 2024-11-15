﻿
namespace StableManager.View
{
    partial class PromptRegister
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxPromptEn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPromptJp = new System.Windows.Forms.TextBox();
            this.textBoxMemo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxIsNegative = new System.Windows.Forms.CheckBox();
            this.checkBoxIsBookmark = new System.Windows.Forms.CheckBox();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(51, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "登録";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxPromptEn
            // 
            this.textBoxPromptEn.Location = new System.Drawing.Point(241, 130);
            this.textBoxPromptEn.Name = "textBoxPromptEn";
            this.textBoxPromptEn.Size = new System.Drawing.Size(164, 19);
            this.textBoxPromptEn.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "プロンプト";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "意味";
            // 
            // textBoxPromptJp
            // 
            this.textBoxPromptJp.Location = new System.Drawing.Point(241, 161);
            this.textBoxPromptJp.Name = "textBoxPromptJp";
            this.textBoxPromptJp.Size = new System.Drawing.Size(164, 19);
            this.textBoxPromptJp.TabIndex = 4;
            // 
            // textBoxMemo
            // 
            this.textBoxMemo.Location = new System.Drawing.Point(241, 186);
            this.textBoxMemo.Name = "textBoxMemo";
            this.textBoxMemo.Size = new System.Drawing.Size(164, 19);
            this.textBoxMemo.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "メモ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "カテゴリー";
            // 
            // checkBoxIsNegative
            // 
            this.checkBoxIsNegative.AutoSize = true;
            this.checkBoxIsNegative.Location = new System.Drawing.Point(172, 254);
            this.checkBoxIsNegative.Name = "checkBoxIsNegative";
            this.checkBoxIsNegative.Size = new System.Drawing.Size(69, 16);
            this.checkBoxIsNegative.TabIndex = 9;
            this.checkBoxIsNegative.Text = "ネガティブ";
            this.checkBoxIsNegative.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsBookmark
            // 
            this.checkBoxIsBookmark.AutoSize = true;
            this.checkBoxIsBookmark.Location = new System.Drawing.Point(247, 254);
            this.checkBoxIsBookmark.Name = "checkBoxIsBookmark";
            this.checkBoxIsBookmark.Size = new System.Drawing.Size(75, 16);
            this.checkBoxIsBookmark.TabIndex = 10;
            this.checkBoxIsBookmark.Text = "お気に入り";
            this.checkBoxIsBookmark.UseVisualStyleBackColor = true;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(241, 211);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(121, 20);
            this.comboBoxCategory.TabIndex = 11;
            // 
            // PromptRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 364);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.checkBoxIsBookmark);
            this.Controls.Add(this.checkBoxIsNegative);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxMemo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPromptJp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPromptEn);
            this.Controls.Add(this.button1);
            this.Name = "PromptRegister";
            this.Text = "PromptRegister";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxPromptEn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPromptJp;
        private System.Windows.Forms.TextBox textBoxMemo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxIsNegative;
        private System.Windows.Forms.CheckBox checkBoxIsBookmark;
        private System.Windows.Forms.ComboBox comboBoxCategory;
    }
}