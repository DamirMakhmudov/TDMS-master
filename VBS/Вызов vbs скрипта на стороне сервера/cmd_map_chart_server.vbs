extern map_chart_start

public o_plan_ksg

function map_chart_start(guid)
  thisscript.SysAdminModeOn
  set o_plan_ksg = thisapplication.GetObjectByGUID(guid)
  set o_project = o_plan_ksg.Attributes("A_Ref_Project").Object
  set stages = o_project.Content.ObjectsByDef(thisapplication.ObjectDefs("o_stage"))
  count = stages.count
  for each o_stage in stages
    createO_PLAN_WBS o_plan_ksg, o_stage
  next  
'  map_chart_start = "200"
  thisapplication.SaveContextObjects
end function

function createO_PLAN_WBS(parent, obj)
  set o_plan_wbs = obj.attributes("A_Ref_PLAN_Activity").object
  if o_plan_wbs is nothing then
    set o_plan_wbs = parent.Content.Create(thisapplication.ObjectDefs("o_plan_wbs"))
  end if
  with o_plan_wbs
    .attributes("A_Str_Name").value = obj.attributes("A_Str_Name").value
    .attributes("A_Date_Begin").value = obj.attributes("A_Date_Begin").value
    .attributes("A_Date_End") = obj.attributes("A_Date_End").value
    .attributes("A_Date_Begin_Fact").value = obj.attributes("A_Date_Begin_Fact").value
    .attributes("A_Date_End_Fact").value = obj.attributes("A_Date_End_Fact").value
  end with
  obj.attributes("A_Ref_PLAN_Activity").value = o_plan_wbs  
  
  for each o_task in obj.Contentall.ObjectsByDef(thisapplication.ObjectDefs("o_task"))
    set o_plan_activity = createO_PLAN_Activity(o_plan_wbs, o_task)
    o_plan_activity.attributes("A_Cls_PLAN_Activity_Type").value = thisapplication.Classifiers.FindBySysId("N_PLAN_Activity_Type_02")
    o_plan_activity.Icon = ThisApplication.Icons("I_O_PLAN_ACTIVITY_TASK")
  next

  for each o_task in obj.Contentall.ObjectsByDef(thisapplication.ObjectDefs("O_Set"))
    set o_plan_activity = createO_PLAN_Activity(o_plan_wbs, o_task)
    o_plan_activity.attributes("A_Cls_PLAN_Activity_Type").value = thisapplication.Classifiers.FindBySysId("N_PLAN_Activity_Type_01")
    o_plan_activity.Icon = ThisApplication.Icons("I_O_PLAN_ACTIVITY_DOC")
  next
  
  for each o_task in obj.Contentall.ObjectsByDef(thisapplication.ObjectDefs("O_Volume"))
    set o_plan_activity = createO_PLAN_Activity(o_plan_wbs, o_task)
    o_plan_activity.attributes("A_Cls_PLAN_Activity_Type").value = thisapplication.Classifiers.FindBySysId("N_PLAN_Activity_Type_01")
    o_plan_activity.Icon = ThisApplication.Icons("I_O_PLAN_ACTIVITY_DOC")
  next
 
  for each o_task in obj.Contentall.ObjectsByDef(thisapplication.ObjectDefs("O_TPPD_Volume"))
    set o_plan_activity = createO_PLAN_Activity(o_plan_wbs, o_task)
    o_plan_activity.attributes("A_Cls_PLAN_Activity_Type").value = thisapplication.Classifiers.FindBySysId("N_PLAN_Activity_Type_01")
    o_plan_activity.Icon = ThisApplication.Icons("I_O_PLAN_ACTIVITY_DOC")
  next

  for each item in obj.Content.ObjectsByDef(thisapplication.ObjectDefs("O_Folder_Doc_Stage"))
'    ThisApplication.DebugPrint item.objectdefname & " " & item.Description
    createO_PLAN_WBS o_plan_wbs, item
  next
end function

function createO_PLAN_Activity(parent, obj)
  set o_plan_activity = obj.attributes("A_Ref_PLAN_Activity").object
  if o_plan_activity is nothing then
    set o_plan_activity = parent.Content.Create(thisapplication.ObjectDefs("o_plan_activity"))
  end if
  with o_plan_activity
    .attributes("A_Str_Name").value = obj.attributes("A_Str_Name").value
    .attributes("A_Ref_Stage").value = obj.attributes("A_Ref_Stage").object
    .attributes("A_Date_Begin").value = obj.attributes("A_Date_Begin").value
    .attributes("A_Date_End").value = obj.attributes("A_Date_End").value
    .attributes("A_Date_Begin_Fact").value = obj.attributes("A_Date_Begin_Fact").value
    .attributes("A_Date_End_Fact").value = obj.attributes("A_Date_End_Fact").value
  end with
  obj.attributes("A_Ref_PLAN_Activity").value = o_plan_activity  
  set createO_PLAN_Activity = o_plan_activity
end function
