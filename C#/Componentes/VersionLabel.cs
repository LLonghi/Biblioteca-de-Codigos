using System;
using System.Windows.Forms;

public class VersionLabel : Label
{
    protected override void OnHandleCreated(EventArgs e)
    {
        try { 
        Text = "Versão: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
        {
            Text = "Versão: " + System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
        }
    }
        catch { }
    }

    protected override void CreateHandle()
    {        
        base.CreateHandle();
    }

    protected override void OnTextChanged(EventArgs e)
    {
    //    try
    //    {
    //        Text = "Versão: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
    //        if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
    //        {
    //            Text = "Versão: " + System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
    //        }
    //    }
    //    catch { }
        //base.OnTextChanged(e);
    }
}
