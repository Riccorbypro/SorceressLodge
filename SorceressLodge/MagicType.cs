using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorceressLodge {
    abstract class MagicType {
        private string typeName;

        public string Type {
            get { return typeName; }
            set { typeName = value; }
        }

        private bool isAllowed;

        public bool Allowed {
            get { return isAllowed; }
            set { isAllowed = value; }
        }
    }
}
