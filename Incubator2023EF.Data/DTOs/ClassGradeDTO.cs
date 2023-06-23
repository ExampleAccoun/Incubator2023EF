using Incubator2023EF.Data.Models;

namespace Incubator2023EF.Data.DTOs;

public class ClassGradeDTO
{
    public ClassGradeDTO(ClassGrade classGradeModel)
    {
        Grade = classGradeModel.Grade;
        ClassName = classGradeModel.Class.ClassName;
    }
    
    public string ClassName { get; set; }
    
    public int? Grade { get; set; }
}