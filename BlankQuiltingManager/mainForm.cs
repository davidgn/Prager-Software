using System;
using System.Windows.Forms;

namespace Blank_Quilting_Manager
{
    public partial class mainForm : Form
    {
        public mainForm() {
            InitializeComponent();

            OpenDB();  //  open the database


        }


        //-------------------    add record to d/b    ----------------------|
        private void bDBAdd_Click(object sender, EventArgs e) {
            CustomerDBAdd();
        }

        //-------------------    update record to d/b    ----------------------|
        private void bDBUpdate_Click(object sender, EventArgs e) {

        }

        //-------------------    delete record to d/b    ----------------------|
        private void bDBDelete_Click(object sender, EventArgs e) {

        }

        //-------------------    scan order and place pdf address in d/b    ----------------------|
        private void bScanOrder_Click(object sender, EventArgs e) {

        }






    }
}
