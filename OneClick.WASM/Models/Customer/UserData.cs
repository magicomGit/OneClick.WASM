using OneClick.Shared.AppEnums.UserEnums;

namespace OneClick.WASM.Models.Customer
{
    public class UserData
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? Avatar { get; set; }
        public string? Language { get; set; }
        public double Balance { get; set; }
        public DateTime? FreezeDay { get; set; }
        public UserTheme Theme { get; set; }
    }
}
