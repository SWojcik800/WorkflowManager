using StorageManager.App.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StorageManager.App.Models;

public partial class User : IEntity
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public string? Password { get; set; }

    public virtual ICollection<UserUserGroup> UserUserGroups { get; set; } = new List<UserUserGroup>();
    public bool IsAdmin { get; set; }
    public string? Groups { get; set; }
    [NotMapped]
    public string UserType { 
        get {
            if (IsAdmin)
                return "Administrator";
            return "Użytkownik";
        }
    }
    public List<string> GroupList()
        => string.IsNullOrEmpty(Groups) ? new List<string>() : Groups.Split(";").ToList();
}
