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
/// Summary description for Utilities
/// </summary>
public class Utilities
{
	public Utilities()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public static string gs_RadixTable = "qwertyuiopasdfghjklzxcvbnm0987654321~!@#$%^&*MNBVCXZLKJHGFDSAPOIUYTREWQ";
    public static string vv_RadixTable = "MNBVCXZLKJHGFDSAPOIUYTREWQ0987654321";

    public static String ToStr(object obj)
    {
        if (obj != null)
        {
            return (obj.ToString());
        }
        return (null);
    }
    
    public static string UlongToStringByTable(ulong val, string table)
    {
        string result = "";
        ulong radix = (ulong)table.Length;
        while (val > 0)
        {
            ulong d = val / radix;
            ulong idx = val - d * radix;
            result += table[(int)idx];
            val = d;
        }
        return (result);
    }

    public static ulong MakeStringHash(string str)
    {
        ulong hash = (ulong)str.Length;
        for (int i = 0; i < str.Length; i++)
        {
            hash = (hash << 4) + hash + (ulong)str[i];
        }
        return (hash);
    }

    public static string GeneratePassword()
    {
        DateTime dt = DateTime.Now;
        string s = ToStr(dt.Ticks) + ToStr(dt.Year) + ToStr(dt.Millisecond) + ToStr(dt.Month) + ToStr(dt.Second) + ToStr(dt.Day) + ToStr(dt.Minute) + ToStr(dt.Hour);
        ulong hash = MakeStringHash(s);
        string i = (UlongToStringByTable(hash, vv_RadixTable));
        return (i.Substring(1, 8));
    }

    public static string GenerateMasID(string VaultID)
    {
        DateTime dt = DateTime.Now;
        //string s = ToStr( dt.Ticks ) + ToStr( dt.Year ) + ToStr( dt.Millisecond ) + ToStr( dt.Month ) + ToStr( dt.Second ) + ToStr( dt.Day ) + ToStr( dt.Minute ) + ToStr( dt.Hour ) ;
        string s = ToStr(dt.Ticks) + ToStr(dt.Millisecond) + ToStr(dt.Second) + ToStr(dt.Minute);
        ulong hash = MakeStringHash(s);
        string i = UlongToStringByTable(hash, vv_RadixTable);
        return (VaultID + i.Substring(1, 3));
    }

    public static string GenerateVaultID()
    {
        DateTime dt = DateTime.Now;
        //string s = ToStr( dt.Ticks ) + ToStr( dt.Year ) + ToStr( dt.Millisecond ) + ToStr( dt.Month ) + ToStr( dt.Second ) + ToStr( dt.Day ) + ToStr( dt.Minute ) + ToStr( dt.Hour ) ;
        string s = ToStr(dt.Ticks) + ToStr(dt.Millisecond) + ToStr(dt.Second) + ToStr(dt.Minute);
        ulong hash = MakeStringHash(s);
        string i = UlongToStringByTable(hash, vv_RadixTable);
        return (i.Substring(1, 5));
    }

    public static string Left(string text, int length)
    {
        if (length < 0)
            throw new ArgumentOutOfRangeException("length", length, "length must be > 0");
        else if (length == 0 || text.Length == 0)
            return "";
        else if (text.Length <= length)
            return text;
        else
            return text.Substring(0, length);
    }

    public static string CleanTheString(string theString)
    {
        string CleanedString = "";
        string strAlphaNumeric = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string strChar = "";
        for (int i = 0; i < theString.Length; i++)
        {
            strChar = theString.Substring(i, 1);
            if (strAlphaNumeric.IndexOf(strChar) > 0)
            {
                CleanedString = CleanedString + strChar;
            }

        }

        return CleanedString;

    }

}
