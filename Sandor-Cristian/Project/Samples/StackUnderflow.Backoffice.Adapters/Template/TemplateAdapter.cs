using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Access.Primitives.IO;
using LanguageExt;
using StackUnderflow.Domain.Schema.Backoffice.InviteTenantAdminOp;

namespace StackUnderflow.Backoffice.Adapters.Template
{
    public partial class TemplateAdapter : Adapter<Unit, Unit, Unit>
    {
        //change the type arguments and generate the correct overrides
        public override Task PostConditions(Unit cmd, Unit result, Unit state)
        {
            throw new NotImplementedException();
        }

        public override Task<Unit> Work(Unit cmd, Unit state)
        {
            throw new NotImplementedException();
        }
    }
}
