using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerSide {
    public partial class Main : Form {

        delegate void SetTextCallback(string text);
        public bool started = false;
        public bool closed = false;

        public bool Started {
            get { return started; }
        }

        public Main(bool autoStart) {
            InitializeComponent();
            if (autoStart) {
                started = true;
                startButt.Enabled = false;
            } else {
                stopButt.Enabled = false;
            }
        }

        public void AppendWorker(string s) {
            AppendText(s);
        }

        private void AppendText(string s) {
            if (logBox.InvokeRequired) {
                SetTextCallback d = new SetTextCallback(AppendWorker);
                Invoke(d, new object[] { s });
            } else {
                try {
                    logBox.AppendText(s + "\n");
                } catch (Exception) { }
            }
        }

        private void startButt_Click(object sender, EventArgs e) {
            started = true;
            startButt.Enabled = false;
            stopButt.Enabled = true;
        }

        private void stopButt_Click(object sender, EventArgs e) {
            started = false;
            stopButt.Enabled = false;
            startButt.Enabled = true;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e) {
            started = false;
            closed = true;
        }
    }
}
