using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WEB_api.Models;
namespace WEB_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EvidencijaController : ControllerBase
    {
        public EvidencijaContext Context { get; set; }
        
        
        public EvidencijaController(EvidencijaContext context)
        {
            Context = context;
        }

        [Route("PreuzmiEvidencije")]
        [HttpGet]
        public async Task<List<Evidencija>> PreuzmiVrtove()
        {
            return await Context.Evidencije.Include(p => p.ListaVozackih).ThenInclude(s => s.Kategorije).ToListAsync();
        }

        [Route("PreuzimiVozaca")]
        [HttpGet]
        public async Task<List<Vozacka>> PreuzmiVozacke()
        {
            return await Context.Vozacke.Include(p => p.Kategorije).ToListAsync();
        }

        [Route("PreuzimiVozaca/{idEvidencije}")]
        [HttpGet]
        public async Task<List<Vozacka>> PreuzmiVozacke(int idEvidencije)
        {
            return await Context.Vozacke.Where(e => e.evidencija.ID == idEvidencije).ToListAsync();
        }

        [Route("GetID/{JMBG}")]
        [HttpGet]
        public async Task<List<Vozacka>> GetID(string JMBG)
        {
            return await Context.Vozacke.Where(e => e.JMBG == JMBG).ToListAsync();
        }
        
        [Route("PreuzmiKategorije/{idVozaca}")]
        [HttpGet]
        public async Task<List<Kategorija>> PreuzmiKategorije(int idVozaca)
        {
            return await Context.Kategorije.Where(e => e.vozac.ID == idVozaca).ToListAsync();
        }

        [Route("UpisiEvidenciju")]
        [HttpPost]
        public async Task UpisiEvidenciju([FromBody] Evidencija evid)
        {
            Context.Evidencije.Add(evid);
            await Context.SaveChangesAsync();
        }

        [Route("UpisiVozaca/{idEvidencije}")]
        [HttpPost]

        public async Task UpisiVozaca(int idEvidencije, [FromBody] Vozacka vozac)
        {
            vozac.evidencija = await Context.Evidencije.FindAsync(idEvidencije);
            Context.Vozacke.Add(vozac);
            vozac.evidencija.ListaVozackih.Add(vozac);
            await Context.SaveChangesAsync();
        }

        [Route("UpisiKategoriju/{idVozaca}")]
        [HttpPost]
        public async Task UpisiKategoriju(int idVozaca, [FromBody] Kategorija kateg)
        {
            kateg.vozac = await Context.Vozacke.FindAsync(idVozaca);
            Context.Kategorije.Add(kateg);
            kateg.vozac.Kategorije.Add(kateg);
            await Context.SaveChangesAsync();
        }

        [Route("IzmeniEvidenciju")]
        [HttpPut]
        public async Task IzmeniEvidenciju([FromBody] Evidencija evid)
        {
            Context.Update<Evidencija>(evid);
            await Context.SaveChangesAsync();
        }

        [Route("IzmeniVozaca")]
        [HttpPut]
        public async Task IzmeniVozaca([FromBody] Vozacka vozac)
        {
            Context.Update<Vozacka>(vozac);
            await Context.SaveChangesAsync();
        }

        [Route("IzmeniKategoriju")]
        [HttpPut]
        public async Task IzmeniKategoriju([FromBody] Kategorija kateg)
        {
            Context.Update<Kategorija>(kateg);
            await Context.SaveChangesAsync();
        }

        [Route("IzbrisiEvidenciju/{idEvidencije}")]
        [HttpDelete]
        public async Task IzbrisiEvidenciju(int idEvidencije) //treba opraiti
        {
            var evid = await Context.Evidencije.FindAsync(idEvidencije);
            Context.Remove(evid);
            await Context.SaveChangesAsync();
        }

        [Route("IzbrisiVozaca/{idVozaca}")]
        [HttpDelete]
        public async Task IzbrisiVozaca(int idVozaca)
        {
            var vozac = await Context.Vozacke.FindAsync(idVozaca);
            Context.Remove(vozac);
            await Context.SaveChangesAsync();
        }
        
        [Route("IzbrisiKategoriju/{idKategorije}")]
        [HttpDelete]
        public async Task IzbrisiKategoriju(int idKategorije)
        {
            var kateg = await Context.Kategorije.FindAsync(idKategorije);
            Context.Remove(kateg);
            await Context.SaveChangesAsync();
        }
    }
}
