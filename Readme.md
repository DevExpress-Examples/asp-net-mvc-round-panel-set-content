<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128552509/14.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4477)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# Round Panel for ASP.NET MVC - How to define control content
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4477/)**
<!-- run online end -->

The `SetContent` method allows you to define the content of DevExpress MVC extensions. This example demonstrates how to use these method overloads to define [RoundPanel](https://docs.devexpress.com/AspNetMvc/8976/components/multi-use-site-extensions/round-panel) content in the following ways:

* Call the [SetContent(String content)](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.RoundPanelSettings.SetContent(System.String)) method overload to specify the content as a string. This overload is intended for scenarios where it is necessary to render simple HTML content (specified directly as a parameter).
  ```
  settings.SetContent(@"<table border=\"1\"><tr><td>RoundPanel Content Here</td></tr></table>");
  ```
* Call the [SetContent(Action contentMethod)](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.RoundPanelSettings.SetContent(System.Action)) method overload to add a DevExpress MVC Extension in the panel content.
  ```
  settings.SetContent(() => {
      Html.DevExpress().Label(lbl => {
          lbl.Name = "lbl";
          lbl.Text = "DevExpress Label - Some Text";
      }).Render();
  });
  ```
* Call the [ViewContext.Writer.Write](https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter.write) method to combine different syntax constructions (raw HTML tags, action methods, built-in HtmlHelper methods, DevExpress MVC Extensions) into a text stream and pass it to the [SetContent(String content)](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.RoundPanelSettings.SetContent(System.String)) method overload.
  ```
  settings.SetContent(() => {
      //Raw HTML
      ViewContext.Writer.Write("<table border=\"1\"><tr><td>Content From Raw <b>HTML</b> Table Here...</td></tr></table>");
      ViewContext.Writer.Write("<br/>");
  
      //Action Method
      Html.RenderAction("SeparateAction");
      ViewContext.Writer.Write("<br/>");
      ViewContext.Writer.Write("<br/>");
  
      //Partial View with Html.BeginForm
      Html.RenderPartial("SeparatePartialView");
      ViewContext.Writer.Write("<br/>");
      ViewContext.Writer.Write("<br/>");
  
      //Html Helper
      ViewContext.Writer.Write(Html.TextBox("txtName").ToHtmlString());
      ViewContext.Writer.Write("<br/>");
      ViewContext.Writer.Write("<br/>");
      
      //Conditional
      ViewContext.Writer.Write("Content From Conditional Rendering Block:");
      ViewContext.Writer.Write("<br/>");
      bool condition = DateTime.Now.Year == 2014;
      if(condition) {
          ViewContext.Writer.Write("<b>Condition Passed</b>");
      } else {
          ViewContext.Writer.Write("<b>Condition Failed</b>");
      }
      ViewContext.Writer.Write("<br/>");
      ViewContext.Writer.Write("<br/>");
      
      //DevExpress MVC Extensions
      Html.DevExpress().Label(lbl => {
          lbl.Name = "lbl";
          lbl.Text = "Content From DevExpress Label Here...";
      }).Render();
  });
  ```

You can use these approaches for every DevExpress MVC Extension that suppors the `SetContent` or `SetNestedContent` method.

It is also possible to handle `Set{ElementName}TemplateContent` methods to define template content. 

## Files to Review

* [Plain.cshtml](./CS/Views/Home/Plain.cshtml)
* [DX.cshtml](./CS/Views/Home/DX.cshtml)
* [All.cshtml](./CS/Views/Home/All.cshtml)
* [Index.cshtml](./CS/Views/Home/Index.cshtml)
* [SeparatePartialView.cshtml](./CS/Views/Home/SeparatePartialView.cshtml)
* [HomeController.cs](./CS/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Controllers/HomeController.vb))
  
## Documentation

* [Templates](https://docs.devexpress.com/AspNetMvc/14721/common-features/templates)
