
namespace OmniGov.Core.Models
{
    public class DatabaseConfig
    {
        public string Server { get; set; } = "localhost";
        public string Database { get; set; } = "";
        public string UserId { get; set; } = "root";
        public string Password { get; set; } = "";
        public uint Port { get; set; } = 3306;

        public string ToConnectionString()
        {
            return $"Server={Server};Database={Database};Uid={UserId};Pwd={Password};Port={Port};Convert Zero Datetime=True;Allow Zero Datetime=True;";
        }
    }

    public class LguProfile
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string MunicipalityCode { get; set; } = "";
        public string ProvinceCode { get; set; } = "";
        public string ProvinceName { get; set; } = "";
        public DatabaseConfig LfsDatabase { get; set; } = new();
        public DatabaseConfig RptDatabase { get; set; } = new();
        public string EmblemName { get; set; } = ""; // Resource name
    }
}
