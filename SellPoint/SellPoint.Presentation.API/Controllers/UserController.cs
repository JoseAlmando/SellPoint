using Microsoft.AspNetCore.Mvc;
using SellPoint.Bussines.Services;
using SellPoint.Data.DTO;
using SellPoint.Data.Models;
using SellPoint.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SellPoint.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private UnitOfWork _unitOfWork;
        private GenericRepository<User> _repoUser;
        public UserController()
        {
            _unitOfWork = new UnitOfWork();
            _repoUser = _unitOfWork.Repository<User>();
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult<User>> SignIn([FromBody] UserDTO user)
        {
            try
            {
                var passwordEncrypt = user.PassWord.Encrypt();
                var result = await _repoUser.FindWhere(x => x.UserNameEntidad == user.Username && x.PasswordEntidad == passwordEncrypt);
                if (result is null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            try
            {
                
                var result = await _repoUser.GetById(id);
                if (result is null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpGet("TieneUsuarios")]
        public async Task<ActionResult<bool>> TieneUsuarios()
        {

            try
            {

              var usuarios = await _repoUser.GetList();

                return usuarios.Count() > 0;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO user)
        {
            try
            {

                if (!ModelState.IsValid) return BadRequest();
                var userMapped = user.MapToUserEntity();
                await _repoUser.Add(userMapped);

                var userSave  = await _repoUser.FindWhere(u => u.UserNameEntidad == user.Username);

                return Ok(userSave);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserDTO user)
        {
            try
            {

                if (!ModelState.IsValid) return BadRequest();

                var isExist = await _repoUser.Exists(u => u.Id == id);
                
                if (!isExist)
                {
                    return NotFound();
                }

                var userDB = user.MapToUserEntity();
                userDB.Id = id;

                await _repoUser.Update(userDB);

                return Ok(userDB);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<UserDTO>> Delete(int id)
        {
            try
            {


                var user = await _repoUser.FindWhere(u => u.Id == id);

                if (user is null)
                {
                    return NotFound(new { Message = "User not Found." });
                }

                await _repoUser.Delete(user);

                var userDTO = user.MapToUserDTO();
                return Ok(userDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

    }
}
