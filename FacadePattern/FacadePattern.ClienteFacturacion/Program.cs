﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacadePattern.Fachada;

namespace FacadePattern.ClienteFacturacion
{
    class Program
    {
        //lo estoy comentando por mientras
        static void Main(string[] args)
        {
            Console.Write("Digite la identificación del empleado para obtener su total de ingresos ...");
            var idEmpleado = Console.ReadLine();

            var empleadoFacade = new EmpleadoFacade();
            var salario = empleadoFacade.ObtenerTotalIngresosEmpleado(idEmpleado);
            Console.Write("Los ingresos totales del empleado con identificación {0}, son: {1}", idEmpleado, salario);
            Console.ReadLine();
        }
    }
}
