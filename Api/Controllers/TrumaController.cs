using Api.Model;
using data;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;

namespace Api.Controllers
{
    public class TurmaController : ApiController
    {
        private data.MarlinBdEntities _context;

        // GET api/turma
        public List<Model.Turma> Get()
        {
            _context = new data.MarlinBdEntities();
            var t = _context.Turma;
            List<Model.Turma> dados = new List<Model.Turma>();
            foreach (var x in t)
            {
                 Model.Turma tt = new Model.Turma()
                                           {
                                               TurmaId = x.TurmaId,
                                               NomeTurma = x.NomeTurma,
                                               Alunos = listaAlunos(x)

                                           };
                dados.Add(tt);
            }
            return dados;
        }

        private List<Model.Aluno> listaAlunos(data.Turma turma)
        {
            List<Model.Aluno> alunos = new List<Model.Aluno>();
            foreach (var x in turma.Aluno)
            {
                Model.Aluno a = new Model.Aluno() {
                                       
                    AlunoId = x.AlunoId,
                                           Idade = x.Idade,
                                           Nome = x.Nome,
                                           Sobrenome = x.Sobrenome
                    };
                alunos.Add(a);
            }
            return alunos;
        }

        // GET api/turma/5
        public Model.Turma Get(int id)
        {
            _context = new data.MarlinBdEntities();
            Model.Turma turma = (from x in _context.Turma
                                 where x.TurmaId == id
                                       select new Model.Turma
                                       {
                                           TurmaId = x.TurmaId,
                                           NomeTurma = x.NomeTurma,                                          

                                       }
                                       ).FirstOrDefault();
            return turma;
        }

        // POST api/turma
        public void Post([FromBody] Model.Turma turma)
        {
            _context = new data.MarlinBdEntities();
            data.Turma novaTurma = new data.Turma();
            novaTurma.NomeTurma = turma.NomeTurma;            

            _context.Turma.Add(novaTurma);

            _context.SaveChanges();
        }

        // PUT api/turma/5
        public void Put(int id, [FromBody] Model.Turma turma)
        {

        }

        // DELETE api/turma/5
        public void Delete(int id)
        {
            _context = new data.MarlinBdEntities();

            data.Turma turma = _context.Turma.Where(x => x.TurmaId == id).FirstOrDefault();

            if (id != turma.TurmaId)
            {
                BadRequest();
            }

            if(turma.Aluno.Count != 0)
            {
                BadRequest();
            }
            _context.Turma.Remove(turma);
            _context.SaveChanges();
        }
    }
}
