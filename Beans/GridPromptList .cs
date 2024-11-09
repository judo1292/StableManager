using System.ComponentModel;

namespace StableManager.Beans
{
    /// <summary>
    /// グリッドでプロンプトをリアルタイムにデータを扱うためのスタティックリスト
    /// </summary>
    static class GridPromptList
    {
        static public BindingList<Prompt> positiveTableMain = new BindingList<Prompt>();
        static public BindingList<Prompt> negativeTableMain = new BindingList<Prompt>();
        static public BindingList<Prompt> positiveTablePreset = new BindingList<Prompt>();
        static public BindingList<Prompt> negativeTablePreset = new BindingList<Prompt>();


        static public BindingList<Prompt> positiveTableTaste = new BindingList<Prompt>();
        static public BindingList<Prompt> positiveTableModel = new BindingList<Prompt>();
        static public BindingList<Prompt> positiveTableCamera = new BindingList<Prompt>();
        static public BindingList<Prompt> positiveTableLight = new BindingList<Prompt>();
        static public BindingList<Prompt> positiveTableGender = new BindingList<Prompt>();
        static public BindingList<Prompt> positiveTableBody = new BindingList<Prompt>();
        static public BindingList<Prompt> positiveTableHair = new BindingList<Prompt>();
        static public BindingList<Prompt> positiveTableFace = new BindingList<Prompt>();
        static public BindingList<Prompt> positiveTableClothes = new BindingList<Prompt>();
        static public BindingList<Prompt> positiveTablePause = new BindingList<Prompt>();
        static public BindingList<Prompt> positiveTableItem = new BindingList<Prompt>();
        static public BindingList<Prompt> positiveTableBodyEffect = new BindingList<Prompt>();
        static public BindingList<Prompt> positiveTableBackground = new BindingList<Prompt>();
        static public BindingList<Prompt> positiveTableBackgroundEffects = new BindingList<Prompt>();
        static public BindingList<Model> modelTable = new BindingList<Model>();
        static public BindingList<Prompt> positiveTableQuality = new BindingList<Prompt>();
        


        static public BindingList<BindingList<Prompt>> positivePromptLists
    = new BindingList<BindingList<Prompt>>
        {
        positiveTableMain,
        positiveTableBody,
        positiveTableCamera,
        positiveTableTaste,
        positiveTableQuality
        };
        static public BindingList<BindingList<Prompt>> negativePromptLists
            = new BindingList<BindingList<Prompt>>();

    }

}
