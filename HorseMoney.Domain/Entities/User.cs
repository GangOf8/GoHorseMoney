namespace HorseMoney.Domain.Entities;

public class User
{
    #region Ref. Foreign Key

    public ICollection<Category> Category { get; set; } = new List<Category>();

    #endregion Ref. Foreign Key
}