using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoClicker
{
    class infoPasser
    {
        public static Label exposeLabel(string labelName, Form parentForm)
        {
           foreach( Control ctrl in parentForm.Controls)
           {
               if(ctrl.Name == labelName && ctrl is Label)
               {
                   return (Label)ctrl;
               }
           }
           return null;
        }

        public static TextBox exposeTextBox(string textboxName, Form parentForm)
        {
            foreach (Control ctrl in parentForm.Controls)
            {
                if(ctrl.Name == textboxName && ctrl is TextBox)
                {
                    return (TextBox)ctrl;
                }
            }
            return null;
        }
    }
}
