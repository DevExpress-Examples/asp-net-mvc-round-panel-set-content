Imports System.Web.Mvc

Namespace CS.Controllers

    Public Class HomeController
        Inherits Controller

        Public Function Index() As ActionResult
            Return View()
        End Function

        Public Function All() As ActionResult
            Return View()
        End Function

        Public Function DX() As ActionResult
            Return View()
        End Function

        Public Function Plain() As ActionResult
            Return View()
        End Function

        Public Function SeparateAction() As ActionResult
            Return Content("Content From Separate <b>Action</b> Here...")
        End Function
    End Class
End Namespace
