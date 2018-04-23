Imports System.Web.Mvc
Imports DevExpress.Web.Mvc


Public Class HomeController
    Inherits Controller
    Private list As New PersonsList()

    Public Function Index() As ActionResult
        Return View(list.GetPersons())
    End Function

    Public Function GridViewTemplatePartial() As ActionResult
        Return PartialView(list.GetPersons())
    End Function

    <HttpPost(), ValidateInput(False)> _
    Public Function EditingAddNew(<ModelBinder(GetType(DevExpressEditorsBinder))> ByVal person As Person) As ActionResult
        If ModelState.IsValid Then
            list.AddPerson(person)
        End If
        Return PartialView("GridViewTemplatePartial", list.GetPersons())
    End Function

    <HttpPost(), ValidateInput(False)> _
    Public Function EditingUpdate(<ModelBinder(GetType(DevExpressEditorsBinder))> ByVal personInfo As Person) As ActionResult
        If ModelState.IsValid Then
            list.UpdatePerson(personInfo)
        End If
        Return PartialView("GridViewTemplatePartial", list.GetPersons())
    End Function

    Public Function EditingDelete(ByVal personId As Integer) As ActionResult
        list.DeletePerson(personId)
        Return PartialView("GridViewTemplatePartial", list.GetPersons())
    End Function
End Class