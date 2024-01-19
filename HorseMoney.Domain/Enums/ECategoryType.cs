using System.ComponentModel;

namespace HorseMoney.Domain.Enums;

public enum ECategoryType
{
    [Description("Undefined")] Undefined = 0,
    [Description("Income")] Income = 1,
    [Description("OutGoing")] OutGoing = 2
}