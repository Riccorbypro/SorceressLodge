using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorceressLibs {
    [Serializable]
    public class SerializedObject {
        private string objectClass = "";
        private string objectMethod = "";
        private object[] objectS = new object[0];
        private DateTime dt = DateTime.Now;
        private Users user = new Users("", "", false);

        public string ObjectClass {
            get {
                return objectClass;
            }

            set {
                objectClass = value;
            }
        }

        public object[] ObjectS {
            get {
                return objectS;
            }

            set {
                objectS = value;
            }
        }

        public DateTime Dt {
            get {
                return dt;
            }

            set {
                dt = value;
            }
        }

        public Users User {
            get {
                return user;
            }

            set {
                user = value;
            }
        }

        public string ObjectMethod {
            get {
                return objectMethod;
            }

            set {
                objectMethod = value;
            }
        }

        public SerializedObject(string oc, string om, object[] o, Users u) {
            ObjectClass = oc;
            ObjectMethod = om;
            ObjectS = o;
            User = u;
            Dt = DateTime.Now;
        }

    }
}
