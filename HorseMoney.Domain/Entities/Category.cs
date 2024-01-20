using HorseMoney.Domain.Enums;

namespace HorseMoney.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public bool CreateByUser { get; set; }
    public ECategoryType Type { get; set; }
    public Guid? UserId { get; set; } = null;

    #region Ref. Foreign Key

    public User User { get; set; } = new User();

    #endregion Ref. Foreign Key
}