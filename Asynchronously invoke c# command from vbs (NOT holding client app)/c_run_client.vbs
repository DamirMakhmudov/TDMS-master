'+-------------------------+
'+ Тип команды - Общая    +
'+-------------------------+

Call main()

function main()
 
  ' Вызов с ожиданием ответа
  Dim res = ThisApplication.ExecuteScript("c_run_server", "c_run_server_func", "hello")   
  msgbox "Завершено", 64

end function