using Fiap.Web.Alunos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.Alunos.Controllers
{
    public class ClienteController : Controller
    {

        //private List<ClienteModel> _clientes;
        public IList<ClienteModel> clientes { get; set; }
        public IList<RepresentanteModel> representantes { get; set; }
        public ClienteController()
        {
            clientes = GerarClientesMocados();
            representantes = GerarRepresentantesMocados();
        }

        public IActionResult Index ()
        {
            if (clientes == null)
            {
                clientes = new List<ClienteModel>();
            }
            return View(clientes);
        }

        //Funcionalidade Criar
        [HttpGet]
        public IActionResult Create()
        {
            Console.WriteLine("Executou a Action Cadastrar()");
            //Cria a variável para armazenar o SelectList
            var selectListRepresentantes =
                new SelectList(representantes,
                                nameof(RepresentanteModel.RepresentanteId),
                                nameof(RepresentanteModel.NomeRepresentante));
            //Adiciona o SelectList a ViewBag para se enviado para a View
            //A propriedade Representantes é criada de forma dinâmica na ViewBag
            ViewBag.Representantes = selectListRepresentantes;
            // Retorna para a View Create um 
            // objeto modelo com as propriedades em branco 
            return View(new ClienteModel());
        }

        [HttpPost]
        public IActionResult Create(ClienteModel clienteModel)
        {

            Console.WriteLine("Cliente cadastrado com sucesso!");

            TempData["mensagemSucesso"] = $"Cliente {clienteModel.Nome} foi cadastrado com sucesso!";
            return RedirectToAction(nameof(Index));
        }



        // Anotação de uso do Verb HTTP Get
        // Funcionalidade Edição
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var selectListRepresentantes =
                new SelectList(representantes,
                                nameof(RepresentanteModel.RepresentanteId),
                                nameof(RepresentanteModel.NomeRepresentante));
            ViewBag.Representantes = selectListRepresentantes;
            // Simulando a busca no banco de dados 
            var clienteConsultado =
                clientes.Where(c => c.ClienteId == id).FirstOrDefault();
            // Retornando o cliente consultado para a View
            return View(clienteConsultado);
        }
        [HttpPost]
        public IActionResult Edit(ClienteModel clienteModel)
        {
            TempData["mensagemSucesso"] = $"Os dados do cliente {clienteModel.Nome} foram alterados com sucesso";
            return RedirectToAction(nameof(Index));
        }


        //Details
        [HttpGet]
        public IActionResult Details(int id)
        {
            var selectListRepresentantes =
                new SelectList(representantes,
                                nameof(RepresentanteModel.RepresentanteId),
                                nameof(RepresentanteModel.NomeRepresentante));
            ViewBag.Representantes = selectListRepresentantes;
            // Simulando a busca no banco de dados 
            var clienteConsultado =
                clientes.Where(c => c.ClienteId == id).FirstOrDefault();
            // Retornando o cliente consultado para a View
            return View(clienteConsultado);


        }

        // Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Simulando a busca no banco de dados 
            var clienteConsultado =
                clientes.Where(c => c.ClienteId == id).FirstOrDefault();
            if (clienteConsultado != null)
            {
                TempData["mensagemSucesso"] = $"Os dados do cliente {clienteConsultado.Nome} foram removidos com sucesso";
            }
            else
            {
                TempData["mensagemSucesso"] = $"OPS !!! Cliente inexistente.";
            }
            return RedirectToAction(nameof(Index));
        }

        /**
         * Este método estático GerarRepresentantesMocados 
         */
        public static List<RepresentanteModel> GerarRepresentantesMocados()
        {
            var representantes = new List<RepresentanteModel>
            {
                new RepresentanteModel { RepresentanteId = 1, NomeRepresentante = "Representante 1", Cpf = "111.111.111-11" },
                new RepresentanteModel { RepresentanteId = 2, NomeRepresentante = "Representante 2", Cpf = "222.222.222-22" },
                new RepresentanteModel { RepresentanteId = 3, NomeRepresentante = "Representante 3", Cpf = "333.333.333-33" },
                new RepresentanteModel { RepresentanteId = 4, NomeRepresentante = "Representante 4", Cpf = "444.444.444-44" }
            };
            return representantes;
        }

        /**
        Este método estático GerarClientesMocados
        cria uma lista de 5 clientes com dados fictícios
        */
        public static List<ClienteModel> GerarClientesMocados() 
        {
            var clientes = new List<ClienteModel>();

            for (int i = 1; i <= 5; i++)
            {
                var cliente = new ClienteModel
                {
                    ClienteId = i,
                    Nome = "Cliente" + i,
                    Sobrenome = "Sobrenome" + i,
                    Email = "cliente" + i + "@example.com",
                    DataNascimento = DateTime.Now.AddYears(-30),
                    RepresentanteId = i,
                    Representante = new RepresentanteModel
                    {
                        RepresentanteId = i,
                        NomeRepresentante = "Representante" + i,
                        Cpf = "000000191"
                    }
                };
                clientes.Add(cliente);
            }
            return clientes;
        }



    }
}
