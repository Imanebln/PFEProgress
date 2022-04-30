/*#nullable disable
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFE.Data;
using PFE.Models;

namespace PFE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    *//*[EnableCors]*/
    /* [DisableCors]*//*

    public class UsersController : ControllerBase
    {


        private readonly PFEContext _context;

        public UsersController(PFEContext context)
        {
            _context = context;
        }
        [Route("Login")]
        [HttpPost]
        public Response UserLogin(Login login)
        {
            var logChef = _context.Chefs.Where(x => x.Email.Equals(login.Email) &&
                      x.Password.Equals(login.Password)).FirstOrDefault();
            var logEncadrant = _context.Encadrants.Where(x => x.Email.Equals(login.Email) &&
                      x.Password.Equals(login.Password)).FirstOrDefault();
            var logEtudiant = _context.Etudiants.Where(x => x.Email.Equals(login.Email) &&
                      x.Password.Equals(login.Password)).FirstOrDefault();


            if (logEtudiant == null && logEncadrant == null && logChef != null)
            {
                return new Response { Status = "Succesfully logged in Chef!", Message = "Hy Chef" };
            }

            else if (logEtudiant == null && logEncadrant != null && logChef == null)
            {
                return new Response { Status = "Succesfully logged in Encadrant!", Message = "Hy Encadrant" };
            }
            else if (logEtudiant != null && logEncadrant == null && logChef == null)
            {
                return new Response { Status = "Succesfully logged in Etudiant!", Message = "Hy Etudiant" };
            }
            else if (logEtudiant == null && logEncadrant != null && logChef != null)
            {
                return new Response { Status = "Succesfully logged in Chef/Encadrant!", Message = "Hy Chef/Encadrant" };
            }

            else
                return new Response { Status = "Invalid", Message = "Invalid User." };
        }

        // GET: api/Chefs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chef>>> GetChefs()
        {
            return await _context.Chefs.ToListAsync();
        }

        // GET: api/Chefs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chef>> GetChef(int id)
        {
            var chef = await _context.Chefs.FindAsync(id);

            if (chef == null)
            {
                return NotFound();
            }

            return chef;
        }

        //Ajouter un encadrant
        [Route("AjouterProf")]
        [HttpPost]
        public async Task<ActionResult<Encadrant>> AjouterEncadrant(Encadrant encadrant)
        {
            _context.Encadrants.Add(encadrant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEncadrant", new { id = encadrant.Id }, encadrant);
        }
        //Modifer un encadrant
        [Route("ModifierProf")]
        [HttpPost]
        public async Task<ActionResult> ModifierEncadrant(int id, Encadrant encadrant)
        {
            if (id != encadrant.Id)
            {
                return BadRequest();
            }

            _context.Entry(encadrant).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EncadrantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();

        }
        private bool EncadrantExists(int id)
        {
            return _context.Encadrants.Any(e => e.Id == id);
        }

        //supprimer encadrant
        [Route("SuppProf")]
        [HttpDelete]
        public async Task<IActionResult> SupprimerEncadrant(int id)
        {

            //fetching and filter specific member id record   
            var encadrant = await _context.Encadrants.FindAsync(id);

            //checking fetched or not with the help of NULL or NOT.  
            if (encadrant != null)
                {

                    _context.Encadrants.Remove(encadrant);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    //return response error as Not Found  with exception message.  
                    return NotFound();
                }
            return NoContent();

        }


    }
}*/