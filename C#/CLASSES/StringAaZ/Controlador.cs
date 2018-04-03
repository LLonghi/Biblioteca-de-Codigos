using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class Controlador
{

    const int ColumnBase = 26;
    int DigitMax = 5; // ceil(log26(Int32.Max))
    const string Digits = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    int max
    {
        get { return DigitMax; }
        set { DigitMax = value; }
    }

    public string ItoS(int index)
    {
        if (index <= ColumnBase)
            return Digits[index - 1].ToString();

        var sb = new StringBuilder().Append(' ', DigitMax);
        var current = index;
        var offset = DigitMax;
        while (current > 0)
        {
            sb[--offset] = Digits[--current % ColumnBase];
            current /= ColumnBase;
        }
        return sb.ToString(offset, DigitMax - offset);
    }
}
