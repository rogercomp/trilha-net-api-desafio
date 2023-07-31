using TrilhaApiDesafio.Context;

namespace TrilhaApiDesafio.Models
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly OrganizadorContext _context;
        public TarefaRepository(OrganizadorContext context)
        {
            _context = context;           
        }    

        public Tarefa BuscarPorID(int Id)
        {
            Tarefa tarefa = _context.Tarefas.Find(Id);
            return tarefa;
        }

        public void Deletar(int Id)
        {
            var tarefa = BuscarPorID(Id);
            _context.Tarefas.Remove(tarefa);            
        }

        public List<Tarefa> ObterPorData(DateTime data)
        {
            var tarefas = _context.Tarefas.Where(x => x.Data.Date == data.Date).ToList();

            return tarefas;
        }

        public List<Tarefa> ObterPorStatus(EnumStatusTarefa status)
        {
            var tarefas = _context.Tarefas.Where(x => x.Status == status).ToList();
            return tarefas;
        }

        public List<Tarefa> ObterPorTitulo(string titulo)
        {
            var tarefas = _context.Tarefas.Where(x => x.Titulo == titulo).ToList();
            return tarefas;
        }

        public List<Tarefa> ObterTodos()
        {
            var tarefas = _context.Tarefas.ToList();

            return tarefas;
        }

        public void Adicionar(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
        }

        public void Atualizar(int id, Tarefa tarefa)
        {
            var objRow = BuscarPorID(id);

            objRow.Descricao = tarefa.Descricao;
            objRow.Data = tarefa.Data;
            objRow.Titulo = tarefa.Titulo;
            objRow.Status = tarefa.Status;

            _context.SaveChanges();
        }

        public void Salvar()
        {            
            _context.SaveChanges();
        }
    }
}
