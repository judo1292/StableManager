using System;
using System.Collections.Generic;

namespace StableManager.Model
{
    using Beans;
    /// <summary>
    /// 画像作成リクエストボディの値を決めるクラス
    /// </summary>
    class EditPayloadLogic
    {
        Random random = new Random();
        PrePayload settings = PrePayload.Instance;
        public decimal Seeds()
        {
            return settings.Seed;
        }
        public int Steps()
        {

            if (settings.IsRandomModeStep)
            {
                return random.Next(settings.Steps_Min, settings.Steps_Max);
            }
            else
            {
                return settings.Steps_Max;
            }
        }
        public ImageHW ImageSize()
        {
            if (settings.IsRandomModeWH && random.Next(0, 2) == 0)
            {
                return new ImageHW() {Height = settings.Width , Widht = settings.Height } ;
            }
            else
            {
                return new ImageHW() { Height = settings.Height, Widht = settings.Width };
            }
        }
        public int CfgScale()
        {
            if (settings.IsRandomModeCfg)
            {
                return random.Next(settings.Cfg_scale_Min, settings.Cfg_scale_Max);
            }
            else
            {
                return settings.Cfg_scale_Max;
            }
        }
        public decimal DenoisingStrength()
        {
            if (settings.IsRandomModeCfg)
            {
                return random.Next(settings.Denoising_Min, settings.Denoising_Max) / 100.0M;
            }
            else
            {
                return (decimal)settings.Denoising_Max / 100.0M;
            }
        }
        public string Prompt(bool IsPositive)
        {
            // スタティックのプロンプトリストを現段階の状態で一時リストに入れる
            List<Prompt> ListPrompt = new List<Prompt>();
            string prompt = "";
            string tmpPrompt = "";
            if (IsPositive)
            {
                ListPrompt = new List<Prompt>(GridPromptList.positiveTableMain);
            }
            else
            {
                ListPrompt = new List<Prompt>(GridPromptList.negativeTableMain);
            }
            if (settings.IsActiveRandomGenerateMode)
            {
                AddRandomGeneratePrompt(IsPositive, ListPrompt);
            }

            // プロンプトのランダムモードが有効なら一時リストをシャッフルする
            if ((IsPositive && settings.IsRandomModePositivePrompt)//ポジティブプロンプトかつランダムが有効
                || (!IsPositive && settings.IsRandomModeNegativePrompt))//もしくはネガティブプロンプトかつランダム有効
            {
                ListPrompt.Shuffle();
            }

            foreach (Prompt p in ListPrompt)
            {
                tmpPrompt = p.PromptEn;
                if (!p.IsActive) continue; // 無効になっていれば追加をスルーする
                if (p.IsRandom && random.Next(0, 2) == 0) continue; // 反映ランダム有効であれば２分の１の確率で追加をスルーする

                // プライマリレベルを決める
                int primaryLebel = 0;
                if ((IsPositive && settings.IsRandomModePrimaryLevelPositive && random.Next(0, 10) == 1)
                    || (!IsPositive && settings.IsRandomModePrimaryLevelNegative && random.Next(0, 10) == 0))
                {// プライマリレベルランダムが有効なら１０分の１の確率で強度ランダム
                    primaryLebel = random.Next(0, 7);
                }
                else if (p.PrimaryLevel >= 1)
                {
                    primaryLebel = p.PrimaryLevel;
                }
                while (primaryLebel > 0)
                {
                    tmpPrompt= "{" + tmpPrompt + "}";
                    primaryLebel--;
                }
                prompt += tmpPrompt + ",";
            }
       

            return prompt;
        }
        public string Lora()
        {
            string loraTag = "";
            if (settings.IsActiveLora && settings.LoraName != "")
            {
                if (settings.IsRandomModeLora)
                {
                    int min = (int)(settings.LoraNumMin * 100);
                    int max = (int)(settings.LoraNumMax * 100);
                    decimal loraRunNam = (random.Next(min, max)) / 100.00M;
                    loraTag = $" <lora:{settings.LoraName}:{loraRunNam}>";
                }
                else
                {
                    loraTag = $" <lora:{settings.LoraName}:{settings.LoraNumMax}>";
                }
            }
            return loraTag;
        }

        public string SumplerName()
        {
            if (settings.IsRandomModeSumplerName)
            {
                var sumpleList = new Beans.Sumplings().SumplingList;
                var a = random.Next(sumpleList.Count);
                return sumpleList[a];

            }
            else
            {
                return settings.Sampler_name;
            }

        }

        public void AddRandomGeneratePrompt(bool isPositive ,List<Prompt> prompts)
        {
            //色テーブル
            string[] color = new string[]{"red","blue","white","black"};
            string[] eye = new string[] {"tsulime","" };
            string[] hair = new string[] { "messy hair", "ponytail", "long hair", "braid hair" };
            string hairType = color[random.Next(color.Length)] + " " + hair[random.Next(hair.Length)] + " " + "eyes";
            string eyeType = color[random.Next(color.Length)] +" " + eye[random.Next(eye.Length)] + " " + "eyes";
            if (isPositive)
            {
                //目の色
                prompts.Add(new Prompt { PromptEn = hairType });
                //髪の色
                prompts.Add(new Prompt { PromptEn = eyeType });

            }
            else
            {

            }
        }
    }
}
