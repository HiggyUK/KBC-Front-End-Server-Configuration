Sub AddDataSheets_OnLoad
	
	EKOManager.StatusMessage "Adding DataSheets to Zip"
	products = split(productList,";")
	
	Dim filesys, newfolder
	Set filesys = CreateObject("Scripting.FileSystemObject")
	If Not filesys.FolderExists("C:\Kofax\MobileDemo\Data\" + username) then
		filesys.CreateFolder("C:\Kofax\MobileDemo\Data\" + username)
	End If

	ZipFile = "C:\Kofax\MobileDemo\Data\" + username + "\SalesInfo.zip"

	
	Dim objZIP
	Set objZIP = CreateObject( "XStandard.Zip" )
	
	For Each product In products
		EKOManager.StatusMessage "Adding " + product
		productFile = "C:\Kofax\MobileDemo\Settings\SalesInfo\" + product + ".pdf"
		objZIP.Pack productFile, ZipFile
	Next
	Set objZIP = Nothing
		
	EKOManager.StatusMessage "Adding Zip File to AutoStore Job"

	Set NewKnowledgeDocument = KnowledgeObject.AddDocument
		If Not(NewKnowledgeDocument Is Nothing) Then
		NewKnowledgeDocument.FilePath = "C:\Kofax\MobileDemo\Data\" + username + "\SalesInfo.zip"
			NewKnowledgeDocument.Status = 1 'DOC_STATUS_OK
			Set KDocumentOptions = NewKnowledgeDocument.AddOption
			'If Not(KDocumentOptions Is Nothing) Then
			'	KDocumentOptions.OnSuccess = 2 'FILEOPTION_DELETE
			'	KDocumentOptions.OnFailure = 1 'FILEOPTION_MOVE
			'End If
		End If
	
	
End Sub

Sub AddDataSheets_OnUnload

End Sub
