using Activ.Pointis.WebAPI.Models;
using Activ.Pointis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Activ.Pointis.WebAPI.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    //[Authorize]
    public class EmployesController : ApiController
    {
        // GET: api/Employes
        [HttpGet]
        public List<Employes> Get()
        {
            return EmployesModel.afficher();
        }

        [HttpGet]
        public List<Employes> Get(string matricule)
        {
            return EmployesModel.AfficherUn(matricule);
        }

        // GET: api/Employes/5
        [HttpGet]
        public List<Employes> Get(long id)
        {
            return EmployesModel.AfficherUnSeul(id);
        }

        [ActionName("Generate")]
        public System.Drawing.Image GenerateQrcode(Employes employes)
        {
            return EmployesModel.GenererQrcode(employes);
        }

        // POST: api/Employes
        [HttpPost]
        public void Post([FromBody]Employes employes)
        {
            EmployesModel.Ajouter(employes);
        }

        // PUT: api/Employes/5
        [HttpPut]
        public void Put(long id, [FromBody] Employes employes)
        {
            EmployesModel.Modifier(id, employes);
        }

        // DELETE: api/Employes/5
        [HttpDelete]
        public void Delete(long id)
        {
            EmployesModel.supprimer(id);
        }
    }
}
