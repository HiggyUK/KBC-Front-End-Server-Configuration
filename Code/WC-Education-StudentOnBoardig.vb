Option Strict Off

Imports System
Imports NSi.AutoStore.WebCapture.Workflow
Imports System.IO
Imports Microsoft.VisualBasic

Module Script
    Sub Form_OnLoad(ByVal eventData As ClientEventData)
		
		eventData.Form.Fields.GetField("formNo").Value = 1
		setForm(eventData)
	End Sub
	
	Sub Form_OnValidate(ByVal eventData As ClientEventData)
      'TODO: add code here to execute when the user presses OK in the form
    End Sub

    Sub Form_OnSubmit(ByVal eventData As ClientEventData)
      'TODO: add code here to execute after the sucessfull submitting of the form
	End Sub	

	Sub setForm(ByVal eventData As ClientEventData)
	
		Dim totalFields As Integer = eventData.Form.Fields.Count
		Dim forms() As String = { "1,2,3,4,5,15", "6,7,8,15,16", "9,10,11,12,15,16", "13,14,16"}
		Dim currentForm As BaseField = eventData.Form.Fields.GetField("formNo")
		Dim fieldItem As String
		Dim fieldItems As String()
		Dim fields As Integer
		Dim items As Integer
		Dim fieldNo As Integer

			
		'Turn all fields off
		For fields = 0 To totalFields - 1
			eventData.Form.Fields.Item(fields).IsHidden = True
		Next
		
		'Turn on fields for the current form
		fieldItems = split(Forms(CInt(currentForm.Value)-1),",")
		For items = 0 To fieldItems.Length -1
			fieldNo = CInt(fieldItems(items))-1
			eventData.Form.Fields.Item(fieldNo).IsHidden=False
		Next
			
	End Sub
	Sub Button_OnClick(ByVal eventData As ClientEventData)
	
	
		Dim button As ButtonField = eventData.Form.Fields.GetField(eventData.EventSource)
		Dim formNo As NumericField = eventData.Form.Fields.GetField("formNo")
		
		If button.Name = "btnNext"
			formNo.value = formNo.Value + 1
			setForm(eventData)
		Else If button.Name = "btnBack"
			formNo.value = formNo.value - 1
			setForm(eventData)
		End If    

		

	End Sub

	Sub StudentID_OnChange(ByVal eventData As ClientEventData)
	
		Dim studentIDfld As TextField = eventData.Form.Fields.GetField("StudentID")
		Dim surnamefld As TextField = eventData.Form.Fields.GetField("Surname")
		Dim forenamefld As TextField = eventData.Form.Fields.GetField("Firstname")
		Dim dobfld As TextField = eventData.Form.Fields.GetField("DOB")
		
		If studentIDfld.value = "123456" Then
			surnamefld.Value = "Jones"
			forenamefld.Value = "Peter"
			dobfld.Value = "14/04/2003"
		End If
		
		If studentIDfld.value = "111111" Then
			surnamefld.Value = "Smith"
			forenamefld.Value = "Mike"
			dobfld.Value = "21/08/2003"
		End If
		
		If studentIDfld.value = "222222" Then
			surnamefld.Value = "Thomas"
			forenamefld.Value = "Mark"
			dobfld.Value = "21/05/2003"
		End If
		
		
		
	End Sub
		
	
End Module
