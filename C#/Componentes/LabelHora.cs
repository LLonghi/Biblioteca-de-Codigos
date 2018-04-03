using System;
using System.ComponentModel;
using System.Windows.Forms;

public class Hora : Label
{
    private Timer xTime = new Timer();
    private bool x = false;
    protected override void OnHandleCreated(EventArgs e)
    {
        xTime.Interval = 100;
        xTime.Enabled = true;
        xTime.Tick += XTime_Tick;
    }

    [Description("Define se o horario é mostrado como Short ou Long."), Category("Model")]
    public bool isLong
    {
        get { return x; }
        set { x = value; }
    }

    private void XTime_Tick(object sender, EventArgs e)
    {
        if(!x)
            Text = DateTime.Now.ToShortTimeString();
        else
            Text = DateTime.Now.ToLongTimeString();
    }

    protected override void CreateHandle()
    {
        base.CreateHandle();
    }

    protected override void OnTextChanged(EventArgs e)
    {
        //Text = DateTime.Now.ToShortTimeString();
        base.OnTextChanged(e);
    }
}
