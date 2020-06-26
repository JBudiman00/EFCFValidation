using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFCFValidate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var cxt = new MyContext())
            {
                cxt.Students.Count();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            using (var cxt = new MyContext())
            {
                var newClass = new Classes
                {
                    className = "Underwater Basket Weaving",
                    creditHours = 1
                };

                var newClass1 = new Classes
                {
                    className = "Anatomy of lint and brown-nosed rats",
                    creditHours = 3
                };

                cxt.Class.Add(newClass1);
                cxt.Class.Add(newClass);
                cxt.SaveChanges();
            }
        }
        private void btnRead_Click(object sender, EventArgs e)
        {
            using (var cxt = new MyContext())
            {
                int count = cxt.Class.Count();
                var readIn = cxt.Class;
                lblRead.Text = "";
                if (count != 0)
                {
                    foreach (var element in readIn)
                    {
                        lblRead.Text +=string.Format("Class Name: {0} Credit hours: {1}\r\n", 
                            element.className, element.creditHours);
                    }
                }
                else
                {
                    lblRead.Text = "Table is empty";
                }
            }
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
            using (var cxt = new MyContext())
            {
                var modifyIn = cxt.Class.Where(s => s.creditHours == 3);
                foreach (var element in modifyIn)
                {
                    element.className = "Intro to EF Code First";
                    element.creditHours = 2;
                }
                lblRead.Text = "";
                cxt.SaveChanges();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (var cxt = new MyContext())
            {
                var readIn = cxt.Class
                    .Where(s => s.creditHours == 2);
                foreach (var element in readIn)
                {
                    cxt.Class.Remove(element);
                }
                cxt.SaveChanges();
                lblRead.Text = "";
            }
        }
    }
}
