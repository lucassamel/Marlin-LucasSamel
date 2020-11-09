using Api.Model;
using data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Api.Controllers
{
    public class HomeController : Controller
    {
        private  data.MarlinBdEntities _context;

        
        public System.Web.Mvc.ActionResult Index()
        {
            ViewBag.Title = "Home Page";

                     
                        

            return View();
        }

        // GET: api/Alunos
        
        public List<Model.Aluno> Get()
        {
            _context = new data.MarlinBdEntities();
            List<Model.Aluno> dados = (from x in _context.Aluno
                         select new Model.Aluno
                         {
                             AlunoId = x.AlunoId,
                             Idade = x.Idade,
                             Turma = new Model.Turma()
                             {
                                 TurmaId = x.Turma.TurmaId,
                                 NomeTurma = x.Turma.NomeTurma
                             }
                         }).ToList();
            return  dados;
        }
    }
}
