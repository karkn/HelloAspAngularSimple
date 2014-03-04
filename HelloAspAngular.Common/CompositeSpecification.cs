using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloAspAngular.Common
{
    public class CompositeSpecification<T> : ISpecification<T>
    {
        private IEnumerable<ISpecification<T>> _specs;

        public CompositeSpecification(IEnumerable<ISpecification<T>> specs)
        {
            _specs = specs;
        }

        public bool IsSatisfiedBy(T subject)
        {
            return BrokenSpecifications(subject).Count() > 0;
        }

        public IEnumerable<ISpecification<T>> BrokenSpecifications(T subject)
        {
            return _specs.Where(spec => !spec.IsSatisfiedBy(subject));
        }
    }
}
