//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Aluno
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get; set; }
        public int TurmaId { get; set; }
    
        public virtual Turma Turma { get; set; }
    }
}