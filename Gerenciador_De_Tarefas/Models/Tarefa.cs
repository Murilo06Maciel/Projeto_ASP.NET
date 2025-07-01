namespace Gerenciador_De_Tarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public bool Concluida { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
