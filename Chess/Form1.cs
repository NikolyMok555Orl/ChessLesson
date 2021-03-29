using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class FormChess : Form
    {
        public FormChess()
        {
            InitializeComponent();
        }
        ClassInterfaceChess classInterface;

        private void btbStart_Click(object sender, EventArgs e)
        {
            tableLayoutPanelChess.Controls.Clear();
            classInterface = new ClassInterfaceChess(tableLayoutPanelChess);
        }

        private void FormChess_Load(object sender, EventArgs e)
        {
            classInterface = new ClassInterfaceChess(tableLayoutPanelChess);
        }
    }
}
