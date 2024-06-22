using StorageManager.App.Commons;
using System;
using System.Collections.Generic;

namespace StorageManager.App.Models;

public partial class UserUserGroup : IEntity
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int UserGroupId { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual UserGroup UserGroup { get; set; } = null!;
}
