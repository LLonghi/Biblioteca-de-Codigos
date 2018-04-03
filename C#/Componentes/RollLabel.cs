using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace StockShower
{
    public partial class RollLabel : UserControl
    {
        private int m_speed = 5;

        public RollLabel()
        {
            InitializeComponent();
        }

        [Category("Appearance"),Browsable(true)]
        public override string Text
        {
            get { return lblMsg.Text; }
            set { lblMsg.Text = value; }
        }

        [Category("Appearance")]
        public int Speed
        {
            get { return m_speed; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                m_speed = value;
            }
        }

        private void RollLabel_Resize(object sender, EventArgs e)
        {
            lblMsg.Top = (this.Height - lblMsg.Height) / 2;
            lblMsg.Left = this.Width;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblMsg.Left = lblMsg.Left - m_speed;
            if (lblMsg.Left <= -lblMsg.Width)
            {
                lblMsg.Left = this.Width;
            }
        }

        private void RollLabel_Load(object sender, EventArgs e)
        {

        }
    }
}
