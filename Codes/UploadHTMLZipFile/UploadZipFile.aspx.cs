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

//Using following name space
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using MySharpZip;

using System.Xml;


public partial class UploadZipDir : System.Web.UI.Page
{
    string id = "", time = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request.QueryString["id"];
        //time = Request.QueryString["time"];
    }
    void AddToPhotoListXML(string DirName, string ItemName)
    {
        XmlDocument m_Doc;
        XmlNode Root_Node;
        XmlNode ItemNode, ClonedNode, DirNode, NameNode;
        string MyDir, SourceFile;
        m_Doc = new XmlDocument();
        MyDir = Server.MapPath("");  //找目前網站目錄
        SourceFile = MyDir + "\\PhotoDirList.xml";
        m_Doc.Load(SourceFile);
        XmlNodeList nodelist = m_Doc.DocumentElement.ChildNodes;

        ItemNode = nodelist[0];
        ClonedNode = ItemNode.Clone();  //複製一 ItemNode
        //設定 DirNode and NameNode 的值       
        DirNode = ItemNode.ChildNodes[0];
        DirNode.FirstChild.Value = DirName;
        NameNode = ItemNode.ChildNodes[1];
        NameNode.FirstChild.Value = ItemName;
        Root_Node = m_Doc.DocumentElement;
        Root_Node.AppendChild(ClonedNode);  //新增項目 
        m_Doc.Save(SourceFile);

    }



    // 需先在專案的bin中，將兩個dll "ICSharpCode.SharpZipLib.dll","MySharpZip.dll"加入參考。
    protected void Button1_Click(object sender, EventArgs e)
    {
        int has = 0, yes = 0;
        System.DateTime currentTime=new System.DateTime();
        currentTime = System.DateTime.Now;
        String year, month, day, hour, min;
        year = currentTime.Year.ToString();
        if (currentTime.Month < 10)
            month = "0" + currentTime.Month.ToString();
        else
            month = currentTime.Month.ToString();
        if (currentTime.Day < 10)
            day = "0" + currentTime.Day.ToString();
        else
            day = currentTime.Day.ToString();
        if (currentTime.Hour < 10)
            hour = "0" + currentTime.Hour.ToString();
        else
            hour = currentTime.Hour.ToString();
        if (currentTime.Minute < 10)
            min = "0" + currentTime.Minute.ToString();
        else
            min = currentTime.Minute.ToString();
        time = year + month + day + "-" + hour + min;
        string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
        
        if (FileUpload1.HasFile)
        {
            has = 1;
            if (fileExtension == ".zip")
                yes = 1;
        }
        if (yes == 1 && has == 1)
        {
            Label1.Text = "";
            string MyDir, SourceZipFile;
            MyDir = Server.MapPath("");  //找目前網站目錄
            MyDir = MyDir + "\\StFiles\\";
            MyDir = MyDir + id + "\\";
            MyDir = MyDir + time;

            DirectoryInfo thisOne = Directory.CreateDirectory(MyDir);
            MyDir = MyDir + "\\";
            SourceZipFile = MyDir + FileUpload1.FileName;  //上傳檔案存檔路徑及檔名 
            FileUpload1.PostedFile.SaveAs(SourceZipFile);
            MySharpZip.CZip oZip = new MySharpZip.CZip();
            string rc = oZip.UnZipFile(SourceZipFile, MyDir);

            if (rc == "Success")
            {

                int Length = FileUpload1.FileName.Length;
                string ZipName; //, ZipDir, FileTag;
                ZipName = FileUpload1.FileName.Substring(0, Length - 4);
                Session["path"] = MyDir;
                Session["id"] = id;
                Session["time"] = time;
                Response.Redirect("ShowAllFile.aspx");
                //AddToPhotoListXML(TextBox1.Text, TextBox2.Text);  //新增上傳 Item 至 XML 檔
            }
        }
        else
        {
            if (has == 0)
                Label1.Text = "未上傳檔案，請上傳檔案。";
            else if (yes == 0)
                Label1.Text = "請上傳ZIP檔。";
        }
    }
}
