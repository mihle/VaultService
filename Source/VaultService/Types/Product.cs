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
public class Product
{
    #region Fields
    private string _productName = "";
    private int _quantity = 0;
    private string _productCode = String.Empty;
    private string _quotaType = String.Empty;
    private ProductType _productType;
    
    #endregion

    public enum ProductType
    {
        Agent = 1,
        Storage = 2,
        OTM = 3

    }

    #region Properties

    public string ProductName
    {
        get { return _productName; }
        set { _productName = value; }
    }

    public int Quantity
    {
        get { return _quantity; }
        set { _quantity = value; }
    }

    public string ProductCode
    {
        get { return _productCode; }
        set { _productCode = value; }
    }

    public string QuotaType
    {
        get { return _quotaType; }
        set { _quotaType = value; }
    }

    public ProductType ProdType
    {
        get { return _productType; }
        set { _productType = value; }
    }

    #endregion




    public Product()
    {
        this.ProductName = "";
        this.Quantity = 0;
    }

    public Product(string productCode, string productName, string quotaType, ProductType productType, int quantity)
    {
        this.ProductName = productName;
        this.Quantity = quantity;
        this.ProductCode = productCode;
        this.QuotaType = quotaType;
        this.ProdType = productType;
    }


}
