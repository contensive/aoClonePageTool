function f
	dim action, pageId, pagePrefix
	'
	f = f  _
		& "<h2>Clone Page Tool</h2>" _
		& "<p>Use this tool to make a copy of a page and all its child pages. All cloned pages will include a prefix.</p>" _
		& ""
	action = cp.doc.getText( "button" )
	pagePrefix = cp.doc.getText( "pagePrefix" )
	pageId = cp.doc.getInteger( "pageId" )
	if action="Clone" Then
	f = f  _
		& "<p><br></p>" _
		& "<h4>cloning pageId: " & pageId & ", prefix: " & pagePrefix & "</h4>" _
		& ""
		f = f & clonePage( pageId, 0, 0, pagePrefix )
	end if
	'
	f = f  _
		& "<p><br></p>" _
		& "<h4>Clone Page Prefix<h4>" _
		& cp.html.inputText( "pagePrefix", pagePrefix )  _
		& "<p><br></p>" _
		& "<h4>Select the page to clone<h4>" _
		& cp.html.selectContent( "pageId", 0, "page content" )  _
		& "<p><br></p>" _
		& cp.html.button( "button", "Clone" ) _
		& ""
	f = cp.html.form( f )
	f = "<div style=""width:500px; margin: 10px auto; padding: 20px; background-color: #f8f8f8;"">" & f & "</div>"
	
end function
'
function clonePage( pageId, newParentId, tier, pagePrefix )
	dim csSrc, csDst, clonedPageId
	set csSrc = cp.csNew()
	set csDst = cp.csNew()
	'
	if tier > 5 Then
		clonePage = clonePage & "<br>Cannot clone tier " & tier & "."
	Else
		clonedPageId = 0
		if csSrc.open( "page content", "id=" & pageId,,false ) Then
			clonePage = clonePage & "<br>cloning pageId: " & pageId & ", to newParentId: " & newParentId & ", tier: " & tier
			if csDst.insert( "page content" ) then
				clonedPageId = csDst.getInteger( "id" )
				call csDst.setField( "parentId", newParentId)
				call csDst.setField( "name", pagePrefix & csSrc.getText( "name" ))
				call csDst.setField( "copyFilename", csSrc.getText( "copyFilename" ))
				'
				call csDst.setField( "Active", csSrc.getText( "Active" ))
				call csDst.setField( "Headline", csSrc.getText( "Headline" ))
				call csDst.setField( "AllowMetaContentNoFollow", csSrc.getText( "AllowMetaContentNoFollow" ))
				call csDst.setField( "BlockContent", csSrc.getText( "BlockContent" ))
				call csDst.setField( "BlockSourceID", csSrc.getText( "BlockSourceID" ))
				call csDst.setField( "CustomBlockMessage", csSrc.getText( "CustomBlockMessage" ))
				call csDst.setField( "RegistrationGroupID", csSrc.getText( "RegistrationGroupID" ))
				call csDst.setField( "ContentPadding", csSrc.getText( "ContentPadding" ))
				call csDst.setField( "ContactMemberID", csSrc.getText( "ContactMemberID" ))
				call csDst.setField( "IsSecure", csSrc.getText( "IsSecure" ))
				call csDst.setField( "TemplateID", csSrc.getText( "TemplateID" ))
				call csDst.setField( "AllowHitNotification", csSrc.getText( "AllowHitNotification" ))
				call csDst.setField( "AllowReturnLinkDisplay", csSrc.getText( "AllowReturnLinkDisplay" ))
				call csDst.setField( "AllowSeeAlso", csSrc.getText( "AllowSeeAlso" ))
				call csDst.setField( "AllowFeedback", csSrc.getText( "AllowFeedback" ))
				call csDst.setField( "AllowMoreInfo", csSrc.getText( "AllowMoreInfo" ))
				call csDst.setField( "AllowPrinterVersion", csSrc.getText( "AllowPrinterVersion" ))
				call csDst.setField( "AllowEmailPage", csSrc.getText( "AllowEmailPage" ))
				call csDst.setField( "AllowLastModifiedFooter", csSrc.getText( "AllowLastModifiedFooter" ))
				call csDst.setField( "AllowMessageFooter", csSrc.getText( "AllowMessageFooter" ))
				call csDst.setField( "AllowReviewedFooter", csSrc.getText( "AllowReviewedFooter" ))
				call csDst.setField( "DateReviewed", csSrc.getText( "DateReviewed" ))
				call csDst.setField( "ReviewedBy", csSrc.getText( "ReviewedBy" ))
				call csDst.setField( "Viewings", csSrc.getText( "Viewings" ))
				call csDst.setField( "PubDate", csSrc.getText( "PubDate" ))
				call csDst.setField( "DateExpires", csSrc.getText( "DateExpires" ))
				call csDst.setField( "DateArchive", csSrc.getText( "DateArchive" ))
				call csDst.setField( "ArchiveParentID", csSrc.getText( "ArchiveParentID" ))
				call csDst.setField( "ImageFilename", csSrc.getText( "ImageFilename" ))
				call csDst.setField( "JSOnLoad", csSrc.getText( "JSOnLoad" ))
				call csDst.setField( "JSHead", csSrc.getText( "JSHead" ))
				call csDst.setField( "JSFilename", csSrc.getText( "JSFilename" ))
				call csDst.setField( "JSEndBody", csSrc.getText( "JSEndBody" ))
				call csDst.setField( "AllowInMenus", csSrc.getText( "AllowInMenus" ))
				call csDst.setField( "AllowInChildLists", csSrc.getText( "AllowInChildLists" ))
				call csDst.setField( "AllowChildListDisplay", csSrc.getText( "AllowChildListDisplay" ))
				call csDst.setField( "ChildListSortMethodID", csSrc.getText( "ChildListSortMethodID" ))
				call csDst.setField( "MenuHeadline", csSrc.getText( "MenuHeadline" ))
				call csDst.setField( "SortOrder", csSrc.getText( "SortOrder" ))
				call csDst.setField( "AllowBrief", csSrc.getText( "AllowBrief" ))
				call csDst.setField( "BriefFilename", csSrc.getText( "BriefFilename" ))
				call csDst.setField( "Link", csSrc.getText( "Link" ))
				call csDst.setField( "Clicks", csSrc.getText( "Clicks" ))
				call csDst.setField( "ParentListName", csSrc.getText( "ParentListName" ))
				call csDst.setField( "ChildPagesFound", csSrc.getText( "ChildPagesFound" ))
				call csDst.setField( "ChildListInstanceOptions", csSrc.getText( "ChildListInstanceOptions" ))
				call csDst.setField( "PageLink", csSrc.getText( "PageLink" ))
			end if
			call csDst.close
		End If
		call csSrc.close()
		'
		if clonedPageId>0 then
			clonePage = clonePage & "<br>cloning child pages"
			if not csSrc.open( "page content", "parentId=" & pageId,,false ) Then
				clonePage = clonePage & "<br>(no child pages found)"
			else 
				Do
					clonePage = clonePage & clonePage( csSrc.getInteger( "id" ), clonedPageId, tier+1, pagePrefix )
					call csSrc.goNext
				Loop While csSrc.ok
			End If
			call csSrc.close()
		end if
	End If
end function