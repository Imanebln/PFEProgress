using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PFE.Auth;
using PFE.Data;
using PFE.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PFE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize (Roles = "Admin")]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly PFEContext _context;


        public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, PFEContext context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            _context = context;

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                dynamic? userData = null;
                if(userRoles.Contains(UserRoles.Admin))
                {
                    userData = await _context.Admins.Where(a => a.Id.Equals(user.Id)).FirstOrDefaultAsync();
                }
                else if (userRoles.Contains(UserRoles.Encadrant))
                {
                    userData = await _context.Encadrants.Where(a => a.Id.Equals(user.Id)).FirstOrDefaultAsync();
                }
                else if (userRoles.Contains(UserRoles.Etudiant))
                {
                    userData = await _context.Etudiants.Where(a => a.Id.Equals(user.Id)).FirstOrDefaultAsync();
                }

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    roles = userRoles
                    /*email = user.Email,
                    id = userData.Id,
                    Nom = userData.Nom,
                    Prenom = userData.Prenom*/
                });
            }
            return Unauthorized();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("add-etudiant")]
        public async Task<IActionResult> RegisterEtudiant([FromBody] RegisterUser model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            string pass = model.Username.ToString()+"GI2022.";
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                PasswordHash = pass,
                EmailConfirmed = true
            };
            var result = await userManager.CreateAsync(user, pass);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await roleManager.RoleExistsAsync(UserRoles.Etudiant))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Etudiant));
            
            
            if (await roleManager.RoleExistsAsync(UserRoles.Etudiant))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Etudiant);
            }

            var etudiant = new Etudiant()
            {
                Nom = model.Nom,
                Prenom = model.Prenom,
                Filiere = "GI",
                Email = model.Email,
                UserName = model.Username,
                PasswordHash = pass,
                SecurityStamp = Guid.NewGuid().ToString()


            };

            _context.Etudiants.Add(etudiant);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                StatusCode(StatusCodes.Status422UnprocessableEntity, "database error");
            }


            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
            /*return base.Ok(mapper.Map<Etudiant>(user));*/
        }

        
        [HttpPost]
        [Route("add-encadrant")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterEncadrant([FromBody] RegisterUser model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            string pass = model.Username.ToString() + "GI2022.";
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                PasswordHash = pass,
                EmailConfirmed = true
            };
            var result = await userManager.CreateAsync(user, pass);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            
            if (!await roleManager.RoleExistsAsync(UserRoles.Encadrant))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Encadrant));

            if (await roleManager.RoleExistsAsync(UserRoles.Encadrant))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Encadrant);
            }

            var encadrant = new Encadrant()
            {
                Nom = model.Nom,
                Prenom = model.Prenom,
                Filiere = "GI",
                Email = model.Email,
                UserName = model.Username,
                PasswordHash = pass,
                SecurityStamp = Guid.NewGuid().ToString()


            };

            _context.Encadrants.Add(encadrant);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                StatusCode(StatusCodes.Status422UnprocessableEntity, "database error");
            }


            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }


        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                EmailConfirmed = true
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.Etudiant))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Etudiant));
            if (!await roleManager.RoleExistsAsync(UserRoles.Encadrant))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Encadrant));

            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            var admin = new Admin()
            {
                Filiere = "GI",
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                Nom = model.Nom,
                Prenom = model.Prenom,
                UserName = model.Username


            };

            _context.Admins.Add(admin);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                StatusCode(StatusCodes.Status422UnprocessableEntity, "database error");
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }



        //Ajouter un encadrant
        /*[Route("AjouterProf")]
        [HttpPost]
        public async Task<ActionResult<Encadrant>> AjouterEncadrant(Encadrant encadrant)
        {
            _context.Encadrants.Add(encadrant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEncadrant", new { id = encadrant.Id }, encadrant);
        }*/


        //Modifer un encadrant

        
        [Route("ModifierProf")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

        // *****************************************gerer l'espace etudiant*******************************************************
        //Ajouter un etudiant
        /*[Route("AjouterEtudiant")]
        [HttpPost]
        public async Task<ActionResult<Etudiant>> AjouterEtudiant(Etudiant etudiant)
        {
            _context.Etudiants.Add(etudiant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEtudiant", new { id = etudiant.Id }, etudiant);
        }*/

        //Modifer un etudiant
        [Authorize(Roles = "Admin")]
        [Route("ModifierEtudiant")]
        [HttpPost]
        public async Task<ActionResult> ModifierEtudiant(int id, Etudiant etudiant)
        {
            if (id != etudiant.Id)
            {
                return BadRequest();
            }

            _context.Entry(etudiant).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtudiantExists(id))
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
        private bool EtudiantExists(int id)
        {
            return _context.Etudiants.Any(e => e.Id == id);
        }

        //supprimer etudiant
        [Authorize(Roles = "Admin")]
        [Route("SuppEtudiant")]
        [HttpDelete]
        public async Task<IActionResult> SupprimerEtudiant(int id)
        {

            //fetching and filter specific member id record   
            var etudiant = await _context.Etudiants.FindAsync(id);
            
            //checking fetched or not with the help of NULL or NOT.  
            if (etudiant != null)
            {

                _context.Etudiants.Remove(etudiant);
                
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
}
