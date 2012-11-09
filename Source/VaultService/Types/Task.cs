using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

/// <summary>
/// Summary description for Order
/// </summary>
public class Task
{
    #region Fields

    private string _name = String.Empty;
    private long _usedPoolSize;
    private long _physicalPoolSize;
    private long _id;
    private Boolean _isActive;

    #endregion

    #region Public Properties
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public Boolean IsActive
    {
        get { return _isActive; }
        set { _isActive = value; }
    }

    public long Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public long PhysicalPoolSize
    {
        get { return _physicalPoolSize; }
        set { _physicalPoolSize = value; }
    }

    public long UsedPoolSize
    {
        get { return _usedPoolSize; }
        set { _usedPoolSize = value; }
    }

    #endregion


    public Task()
    {
        //
        // TODO: Add constructor logic here
        //
    }

}
