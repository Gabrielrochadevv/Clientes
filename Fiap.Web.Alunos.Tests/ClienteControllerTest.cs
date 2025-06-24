using Fiap.Web.Alunos.Controllers;
using Fiap.Web.Alunos.Data;
using Fiap.Web.Alunos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Web.Alunos.Tests
{
    public class ClienteControllerTest
    {
        // Mock do contexto do banco de dados
        private readonly Mock<DatabaseContext> _mockContext;

        // Controlador que será testado
        private readonly ClienteController _clientecontroller;

        // Mock do DbSet para ClienteModel
        private readonly DbSet<ClienteModel> _mockset;


        public ClienteControllerTest() 
        { 
            _mockContext = new Mock<DatabaseContext>();

            _mockset = MockDbSet();

            _mockContext.Setup(m => m.Clientes).Returns(_mockset);

            _clientecontroller = new ClienteController(_mockContext.Object);
        }



        // Método para criar e configurar um DbSet mock para ClienteModel
        private DbSet<ClienteModel> MockDbSet()
        {
            // Lista de clientes para simular dados no banco de dados
            var data = new List<ClienteModel>
            {
                new ClienteModel { ClienteId = 1, Nome = "Cliente 1" },
                new ClienteModel { ClienteId = 2, Nome = "Cliente 2" }
            }.AsQueryable();
            // Cria o mock do DbSet
            var mockSet = new Mock<DbSet<ClienteModel>>();
            // Configura o comportamento do mock DbSet para simular uma consulta ao banco de dados
            mockSet.As<IQueryable<ClienteModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<ClienteModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<ClienteModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<ClienteModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            // Retorna o DbSet mock
            return mockSet.Object;

        }
        //Tenho clientes
        [Fact]

        public void Index_ReturnsViewWithClients() 
        {

            //Act
            var result = _clientecontroller.Index();


            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);


            // verifica se tem conteudo de clientes lá dentro

            //var model = Assert.IsAssignableFrom<ClienteModel>(viewResult.Model);   
            var model = Assert.IsAssignableFrom<IEnumerable<ClienteModel>>(viewResult.Model);

            Assert.Equal(2, model.Count());
        }

        //Não tenho Clientes
        [Fact]

        public void Index_ReturnsViewWithoutClients()
        {

            //Arrange
            _mockset.RemoveRange(_mockset.ToList());
            _mockContext.Setup( m=> m.Clientes).Returns(_mockset);


            //Act
            var result = _clientecontroller.Index();


            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);


            // verifica se tem conteudo de clientes lá dentro

            //var model = Assert.IsAssignableFrom<ClienteModel>(viewResult.Model);   
            var model = Assert.IsAssignableFrom<IEnumerable<ClienteModel>>(viewResult.Model);

            Assert.Empty(model);
        }

    }
}

    