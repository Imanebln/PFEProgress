#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npoi.Mapper;
using NPOI.SS.UserModel;
using PFE.Data;
using PFE.Models;

namespace PFE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PFEsController : ControllerBase
    {
        private readonly PFEContext _context;

        public PFEsController(PFEContext context)
        {
            _context = context;
        }

        // GET: api/PFEs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PFEModel>>> GetPFEs()
        {
            return await _context.PFEs.ToListAsync();
        }

        // GET: api/PFEs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PFEModel>> GetPFE(int id)
        {
            var pfe = await _context.PFEs.FindAsync(id);

            if (pfe == null)
            {
                return NotFound();
            }

            return pfe;
        }

        // PUT: api/PFEs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPFE(int id, PFEModel pfe)
        {
            if (id != pfe.Id)
            {
                return BadRequest();
            }

            _context.Entry(pfe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PFEExists(id))
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

        // POST: api/PFEs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PFEModel>> PostPFE(PFEModel pfe)
        {
            _context.PFEs.Add(pfe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPFE", new { id = pfe.Id }, pfe);
        }

        // DELETE: api/PFEs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePFE(int id)
        {
            var pfe = await _context.PFEs.FindAsync(id);
            if (pfe == null)
            {
                return NotFound();
            }

            _context.PFEs.Remove(pfe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteAllPFEs")]
        public async Task<ActionResult<IEnumerable<PFEModel>>> DeleteAllPFEs()
        {
            var pfe = await _context.PFEs.ToListAsync();

            foreach (var item in pfe)
            {
                _context.PFEs.Remove(item);
                await _context.SaveChangesAsync();
            }
            return NoContent();
        }

        [HttpPost]
        [Route("UploadExcelFile")]
        public async Task<ActionResult<IEnumerable<PFEModel>>> UploadExcelFile(IFormFile file, int sheetIndex = 0)
        {
            IWorkbook workbook;
            var file2 = file.OpenReadStream();

            try
            {
                workbook = WorkbookFactory.Create(file2);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + "Could not open file");
            }

            var importer = new Mapper(workbook);
            var items = importer.Take<ExcelModel>(sheetIndex);

            if (items.Any(i =>
            {
                return (i.Value.Nom == null || i.Value.Prenom == null || i.Value.Ville == null
                || i.Value.Email == null || i.Value.Sujet == null || i.Value.NomSociete == null
                || i.Value.TechnologiesUtilisees == null || i.Value.EmailEncadrant == null || i.Value.Filiere == null);
            }))
            {
                return BadRequest("Column not found");
            }

            //await DeleteAllPFEs();

            foreach (var item in items)
            {
                PFEModel pfeModel = new PFEModel();


                pfeModel.Email = item.Value.Email;
                pfeModel.Sujet = item.Value.Sujet;
                pfeModel.NomSociete = item.Value.NomSociete;
                pfeModel.Ville = item.Value.Ville;
                pfeModel.TechnologiesUtilisees = item.Value.TechnologiesUtilisees;
                pfeModel.EmailEncadrant = item.Value.EmailEncadrant;
                pfeModel.Nom = item.Value.Nom;
                pfeModel.Prenom = item.Value.Prenom;
                pfeModel.Filiere = item.Value.Filiere;
                pfeModel.NormalizedEmail = item.Value.Email;
                pfeModel.UserName = item.Value.Prenom;

                _context.PFEs.Add(pfeModel);
                await _context.SaveChangesAsync();
            }
            return await _context.PFEs.ToListAsync();
        }

        [HttpPost("students/excel/upload")]
        [RequestSizeLimit(bytes: 5_000_000)]
        public async Task<IActionResult> AddStudentsList(IFormFile file)
        {
            if (file.Length <= 0)
                return BadRequest("Empty file");
            var result = await UploadExcelFile(file);
            return Ok();
        }

        private bool PFEExists(int id)
        {
            return _context.PFEs.Any(e => e.Id == id);
        }
    }
}
