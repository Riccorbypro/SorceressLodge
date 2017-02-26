using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorceressLodge {
    public class MagicType {

        private int id;

        public int ID {
            get { return id; }
            set { id = value; }
        }

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

        public MagicType(int id, string typeName, bool isAllowed) {
            this.id = id;
            this.typeName = typeName;
            this.isAllowed = isAllowed;
        }

        public override string ToString() {
            return Type;
        }
    }
}
