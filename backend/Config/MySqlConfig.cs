namespace Roblocks.Config;

public class MySqlConfig
{
    public string Host { get; set; }
    public int Port { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string ConnectionString => $"Server=localhost;Port=3306;Database=roblocks;User=root;Password=;";
}