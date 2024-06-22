using StorageManager.App.Commons;
using System;
using System.Collections.Generic;

namespace StorageManager.App.Models;

public partial class UserGroup : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UserUserGroup> UserUserGroups { get; set; } = new List<UserUserGroup>();
}
