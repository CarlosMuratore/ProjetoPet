namespace PetClean.Models
{
    public class Raca
    {
        public int RacaId { get; set; }
        public string Racas { get; set; }

        public ICollection<Cadastro> Cadastros { get; set; }
    }
}
