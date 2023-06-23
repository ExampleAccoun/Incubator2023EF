namespace Incubator2023EF.Data.Models;

public partial class ClassGrade
{
    public int StudentId { get; set; }

    public int ClassId { get; set; }

    public int? Grade { get; set; }

    public virtual Class Class { get; set; }

    public virtual Student Student { get; set; }
}
