using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class Turma
    {
        public int TurmaId { get; set; }
        public string NomeTurma { get; set; }
        public List<Aluno> Alunos { get; set; }

    }
}
