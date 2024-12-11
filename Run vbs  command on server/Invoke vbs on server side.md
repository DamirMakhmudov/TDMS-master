# Вызов и выполнение `vbs` скрипта на стороне сервера

## Окружение
TDMS Client 7.0.1613.1  
TDMS Apps Server 7.0.107  

## Описание

Команда [c_run_client.vbs](./c_run_client.vbs) Тип: Общая  
Команда [c_run_server.vbs](./c_run_server.vbs) Тип: Серверная

Ввиду отсутствия в серверной команде UI методов, использую контрукцию: `Общая` команда вызывает серверную с помощью `ExecuteScript` или `ExecuteCommand`. Так можно получить результат выполнения серверной команды и добавить диалоги загрузки и завершения. В качестве аргументов `серверной` функции необходимо использовать обычный текст. Поэтому для передачи экземпляра объекта, лучше использовать его `GUID`


В серверной команде вызываемую функцию необходимо выносить наружу с помощью `extern`

```v
extern c_run_server_func

function c_run_server_func(guid)
...
```

При написании `серверной` команды важно сохранять строгий стиль написания кода:

<hr style="background-color: green">

```v
ObjectsByDef(thisapplication.ObjectDefs("O_Doc"))
```

```v
with o_plan_wbs
    .attributes("A_Str_Name").value = obj.attributes("A_Str_Name").value
```

Следующие варианты не сработают:
<hr style="background-color: red">

```v
ObjectsByDef("O_Set")
```
```v
with o_plan_wbs
    .attributes("A_Str_Name") = obj.attributes("A_Str_Name")
```

## :warning: Проблемы
При вызове серверной команды существует некий таймаут, и в случае, если время выполнения его превышает, появляется ошибка истечения времени ожидания (приведу позже, она рандомная)