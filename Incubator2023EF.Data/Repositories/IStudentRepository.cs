using Incubator2023EF.Data.DTOs;
using Incubator2023EF.Data.Models;

namespace Incubator2023EF.Data.Repositories;

public interface IStudentRepository
{
    List<StudentDTO> GetAllStudents();
    
    StudentDTO GetStudentById(int studentId);

    List<StudentDTO> SearchStudentsByName(string searchValue);

    List<StudentDTO> SearchStudentsByClass(string className);

    List<StudentDTO> SearchStudentsWithoutGrades();

    int AddStudent(Student student);

    StudentDTO UpdateStudent(int studentId, Student student);

    void DeleteStudent(int studentId);
}