using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.ObjectModel;
using System.Collections.Generic;


/// <summary>
/// Summary description for Order
/// </summary>
public class Result
{
    #region Fields
    private int _returnCode ;
    private string _message ;
    private bool _isError;
    private object results;


    #endregion

    #region Properties

    public int ReturnCode
    {
        get { return _returnCode; }
        set { _returnCode = value; }
    }

    public string Message
    {
        get { return _message; }
        set { _message = value; }
    }

    public bool IsError
    {
        get { return _isError; }
        set { _isError = value; }
    }

    public object Results
    {
        get { return results; }
        set { results = value; }
    } 
    #endregion




    public Result()
    {
        this.ReturnCode = 0;
        this.Message = "success";
        this.IsError = false;
    }



}
