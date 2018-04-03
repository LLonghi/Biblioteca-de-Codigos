using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

public class EmpresaAtiva: Label
{
    private bool iTeste = false;
    private iSistema model = iSistema.Finwin;

    private string codemp = "", stremp = "";


    #region Diretorio 
    [Description("Define o diretorio do sistema sendo utilizado"), Category("Model")]
    public string Diretorio { get; set;}
    #endregion

    protected override void OnHandleCreated(EventArgs e)
    {
        Diretorio = @"C:\";
    }

    [Description("Define o sistema sendo utilizado(ex: 'C:\')"), Category("Model")]
    public iSistema Sistema {
        get { return model; }
        set { model = value;Carrega(); }
    }

    
    private void Carrega()
    {
        switch (model)
        {

            case iSistema.EFiscal:
                if (iTeste) { Text = "Empresa Teste: 9999"; stremp = "9999";codemp = "e9999"; }
                else {
                    Text = "Em Construção";
                }
                break;

            case iSistema.Finwin:
                #region
                if (iTeste) { Text = "Empresa Teste: 99999"; stremp = "99999"; codemp = "99999"; }
                else {
                    string xE = txt_empresa_FinWin();
                    Text = "Empresa: " + xE;
                    stremp = xE;
                    codemp = xE;
                }
                #endregion
                break;

            case iSistema.Fatwin:
                #region
                if (iTeste) { Text = "Empresa Teste: 99999"; stremp = "99999"; codemp = "99999"; }
                else {
                    string xE = txt_empresa_FatWin();
                    Text = "Empresa: " + xE;
                    stremp = xE;
                    codemp = xE;
                }
                #endregion
                break;

            case iSistema.Folhawin:
                if (iTeste) { Text = "Empresa Teste: 9999"; stremp = "9999"; codemp = "f9999"; }
                else { Text = "Em Construção"; }
                break;

            case iSistema.Contabil:
                if (iTeste) { Text = "Empresa Teste: 9999"; stremp = "9999"; codemp = "c9999"; }
                else { Text = "Em Construção"; }
                break;

            default:
                Text = "Erro.";
                break;
        }
    }

    private string txt_empresa_FinWin()
    {
        try
        {
            string caminho_empresa = File.ReadAllText(Diretorio + @"FinWin\Plus\ATIVAE.txt");
            return caminho_empresa.Substring(10, 5);
        }
        catch(Exception ex)
        {
            throw;
        }
    }

    private string txt_empresa_FatWin()
    {
        try
        {
            string caminho_empresa = File.ReadAllText(Diretorio + @"FatWin\Plus\ATIVAE.txt");
            return caminho_empresa.Substring(10, 5);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public enum iSistema
    {
        Folhawin,
        EFiscal,
        Fatwin,
        Finwin,
        Contabil,
    }

    [Description("Define o sistema esta em modo de testes"), Category("Model")]
    public bool Teste { get { return iTeste; } set { iTeste = value; } }


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
