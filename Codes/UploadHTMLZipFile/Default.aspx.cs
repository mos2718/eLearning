using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["name"];
        string website = Request.QueryString["website"];
        Response.Write(id + "< br>" + website);
        //url  http://localhost:28188/2_UploadZipPhoto/Default.aspx?name=456&website=qqqq
        Response.Write("你使用的是" + Request.RequestType + "方式傳送數據");  
    }
}