Sub GetSignatures_OnLoad
	
		
	' Get the Signature Images and Remove from KBO
	photos = ""
	
	Set KnowledgeDocument = KnowledgeObject.GetFirstDocument()	
	While Not(KnowledgeDocument Is Nothing)

		FileName = KnowledgeDocument.GetFileName
		FilePath = KnowledgeDocument.FilePath
		
		If ucase(left(FileName,16)) = "DRIVERSIGNATURE_" Then
			DriverSignatureFile = FilePath
			EKOManager.StatusMessage "New Signature File Path: " & FilePath 
			KnowledgeDocument.Visible = False
			FileCount = FileCount - 1
		end if

		If ucase(left(FileName,17)) = "MANAGERSIGNATURE_" Then
			ManagerSignatureFile = FilePath
			EKOManager.StatusMessage "New Signature File Path: " & FilePath 
			KnowledgeDocument.Visible = False
			FileCount = FileCount - 1
		end if
		
		If  ucase(left(FileName,16)) <> "DRIVERSIGNATURE_" And ucase(left(FileName,17)) <> "MANAGERSIGNATURE_" Then
			photos = photos  + FilePath + "|"
			KnowledgeDocument.Visible = False
		
		End If
		
		Set KnowledgeDocument = KnowledgeObject.GetNextDocument
	Wend
		
	Set PTopic = KnowledgeContent.GetTopicInterface
	If Not(PTopic Is Nothing) Then
		PTopic.Replace "~USR::DriverSignature~", DriverSignatureFile
		PTopic.Replace "~USR::ManagerSignature~", ManagerSignatureFile
		PTopic.Replace "~USR::Photos~", photos
		PTopic.Replace "~USR::FileCount~", FileCount
	End If
	
End Sub

Sub GetSignatures_OnUnload

End Sub
