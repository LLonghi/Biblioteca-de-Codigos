using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

class labelStyled : Label
{
    [Localizable(true)]

    private Color cOnOver,
                  cOnDown,
                  cColor;

    //Mouse Sobre
    [Description("Cor do controle ao passar mouse sobre."), Category("Color")]
    public Color ColorOnOver
    {
        get { return cOnOver; }
        set { cOnOver = value;  }
    }
    private void updateBackOver()
    {
        this.BackColor = cOnOver;
    }
    protected override void OnMouseEnter(EventArgs e)
    {
        updateBackOver();
        base.OnMouseEnter(e);
    }


    //Mouse Click
    [Description("Cor do controle ao clicar mouse."), Category("Color")]
    public Color ColorOnDown
    {
        get { return cOnDown; }
        set { cOnDown = value; }
    }
    private void updateBackDown()
    {
        this.BackColor = cOnDown;
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
        updateBackDown();
        base.OnMouseDown(e);
    }


    //Mouse Up ou Mouse Leave
    [Description("Cor do controle ao retirar mouse."), Category("Color")]
    public new Color Color
    {
        get { return cColor; }
        set { cColor = value; updateBack();}
    }
    private void updateBack()
    {
        this.BackColor = cColor;
    }
    protected override void OnMouseLeave(EventArgs e)
    {
        updateBack();
        base.OnMouseLeave(e);
    }
    protected override void OnMouseUp(MouseEventArgs e)
    {
        updateBack();
        base.OnMouseUp(e);
    }

    protected override void OnBackColorChanged(EventArgs e)
    {
       base.OnBackColorChanged(e);
    }

    protected override void OnParentBackColorChanged(EventArgs e)
    {
        base.OnParentBackColorChanged(e);
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        cColor = BackColor;
        AutoSize = false;
        TextAlign = ContentAlignment.MiddleCenter;
        ImageAlign = ContentAlignment.MiddleLeft;
        Font f = new Font(Font.FontFamily,9,FontStyle.Bold);
        this.Font = f;

    }
}
