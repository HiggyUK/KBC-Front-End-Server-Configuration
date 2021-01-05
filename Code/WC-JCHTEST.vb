Option Strict Off

Imports System
Imports NSi.AutoStore.WebCapture.Workflow

Module Script
    Sub Form_OnLoad(ByVal eventData As ClientEventData)
		'TODO: add code here to execute when the form is first shown

		eventData.Form.Fields.GetField("UA0").Value = eventData.User.UserAttributes.Item(0).Data
		eventData.Form.Fields.GetField("UA1").Value = eventData.User.UserAttributes.Item(1).Data
		eventData.Form.Fields.GetField("UA2").Value = eventData.User.UserAttributes.Item(2).Data
		eventData.Form.Fields.GetField("UA3").Value = eventData.User.UserAttributes.Item(3).Data
		eventData.Form.Fields.GetField("UN0").Value = eventData.User.UserAttributes.Item(0).Name
		eventData.Form.Fields.GetField("UN1").Value = eventData.User.UserAttributes.Item(1).Name
		eventData.Form.Fields.GetField("UN2").Value = eventData.User.UserAttributes.Item(2).Name
		eventData.Form.Fields.GetField("UN3").Value = eventData.User.UserAttributes.Item(3).Name

	End Sub
	
    Sub Form_OnValidate(ByVal eventData As ClientEventData)
      'TODO: add code here to execute when the user presses OK in the form
    End Sub

    Sub Form_OnSubmit(ByVal eventData As ClientEventData)
      'TODO: add code here to execute after the sucessfull submitting of the form
    End Sub
End Module
