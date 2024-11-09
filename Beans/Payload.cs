
namespace StableManager.Beans
{
    /// <summary>
    /// StableDiffudionに送るリクエストのボディ部分
    /// </summary>
    class Payload
    {
        public string prompt = "";
        public string negative_prompt = "";
        public decimal seed = -1;
        public string sampler_name = "DDIM";
        public decimal denoising_strength = 1;
        public int batch_size = 1;
        public int steps = 5;
        public int cfg_scale = 5;
        public int width = 512;
        public int height = 512;
        public bool override_settings_restore_afterwards = true;
        public bool save_images = true;
        public string[] init_images;
        public int resize_mode = 1;

    }
}
