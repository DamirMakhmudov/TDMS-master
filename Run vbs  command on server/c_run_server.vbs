'+-------------------------+
'+ Тип команды - Server    +
'+-------------------------+

Extern c_run_server_func

function c_run_server_func(text)
  ' some script

  Thisapplication.DebugPrint text
  c_run_server_func = res ' возврат ответа

end function





