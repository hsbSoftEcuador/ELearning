''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''  Increment the version number of an MSI setup project  ''
''  and update relevant GUIDs                             ''
''                                                        '' 
''  Hans-Jürgen Schmidt / 19.12.2007                      ''
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	set args = wscript.arguments
	if args.count < 2 then wscript.quit 1

'read and backup project file
	Set fso = CreateObject("Scripting.FileSystemObject")
	Set f = fso.OpenTextFile(args(0))
	fileText = f.ReadAll
	f.Close
	fbak = args(0) & ".bak"
	if fso.fileexists(fbak) then fso.deletefile fbak
	fso.movefile args(0), fbak

'find, increment and replace version number
	set re = new regexp
	re.global = true
	re.pattern = "(""ProductVersion"" = ""8:)(\d+(\.\d+)+)"""
	set m = re.execute(fileText)
	
	wscript.echo "The number of matches is : " & m.count
	
	strVersion = m(0).submatches(1)
	wscript.echo "The current version is: " & strVersion
	
	strVersionTokens = split(strVersion, ".")
	
	iMajor = strVersionTokens(0)
	wscript.echo "Major: " & iMajor
	iMinor = strVersionTokens(1)
	wscript.echo "Minor " & iMinor
	iBuild = strVersionTokens(2)
	wscript.echo "Build " & iBuild

	iVersionToken = args(1)
	
	wscript.echo "The current Version Token is: " & iVersionToken
	
	If iVersionToken = 0 Then
		iMajor = iMajor + 1
	ElseIf iVersionToken = 1 Then
		iMinor = iMinor + 1
	ElseIf iVersionToken = 2 Then
		iBuild = iBuild + 1
	End If
	
	strNewVersion = iMajor & "." & iMinor & "." & iBuild
	
	wscript.echo "The new version is: " & strNewVersion
	
	fileText = re.replace(fileText, "$1" & strNewVersion & """")
	
'replace ProductCode

	re.pattern = "(""ProductCode"" = ""8:)(\{.+\})"""
	guid = CreateObject("Scriptlet.TypeLib").Guid
	guid = left(guid, len(guid) - 2)
	fileText = re.replace(fileText, "$1" & guid & """")

'replace PackageCode

	re.pattern = "(""PackageCode"" = ""8:)(\{.+\})"""
	guid = CreateObject("Scriptlet.TypeLib").Guid
	guid = left(guid, len(guid) - 2)
	fileText = re.replace(fileText, "$1" & guid & """")

'write project file

	fnew = args(0)
	set f = fso.CreateTextfile(fnew, true)
	f.write(fileText)
	f.close