using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class TranspTextBox : RichTextBox
{
    public TranspTextBox()
    {
        this.SetStyle(ControlStyles.Opaque, true);
        this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
        this.TextChanged += TransparentLabel_TextChanged;
        this.VScroll += TransparentLabel_TextChanged;
        this.HScroll += TransparentLabel_TextChanged;
    }


    void TransparentLabel_TextChanged(object sender, System.EventArgs e)
    {
        this.ForceRefresh();
    }
    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams parms = base.CreateParams;
            parms.ExStyle |= 0x20;  // Turn on WS_EX_TRANSPARENT
            
            if(Password)
            parms.Style |= 0x20;// Turn on ES_PASSWORD

            return parms;
        }
    }
    public void ForceRefresh()
    {
        this.UpdateStyles();
    }

   
    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        if(Upcase)
        e.KeyChar = Char.ToUpper(e.KeyChar);
        base.OnKeyPress(e);
    }

    //System.Windows.Forms.HorizontalAlignment.Center;

    [Localizable(true)]
    public System.Windows.Forms.HorizontalAlignment TextAlign
    {
        get { return this.SelectionAlignment; }
        set { SelectionAlignment = value; }
    }

    private bool Passw = false;
    [Localizable(true)]
    public bool Password
    {
        get { return Passw; }
        set { Passw = value; }
    }

    private bool Upcase = false;
    [Localizable(true)]
    public bool UpperCase
    {
        get { return Upcase; }
        set { Upcase = value; }
    }

    [Localizable(true)]
    public string Cue
    {
        get { return mCue; }
        set { mCue = value; updateCue(); }
    }

    private void updateCue()
    {
        if (this.IsHandleCreated && mCue != null)
        {
            SendMessage(this.Handle, 0x1501, (IntPtr)1, mCue);
        }
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        updateCue();
    }
    private string mCue;

    // PInvoke
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, string lp);
}