using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

public class TranspButton : Button
{
    public TranspButton()
    {
        this.transparentBackColor = Color.Blue;
        aux = transparentBackColor;
        this.opacity = 100;
        this.BackColor = Color.Transparent;
    }
    Color aux ;

    protected override void OnMouseClick(MouseEventArgs e)
    {
        base.OnMouseClick(e);
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        this.transparentBackColor = this.FlatAppearance.MouseOverBackColor;
        Refresh();
        base.OnMouseEnter(e);
    }
    protected override void OnMouseLeave(EventArgs e)
    {
        this.transparentBackColor = aux;
        Refresh();
        base.OnMouseLeave(e);
    }
    protected override void OnMouseDown(MouseEventArgs mevent)
    {
        this.transparentBackColor = this.FlatAppearance.MouseDownBackColor;
        Refresh();
        base.OnMouseDown(mevent);
    }
    protected override void OnMouseUp(MouseEventArgs mevent)
    {
        this.transparentBackColor = aux;
        Refresh();
        base.OnMouseUp(mevent);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (Parent != null)
        {
            using (var bmp = new Bitmap(Parent.Width, Parent.Height))
            {
                Parent.Controls.Cast<Control>()
                      .Where(c => Parent.Controls.GetChildIndex(c) > Parent.Controls.GetChildIndex(this))
                      .Where(c => c.Bounds.IntersectsWith(this.Bounds))
                      .OrderByDescending(c => Parent.Controls.GetChildIndex(c))
                      .ToList()
                      .ForEach(c => c.DrawToBitmap(bmp, c.Bounds));


                e.Graphics.DrawImage(bmp, -Left, -Top);
                using (var b = new SolidBrush(Color.FromArgb(this.Opacity, this.TransparentBackColor)))
                {
                    e.Graphics.FillRectangle(b, this.ClientRectangle);
                }
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                TextRenderer.DrawText(e.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, Color.Transparent);
            }
        }
    }

    private int opacity;
    public int Opacity
    {
        get { return opacity; }
        set
        {
            if (value >= 0 && value <= 255)
                opacity = value;
            this.Invalidate();
        }
    }

    public Color transparentBackColor;
    public Color TransparentBackColor
    {
        get { return transparentBackColor; }
        set
        {
            transparentBackColor = value;
            aux = transparentBackColor;
            this.Invalidate();
        }
    }

    [Browsable(false)]
    public override Color BackColor
    {
        get
        {
            return Color.Transparent;
            
        }
        set
        {
            base.BackColor = Color.Transparent;
        }
    }
}