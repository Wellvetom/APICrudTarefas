using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICrudTarefas.Application.DTO.Response
{
    public class ImportacaoTarefasResponse
    {
        public int TotalProcessadas { get; set; }
        public int Sucesso { get; set; }
        public int Falhas { get; set; }

        public List<ErroImportacaoTarefa> Erros { get; set; } = new();
    }
    public class ErroImportacaoTarefa
    {
        public int Linha { get; set; }
        public string Titulo { get; set; }
        public string Motivo { get; set; } 
    }
}
