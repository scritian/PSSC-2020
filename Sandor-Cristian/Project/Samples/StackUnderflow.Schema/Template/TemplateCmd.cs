using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Access.Primitives.IO;
using EarlyPay.Primitives.ValidationAttributes;

namespace StackUnderflow.Domain.Schema.Template
{
    public enum TemplateCmdInput
    {
        Valid,
        Invalid,
        //add extra cases here
    }

    public class TemplateCmdGen : InputGenerator<TemplateCmd, TemplateCmdInput>
    {
        public TemplateCmdGen()
        {
            mappings.Add(TemplateCmdInput.Valid, () => new TemplateCmd() /*return VALID instance here*/);
            mappings.Add(TemplateCmdInput.Invalid, () => new TemplateCmd() /*return INVALID instance here*/);
        }
    }

    public struct TemplateCmd
    {
        [NonDefaultRequired]
        public Guid Id { get; }

        [Required]
        public string Foo { get; }

        [Required]
        public string Bar { get; }

        public TemplateCmd(Guid id, string foo, string bar)
        {
            Id = id;
            Foo = foo;
            Bar = bar;
        }
    }
}
