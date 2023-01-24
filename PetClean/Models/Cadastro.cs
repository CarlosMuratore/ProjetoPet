namespace PetClean.Models
{
    public class Cadastro
    {
        public int CadastroId { get; set; }
        public string Nome { get; set; }
        public string NomePet { get; set; }
        public string Endereço { get; set; }
        public string Email { get; set; }
        public double Telefone { get; set; }

        public int RacaId { get; set; }
        public Raca Racas { get; set; }

    }
}
