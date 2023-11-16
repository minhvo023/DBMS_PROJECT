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

    public partial class FormSoLuongGioHang : Form
    {
        public delegate void ssoluong(string text);
        public ssoluong sl;
        public FormSoLuongGioHang()
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
            FormSoLuongGioHang.ActiveForm.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            FormSoLuongGioHang.ActiveForm.Close();
        }

    }
}
