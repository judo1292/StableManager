
namespace StableManager.Beans
{
    /// <summary>
    /// StableDiffudionに送るリクエストのボディ部分の前準備
    /// MainPanelのパラメータはぜんぶここに行く
    /// </summary>
    class PrePayload
    {
        private static PrePayload instance;
        public PrePayload() { }
        public static PrePayload Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PrePayload();
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }

         private string prompt = "";
         private string negative_prompt = "";
         private decimal seed = -1;
         private string sampler_name = "Euler a";
         private decimal denoising_strength = 1;
         private int denoising_Max = 50;
         private int denoising_Min = 5;
         private int batch_size = 1;
         private int steps = 30;
         private int steps_Max = 30;
         private int steps_Min = 15;
         private int cfg_scale = 5;
         private int cfg_scale_Max = 10;
         private int cfg_scale_Min = 3;
         private int width = 512;
         private int height = 512;
         private bool override_settings_restore_afterwards = true;
         private bool save_images = true;
         private bool isRandomModeStep = true;
         private bool isRandomModeWH = false;
         private bool isRandomModeCfg = true;
         private bool isRandomModeDenoise = true;
         private bool isRandomModePositivePrompt = true;
         private bool isRandomModeNegativePrompt = true;
         private bool isRandomModePrimaryLevelPositive = false;
         private bool isRandomModePrimaryLevelNegative = false;
         private bool isRandomModeSumplerName = false;
         private bool isActiveLora = false;
         private string loraName = "";
         private bool isRandomModeLora = true;
         private double loraNumMax = 1.01;
         private double loraNumMin = 0.80;
         private string selectedModel = "";
         private bool isRandomModeModel = false;
         private string cullentModel = "";
         private bool isI2Imode = false;
         private string[] i2iImages;
         private bool isActiveRoop = false;
        private bool isActiveRandomGenerateMode = false;
        private bool isActiveBatchMode = false;
        private string batchPath; 


        public  string Prompt { get => prompt; set => prompt = value; }
        public  string Negative_prompt { get => negative_prompt; set => negative_prompt = value; }
        public  decimal Seed { get => seed; set => seed = value; }
        public  string Sampler_name { get => sampler_name; set => sampler_name = value; }
        public  int Batch_size { get => batch_size; set => batch_size = value; }
        public  int Steps { get => steps; set => steps = value; }
        public  int Steps_Max { get => steps_Max; set => steps_Max = value; }
        public  int Steps_Min { get => steps_Min; set => steps_Min = value; }
        public  int Cfg_scale { get => cfg_scale; set => cfg_scale = value; }
        public  int Width { get => width; set => width = value; }
        public  int Height { get => height; set => height = value; }
        public  bool Override_settings_restore_afterwards { get => override_settings_restore_afterwards; set => override_settings_restore_afterwards = value; }
        public  bool Save_images { get => save_images; set => save_images = value; }
       /// <summary>
       /// 真ならステップ数がMin~Maxの間でランダム、偽ならMaxの値を参照する
       /// </summary>
        public  bool IsRandomModeStep { get => isRandomModeStep; set => isRandomModeStep = value; }
        public  bool IsRandomModeWH { get => isRandomModeWH; set => isRandomModeWH = value; }
        public  bool IsRandomModeCfg { get => isRandomModeCfg; set => isRandomModeCfg = value; }
        public  int Cfg_scale_Max { get => cfg_scale_Max; set => cfg_scale_Max = value; }
        public  int Cfg_scale_Min { get => cfg_scale_Min; set => cfg_scale_Min = value; }
        public  bool IsRandomModeDenoise { get => isRandomModeDenoise; set => isRandomModeDenoise = value; }
        public  decimal Denoising_strength { get => denoising_strength; set => denoising_strength = value; }
        public  int Denoising_Max { get => denoising_Max; set => denoising_Max = value; }
        public  int Denoising_Min { get => denoising_Min; set => denoising_Min = value; }
        public  bool IsRandomModePositivePrompt { get => isRandomModePositivePrompt; set => isRandomModePositivePrompt = value; }
        public  bool IsRandomModeNegativePrompt { get => isRandomModeNegativePrompt; set => isRandomModeNegativePrompt = value; }
        public  bool IsRandomModePrimaryLevelPositive { get => isRandomModePrimaryLevelPositive; set => isRandomModePrimaryLevelPositive = value; }
        public  bool IsRandomModePrimaryLevelNegative { get => isRandomModePrimaryLevelNegative; set => isRandomModePrimaryLevelNegative = value; }
        public  bool IsActiveLora { get => isActiveLora; set => isActiveLora = value; }
        public  string LoraName { get => loraName; set => loraName = value; }
        public  bool IsRandomModeLora { get => isRandomModeLora; set => isRandomModeLora = value; }
        public  double LoraNumMax { get => loraNumMax; set => loraNumMax = value; }
        public  double LoraNumMin { get => loraNumMin; set => loraNumMin = value; }
        public  string SelectedModel { get => selectedModel; set => selectedModel = value; }
        public  bool IsRandomModeModel { get => isRandomModeModel; set => isRandomModeModel = value; }
        public  string CullentModel { get => cullentModel; set => cullentModel = value; }
        public  bool IsI2Imode { get => isI2Imode; set => isI2Imode = value; }
        public  string[] I2iImages { get => i2iImages; set => i2iImages = value; }
        public  bool IsActiveRoop { get => isActiveRoop; set => isActiveRoop = value; }
        public bool IsActiveRandomGenerateMode { get => isActiveRandomGenerateMode; set => isActiveRandomGenerateMode = value; }
        public bool IsActiveBatchMode { get => isActiveBatchMode; set => isActiveBatchMode = value; }
        public string BatchPath { get => batchPath; set => batchPath = value; }
        /// <summary>
        /// サンプラーをランダム選択にする
        /// </summary>
        public bool IsRandomModeSumplerName { get => isRandomModeSumplerName; set => isRandomModeSumplerName = value; }
    }
}
