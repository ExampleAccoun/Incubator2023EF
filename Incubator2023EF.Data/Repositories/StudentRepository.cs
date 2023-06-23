using Incubator2023EF.Data.DTOs;
using Incubator2023EF.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Incubator2023EF.Data.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly EfexampleContext _dbContext;

    public StudentRepository(EfexampleContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<StudentDTO> GetAllStudents()
    {
        List<Student> students = _dbContext.Students.ToList();

        var studentDtos = students.Select(x => new StudentDTO(x));

        return studentDtos.ToList();
    }

    public StudentDTO GetStudentById(int studentId)
    {
        Student student = _dbContext.Students
            .FirstOrDefault(s => s.Id == studentId);

        return student is not null ? new StudentDTO(student) : null;
    }

    public List<StudentDTO> SearchStudentsByName(string searchValue)
    {
        IQueryable<Student> studentsQuery = _dbContext.Students
            .Where(s => s.StudentName.ToLower().Contains(searchValue.ToLower()));
        
        List<Student> students = studentsQuery.ToList();
        
        var studentDtos = students.Select(x => new StudentDTO(x));

        var queryString = studentsQuery.ToQueryString();

        return studentDtos.ToList();
    }

    public List<StudentDTO> SearchStudentsByClass(string className)
    {
        IQueryable<Student> studentsQuery = _dbContext.Students
            .Where(s => s.ClassGrades.Any(cg => cg.Class.ClassName.ToLower() == className.ToLower()));
        
        List<Student> students = studentsQuery.ToList();
        
        var studentDtos = students.Select(x => new StudentDTO(x));

        var queryString = studentsQuery.ToQueryString();

        return studentDtos.ToList();
    }

    public List<StudentDTO> SearchStudentsWithoutGrades()
    {
        IQueryable<Student> studentsQuery = _dbContext.Students
            .Where(s => !s.ClassGrades.Any());
        
        List<Student> students = studentsQuery.ToList();
        
        var studentDtos = students.Select(x => new StudentDTO(x));

        var queryString = studentsQuery.ToQueryString();

        return studentDtos.ToList();
    }

    public int AddStudent(Student student)
    {
        student.Id = 0;

        _dbContext.Students.Add(student);

        _dbContext.SaveChanges();

        return student.Id;
    }

    public StudentDTO UpdateStudent(int studentId, Student student)
    {
        Student studentToUpdate = _dbContext.Students.FirstOrDefault(s => s.Id == studentId);

        if (studentToUpdate is null)
        {
            return null;
        }
        
        UpdateStudentEntity(studentToUpdate, student);

        _dbContext.SaveChanges();

        return new StudentDTO(studentToUpdate);
    }

    public void DeleteStudent(int studentId)
    {
        Student studentToDelete = _dbContext.Students.FirstOrDefault(s => s.Id == studentId);
        
        if (studentToDelete is null)
        {
            return;
        }

        _dbContext.ClassGrades.RemoveRange(studentToDelete.ClassGrades);
        _dbContext.Students.Remove(studentToDelete);

        _dbContext.SaveChanges();
    }

    private void UpdateStudentEntity(Student studentToUpdate, Student studentNewData)
    {
        if (!string.IsNullOrEmpty(studentNewData.StudentName))
        {
            studentToUpdate.StudentName = studentNewData.StudentName;
        }

        if (studentNewData.StartYear != 0)
        {
            studentToUpdate.StartYear = studentNewData.StartYear;
        }

        if (studentNewData.CurrentGrade != 0)
        {
            studentToUpdate.CurrentGrade = studentNewData.CurrentGrade;
        }

        if (studentNewData.Age != 0)
        {
            studentToUpdate.Age = studentNewData.Age;
        }
    }
}