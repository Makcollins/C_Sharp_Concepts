using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsAPI.Models;

namespace StudentsAPI.Controllers
{
    [Route("api/students")]
    // [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<StudentDTO>> GetStudents()
        {
            var students = CollegeRepository.Students.Select(s => new StudentDTO()
            {
                Id = s.Id,
                StudentName = s.StudentName,
                Address = s.Address,
                Email = s.Email
            });

            return Ok(students);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StudentDTO> GetStudentById(int id)
        {
            var student = CollegeRepository.Students.Find(x => x.Id == id);
            if (id <= 0)
                return BadRequest("Invalid entry");
            if (student == null)
                return NotFound($"Student with id {id} not found!");

            var studentDTO = new StudentDTO { Id = student.Id, StudentName = student.StudentName, Address = student.Address, Email = student.Email };
            return Ok(studentDTO);
        }

        [HttpPost]
        [Route("Create")] //api/student/create
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StudentDTO> CreateStudent([FromBody] StudentDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            if (model == null)
                return BadRequest();
            int newID = CollegeRepository.Students.LastOrDefault()!.Id + 1;
            var student = new Student { Id = newID, StudentName = model.StudentName, Address = model.Address, Email = model.Email };

            CollegeRepository.Students.Add(student);
            model.Id = student.Id;

            return CreatedAtAction(nameof(GetStudentById), new { id = model.Id }, model);
        }

        [HttpGet("{name:alpha}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StudentDTO> GetStudentByName(string name)
        {
            var student = CollegeRepository.Students.Find(x => x.StudentName == name);
            if (student == null)
                return NotFound($"Student with name {name} not found!");
            var studentDTO = new StudentDTO { Id = student.Id, StudentName = student.StudentName, Address = student.Address, Email = student.Email };
            return Ok(studentDTO);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Student> DeleteStudentById(int id)
        {
            var student = CollegeRepository.Students.Find(x => x.Id == id);
            if (id <= 0)
                return BadRequest("Invalid entry");
            if (student == null)
                return NotFound($"Wrong Id! student with id {id} doesn't exist");
            CollegeRepository.Students.Remove(student);
            return NoContent();
        }
    }
}