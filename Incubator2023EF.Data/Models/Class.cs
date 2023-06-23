namespace Incubator2023EF.Data.Models;

public class Class
{
    public int Id { get; set; }

    public string ClassName { get; set; }

    public virtual ICollection<ClassGrade> ClassGrades { get; set; }
}
