namespace ppedv.Autovermietung.Model
{
    public class Vermietung : Entity
    {
        public string Mieter { get; set; } = string.Empty;
        public DateTime Von { get; set; }
        public DateTime Bis { get; set; }
        public virtual Auto? Auto { get; set; }
    }
}