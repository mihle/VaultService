using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Error
/// </summary>
public class Error
{
    private bool isFatal;
    private string error;
    private string errorDetails;


    public bool IsFatal
    {
        get { return isFatal; }
        set { isFatal = value; }
    }

    public string ErrorMessage
    {
        get { return error; }
        set { error = value; }
    }


    public string ErrorDetails
    {
        get { return errorDetails; }
        set { errorDetails = value; }
    }


	public Error()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
