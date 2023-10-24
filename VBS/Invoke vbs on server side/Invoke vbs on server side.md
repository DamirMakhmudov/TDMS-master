# Вызов и выполнение `vbs` скрипта на стороне сервера

## Окружение
TDMS Client 7.0.1613.1  
TDMS Apps Server 7.0.44  
Клинет и сервер в одной локальной сети

## Описание

Команда [cmd_map_chart.vbs](./cmd_map_chart.vbs) Тип: Общая  
Команда [cmd_map_chart_server.vbs](./cmd_map_chart_server.vbs) Тип: Серверная

Мои тесты показали разницу в скорости выполнения аналогичноого кода серверой и обычной команды в 5-7 раз :+1:

Ввиду отсутствия в серверной окманде UI методов (что логично), использую контрукцию: обычная комнада вызывает серверную с помощью `ExecuteScript` или `ExecuteCommand`. Так можно получить результат выполнения серверной команды и добавиь диалоги загрузки и завершения, иначе пользоват

В качестве аргументов `серверной` функции необходимо использовать обычный текст. Поэтому для передачи экземпляра объекта, лучше использовать его `GUID`

```v
ThisApplication.ExecuteScript("cmd_map_chart_server", "map_chart_start", obj.GUID)
```
В серверной команде вызываемую функцию необходимо выносить наружу с помощью `extern`

```v
extern map_chart_start

function map_chart_start(guid)
...
```

При написании `серверной` команды важно сохранять строгий стиль написания кода:

<hr style="background-color: green">

```v
ObjectsByDef(thisapplication.ObjectDefs("O_Set"))
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
Судя по всему при вызове серверной команды существует некий таймаут, и в случае, если время выполнения его превышает, появляется ошибка истечения времени ожидания (приведу позже, она рандомная)