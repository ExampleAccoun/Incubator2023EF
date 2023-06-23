namespace Incubator2023EF.Data.Models;

public partial class Student
{
    public int Id { get; set; }

    public string StudentName { get; set; }

    public int StartYear { get; set; }

    public int CurrentGrade { get; set; }

    public int Age { get; set; }

    public virtual ICollection<ClassGrade> ClassGrades { get; set; }
}
