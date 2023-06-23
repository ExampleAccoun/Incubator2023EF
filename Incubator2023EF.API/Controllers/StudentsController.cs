using Incubator2023EF.Data.Models;
using Incubator2023EF.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Incubator2023EF.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private IStudentRepository _studentRepository;
    
    public StudentsController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    
    [HttpGet]
    public IActionResult GetAllStudents()
    {
        var students = _studentRepository.GetAllStudents();
        return Ok(students);
    }

    [HttpGet("{studentId}")]
    public IActionResult GetStudentById(int studentId)
    {
        var student = _studentRepository.GetStudentById(studentId);
        
        return Ok(student);
    }

    [HttpGet("byName/{searchValue}")]
    public IActionResult SearchStudentsByName(string searchValue)
    {
        var students = _studentRepository.SearchStudentsByName(searchValue);

        return Ok(students);
    }
    
    [HttpGet("byClass/{className}")]
    public IActionResult SearchStudentsByClass(string className)
    {
        var students = _studentRepository.SearchStudentsByClass(className);

        return Ok(students);
    }
    
    [HttpGet("withoutGrades")]
    public IActionResult SearchStudentsWithoutGrades()
    {
        var students = _studentRepository.SearchStudentsWithoutGrades();

        return Ok(students);
    }

    [HttpPost]
    public IActionResult AddNewStudent([FromBody] Student student)
    {
        var newStudent = _studentRepository.AddStudent(student);

        return Ok(newStudent);
    }

    [HttpPatch("{studentId}")]
    public IActionResult UpdateStudent(int studentId, [FromBody] Student student)
    {
        var updatedStudent = _studentRepository.UpdateStudent(studentId, student);

        return Ok(updatedStudent);
    }

    [HttpDelete("{studentId}")]
    public IActionResult DeleteStudent(int studentId)
    {
        _studentRepository.DeleteStudent(studentId);

        return Ok();
    }
}