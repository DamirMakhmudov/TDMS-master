'+-------------------------+
'+ Тип команды - Server    +
'+-------------------------+

Extern c_run_server_func

function c_run_server_func(text)

  Thisapplication.DebugPrint text
  res = ThisApplication.ExecuteScript("C_API", "Execute", "hello")
  Thisapplication.DebugPrint res
  c_run_server_func = res

end function