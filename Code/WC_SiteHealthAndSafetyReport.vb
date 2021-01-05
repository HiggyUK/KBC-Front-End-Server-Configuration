Option Strict Off

Imports System
Imports NSi.AutoStore.WebCapture.Workflow
Imports System.IO
Imports Microsoft.VisualBasic

Module Script
    Sub Form_OnLoad(ByVal eventData As ClientEventData)
 
		eventData.Form.Fields.Item(6).Display = "General site safety & Arragements"
		eventData.form.fields.Item(7).Display = "Site tidiness & conditions (waste)"
		eventData.form.fields.Item(10).Display = "Access for major items (plant/equip)"
		eventData.form.fields.Item(12).Display = "Adequate/clean welfare facilities"
				eventData.form.fields.Item(13).Display = "Fire Management/Fire fighting equip"
		
		eventData.Form.Fields.GetField("formNo").value = 1
		setForm(eventData)
		
		'TODO: add code here to execute when the form is first shown
    End Sub
	
    Sub Form_OnValidate(ByVal eventData As ClientEventData)
      'TODO: add code here to execute when the user presses OK in the form
    End Sub

    Sub Form_OnSubmit(ByVal eventData As ClientEventData)
      'TODO: add code here to execute after the sucessfull submitting of the form
	End Sub
	Sub setForm(ByVal eventData As ClientEventData)
	
		Dim totalFields As Integer = eventData.Form.Fields.Count
		Dim forms() As String = { "1,2,3,4,28" , "5,6,7,8,9,10,11,12,13,14,15,28,29", "16,17,18,19,20,21,28,29", "22,23,28,29", "24,25,26,27,29"}
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
	

End Module
