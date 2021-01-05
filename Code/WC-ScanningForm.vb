Option Strict Off

Imports System
Imports NSi.AutoStore.WebCapture.Workflow
Imports System.IO
Imports Microsoft.VisualBasic

Module Script
    Sub Form_OnLoad(ByVal eventData As ClientEventData)
      

		
		eventData.Form.Fields.Item(5).Display = "Average scanning volume (in pages)"
		eventData.Form.Fields.Item(7).Display = "Average number of pages per document"
		eventData.Form.Fields.Item(8).Display = "I use the following devices for scanning"
		eventData.Form.Fields.Item(9).Display = "Distance to the device in metres (approx)"
		eventData.Form.Fields.Item(10).Display = "How Often do you walk this distance per day for scanning?"
		eventData.Form.Fields.Item(15).Display = "How much time do you need approximately per scan"
		eventData.Form.Fields.Item(18).Display = "For scans on a multi-function device"
		eventData.Form.Fields.Item(19).Display = "Scanning workflow On the multi-Function device"
		eventData.Form.Fields.Item(25).Display = "The scanning worlflow on the multi-function device is"
		eventData.Form.Fields.Item(26).Display = "The number of input/selection fields for the scanning workflow(s) is"
		eventData.Form.Fields.Item(27).Display = "How often are additional steps required afer the actual scanning process?"
		eventData.Form.Fields.Item(28).Display = "Which steps do you generally perform after the actual scan process"
		eventData.Form.Fields.Item(29).Display = "Which scanning workflow(s) would assist you In handling your business processes even more effectively And quickly?"
		eventData.Form.Fields.Item(30).Display = "How much time do you need approximatey for further processing after the actual scanning process?"
		eventData.Form.Fields.Item(31).Display = "Which departments/locations process the scanned documents after you?"
		eventData.Form.Fields.item(32).Display = "How often do you need to access scanned documetns again as part of the same or different business processes?"
		eventData.Form.Fields.Item(33).Display = "How often do you look for documents?"
		eventData.Form.Fields.Item(35).Display = "How much time Do you need approxiamtely per search?"
		eventData.Form.Fields.Item(37).Display = "Where are these documents located/in which systems do you look for the documents?"
		eventData.Form.Fields.Item(39).Display = "On what basis do you look for documents?"
		eventData.Form.fields.item(40).Display = "How do perceive your search for documents?"
		
		eventData.Form.Fields.GetField("FormNo").Value = 1
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
		Dim forms() As String = { "1,2,3,4,42" , "5,6,7,8,9,42,43","5,10,11,12,13,14,15,42,43", "5,16,17,18,42,43","5,19,20,42,43","5,21,22,23,24,25,26,42,43","5,27,28,29,30,42,43","5,31,32,33,34,35,36,37,42,43","5,38,39,40,41,43" }
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
		Dim formNo As NumericField = eventData.Form.Fields.GetField("FormNo")
		
		If button.Name = "btnNext"
			formNo.value = formNo.Value + 1
			setForm(eventData)
		Else If button.Name = "btnBack"
			formNo.value = formNo.value - 1
			setForm(eventData)
		End If    

		
	End Sub

End Module
