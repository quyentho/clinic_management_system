using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic
{
    public partial class OperationForm : Form
    {
        public Operation Operation { get; set; }
        public  EventHandler UpdateDataGridViewEventHandler;
        public int IdSelected { get; set; }
    
    }
}
