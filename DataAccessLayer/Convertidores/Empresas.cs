﻿using DataAccessLayer.Convertidores;
using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    partial class Empresas
    {
        public void setModel(Empresa emp)
        {
            Activo = (bool)emp.Activo;
            Nombre = emp.Nombre;
            RUT = emp.RUT;
            Zona_Latitud = (Double)emp.Zona_Latitud;
            Zona_Longitud = (Double)emp.Zona_Longitud;
            this.Empleados = new ConvertType().EmpleadoToEmpleadoDB(emp.Lista_Empleados, emp.RUT);
            this.Vehiculos = new ConvertType().VehiculoToVehiculoDB(emp.Lista_Vehiculos, emp.RUT);


        }

        public Empresa getEntity()
        {
            Empresa nuevo = new Empresa();
            nuevo.Activo = (bool)Activo;
            nuevo.Nombre = Nombre;
            nuevo.RUT = RUT;
            nuevo.Zona_Latitud = (Double)Zona_Latitud;
            nuevo.Zona_Longitud = (Double)Zona_Longitud;
            nuevo.Lista_Empleados = new ConvertType().EmpleadoDBToEmpleado((List<Empleados>)Empleados);
            nuevo.Lista_Usuarios = new ConvertType().UsuarioDBToUsuario((List<Usuarios>)Usuarios);
            nuevo.Lista_Vehiculos = new ConvertType().VehiculoDBToVehiculo((List<Vehiculos>)Vehiculos);
            return nuevo;

        }
    }
}