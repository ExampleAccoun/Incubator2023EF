using Incubator2023EF.Data.Models;

namespace Incubator2023EF.Data.DTOs;

public class StudentDTO
{
    public StudentDTO(Student studentModel)
    {
        Id = studentModel.Id;
        StudentName = studentModel.StudentName;
        StartYear = studentModel.StartYear;
        CurrentGrade = studentModel.CurrentGrade;
        Age = studentModel.Age;

        ClassGrades = studentModel.ClassGrades
            ?.Select(x => new ClassGradeDTO(x))
            .ToList() ?? new List<ClassGradeDTO>();
    }

    public int Id { get; set; }

    public string StudentName { get; set; }

    public int StartYear { get; set; }

    public int CurrentGrade { get; set; }

    public int Age { get; set; }
    
    public List<ClassGradeDTO> ClassGrades { get; set; }
}