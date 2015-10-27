using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Collections.Generic;

public partial class ShowAllFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String path = Session["path"].ToString();
        String id = Session["id"].ToString();
        String time = Session["time"].ToString();
        List<string> fileList = new List<string>();
        DirectoryInfo dir = new DirectoryInfo(path);
        foreach (FileInfo fileName in dir.GetFiles("*.*", SearchOption.AllDirectories))
        {
            int can = 0;
            String [] sp = fileName.FullName.Split(new char[3]{'\\','.',':'});
            for (int i = 0; i < sp.Length; i++)
            {
                if (sp[i] == "html" || sp[i] == "htm")
                    can = 1;
                else if (sp[i] == "config")
                    can = 2;
            }
            if (can == 1)
                fileList.Add(fileName.FullName);
            else if (can == 2)
            {
                File.Delete(fileName.FullName);
            }
        }
        String a = "C:\\StFiles\\StFiles\\" + id + "\\" + time + "\\";
        for (int i = 0; i < fileList.Count; i++)
        {
           // Response.Write(fileList[i]);
            
            String sp= fileList[i].Replace(a,"");
            string URLStr = "<a href=\"http://203.64.84.21/StUpload/StFiles/" + id + "/" + time + "/" + sp + "\">";    //\">回首頁</a>"
            URLStr += sp + "</a><br /><br /> ";
            Response.Write(URLStr);
            //Response.Write(sp);
        }
    }
}