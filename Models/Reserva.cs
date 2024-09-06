namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verifica se a capacidade da suite é maior ou igual ao número de hóspedes recebidos
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Lança uma exceção se a capacidade for menor que o número de hóspedes
                throw new Exception("A capacidade da suíte é inferior ao número de hóspedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes
            return Hospedes?.Count ?? 0; // Se Hospedes for null, retorna 0
        }

        public decimal CalcularValorDiaria()
        {
            // Cálculo do valor da diária
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Aplica desconto de 10% se os dias reservados forem 10 ou mais
            if (DiasReservados >= 10)
            {
                valor *= 0.90m; // Aplica 10% de desconto
            }

            return valor;
        }
    }
}
