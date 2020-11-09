using Api.Model;
using Newtonsoft.Json;
//using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using System.Web.Mvc;

namespace Api.Controllers
{
    public class AlunoController : ApiController
    {
        private data.MarlinBdEntities _context;

        // GET api/aluno
        //Lista todos os Alunos
        public HttpResponseMessage Get()
        {
            try
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
                return Request.CreateResponse(HttpStatusCode.OK, dados);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }

        // GET api/aluno/5
        //Lista o Aluno Por Id
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
        //Cria um novo aluno
        public HttpResponseMessage Post([FromBody] AlunoInsert aluno)
        {
            _context = new data.MarlinBdEntities();

            data.Turma turma = _context.Turma.Where(x => x.TurmaId == aluno.TurmaId).FirstOrDefault();


            if (turma == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Turma não existe.");
            }
            if (turma.Aluno.Count >= 5)
            {
              return  Request.CreateResponse(HttpStatusCode.BadRequest, "Turma completa.");
            }

            data.Aluno novoAluno = new data.Aluno();
            novoAluno.Nome = aluno.Nome;
            novoAluno.Sobrenome = aluno.Sobrenome;
            novoAluno.TurmaId = aluno.TurmaId;

            _context.Aluno.Add(novoAluno);

            _context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Aluno criado com sucesso!");
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
        //Deleta um aluno
        public HttpResponseMessage Delete(int id)
        {
            _context = new data.MarlinBdEntities();
            data.Aluno aluno = _context.Aluno.Where(x => x.AlunoId == id).FirstOrDefault();

            if (aluno.AlunoId != id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Aluno não encontrado");
            }

            _context.Aluno.Remove(aluno);
            _context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Aluno excluido com sucesso!");
        }
    }
}
