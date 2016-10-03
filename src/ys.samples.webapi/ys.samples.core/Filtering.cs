using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples {
    public class Filtering {
        public enum ConditionOperator {
            Equal = 0,
            NotEqual = 1,
            LessThan = 2,
            LessEqualThan = 3,
            GreaterThan = 4,
            GreaterEqualThan = 5,
            Contains = 6,
            NotContains =7,
        }
        public enum LogicalOperator {
            None = 0,
            And = 1,
            Or = 2,
        }
        public class Condition {
            public Condition( ) {
                this.NextConjugation = LogicalOperator.None;
            }
            public string Name {
                get;
                set;
            }
            public ConditionOperator Operator {
                get;
                set;
            }
            public object Value {
                get;
                set;
            }
            public LogicalOperator NextConjugation {
                get;set;
            }
        }
        public Condition[] Conditions {
            get;
            set;
        }
    }
}
