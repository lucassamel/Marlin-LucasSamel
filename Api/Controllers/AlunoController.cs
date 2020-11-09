using Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;

namespace Api.Controllers
{
    public class AlunoController : ApiController
    {
        private data.MarlinBdEntities _context;

        // GET api/aluno
        public List<Model.Aluno> Get()
        {
            _context = new data.MarlinBdEntities();
            List<Model.Aluno> dados = (from x in _context.Aluno
                                       select new Model.Aluno
                                       {
                                           AlunoId = x.AlunoId,
                                           Idade = x.Idade,
                                           Nome = x.Nome,
                                           Sobrenome = x.Sobrenome,
                                           Turma = new Model.Turma()
                                           {
                                               TurmaId = x.Turma.TurmaId,
                                               NomeTurma = x.Turma.NomeTurma
                                           }
                                       }).ToList();
            return dados;
        }

        // GET api/aluno/5
        public Model.Aluno Get(int id)
        {
            _context = new data.MarlinBdEntities();
            Model.Aluno aluno = (from x in _context.Aluno
                                 where x.AlunoId == id
                                       select new Model.Aluno
                                       {
                                           AlunoId = x.AlunoId,
                                           Idade = x.Idade,
                                           Nome = x.Nome,
                                           Sobrenome = x.Sobrenome,
                                           Turma = new Model.Turma()
                                           {
                                               TurmaId = x.Turma.TurmaId,
                                               NomeTurma = x.Turma.NomeTurma
                                           }
                                       }
                                       ).FirstOrDefault();
            return aluno;
        }

        // POST api/values
        public void Post([FromBody] Aluno aluno)
        {
            _context = new data.MarlinBdEntities();

            data.Turma turma = _context.Turma.Where(x => x.TurmaId == aluno.Turma.TurmaId).FirstOrDefault();
            if (turma.Aluno.Count >= 5)
            {
                BadRequest();
            }

            data.Aluno novoAluno = new data.Aluno();
            novoAluno.Nome = aluno.Nome;
            novoAluno.Sobrenome = aluno.Sobrenome;
            novoAluno.Turma.TurmaId = aluno.Turma.TurmaId;            

            _context.Aluno.Add(novoAluno);

            _context.SaveChanges();
        }

        // PUT api/aluno/5
        public void Put(int id, [FromBody] Aluno aluno)
        {
            //_context = new data.MarlinBdEntities();
            //if(id != aluno.AlunoId)
            //{
            //    return BadRequest();
            //}      
                                    
        }

        // DELETE api/aluno/5
        public void Delete(int id)
        {
            _context = new data.MarlinBdEntities();
            data.Aluno aluno = _context.Aluno.Where(x => x.AlunoId == id).FirstOrDefault();

            _context.Aluno.Remove(aluno);
            _context.SaveChanges();
        }
    }
}
