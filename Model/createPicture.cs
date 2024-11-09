using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace StableManager.Model
{
    using Beans;
    class createPicture
    {
        PrePayload settings = PrePayload.Instance;
        public void Roop()
        {
            while (true)
            {
                while (!settings.IsActiveRoop)
                {
                    System.Threading.Thread.Sleep(1000);
                }
                try
                {
                    create();
                }
                catch
                {
                    Console.WriteLine("ループエラー sled.cs 41");
                }
                finally
                {
                    System.Threading.Thread.Sleep(1000);
                }

            }

        }
        /// <summary>
        /// 画像生成を開始する
        /// </summary>
        public void create()
        {
            EditPayloadLogic editPayload = new EditPayloadLogic();
            webControll webControll = new webControll();
            Payload payload = new Payload();
            Random random = new Random();

            // サンプリング方式を決める
            payload.sampler_name = editPayload.SumplerName();

            // シード値を決める
            payload.seed = editPayload.Seeds();

            // ステップ数を決める
            payload.steps = editPayload.Steps();

            // 画像の大きさを決める
            var imageSize = editPayload.ImageSize();
            payload.width = imageSize.Widht;
            payload.height = imageSize.Height;

            // Cfgスケールを決める
            payload.cfg_scale = editPayload.CfgScale();

            // ノイズ除去率を決める
            payload.denoising_strength = editPayload.DenoisingStrength();

            // プロンプトを決める
            payload.prompt = editPayload.Prompt(true);
            payload.negative_prompt = editPayload.Prompt(false);

            // Loraを適用する
            payload.prompt += editPayload.Lora();

            List<string> List_Model_tmp = new List<string>();
            // モデルを決める
            if (settings.IsRandomModeModel)
            {
                foreach (var a in GridPromptList.modelTable)
                {
                    if (!a.IsChecked) continue;
                    List_Model_tmp.Add(a.Name);
                }
                if (List_Model_tmp.Count > 0)
                {
                    var s = List_Model_tmp[random.Next(List_Model_tmp.Count)];
                    if (s != settings.CullentModel) settings.CullentModel = s;
                    SendRequestModelChange(s);
                    List_Model_tmp.Clear();
                }
            }
            else if (settings.SelectedModel != settings.CullentModel)
            {
                try
                {
                    settings.CullentModel = settings.SelectedModel;
                    SendRequestModelChange(settings.CullentModel);
                }
                catch
                {
                    Console.WriteLine("エラー sled.cs 246");
                }

            }

            // I2Iモードなら画像を追加する
            if (settings.IsI2Imode)
            {
                if (settings.IsActiveBatchMode)
                {
                    string[] pngFiles = Directory.GetFiles(settings.BatchPath, "*.png");
                    Random ran = new Random();
                    byte[] imageBytes = File.ReadAllBytes(pngFiles[ran.Next(pngFiles.Length)]);
                    string base64String = Convert.ToBase64String(imageBytes);
                    payload.init_images = new string[] { base64String };
                }
                else
                {
                    payload.init_images = settings.I2iImages;
                }

            }
            // httpリクエストのボディを作る
            string body = webControll.BodyMaker(payload);
            Console.WriteLine(body);
            webControll.SendRequest(body, settings.IsI2Imode ? (int)webControll.Mode.img2img : (int)webControll.Mode.txt2img);
        }
        /// <summary>
        /// モデルを変更する指示をStable Diffusionに送る
        /// </summary>
        /// <param name="modelName"></param>
        private void SendRequestModelChange(string modelName)
        {
            webControll webControll = new webControll();
            string result;
            try
            {
                var payload = new
                {
                    sd_model_checkpoint = modelName,

                };
                string payloadJson = JsonConvert.SerializeObject(payload);
                webControll.SendRequest(payloadJson, (int)webControll.Mode.options);
            }
            catch
            {
                Console.WriteLine("エラー sled.cs 303");
                return;
            }

            return;
        }
    }
}
