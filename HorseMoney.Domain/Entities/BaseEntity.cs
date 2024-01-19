using System.ComponentModel.DataAnnotations;

namespace HorseMoney.Domain.Entities;

public abstract class BaseEntity
{
    [Key] public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    #region Methods

    public void Update()
    {
        UpdatedAt = DateTime.Now;
    }

    #endregion Methods
}