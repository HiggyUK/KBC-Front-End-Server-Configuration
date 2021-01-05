Option Strict Off

Imports System
Imports NSi.AutoStore.WebCapture.Workflow
Imports Microsoft.VisualBasic
Imports System.IO

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
		Dim forms() As String = { "1,2,3,29" , "4,5,6,7,8,29,30", "9,10,11,12,13,14,29,30", "15,16,17,29,30", "18,19,20,21,22,23,29,30", "24,25,29,30", "26,27,28,30"}
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

	Sub Registration_OnChange(ByVal eventData As ClientEventData)
	
		If eventData.Form.Fields.GetField("Registration").Value = "MJ17RRU" Then
			eventData.Form.Fields.GetField("Make").Value = "Ford"
			eventData.Form.Fields.GetField("Model").Value = "EcoSport"
			eventData.Form.Fields.GetField("Colour").Value = "Silver"
		End If
		
	End Sub

	Sub AccountNo_OnChange(ByVal eventData As ClientEventData)
	
		If eventData.Form.Fields.GetField("AccountNo").Value = "KFX001" Then
			eventData.Form.Fields.GetField("AccountName").Value = "Kofax UK Ltd"
		End If
		If eventData.Form.Fields.GetField("AccountNo").Value = "ADV001" Then
			eventData.Form.Fields.GetField("AccountName").Value = "Advanced UK"
		End If
	End Sub
		
		
		
	
End Module
