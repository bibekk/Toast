using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notification
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new Form1();
            f.GetPdf("http://www.pdf995.com/samples/pdf.pdf");
            f.Show();
            f.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f = new Form1();
            f.GetPdf("http://unec.edu.az/application/uploads/2014/12/pdf-sample.pdf");
            f.Show();
            f.BringToFront(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var f = new Form1();
            f.GetPdf("http://www.africau.edu/images/default/sample.pdf");
            f.Show();
            f.BringToFront();
        }
    }
}
