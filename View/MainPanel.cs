using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace StableManager.View
{
    using Beans;
    public partial class MainPanel : Form
    {
        // コントロール操作以外のメソッドはこっちでやる
        PrePayload settings = PrePayload.Instance;
        StableManager.Model.MainPanel model = new StableManager.Model.MainPanel();
        #region Method
        private void LoadConfig()
        {
            checkBoxIsActiveLora.Checked = settings.IsActiveLora;
            checkBoxRandomLora.Checked = settings.IsActiveLora;
            checkBoxRandomCfg.Checked = settings.IsRandomModeCfg;
            checkBoxRandomDenoise.Checked = settings.IsRandomModeDenoise;
            checkBoxRandomModel.Checked = settings.IsRandomModeModel;
            checkBoxRandomNegative.Checked = settings.IsRandomModeNegativePrompt;
            checkBoxRandomPositive.Checked = settings.IsRandomModePositivePrompt;
            checkBoxRandomStep.Checked = settings.IsRandomModeStep;
            trackBarImageSizeH.Value = settings.Height;
            Console.WriteLine(settings.Height);
            this.Refresh();

        }
        public MainPanel()
        {
            InitializeComponent();
            InitializeMethod();
        }
        /// <summary>
        /// 開始時初期設定
        /// </summary>
        private void InitializeMethod()
        {
            LoadConfig();
            model.ShowSearchPromptPanel();
            GridInitialize();
            LoadModelList();
            pictureBoxPreview.AllowDrop = true;
            model.RoopStart();
            LoadSumplerList();
            //ShuffleCategory();

        }
        /// <summary>
        /// DataGridView初期設定
        /// </summary>
        private void GridInitialize()
        {
            //プログラム共通のstaticプロンプトリストをメイン画面のグリッドビューのソースとして適用
            dataGridViewPositive.DataSource = null;
            dataGridViewNegative.DataSource = null;
            dataGridViewPositive.DataSource = Beans.GridPromptList.positiveTableMain;
            dataGridViewNegative.DataSource = Beans.GridPromptList.negativeTableMain;


            // グリッドから除外する項目リスト
            string[] notVisibleList = new string[] { "memo", "Id", "Category", "IsNegative", "IsBookmark" };
            // グリッドの幅を調整する項目リスト
            List<(string ColumnName, int Width)> columnWidthPairs = new List<(string, int)>
            {
                ("IsActive",30),
                ("IsRandom",30),
                ("PrimaryLevel",30)
            };

            // グリッドから項目を消す、幅調整
            foreach (string notVisivle in notVisibleList)
            {
                dataGridViewPositive.Columns[$"{notVisivle}"].Visible = false;
                dataGridViewNegative.Columns[$"{notVisivle}"].Visible = false;
            }
            foreach (var col in columnWidthPairs)
            {
                dataGridViewPositive.Columns[col.ColumnName].Width = col.Width;
                dataGridViewNegative.Columns[col.ColumnName].Width = col.Width;
            }
            model.SoatPrompt(true);
            model.SoatPrompt(false);
            dataGridViewPositive.Refresh();
            dataGridViewNegative.Refresh();
        }
        private void ShuffleCategory()
        {
            //var db = new Functions.ConnectDB.MsSql(@"Server=192.168.10.10;Port=3306;Uid=sa;Pwd=judo11822564;Database=stable_diffusion_manager");
            //var sql = "SELECT category_id,category_name FROM categorys WHERE 1 = 1 ";
            //var reader = db.Fetch(sql);
            //while (reader.Read())
            //{
            //    shuffleCategoryTable.Add(new ShuffleCategoryTable() { isChecked = CheckState.Unchecked, id = reader.GetInt32(0), name = reader.GetString(1) });
            //}
            //dataGridViewShuffleCategory.DataSource = shuffleCategoryTable;
            //reader.Close();
            //db.CloseConnection();
        }


        private void LoadModelList()
        {
            dataGridViewModel.DataSource = null;
            comboBoxModel.DataSource = null;
            var modelTable = model.GetModelList();
            List<string> modelList = new List<string>();
            if (modelTable != null)
            {
                dataGridViewModel.DataSource = modelTable;

                foreach (var model in modelTable)
                {
                    modelList.Add(model.Name);
                }
                comboBoxModel.DataSource = modelList;
            }
            LoadSumplerList();
        }
        private void LoadSumplerList()
        {
            comboBoxSumple.DataSource = null;
            comboBoxSumple.DataSource = new Beans.Sumplings().SumplingList;
        }
        #endregion

        #region Event
        private void numericUpDown_seed_ValueChanged(object sender, EventArgs e)
        {
            settings.Seed = numericUpDown_seed.Value;
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (settings.IsActiveRoop)
            {
                buttonStart.Text = "START";
                settings.IsActiveRoop = false;
            }
            else
            {
                buttonStart.Text = "STOP";
                settings.IsActiveRoop = true;

            }
        }
        private void pictureBoxPreview_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files != null && files.Length > 0)
                {
                    string imagePath = files[0];
                    pictureBoxPreview.ImageLocation = imagePath;
                    byte[] imageBytes = File.ReadAllBytes(imagePath);
                    string base64String = Convert.ToBase64String(imageBytes);
                    settings.I2iImages = new string[] { base64String };
                    settings.IsActiveBatchMode = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("エラー　pictureBox1_DragDrop　Form3 ");
            }
        }
        private void pictureBoxPreview_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void checkBoxImg2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxImg2.Checked) settings.IsI2Imode = true;
            else settings.IsI2Imode = false;
        }
        private void buttonUrlLoad_Click(object sender, EventArgs e)
        {
            if (textBoxBatch.Text == "") return;


            settings.IsActiveBatchMode = true;
            settings.BatchPath = textBoxBatch.Text;


        }
        private void comboBoxModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxModel.SelectedItem == null) return;
            settings.SelectedModel = comboBoxModel.SelectedItem.ToString();
        }
        private void checkBoxRandomModel_CheckedChanged(object sender, EventArgs e)
        {
            settings.IsRandomModeModel = checkBoxRandomModel.Checked;
        }
        private void buttonCategoryShuffleChange_Click(object sender, EventArgs e)
        {
            //switch (ShuffleCategoryState)
            //{
            //    case CheckState.Checked:
            //        {
            //            foreach (var cat in shuffleCategoryTable)
            //            {
            //                cat.isChecked = CheckState.Indeterminate;
            //            }
            //            ShuffleCategoryState = CheckState.Indeterminate;
            //            break;
            //        }
            //    case CheckState.Unchecked:
            //        {
            //            foreach (var cat in shuffleCategoryTable)
            //            {
            //                cat.isChecked = CheckState.Checked;
            //            }
            //            ShuffleCategoryState = CheckState.Checked;
            //            break;
            //        }
            //    case CheckState.Indeterminate:
            //        {
            //            foreach (var cat in shuffleCategoryTable)
            //            {
            //                cat.isChecked = CheckState.Unchecked;
            //            }
            //            ShuffleCategoryState = CheckState.Unchecked;
            //            break;
            //        }

            //    default:
            //        {
            //            break;
            //        }
            //}
            //dataGridViewShuffleCategory.Refresh();
        }
        private void プロンプトウインドウToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchPromptPanel promptPanel = new SearchPromptPanel();
            promptPanel.Show();
        }

        private void buttonLoadOverwritePositive_Click(object sender, EventArgs e)
        {
            model.LoadTextBox(true, textBoxPositive.Text, true);
            GridInitialize();
        }

        private void buttonLoadPositive_Click(object sender, EventArgs e)
        {
            model.LoadTextBox(true, textBoxPositive.Text, false);
        }

        private void buttonLoadOverwriteNegative_Click(object sender, EventArgs e)
        {
            model.LoadTextBox(false, textBoxNegative.Text, true);
            GridInitialize();
        }

        private void buttonLoadNegative_Click(object sender, EventArgs e)
        {
            model.LoadTextBox(false, textBoxNegative.Text, false);
            GridInitialize();
        }

        private void プロンプト管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PromptRegister register = new PromptRegister();
            register.Show();
        }

        private void buttonReloadModel_Click(object sender, EventArgs e)
        {
            LoadModelList();
        }

        private void buttonAllCheckModel_Click(object sender, EventArgs e)
        {
            model.AllCheckModel();
            dataGridViewModel.Refresh();
        }

        private void 現在の設定値を保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model.SaveConfig();
        }

        private void 設定を読み込みToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model.LoadConfig();
            settings = PrePayload.Instance;
            LoadConfig();
        }

        private void checkBoxIsRandomGenerate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIsRandomGenerate.Checked) settings.IsActiveRandomGenerateMode = true;
            else settings.IsActiveRandomGenerateMode = false;
        }

        private void プレビューウインドウToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreviewPanel panel = new PreviewPanel();
            panel.Show();
        }
        #region positivPrompt
        private void checkBoxRandomModePrimaryLevelPositive_CheckedChanged(object sender, EventArgs e)
        {
            settings.IsRandomModePrimaryLevelPositive = checkBoxRandomModePrimaryLevelPositive.Checked;
        }
        private void checkBoxRandomPositive_CheckedChanged(object sender, EventArgs e)
        {
            settings.IsRandomModePositivePrompt = checkBoxRandomPositive.Checked;
        }
        private void buttonAllCheckEnablePositive_Click(object sender, EventArgs e)
        {
            model.AllCheckEnable(true);
            dataGridViewPositive.Refresh();
        }
        private void buttonAllCheckRandomPositive_Click(object sender, EventArgs e)
        {
            model.AllCheckRandomActive(true);
            dataGridViewPositive.Refresh();
        }
        private void buttonReloadPositive_Click(object sender, EventArgs e)
        {
            model.Translation(true);
            GridInitialize();

        }


        #endregion
        #region negativePrompt
        private void checkBoxRandomModePrimaryLevelNegative_CheckedChanged(object sender, EventArgs e)
        {
            settings.IsRandomModePrimaryLevelNegative = checkBoxRandomModePrimaryLevelNegative.Checked;
        }
        private void checkBoxRandomNegative_CheckedChanged(object sender, EventArgs e)
        {
            settings.IsRandomModeNegativePrompt = checkBoxRandomNegative.Checked;
        }
        private void buttonAllCheckEnableNegative_Click(object sender, EventArgs e)
        {
            model.AllCheckEnable(false);
            dataGridViewPositive.Refresh();
            dataGridViewNegative.Refresh();
        }
        private void buttonAllcheckRandomNegative_Click(object sender, EventArgs e)
        {
            model.AllCheckRandomActive(false);
            dataGridViewNegative.Refresh();
        }
        private void buttonReloadNegative_Click(object sender, EventArgs e)
        {
            model.Translation(false);
            GridInitialize();

        }


        #endregion
        #region Lora
        private void checkBoxRandomLora_CheckedChanged(object sender, EventArgs e)
        {
            settings.IsRandomModeLora = checkBoxRandomLora.Checked;
        }
        private void numericUpDownLoraMax_ValueChanged(object sender, EventArgs e)
        {
            settings.LoraNumMax = (double)numericUpDownLoraMax.Value;
            if (settings.LoraNumMin >= settings.LoraNumMax)
            {
                settings.LoraNumMin = settings.LoraNumMax - 0.01;
                numericUpDownLoraMin.Value = (decimal)settings.LoraNumMin;
            }
        }
        private void numericUpDownLoraMin_ValueChanged(object sender, EventArgs e)
        {
            settings.LoraNumMin = (double)numericUpDownLoraMin.Value;
            if (settings.LoraNumMin >= settings.LoraNumMax)
            {
                settings.LoraNumMax = settings.LoraNumMin + 0.01;
                numericUpDownLoraMax.Value = (decimal)settings.LoraNumMax;
            }
        }
        private void textBoxLoraName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxLoraName.Text != "")
            {
                settings.LoraName = textBoxLoraName.Text;
            }
        }
        private void checkBoxIsActiveLora_CheckedChanged(object sender, EventArgs e)
        {
            settings.IsActiveLora = checkBoxIsActiveLora.Checked;
        }
        #endregion
        #region CFG
        private void checkBoxRandomCfg_CheckedChanged(object sender, EventArgs e)
        {
            settings.IsRandomModeCfg = checkBoxRandomCfg.Checked;
            if (checkBoxRandomCfg.Checked) trackBar_CfgMin.Enabled = true;
            else trackBar_CfgMin.Enabled = false;
        }
        private void trackBar_CfgMax_Scroll(object sender, EventArgs e)
        {
            settings.Cfg_scale_Max = trackBar_CfgMax.Value;
            numericUpDownCfgMax.Value = trackBar_CfgMax.Value;
            if (settings.Cfg_scale_Min >= settings.Cfg_scale_Max)
            {
                settings.Cfg_scale_Min = settings.Cfg_scale_Max - 1;
                trackBar_CfgMin.Value = settings.Cfg_scale_Max - 1;
                numericUpDownCfgMin.Value = settings.Cfg_scale_Max - 1;
            }

        }
        private void numericUpDownCfgMax_ValueChanged(object sender, EventArgs e)
        {
            settings.Cfg_scale_Max = ((int)numericUpDownCfgMax.Value);
            trackBar_CfgMax.Value = settings.Cfg_scale_Max;
            if (settings.Cfg_scale_Min >= settings.Cfg_scale_Max)
            {
                settings.Cfg_scale_Min = settings.Cfg_scale_Max - 1;
                trackBar_CfgMin.Value = settings.Cfg_scale_Max - 1;
                numericUpDownCfgMin.Value = settings.Cfg_scale_Max - 1;
            }

        }
        private void trackBar_CfgMin_Scroll(object sender, EventArgs e)
        {
            settings.Cfg_scale_Min = trackBar_CfgMin.Value;
            numericUpDownCfgMin.Value = trackBar_CfgMin.Value;
            if (settings.Cfg_scale_Min >= settings.Cfg_scale_Max)
            {
                settings.Cfg_scale_Max = settings.Cfg_scale_Min + 1;
                trackBar_CfgMax.Value = settings.Cfg_scale_Min + 1;
                numericUpDownCfgMax.Value = settings.Cfg_scale_Min + 1;
            }
        }
        private void numericUpDownCfgMin_ValueChanged(object sender, EventArgs e)
        {
            settings.Cfg_scale_Min = ((int)numericUpDownCfgMin.Value);
            trackBar_CfgMin.Value = trackBar_CfgMin.Value;
            if (settings.Cfg_scale_Min >= settings.Cfg_scale_Max)
            {
                settings.Cfg_scale_Max = settings.Cfg_scale_Min + 1;
                trackBar_CfgMax.Value = settings.Cfg_scale_Min + 1;
                numericUpDownCfgMax.Value = settings.Cfg_scale_Min + 1;
            }
            //cfgNumTaskMin = ((int)numericUpDownCfgMin.Value);
            //trackBar_CfgMin.Value = cfgNumTaskMin;
            //if (cfgNumTaskMin >= cfgNumTaskMax)
            //{
            //    cfgNumTaskMax = cfgNumTaskMin + 1;
            //    trackBar_CfgMax.Value = cfgNumTaskMin + 1;
            //    numericUpDownCfgMax.Value = cfgNumTaskMin + 1;
            //}
        }
        #endregion
        #region Denoise
        private void checkBoxRandomDenoise_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRandomDenoise.Checked)
            {
                settings.IsRandomModeDenoise = true;
                trackBar_DenoiseMin.Enabled = true;
            }

            else
            {

                settings.IsRandomModeDenoise = false;
                trackBar_DenoiseMin.Enabled = false;
            }
        }
        private void trackBar_DenoiseMax_Scroll(object sender, EventArgs e)
        {
            settings.Denoising_Max = trackBar_DenoiseMax.Value;
            numericUpDown_DenoiseMax.Value = settings.Denoising_Max / 100.0M;
            if (settings.Denoising_Min >= settings.Denoising_Max)
            {
                settings.Denoising_Min = settings.Denoising_Max - 1;
                trackBar_DenoiseMin.Value = trackBar_DenoiseMax.Value - 1;
                numericUpDown_DenoiseMin.Value = settings.Denoising_Min / 100.0M;
            }
        }
        private void numericUpDown_DenoiseMax_ValueChanged(object sender, EventArgs e)
        {
            settings.Denoising_Max = (int)(numericUpDown_DenoiseMax.Value * 100.0M);
            trackBar_DenoiseMax.Value = (int)settings.Denoising_Max;
            if (settings.Denoising_Min >= settings.Denoising_Max)
            {
                settings.Denoising_Min = settings.Denoising_Max - 1;
                trackBar_DenoiseMin.Value = (int)settings.Denoising_Max - 1;
                numericUpDown_DenoiseMin.Value = (decimal)settings.Denoising_Min / 100.0M;
            }
        }
        private void trackBar_DenoiseMin_Scroll(object sender, EventArgs e)
        {
            settings.Denoising_Min = trackBar_DenoiseMin.Value;
            numericUpDown_DenoiseMin.Value = settings.Denoising_Min / 100.0M;
            if (settings.Denoising_Min >= settings.Denoising_Max)
            {
                settings.Denoising_Max = settings.Denoising_Min + 1;
                trackBar_DenoiseMax.Value = (int)settings.Denoising_Max + 1;
                numericUpDown_DenoiseMax.Value = settings.Denoising_Max / 100.0M;
            }
        }
        private void numericUpDown_DenoiseMin_ValueChanged(object sender, EventArgs e)
        {
            settings.Denoising_Min = (int)(numericUpDown_DenoiseMin.Value * 100.0M);
            trackBar_DenoiseMin.Value = (int)settings.Denoising_Min;
            if (settings.Denoising_Min >= settings.Denoising_Max)
            {
                settings.Denoising_Max = settings.Denoising_Min + 1;
                trackBar_DenoiseMax.Value = (int)settings.Denoising_Min + 1;
                numericUpDown_DenoiseMax.Value = (decimal)settings.Denoising_Max / 100.0M;
            }
        }
        #endregion
        #region ステップ数
        private void checkBoxRandomStep_CheckedChanged(object sender, EventArgs e)
        {
            settings.IsRandomModeStep = checkBoxRandomStep.Checked;
            if (checkBoxRandomStep.Checked)
            {
                trackBar_stepMin.Enabled = true;
                numericUpDownStepMin.Enabled = true;
            }

            else
            {
                trackBar_stepMin.Enabled = false;
                numericUpDownStepMin.Enabled = false;
            }
        }
        private void trackBar_stepMax_Scroll(object sender, EventArgs e)
        {
            settings.Steps_Max = trackBar_stepMax.Value;
            numericUpDownStepMax.Value = trackBar_stepMax.Value;
            if (settings.Steps_Min >= settings.Steps_Max)
            {
                settings.Steps_Min = settings.Steps_Max - 1;
                trackBar_stepMin.Value = settings.Steps_Max - 1;
                numericUpDownStepMin.Value = settings.Steps_Max - 1;
            }
        }
        private void trackBar_stepMin_Scroll(object sender, EventArgs e)
        {
            settings.Steps_Min = trackBar_stepMin.Value;
            numericUpDownStepMin.Value = trackBar_stepMin.Value;
            if (settings.Steps_Min >= settings.Steps_Max)
            {
                settings.Steps_Max = settings.Steps_Min + 1;
                trackBar_stepMax.Value = settings.Steps_Min + 1;
                numericUpDownStepMax.Value = settings.Steps_Min + 1;
            }
        }
        private void numericUpDownStepMax_ValueChanged(object sender, EventArgs e)
        {
            settings.Steps_Max = ((int)numericUpDownStepMax.Value);
            trackBar_stepMax.Value = settings.Steps_Max;
            if (settings.Steps_Min >= settings.Steps_Max)
            {
                settings.Steps_Min = settings.Steps_Max - 1;
                trackBar_stepMin.Value = settings.Steps_Max - 1;
                numericUpDownStepMin.Value = settings.Steps_Max - 1;
            }

        }
        private void numericUpDownStepMin_ValueChanged(object sender, EventArgs e)
        {
            settings.Steps_Min = ((int)numericUpDownStepMin.Value);
            trackBar_stepMin.Value = trackBar_stepMin.Value;
            if (settings.Steps_Min >= settings.Steps_Max)
            {
                settings.Steps_Max = settings.Steps_Min + 1;
                trackBar_stepMax.Value = settings.Steps_Min + 1;
                numericUpDownStepMax.Value = settings.Steps_Min + 1;
            }
        }
        #endregion
        #region 画像サイズ
        private void checkBoxRandomWH_CheckedChanged(object sender, EventArgs e)
        {
            settings.IsRandomModeWH = checkBoxRandomWH.Checked;
        }
        private void buttonImageSizeChange_Click(object sender, EventArgs e)
        {
            var TmpH = settings.Height;
            var TmpW = settings.Width;
            settings.Height = TmpW;
            settings.Width = TmpH;
            trackBarImageSizeW.Value = TmpH;
            trackBarImageSizeH.Value = TmpW;
            numericUpDownImageSizeW.Value = TmpH;
            numericUpDownImageSizeH.Value = TmpW;
        }
        private void numericUpDownImageSizeH_ValueChanged(object sender, EventArgs e)
        {
            settings.Height = (int)numericUpDownImageSizeH.Value;
            trackBarImageSizeH.Value = (int)numericUpDownImageSizeH.Value;
        }
        private void trackBarImageSizeH_Scroll(object sender, EventArgs e)
        {
            settings.Height = trackBarImageSizeH.Value;
            numericUpDownImageSizeH.Value = trackBarImageSizeH.Value;
        }
        private void numericUpDownImageSizeW_ValueChanged(object sender, EventArgs e)
        {
            settings.Width = (int)numericUpDownImageSizeW.Value;
            trackBarImageSizeW.Value = (int)numericUpDownImageSizeW.Value;
        }
        private void trackBarImageSizeW_Scroll(object sender, EventArgs e)
        {
            settings.Width = trackBarImageSizeW.Value;
            numericUpDownImageSizeW.Value = trackBarImageSizeW.Value;
        }

        #endregion

        #endregion

        private void comboBoxSumple_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                settings.Sampler_name = comboBoxSumple.SelectedItem.ToString();
                Console.WriteLine("comboBoxSumple.SelectedText=" + comboBoxSumple.SelectedItem.ToString());
                Console.WriteLine("settings.Sampler_name=" + settings.Sampler_name);
            }
            catch { }

        }

        private void checkBoxSumpleIsRundom_CheckedChanged(object sender, EventArgs e)
        {
            settings.IsRandomModeSumplerName = checkBoxSumpleIsRundom.Checked;
        }
    }
}
