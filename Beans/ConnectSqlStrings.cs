using System;

namespace StableManager.Beans
{
    /// <summary>
    /// MySQLとの接続用文字列Beans このプログラム上ではこれで固定
    /// </summary>
    class ConnectSqlStrings
    {
        const String server = "Server=192.168.10.10;Port=3306;";
        const String userId = "Uid=sa;";
        const String password = "Pwd=judo11822564;";
        const String database = "Database=stable_diffusion_manager";

        public string Server { get => server;}
        public string UserId { get => userId;}
        public string Password { get => password;}
        public string Database { get => database;}
        public string ConnectionString { get => server + userId + password + database;}
    }
}
