'+-------------------------+
'+ Тип команды - Server    +
'+-------------------------+

Extern c_run_server_func

function c_run_server_func(text)
  ' some script

  Thisapplication.DebugPrint text
  res = ThisApplication.ExecuteScript("C_API", "ServerSideFunc", text)
  c_run_server_func = res

end function





