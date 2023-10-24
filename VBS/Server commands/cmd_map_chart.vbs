call map_chart(thisobject)

function map_chart(obj)
  thisscript.SysAdminModeOn
  Set progress = ThisApplication.Dialogs.ProgressDlg
  progress.Type = 0
  progress.Start
  progress.text = "Выполняю..."
  
  'Вызов без ожидания результата
  ThisApplication.ExecuteScript "cmd_map_chart_server", "map_chart_start", obj.GUID
  
  ' Вызов с ожиданием результата
  dim res = ThisApplication.ExecuteScript("cmd_map_chart_server", "map_chart_start", obj.GUID)   
  progress.Stop
  msgbox "Завершено", 64
end function