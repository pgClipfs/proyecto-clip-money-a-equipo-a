namespace WebApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string DNI { get; set; }
        public string Domicilio { get; set; }
        public string Cuil { get; set; }
        public string CorreoElectronico { get; set; }
        public string Saldo { get; set; }

    }
}