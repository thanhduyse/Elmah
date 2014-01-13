#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Elmah
{
    using System;
    using System.Collections.Generic;
    
    #line 2 "..\..\ErrorDetailPage.cshtml"
    using System.Globalization;
    
    #line default
    #line hidden
    
    #line 3 "..\..\ErrorDetailPage.cshtml"
    using System.IO;
    
    #line default
    #line hidden
    using System.Linq;
    using System.Text;
    
    #line 4 "..\..\ErrorDetailPage.cshtml"
    using System.Web;
    
    #line default
    #line hidden
    
    #line 5 "..\..\ErrorDetailPage.cshtml"
    using Elmah;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class ErrorDetailPage : WebTemplateBase
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");







            
            #line 7 "..\..\ErrorDetailPage.cshtml"
  
    var basePageName = Request.Uri.AbsolutePath;
    
    //
    // Retrieve the ID of the error to display and read it from 
    // the store.
    //

    var errorId = Request.Query["id"] ?? string.Empty;

    if (errorId.Length == 0)
    { 
        return;
    }

    var log = this.ErrorLog ?? ErrorLog.GetDefault(null /* TODO? Context */);
    var errorEntry = log.GetError(errorId);

    //
    // Perhaps the error has been deleted from the store? Whatever
    // the reason, bail out silently.
    //

    if (errorEntry == null)
    {
        Response.StatusCode = HttpStatus.NotFound.Code;

            
            #line default
            #line hidden
WriteLiteral("        <p>Error not found in log.</p>\r\n");


            
            #line 34 "..\..\ErrorDetailPage.cshtml"
        return;
    }

    var title = string.Format("Error: {0} [{1}]", errorEntry.Error.Type, errorEntry.Id);

    Layout = new Elmah.MasterPage
    {
        Context  = Context, /* TODO Consider not requiring this */
        Title    = title,
        Footnote = string.Format("This log is provided by the {0}.", log.Name),
        SpeedBarItems = new[] 
        {
            SpeedBar.Home.Format(basePageName),
            SpeedBar.Help,
            SpeedBar.About.Format(basePageName),
        },
    };

    var error = errorEntry.Error;


            
            #line default
            #line hidden
WriteLiteral("\r\n");



WriteLiteral("\r\n\r\n<h1 id=\"PageTitle\">");


            
            #line 59 "..\..\ErrorDetailPage.cshtml"
              Write(error.Message);

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n\r\n<p id=\"ErrorTitle\">");



WriteLiteral("<span id=\"ErrorType\">");


            
            #line 62 "..\..\ErrorDetailPage.cshtml"
                      Write(error.Type);

            
            #line default
            #line hidden
WriteLiteral("</span>");



WriteLiteral("<span id=\"ErrorTypeMessageSeparator\">: </span>");



WriteLiteral("<span id=\"ErrorMessage\">");


            
            #line 64 "..\..\ErrorDetailPage.cshtml"
                         Write(error.Message);

            
            #line default
            #line hidden
WriteLiteral("</span></p>\r\n\r\n");



WriteLiteral("\r\n\r\n");


            
            #line 74 "..\..\ErrorDetailPage.cshtml"
 if (error.Detail.Length != 0)
{

            
            #line default
            #line hidden
WriteLiteral("    <pre id=\"ErrorDetail\">");


            
            #line 76 "..\..\ErrorDetailPage.cshtml"
                     Write(MarkupStackTrace(error.Detail));

            
            #line default
            #line hidden
WriteLiteral("</pre>\r\n");


            
            #line 77 "..\..\ErrorDetailPage.cshtml"
}


            
            #line default
            #line hidden

            
            #line 83 "..\..\ErrorDetailPage.cshtml"
  

            
            #line default
            #line hidden
WriteLiteral("\r\n<p id=\"ErrorLogTime\">");


            
            #line 85 "..\..\ErrorDetailPage.cshtml"
                Write(string.Format(
    @"Logged on {0} at {1}",
    error.Time.ToLongDateString(),
    error.Time.ToLongTimeString()));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\r\n");



WriteLiteral("\r\n\r\n<p>See also:</p>\r\n\r\n<ul>\r\n\r\n");



WriteLiteral("\r\n\r\n");


            
            #line 105 "..\..\ErrorDetailPage.cshtml"
     if (error.WebHostHtmlMessage.Length != 0)
    {
        var htmlUrl = basePageName + "/html?id=" + Uri.EscapeDataString(errorEntry.Id);

            
            #line default
            #line hidden
WriteLiteral("        <li><a href=\"");


            
            #line 108 "..\..\ErrorDetailPage.cshtml"
                Write(basePageName);

            
            #line default
            #line hidden
WriteLiteral("/html?id=");


            
            #line 108 "..\..\ErrorDetailPage.cshtml"
                                      Write(Uri.EscapeDataString(errorEntry.Id));

            
            #line default
            #line hidden
WriteLiteral("\">Original ASP.NET error page</a></li>\r\n");


            
            #line 109 "..\..\ErrorDetailPage.cshtml"
    }


            
            #line default
            #line hidden

            
            #line 113 "..\..\ErrorDetailPage.cshtml"
  

            
            #line default
            #line hidden
WriteLiteral("\r\n    <li>Raw/Source data in \r\n        <a rel=\"");


            
            #line 116 "..\..\ErrorDetailPage.cshtml"
           Write(HtmlLinkType.Alternate);

            
            #line default
            #line hidden
WriteLiteral("\" \r\n           type=\"application/xml\" \r\n           href=\"xml");


            
            #line 118 "..\..\ErrorDetailPage.cshtml"
                Write(Request.Uri.Query);

            
            #line default
            #line hidden
WriteLiteral("\">XML</a>\r\n        or in\r\n        <a rel=\"");


            
            #line 120 "..\..\ErrorDetailPage.cshtml"
           Write(HtmlLinkType.Alternate);

            
            #line default
            #line hidden
WriteLiteral("\" \r\n           type=\"application/json\" \r\n           href=\"json");


            
            #line 122 "..\..\ErrorDetailPage.cshtml"
                 Write(Request.Uri.Query);

            
            #line default
            #line hidden
WriteLiteral("\">JSON</a>\r\n    </li>\r\n</ul>\r\n\r\n");



WriteLiteral("\r\n\r\n");


            
            #line 140 "..\..\ErrorDetailPage.cshtml"
  
    var collection = new
    {
        Data  = error.ServerVariables,
        Id    = "ServerVariables",
        Title = "Server Variables",
    };

    //
    // If the collection isn't there or it's empty, then bail out.
    //

    if (collection.Data != null && collection.Data.Count > 0)
    {
        var items = 
            from i in Enumerable.Range(0, collection.Data.Count)
            select new
            {
                Index  = i,
                Key    = collection.Data.GetKey(i),
                Value  = collection.Data[i],
            };
        
        items = items.OrderBy(e => e.Key, StringComparer.OrdinalIgnoreCase);
        

            
            #line default
            #line hidden
WriteLiteral("        <div id=\"");


            
            #line 165 "..\..\ErrorDetailPage.cshtml"
            Write(collection.Id);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n\r\n            <h2>");


            
            #line 167 "..\..\ErrorDetailPage.cshtml"
           Write(collection.Title);

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n            ");



WriteLiteral(@"

            <div class=""scroll-view"">

                <table cellspacing=""0"" style=""border-collapse:collapse;"" class=""table table-condensed table-striped"">
                    <tr>
                        <th class=""name-col"" style=""white-space:nowrap;"">Name</th>
                        <th class=""value-col"" style=""white-space:nowrap;"">Value</th>
                    </tr>
    
");


            
            #line 183 "..\..\ErrorDetailPage.cshtml"
                     foreach (var item in items)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <tr class=\"");


            
            #line 185 "..\..\ErrorDetailPage.cshtml"
                               Write(item.Index % 2 == 0 ? "even" : "odd");

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            <td class=\"key-col\">");


            
            #line 186 "..\..\ErrorDetailPage.cshtml"
                                           Write(item.Key);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                            <td class=\"value-col\">");


            
            #line 187 "..\..\ErrorDetailPage.cshtml"
                                             Write(item.Value);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                        </tr>\r\n");


            
            #line 189 "..\..\ErrorDetailPage.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("\r\n                </table>\r\n            </div>\r\n        </div>\r\n");


            
            #line 194 "..\..\ErrorDetailPage.cshtml"
    }


            
            #line default
            #line hidden
WriteLiteral("\r\n");



WriteLiteral("\r\n");


        }
    }
}
#pragma warning restore 1591
