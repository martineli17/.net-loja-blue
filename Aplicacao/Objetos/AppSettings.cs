namespace Aplicacao.Objetos
{
    public class AppSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
        public int Expiration { get; set; }
    }
}
