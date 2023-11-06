using DBMS_NHOM_10.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_NHOM_10.Forms_branch
{

    public partial class FormSoLuong : Form
    {
        public delegate void ssoluong(string text);
        public ssoluong sl;
        public FormSoLuong()
        {
            InitializeComponent();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if(txbInputSoluong.Text.Length> 0)
            {
                if(sl != null)
                {
                    sl(txbInputSoluong.Text);
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            FormSoLuong.ActiveForm.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
