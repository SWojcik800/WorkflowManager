using StorageManager.App.Commons;
using StorageManager.App.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StorageManager.App.Models;

public partial class WorkflowStage : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public AssignedEntityType AssignedEntityType { get; set; }

    public int AssignedEntityId { get; set; }

    [NotMapped]
    public string AssignedEntityTypeDisplayName
    {
        get
        {
            switch (this.AssignedEntityType)
            {
                case AssignedEntityType.Creator:
                    {
                        return "Zgłaszający";
                        break;
                    }
                case AssignedEntityType.Group:
                    {
                        return "Grupa";
                        break;
                    }
                case AssignedEntityType.SpecificUser:
                    {
                        return "Użytkownik";
                        break;
                    }
                default:
                    return "Zgłaszający";
                    break;
            }
        }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                switch (value)
                {
                    case "Zgłaszający":
                        {
                            AssignedEntityType = AssignedEntityType.Creator;
                            break;
                        }
                    case "Grupa":
                        {
                            AssignedEntityType = AssignedEntityType.Group;

                            break;
                        }
                    case "Użytkownik":
                        {
                            AssignedEntityType = AssignedEntityType.SpecificUser;

                            break;
                        }
                    default:
                        {
                            AssignedEntityType = AssignedEntityType.Creator;
                            break;
                        }
                }

            }
        }

    }

    [NotMapped]
    public string AssignedEntityDisplayName
    { 
        get {
            switch (this.AssignedEntityType)
            {
                case AssignedEntityType.Creator:
                    {
                        return "Zgłaszający";
                    }
                case AssignedEntityType.Group:
                    {
                        var entityId = AssignedEntityId;
                        var group = AppManager.Instance.Dictionaries.FirstOrDefault(x => x.Name == "Grupy użytkowników");

                        if (group is null)
                        {
                            AppManager.Instance.ShowErrorMessage("Nie ustawiono słownika Grupy użytkowników");
                            return "";
                        }

                        var foundGroup = group.DictionaryItems.FirstOrDefault(x => x.Id == entityId);
                        if(foundGroup is null)
                        {
                            return "";
                        }

                        return foundGroup.Name;

                    }
                case AssignedEntityType.SpecificUser:
                    {
                        var entityId = AssignedEntityId;
                        var user = AppManager.Instance.Users.FirstOrDefault(x => x.Id == entityId);

                        return user.Login;
                    }
                default:
                    return "Zgłaszający";
                    break;
            }
        }

    }

    public int? StageIndex { get; set; }

    public int? WorkflowId { get; set; }
    public Workflow? Workflow { get; set; }
}

public enum AssignedEntityType
{
    Creator,
    Group,
    SpecificUser
}
