# **Prueba FullStack F2X**

## **Lógica de negocio**

Desarrollar una api que entregue la información de todos los recaudos de los últimos tres meses y un reporte con la información tabulada, que sea visible a través de una api Rest y una vista en Angular.

## **Código fuente**

### **Back end**

La api fue desarrollada en **.NET Core 3.1**, se hizo uso de **Sql Server** como gestor de base de datos para almacenar los datos obtenidos a través de la api **http://190.145.81.67:5200/documentation/**.

- #### **Instalación**

  Luego de obtener el código fuente del repositorio abrir en Visual Studio 2019, compilar y ejecutar el proyecto **RecaudoVehiculosF2X.WebApi**.

- #### **Consumo de la api**

  http://localhost:24353/swagger/index.html

- **Consulta de recaudos**

  GET → http://localhost:24353/api/RecaudoVehiculos

- **Consulta de reporte tabulado**

  POST → http://localhost:24353/api/RecaudoVehiculos/ExportarRecaudos

### **Front end**

Realizado en **Angular CLI: 13.0.3**.

#### **Instalación**

Luego de obtener el código fuente del repositorio abrir en Visual Studio Code, ejecutar el comando **npm install** y luego que termine de descargar los componentes necesarios ejecutar el comando **ng serve**.

- #### **Consumo web**

  http://localhost:4200/

  http://localhost:4200/ExportarRecaudos
