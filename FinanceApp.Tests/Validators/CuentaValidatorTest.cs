using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NUnit.Framework;
using FinanceApp.web.Models;
using FinanceApp.web.Validators;
using FinanceApp.web;

namespace FinanceApp.Tests.Validators
{
    public class CuentaValidatorTest
    {
        [Test]
        public void NombreCuentaUnico()
        {
            var contextMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
            contextMock.Setup(c => c.Cuentas).ReturnsDbSet(new List<Cuenta>
            {
                new Cuenta { Nombre = "101010101010"},
                new Cuenta {Nombre="20202020"},
                new Cuenta {Nombre="30303030"},
                new Cuenta{Nombre="40404040"},
            });
            var context = contextMock.Object;
            var validator = new CuentaValidator();
            var resultado = validator.hasUniqueName(context, new Cuenta { Nombre = "101010101010" });
            Assert.AreEqual(false, resultado);
        }
        [Test]
        public void NombreCuentaUnico2()
        {
            var contextMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
            contextMock.Setup(c => c.Cuentas).ReturnsDbSet(new List<Cuenta>
            {
                new Cuenta { Nombre = "101010101010"},
                new Cuenta {Nombre="20202020"},
                new Cuenta {Nombre="30303030"},
                new Cuenta{Nombre="40404040"},
            });
            var context = contextMock.Object;
            var validator = new CuentaValidator();
            var resultado = validator.hasUniqueName(context, new Cuenta { Nombre = "30303030" });
            Assert.AreEqual(false, resultado);
        }
        [Test]
        public void NombreCuentaUnico3()
        {
            var contextMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
            contextMock.Setup(c => c.Cuentas).ReturnsDbSet(new List<Cuenta>
            {
                new Cuenta { Nombre = "101010101010"},
                new Cuenta {Nombre="20202020"},
                new Cuenta {Nombre="30303030"},
                new Cuenta{Nombre="40404040"},
            });
            var context = contextMock.Object;
            var validator = new CuentaValidator();
            var resultado = validator.hasUniqueName(context, new Cuenta { Nombre = "00000000000" });
            Assert.AreEqual(true, resultado);
        }
    }
}
