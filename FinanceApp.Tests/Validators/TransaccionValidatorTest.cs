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
    public class TransaccionValidatorTest
    {
        [Test]
        public void ValidarCategoriaExiste()
        {
            var contextMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
            contextMock.Setup(c => c.Categorias).ReturnsDbSet(new List<Categoria>
            {
                new Categoria { Id = 1},
                new Categoria {Id=2},
                new Categoria {Id=3},
                new Categoria{Id=4},
            });
            contextMock.Setup(c => c.Transacciones).ReturnsDbSet(new List<Transaccion>
            {
                new Transaccion { CategoryId = 1 },
                new Transaccion {CategoryId=2},
                new Transaccion {CategoryId=3},
                new Transaccion{CategoryId=4},
            });
            
            var context = contextMock.Object;
            var validator = new TransaccionValidator();
            var resultado = validator.hasValidCategory(context,new Transaccion { CategoryId=1});
            Assert.AreEqual(false, resultado);
        }
        [Test]
        public void ValidarCategoriaExiste2()
        {
            var contextMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
            contextMock.Setup(c => c.Categorias).ReturnsDbSet(new List<Categoria>
            {
                new Categoria { Id = 1},
                new Categoria {Id=2},
                new Categoria {Id=3},
                new Categoria{Id=4},
            });
            contextMock.Setup(c => c.Transacciones).ReturnsDbSet(new List<Transaccion>
            {
                new Transaccion { CategoryId = 1},
                new Transaccion {CategoryId=2},
                new Transaccion {CategoryId=3},
                new Transaccion{CategoryId=4},
            });
            var context = contextMock.Object;
            var validator = new TransaccionValidator();
            var resultado = validator.hasValidCategory(context, new Transaccion { CategoryId = 2 });
            Assert.AreEqual(false, resultado);
        }
        [Test]
        public void ValidarCategoriaExiste3()
        {
            var contextMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
            contextMock.Setup(c => c.Categorias).ReturnsDbSet(new List<Categoria>
            {
                new Categoria { Id = 1},
                new Categoria {Id=2},
                new Categoria {Id=3},
                new Categoria{Id=4},
            });
            contextMock.Setup(c => c.Transacciones).ReturnsDbSet(new List<Transaccion>
            {
                new Transaccion { CategoryId = 1},
                new Transaccion {CategoryId=2},
                new Transaccion {CategoryId=3},
                new Transaccion{CategoryId=4},
            });
            var context = contextMock.Object;
            var validator = new TransaccionValidator();
            var resultado = validator.hasValidCategory(context, new Transaccion { CategoryId = 8 });
            Assert.AreEqual(true, resultado);
        }
    }
}
