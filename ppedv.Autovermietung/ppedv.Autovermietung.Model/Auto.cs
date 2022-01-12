namespace ppedv.Autovermietung.Model
{
    public class Auto : Entity
    {
        public string Hersteller { get; set; } = string.Empty;
        public string Modell { get; set; } = string.Empty;
        public int PS { get; set; }
        public DateTime Baujahr { get; set; }
        public virtual ICollection<Vermietung> Vermietungen { get; set; } = new HashSet<Vermietung>();
    }
}