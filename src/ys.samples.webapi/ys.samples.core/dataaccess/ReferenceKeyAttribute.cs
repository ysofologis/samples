using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.dataaccess {
    public class ReferenceKeyAttribute : StringLengthAttribute {
        public ReferenceKeyAttribute() : base(PersistentEntity.KEY_SIZE) {
            this.MinimumLength = PersistentEntity.KEY_SIZE;
        }
    }
}
