using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using LanguageExt;

namespace StackUnderflow.Backoffice.Adapters.Template
{
    public partial class TemplateAdapter
    {
        public override Task Assertions(object[] path, Unit state, Unit op, Unit result)
        {
            var withInput = from case1 in path.OfType<Case1>().HeadOrNone()
                            from effect1 in path.OfType<Effect1>().HeadOrNone()
                                //extract as many cases as required
                            select AssertionsWithInput(case1, effect1, op, result, state);

            return Task.CompletedTask;
        }

        private Unit AssertionsWithInput(Case1 case1, Effect1 effect1, Unit op, Unit result, Unit state)
        {
            var _ = (case1, effect1) switch
            {
                (Case1.ValidCase, Effect1.OK) => PostConditions(op, result, state),
                (Case1.InvalidCase, _) => OnInvalidCase1(op, result, state),
                _ => throw new Exception($"The provided path was not handled")
            };
            return Unit.Default;
        }

        private Task OnInvalidCase1(Unit op, Unit result, Unit state)
        {
            //assertions here over any possible correlation between 
            return Task.CompletedTask;
        }
    }
}
