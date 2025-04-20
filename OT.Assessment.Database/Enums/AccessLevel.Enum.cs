using System.ComponentModel;

namespace OT.Assessment.Database.Enums;

public enum AccessLevelEnum
{
    [Description("This is for qa-testers")]
    QaTester,

    [Description("This is for developers")]
    Developer,

    [Description("This is for admin")]
    Administrator
}