Option Strict Off

Imports System
Imports NSi.AutoStore.WebCapture.Workflow

Module Script
    Sub Form_OnLoad(ByVal eventData As ClientEventData)
		'TODO: add code here to execute when the form is first shown

		eventData.Form.Fields.GetField("Label1").Value = "The safety of our employees, visitors, and their families remain KOFAXs’ overriding priority.  That is why we are following government advice and working responsibly at our Kofax Office Locations to keep everyone sage. To prevent the spread Of COVID-19 And To reduce any risk Of exposure To our employees And visitors, we are conducting mandatory screening questionnaire To be completed by every visitor. Contact details provided On the questionnaire will be used For contact tracing purposes As per the Government Guidelines. These forms will only be retained For a period Of 21 days after your visit. If you are displaying COVID-19 symptoms, you MUST Not enter any Kofax Office Location. Thank you For your help complying And assisting With these precautionary steps."

    End Sub
	
    Sub Form_OnValidate(ByVal eventData As ClientEventData)
      'TODO: add code here to execute when the user presses OK in the form
    End Sub

    Sub Form_OnSubmit(ByVal eventData As ClientEventData)
      'TODO: add code here to execute after the sucessfull submitting of the form
    End Sub
End Module
