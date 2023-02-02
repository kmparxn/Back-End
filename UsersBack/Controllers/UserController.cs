using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersBack.Data;
using UsersBack.Dto;
using UsersBack.Interfaces;
using UsersBack.Models;

namespace UsersBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userReposiroty;

        public UserController(IUserRepository userReposiroty)
        {
            _userReposiroty = userReposiroty;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _userReposiroty.GetAll();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(users.Select(x => ItemToDTO(x)));
            
        }

        // GET: api/TodoItems/5
        // <snippet_GetByID>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetTodoItem(long id)
        {
            var user = await _userReposiroty.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return ItemToDTO(user);
        }

        // </snippet_GetByID>

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // <snippet_Update>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem([FromQuery] long id, [FromBody] UserDto todoDTO)
        {
            if (id != todoDTO.Id)
            {
                return BadRequest();
            }

            if (todoDTO == null)
                return BadRequest(ModelState);

            var user = await _userReposiroty.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Name= todoDTO.Name;
            user.LastName = todoDTO.LastName;
            user.Date = todoDTO.Date;
            user.Adress = todoDTO.Adress;
            user.Gender = todoDTO.Gender;
            user.Age = todoDTO.Age;

            if (!_userReposiroty.Update(user))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // <snippet_Create>
        [HttpPost]
        public async Task<ActionResult<UserDto>> PostTodoItem([FromBody] UserDto todoDTO)
        {
            if (todoDTO == null)
                return BadRequest(ModelState);

            var user = new User
            {
                Name = todoDTO.Name,
                LastName = todoDTO.LastName,
                Date = todoDTO.Date,
                Adress = todoDTO.Adress,
                Gender = todoDTO.Gender,
                Age = todoDTO.Age,
            };

            if (!_userReposiroty.Add(user))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        // </snippet_Create>

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var user = await _userReposiroty.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            if (!_userReposiroty.Delete(user))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }

        private static UserDto ItemToDTO(User todoItem) =>
          new UserDto
          {
              Id = todoItem.Id,
              Name = todoItem.Name,
              LastName = todoItem.LastName,
              Date = todoItem.Date,
              Adress = todoItem.Adress,
              Gender = todoItem.Gender,
              Age = todoItem.Age
          };

    }
}
