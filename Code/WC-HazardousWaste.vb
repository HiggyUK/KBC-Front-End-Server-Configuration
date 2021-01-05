Option Strict Off

Imports System
Imports NSi.AutoStore.WebCapture.Workflow
Imports System.IO
Imports Microsoft.VisualBasic

Module Script
    Sub Form_OnLoad(ByVal eventData As ClientEventData)
		'TODO: add code here to execute when the form is first shown
		eventData.Form.Fields.GetField("Description").IsHidden = True
		eventData.Form.Fields.GetField("EngineerName").Value = eventData.User.UserAttributes.Item(0).Data
		eventData.Form.Fields.GetField("EngineerNumber").Value = "10001"
	End Sub
	
	Sub Form_OnValidate(ByVal eventData As ClientEventData)
		'TODO: add code here to execute when the user presses OK in the form
	End Sub

	Sub Form_OnSubmit(ByVal eventData As ClientEventData)
      'TODO: add code here to execute after the sucessfull submitting of the form
	End Sub

	
	Sub WasteType_OnChange(ByVal eventData As ClientEventData)
	
		If eventData.Form.Fields.GetField("WasteType").Value = "Other" Then
			eventData.Form.Fields.GetField("Description").IsHidden = False
		Else
			eventData.Form.Fields.GetField("Description").IsHidden = True
		End If			
	End Sub
End Module
