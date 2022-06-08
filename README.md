# Wine Joy (Back End Rest Api)

Back End para la prueba tecnica para de Amadeus, consiste en un Web API que implementa swagger el cual ofrece un CRUD de las entidades del projecto.
Incluye el proyecto principal en NET Core 5.0 y el de pruebas unitarias con Xunit
## Swagger

Se implementa Swagger utilizando los correspondientes metodos HTTP para ofertar el CRUD de las entidades implementadas

## Entidades

Wine: Entidad principal. implementa ints, floats, varchars contiene las FK a las demas
Otras entidades. Clasification, Sweetness, Acidity. Para la descirpcion de caracteristicas

## BD

La BD esta implementada en MySQL y una versión publicada,se encuentra ubicacda en la plataforma remoteremotemysql
https://remotemysql.com/phpmyadmin/index.php
Username: OxAIZvu7Va
Database name: OxAIZvu7Va
Password: CUeqNsd0vO
Server: remotemysql.com
Port: 3306
solo esta disponible hasta (08/07/2022)

El conection string se puede modificar en 
Controlers/GeneralControllerHelpers connectionString

## Importante

De ser necesario cambiar los puertos en los cuales se expone el API de ser requerido y en el Startup ConfigureServices los permisos de CORS

https://i.ibb.co/TKn2Ndf/AT1.png



