<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadZipFile.aspx.cs" Inherits="UploadZipDir" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
    <style type="text/css">
        .style1
        {
            font-family: 微軟正黑體;
            font-size: medium;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        &nbsp;<span class="style1">選擇上傳壓縮檔(.zip)&nbsp; &nbsp; </span>
    
        <asp:FileUpload ID="FileUpload1" runat="server" Height="28px" Width="345px" 
            style="font-size: medium; font-family: 微軟正黑體" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" 
            style="color: #FF0000; font-size: medium; font-family: 微軟正黑體"></asp:Label>
        <br />
        <br />
    
    </div>
    <asp:Button ID="Button1" runat="server" Height="39px" Text="上傳" 
        Width="125px" onclick="Button1_Click" 
        style="font-size: medium; font-weight: 700; font-family: 微軟正黑體" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </form>
</body>
</html>
