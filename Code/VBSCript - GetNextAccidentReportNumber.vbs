Sub ReportNo_OnLoad
	
	Dim strBatch

	Set Topic = KnowledgeContent.GetTopicInterface
	If Topic Is Nothing Then
		KnowledgeObject.Status = 2
		EKOManager.ErrorMessage "Cannot retrieve Topic Interface"
		Exit Sub
	End If
	strBatch = recordBatch()
	Call Topic.Replace("~USR::ReportNo~", strBatch)
	EKOManager.StatusMessage ("New Report number is " & strBatch)

End Sub

Sub ReportNo_OnUnload

End Sub

Function recordBatch()
	Dim cn, commandText, recID, batchID
	Dim sFSpec : sFSpec = "C:\Kofax\MobileDemo\Settings\AccidentReportNumber.txt"
	Dim oFS : Set oFS = CreateObject("Scripting.FileSystemObject")
	
	recID = oFS.OpenTextFile(sFSpec).ReadAll()
	recID = recID + 1
	batchID = right("0000000" & recID, 7)
		

	oFS.CreateTextFile(sFSpec, True).Write recID
	Set oFS = Nothing
	Set sFSpec = Nothing
	Set sFSlog = Nothing
	recordBatch = batchID 
End Function
