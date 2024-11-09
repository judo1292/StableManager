
namespace StableManager.Beans
{
    /// <summary>
    /// プロンプトテーブル用Beans　グリッド用にチェック項目を付け加えている
    /// </summary>
    class Prompt
    {
        private bool isActive = true;
        private int id;
        private int category;
        private string promptEn;
        private string promptJp = "";
        private string memo;
        private bool isNegative = false;
        private bool isBookmark = false;
        private bool isRandom;
        private int primaryLevel;
        private bool asNegative;

        /// <summary>
        /// プロンプトに反映するかどうか
        /// </summary>
        public bool IsActive { get => isActive; set => isActive = value; }
        public int Id { get => id; set => id = value; }
        public int Category { get => category; set => category = value; }
        public string PromptEn { get => promptEn; set => promptEn = value; }
        public string PromptJp { get => promptJp; set => promptJp = value; }
        public string Memo { get => memo; set => memo = value; }
        public bool IsNegative { get => isNegative; set => isNegative = value; }
        public bool IsBookmark { get => isBookmark; set => isBookmark = value; }

        public bool IsRandom { get => isRandom; set => isRandom = value; }
        public int PrimaryLevel { get => primaryLevel; set => primaryLevel = value; }
        public bool AsNegative { get => asNegative; set => asNegative = value; }
    }
}
