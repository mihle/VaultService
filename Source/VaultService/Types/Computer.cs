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
public class Computer
{
    #region Fields
    protected string _agentType = String.Empty;
    protected string _agentVersion = String.Empty;
    protected string _ipAddress = String.Empty;
    protected string _name = String.Empty;
    protected string _osType = String.Empty;
    protected string _osVersion = String.Empty;
    protected string _domain = String.Empty;
    protected string _productCode = String.Empty;
    private long? _totalCompressedSize = null;
    private long? _totalOriginalSize = null;
    private List<Task> tasks;



    #endregion

    #region Public Properties
    	public string AgentType
		{
            get {return _agentType;}
			set {_agentType = value;}

		}
    public string ProductCode
    {
        get { return _productCode; }
        set { _productCode = value; }

    }
    public string AgentVersion
		{
            get {return _agentVersion;}
			set {_agentVersion = value;}

		}

            public string IpAddress
		{
            get { return _ipAddress; }
            set { _ipAddress = value; }

		}

    public string Name
		{
            get { return _name; }
            set { _name = value; }

		}

    public string OsType
    {
        get { return _osType; }
        set { _osType = value; }

    }

    public string OsVersion
    {
        get { return _osVersion; }
        set { _osVersion = value; }

    }

    public string Domain
    {
        get { return _domain; }
        set { _domain = value; }

    }

    public List<Task> Tasks
    {
        get { return tasks; }
        set { tasks = value; }
    }

    public long? TotalCompressedSize
    {
        get { return _totalCompressedSize; }
        set { _totalCompressedSize = value; }
    }

    public long? TotalOriginalSize
    {
        get { return _totalOriginalSize; }
        set { _totalOriginalSize = value; }
    }

    #endregion


    public Computer()
    {
        //
        // TODO: Add constructor logic here
        //
    }

}
