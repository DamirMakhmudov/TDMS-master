'+-------------------------+
'+ Тип команды - Общая    +
'+-------------------------+

Call main()

function main()
  Set progress = ThisApplication.Dialogs.ProgressDlg
  progress.Type = 0
  progress.Start
  progress.text = "Выполняю..."

  'Вызов без ожидания ответа
  ThisApplication.ExecuteScript "c_run_server", "c_run_server_func", "hello"
 
  ' Вызов с ожиданием ответа
  Dim res = ThisApplication.ExecuteScript("c_run_server", "c_run_server_func", "hello")   
  progress.Stop
  msgbox "Завершено", 64

end function