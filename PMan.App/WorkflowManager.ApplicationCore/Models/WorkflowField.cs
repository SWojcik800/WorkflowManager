using Microsoft.IdentityModel.Protocols;
using StorageManager.App.Commons;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace StorageManager.App.Models;

public partial class WorkflowField : IEntity
{
    public int Id { get; set; }

    public int? WorkflowId { get; set; }

    public string DisplayName { get; set; } = null!;

    public string Code { get; set; } = null!;

    public WorkflowFieldType Type { get; set; }

    public string DisplayData { get; set; } = "";

    [IgnoreDataMember]
    public string FieldType
    {
        get
        {
            return WorkflowFieldTypeExtensions.GetName(Type);
        }

        set
        {
            if(!string.IsNullOrEmpty(value))
                Type = WorkflowFieldTypeExtensions.GetValue(value);
        }
    }

    public virtual Workflow? Workflow { get; set; } = null;
}

public static class WorkflowFieldTypeExtensions
{

    private static Dictionary<WorkflowFieldType, string>  _dict = new Dictionary<WorkflowFieldType, string>
        {
            { WorkflowFieldType.Text, "Pole Tekstowe" },
            { WorkflowFieldType.Checkbox, "Checkbox" },
            { WorkflowFieldType.ComboBox, "Combobox" },
            { WorkflowFieldType.Dictionary, "Słownik" },
            { WorkflowFieldType.User, "Użytkownik" },
            { WorkflowFieldType.Date, "Data" },
        };
    public static string GetName(WorkflowFieldType e)
    {
        return _dict[e];
    }

    public static WorkflowFieldType GetValue(string e)
    {
        var dict = _dict.ToDictionary(x => x.Value, y => y.Key);
        return dict[e];
    }

    public static List<string> GetOptions()
        => _dict.Select(x => x.Value).ToList();

}

public enum WorkflowFieldType
{
    Text,
    Checkbox,
    ComboBox,
    Dictionary,
    User,
    Date
}
