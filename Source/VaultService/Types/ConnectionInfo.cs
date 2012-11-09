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
/// Summary description for Vault Connection class
/// </summary>

namespace VaultService
{
    public class ConnectionInfo
{
    #region Fields
    protected string _vaultName = String.Empty;
    protected string _address = String.Empty;
    protected string _extAddress = String.Empty;
    protected string _domain = String.Empty;
    protected string _description = String.Empty;
    protected string _defaultRaidArea = String.Empty;
    protected string _defaultWorkArea = String.Empty;
    protected string _connectionUser = String.Empty;
    protected string _connectionPassword = String.Empty;
    protected string _webCCAPI_Url = String.Empty;
    protected string _customerPrefix = String.Empty;
    protected string _slxAccountID = string.Empty;
    protected string _productInterest = string.Empty;
    protected string _channelManager = string.Empty;
    protected string _accountName = string.Empty;
    protected string _webccURL = string.Empty;
    protected string _emailCC = "";
    protected string _emailBCC = "";
    protected string _reportUrl = string.Empty;
    private string _logFileName = string.Empty;
    private string _auditFileName = string.Empty;

    
    #endregion

    #region Public Properties

    public string AccountName
    {
        get { return _accountName; }
        set { _accountName = value; }

    }

    public string WebccURL
    {
        get { return _webccURL; }
        set { _webccURL = value; }

    }


    public string ReportUrl
    {
        get { return _reportUrl; }
        set { _reportUrl = value; }

    }



    public string ConnectionUser
    {
        get { return _connectionUser; }
        set { _connectionUser = value; }

    }

    public string ProductInterest
    {
        get { return _productInterest; }
        set { _productInterest = value; }

    }

    public string ChannelManager
    {
        get { return _channelManager; }
        set { _channelManager = value; }

    }


    public string SlxAccountID
    {
        get { return _slxAccountID; }
        set { _slxAccountID = value; }

    }

    public string CustomerPrefix
    {
        get { return _customerPrefix; }
        set { _customerPrefix = value; }

    }



    public string ConnectionPassword
    {
        get { return _connectionPassword; }
        set { _connectionPassword = value; }

    }

    public string VaultName
    {
        get { return _vaultName; }
        set { _vaultName = value; }
    }

    public string Address
		{
            get { return _address; }
            set { _address = value; }
		}

    public string ExternalAddress
    {
        get { return _extAddress; }
        set { _extAddress = value; }
    }


    public string Domain
        {
            get { return _domain; }
            set { _domain = value; }
        }

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    public string DefaultRaidArea
    {
        get { return _defaultRaidArea; }
        set { _defaultRaidArea = value; }
    }

    public string DefaultWorkArea
    {
        get { return _defaultWorkArea; }
        set { _defaultWorkArea = value; }
    }

    public string WebccAPIUrl
    {
        get { return _webCCAPI_Url; }
        set { _webCCAPI_Url = value; }
    }

    public string EmailCC
    {
        get { return _emailCC; }
        set { _emailCC = value; }
    }

    public string EmailBCC
    {
        get { return _emailBCC; }
        set { _emailBCC = value; }
    }

    public string LogFileName
    {
        get { return _logFileName; }
        set { _logFileName = value; }
    }


    public string AuditFileName
    {
        get { return _auditFileName; }
        set { _auditFileName = value; }
    }

    #endregion

    public ConnectionInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }



}
}
