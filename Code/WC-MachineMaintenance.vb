Option Strict Off

Imports System
Imports NSi.AutoStore.WebCapture.Workflow
Imports System.IO
Imports Microsoft.VisualBasic

Module Script
    Sub Form_OnLoad(ByVal eventData As ClientEventData)
		'TODO: add code here to execute when the form is first shown

		
		eventData.Form.Fields.Item(4).Display = "change panel filter and check panel cooling fant for operation"
		eventData.Form.Fields.Item(5).Display = "check wiring connection in panel, have thermal imagery carried out of panel"
		eventData.Form.Fields.Item(6).Display = "check condition of splined shafts and bushes, change if required"
		eventData.Form.Fields.Item(7).Display = "change tapered bearings in drive heads"
		eventData.Form.Fields.Item(8).Display = "change tapered bearings in drive heads"
		
		eventData.Form.Fields.Item(10).Display = "check motor cabling and connections"
		eventData.Form.Fields.Item(11).Display = "check condition of tooling on machine at time of maintenance"
		eventData.Form.Fields.Item(12).Display = "check wire resistance reading rubber pads / copper blocks for wear, change as required"
		
		eventData.Form.Fields.Item(14).Display = "check all control button lighting is working"
		eventData.Form.Fields.Item(15).Display = "check condition and operation of all sensors"
		eventData.Form.Fields.Item(16).Display = "check pneumatic circuits for leaks & correct operation"
		eventData.Form.Fields.Item(17).Display = "lightly lubricate & clean all slideways"
		eventData.Form.Fields.Item(18).Display = "check oil level in wire lubrication system"
		eventData.Form.Fields.Item(19).Display = "check extraction points are clear of any blockages"
		eventData.Form.Fields.Item(20).Display = "check operation and condition of gaurding, interlcks and E stops"
		eventData.Form.Fields.Item(21).Display = "check wire strip lubrication for leaks and condition of lubrication pads"
		eventData.Form.Fields.Item(22).Display = "check condition and tension of drive belts and pulleys"
		eventData.Form.Fields.Item(23).Display = "verify operation of machine after all tasks are complete"
		
		
		
		eventData.Form.Fields.GetField("formNo").value = 1
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
		Dim forms() As String = { "1,2,3,27","4,5,6,7,8,9,27,28","10,11,12,13,27,28","14,15,16,17,18,19,20,21,22,23,24,27,28","25,26,28"}
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
