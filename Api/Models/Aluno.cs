using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class Aluno
    {

        public Aluno()
        {
            Turma = new Turma();
        }

        public int AlunoId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required]
        public Turma Turma { get; set; }
    }

    public class AlunoInsert
    {        
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required]
        public int TurmaId { get; set; }
    }
}
