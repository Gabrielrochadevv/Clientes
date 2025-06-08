# Clientes
# Sistema de Gerenciamento de Clientes - ASP.NET Core MVC

## 📌 Descrição do Projeto

Este projeto é um sistema simples desenvolvido com **ASP.NET Core MVC**, com foco no entendimento do padrão MVC (Model-View-Controller) e da navegação entre as páginas da aplicação. 

Atualmente, o sistema é **puramente visual e simulado**, ou seja, **não possui conexão com banco de dados**. Os dados são gerados de forma estática na aplicação com o objetivo de demonstrar:

- O funcionamento das rotas e controllers;
- A troca de informações entre cliente (navegador) e servidor;
- O uso de `ViewBag`, `SelectList`, e `TempData`;
- A criação e organização das camadas **Model**, **View** e **Controller**.

---

## ⚙️ Funcionalidades Implementadas

As funcionalidades giram em torno da classe `ClienteModel`, representando um cliente da aplicação.

- ✅ **Listar Clientes:** Exibe todos os clientes cadastrados na tela principal.
- ✅ **Cadastrar Cliente:** Permite a criação de um novo cliente, com seleção de um representante.
- ✅ **Editar Cliente:** Permite editar os dados de um cliente existente.
- ✅ **Visualizar Detalhes:** Exibe as informações completas de um cliente.
- ✅ **Excluir Cliente:** Remove um cliente da listagem simulada.

As informações dos clientes e representantes são geradas através de métodos mockados (`GerarClientesMocados` e `GerarRepresentantesMocados`).

- proximo passo: Integração com banco de dados.
---

## 🧠 Estrutura do Projeto

```bash
Fiap.Web.Alunos/
│
├── Controllers/
│   ├── ClienteController.cs       # Lógica das rotas e manipulação das requisições do cliente
│   └── HomeController.cs          # Página inicial e privacidade
│
├── Models/
│   ├── ClienteModel.cs            # Modelo que representa um Cliente
│   └── RepresentanteModel.cs      # Modelo que representa um Representante
│
├── Views/
│   └── Cliente/
│       ├── Index.cshtml           # Lista todos os clientes
│       ├── Create.cshtml          # Formulário de cadastro
│       ├── Edit.cshtml            # Formulário de edição
│       ├── Details.cshtml         # Detalhes do cliente
│   └── Home/
│       ├── Index.cshtml
│       ├── Privacy.cshtml
│
├── wwwroot/                       # Arquivos estáticos (CSS, JS)
└── Program.cs / Startup.cs        # Configuração da aplicação
