﻿using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

public class TransparentPictureBox: PictureBox
{
    public TransparentPictureBox()
    {
        this.transparentBackColor = Color.Blue;
        this.opacity = 100;
        this.BackColor = Color.Transparent;
    }
    //protected override void OnPaint(PaintEventArgs e)
    //{
    //}

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
        base.OnPaintBackground(pevent);
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


                pevent.Graphics.DrawImage(bmp, -Left, -Top);
                using (var b = new SolidBrush(Color.FromArgb(this.Opacity, this.TransparentBackColor)))
                {
                    pevent.Graphics.FillRectangle(b, this.ClientRectangle);
                }
                pevent.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, Color.Transparent);
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