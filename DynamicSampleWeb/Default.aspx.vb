Imports System.Collections.Generic

Imports Phydeaux.Utilities
Imports DynamicComparerSample

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Dim fieldsToBind As List(Of String)
    Dim person As Person = New Person("Jon", "Rothlander", Gender.Male, 42) ' this pretends to be a database row...

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ' these are the dynamically driven fields
        fieldsToBind = New List(Of String)
        fieldsToBind.Add("FirstName")
        fieldsToBind.Add("LastName")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            For Each fieldName As String In fieldsToBind
                Dim getProperty As Func(Of Person, String) = Dynamic(Of Person).Instance.Property(Of String).Explicit.Getter.CreateDelegate(fieldName)
                Dim value As String = getProperty.Invoke(person) ' get the field value

                Dim getInput As Func(Of _Default, HtmlInputText) = Dynamic(Of _Default).Instance.Property(Of HtmlInputText).Explicit.Getter.CreateDelegate(fieldName)
                Dim inputField As HtmlInputText = getInput.Invoke(Me) ' get the input element of the page

                Dim setValue As Proc(Of HtmlInputText, String) = Dynamic(Of HtmlInputText).Instance.Property(Of String).Explicit.Setter.CreateDelegate("Value")
                setValue.Invoke(inputField, value)  ' set the element
            Next
        End If
    End Sub

    Protected Sub Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Submit.Click
        For Each fieldName As String In fieldsToBind
            Dim getInput As Func(Of _Default, HtmlInputText) = Dynamic(Of _Default).Instance.Property(Of HtmlInputText).Explicit.Getter.CreateDelegate(fieldName)
            Dim inputField As HtmlInputText = getInput.Invoke(Me) ' get the input element of the page

            Dim getValue As Func(Of HtmlInputText, String) = Dynamic(Of HtmlInputText).Instance.Property(Of String).Explicit.Getter.CreateDelegate("Value")
            Dim value As String = getValue.Invoke(inputField)  ' get the element value

            Dim setField As Proc(Of Person, String) = Dynamic(Of Person).Instance.Property(Of String).Explicit.Setter.CreateDelegate(fieldName)
            setField.Invoke(person, value) ' set the field value
        Next

        Debug.Print(person.ToString())
    End Sub
End Class