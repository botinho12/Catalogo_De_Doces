namespace CatalogoDeDoces.Dtos
{
    public class JwtSettingDto
    {
        public string? SecretKey { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public int ExpirationMinutes { get; set; }
    }
}
