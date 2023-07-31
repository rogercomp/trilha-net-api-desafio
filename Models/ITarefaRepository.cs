namespace TrilhaApiDesafio.Models
{
    public interface ITarefaRepository
    {
        public List<Tarefa> ObterTodos();
        public List<Tarefa> ObterPorData(DateTime data);
        public List<Tarefa> ObterPorStatus(EnumStatusTarefa status);
        public List<Tarefa> ObterPorTitulo(string titulo); 
        public Tarefa BuscarPorID(int Id);
        public void Adicionar(Tarefa tarefa);
        public void Atualizar(int id, Tarefa tarefa);
        public void Salvar();
        public void Deletar(int Id);

    }
}
