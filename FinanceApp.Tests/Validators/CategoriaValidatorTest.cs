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
    public class CategoriaValidatorTest
    {
        [Test]
        public void NombreCategoriaUnico()
        {
            var contextMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
            contextMock.Setup(c => c.Categorias).ReturnsDbSet(new List<Categoria>
            {
                new Categoria { Nombre = "BCP"},
                new Categoria {Nombre="BBVA"},
                new Categoria {Nombre="Banco de la Nacion"},
                new Categoria{Nombre="Interbank"},
            });
            var context = contextMock.Object;
            var validator = new CategoriaValidator();
            var resultado = validator.hasUniqueName(context, new Categoria { Nombre = "BCP" });
            Assert.AreEqual(false,resultado);
        }
        [Test]
        public void NombreCategoriaUnico2()
        {
            var contextMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
            contextMock.Setup(c => c.Categorias).ReturnsDbSet(new List<Categoria>
            {
                new Categoria { Nombre = "BCP"},
                new Categoria {Nombre="BBVA"},
                new Categoria {Nombre="Banco de la Nacion"},
                new Categoria{Nombre="Interbank"},
            });
            var context = contextMock.Object;
            var validator = new CategoriaValidator();
            var resultado = validator.hasUniqueName(context, new Categoria { Nombre = "CMR" });
            Assert.AreEqual(true, resultado);
        }
        [Test]
        public void NombreCategoriaUnico3()
        {
            var contextMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
            contextMock.Setup(c => c.Categorias).ReturnsDbSet(new List<Categoria>
            {
                new Categoria { Nombre = "BCP"},
                new Categoria {Nombre="BBVA"},
                new Categoria {Nombre="Banco de la Nacion"},
                new Categoria{Nombre="Interbank"},
            });
            var context = contextMock.Object;
            var validator = new CategoriaValidator();
            var resultado = validator.hasUniqueName(context, new Categoria { Nombre = "BBVA" });
            Assert.AreEqual(false, resultado);
        }
        [Test]
        public void TipoCategoriaValido()
        {
            var validator = new CategoriaValidator();
            var resultado = validator.hasValidType(new Categoria { Tipo = "INGRESO" });
            Assert.AreEqual(true, resultado);
        }
        [Test]
        public void TipoCategoriaValido2()
        {
            var validator = new CategoriaValidator();
            var resultado = validator.hasValidType(new Categoria { Tipo = "EGRESO" });
            Assert.AreEqual(true, resultado);
        }
        [Test]
        public void TipoCategoriaValido3()
        {
            var validator = new CategoriaValidator();
            var resultado = validator.hasValidType(new Categoria { Tipo = "lalalla" });
            Assert.AreEqual(false, resultado);
        }
    }
}
