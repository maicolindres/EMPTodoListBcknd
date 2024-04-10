Readme.md

Descargar codigo de de GitHub
    - https://github.com/maicolindres/EMPTodoListFntnd.git
    - https://github.com/maicolindres/EMPTodoListBcknd.git

Proyecto <EMPTodoListBcknd>
    1) Modificar archivo appsettings.json del proyecto EMPTodoListBcknd
        - Abrir archivo en la ruta /
        - Cambiar los siguientes parametros:
            - "DefaultConnection"
                - Actualizar el el host del servidor MSSQL Server en la etiqueta "Server=".
                - Actualizar el password del usuario SA en la etiqueta "Password="
    2) Realizar la migracion desde la Terminal para crear la estructura de la BD:
                - dotnet ef migrations add migrationToDoBcknd
                - dotnet ef database update
    3) Desde la tarminal correo el aplicativo dotnet run


Proyecto <EMPTodoListFntnd>
    1) Modificar archivo Program.cs y agregar la url de donde se publico el proyecto de backend (linea 13), en mi caos es: http://localhost:5283
    2)  Desde la tarminal correo el aplicativo dotnet run

Finalmente interactuar con el aplicativo agregando listas y sus respectivas tareas.