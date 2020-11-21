using System;
using System.Collections.Generic;
using System.Text;
using LanguageExt;

namespace StackUnderflow.Domain.Schema.Backoffice.SetPermissionsOp
{
    public struct SetPermissionCmd
    {
        public Option<Guid> UserId { get; }
        public int Level { get; }

        public SetPermissionCmd(Option<Guid> userId, int level)
        {
            UserId = userId;
            Level = level;
        }
    }

    public class SetPermissionResult
    {
    }
}
