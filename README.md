# Projeto ASP.NET

# Gerenciador de Tarefas ASP.NET 8.0

## Descrição

Este projeto é uma aplicação web simples para **gerenciamento de tarefas**, desenvolvida em **ASP.NET 8.0** com Entity Framework Core e MySQL.  
Permite **cadastrar, listar, editar, concluir e excluir tarefas** em uma única tabela no banco de dados.

---

## Funcionalidades

- **Adicionar tarefa:** Informe a descrição e salve.
- **Listar tarefas:** Visualize todas as tarefas cadastradas.
- **Concluir tarefa:** Marque uma tarefa como concluída.
- **Excluir tarefa:** Remova uma tarefa após confirmação.
- **Interface moderna:** Utiliza Bootstrap 5 e Bootstrap Icons.

---



## Estrutura do Projeto

O projeto está organizado em pastas e arquivos conforme boas práticas do ASP.NET Core MVC:

```
Gerenciador_De_Tarefas/
  appsettings.json
  appsettings.Development.json
  Program.cs
  Data/
    TarefasContext.cs
  Models/
    Tarefa.cs
  Controllers/
    TarefasController.cs
  Views/
    Tarefas/
      Index.cshtml
      Edit.cshtml
  Migrations/
    20250627195714_Inicial.cs
  wwwroot/
    index.html
    js/
      script.js
    css/
      style.css
  GerenciadorTarefas.sql
```

**Principais responsabilidades:**
- `Program.cs`: Inicialização, configuração de serviços, middlewares e rotas.
- `Data/`: DbContext do Entity Framework Core.
- `Models/`: Classes de domínio (ex: Tarefa).
- `Controllers/`: Lógica dos endpoints HTTP (REST ou MVC).
- `Views/`: Páginas Razor (MVC) para exibição de dados (opcional, caso use Razor além do SPA).
- `Migrations/`: Scripts de versionamento do banco de dados.
- `wwwroot/`: Arquivos estáticos (HTML, JS, CSS, imagens).
- `appsettings.json`: Configurações gerais e de conexão.
- `GerenciadorTarefas.sql`: Script SQL para criação manual do banco.

### Fluxo geral

1. O usuário acessa a interface web (`index.html`), que consome a API REST via JavaScript.
2. O backend ASP.NET expõe endpoints para CRUD de tarefas, usando o padrão Controller.
3. O Entity Framework Core faz o mapeamento objeto-relacional e aplica as migrations automaticamente ao iniciar.
4. Toda a comunicação entre frontend e backend é feita via fetch/AJAX, sem recarregar a página.

### Observações sobre a estrutura

- O projeto está pronto para crescer: basta adicionar novos Models, Controllers ou Views conforme necessário.
- O código segue boas práticas de separação de responsabilidades.
- A interface é responsiva e moderna, utilizando Bootstrap 5.
- O backend está preparado para produção, com logging configurado e migrations automáticas.

---

## Como funciona o código

### Backend (`Program.cs`)

- **Configuração do DbContext:**  
  Usa `TarefasContext` para mapear a tabela `Tarefas` no banco MySQL.
- **Endpoints REST:**
  - `GET /api/tarefas`: Lista todas as tarefas.
  - `POST /api/tarefas`: Adiciona uma nova tarefa.
  - `PUT /api/tarefas/{id}/concluir`: Marca uma tarefa como concluída.
  - `DELETE /api/tarefas/{id}`: Exclui uma tarefa.
- **Migração automática:**  
  Ao iniciar, aplica as migrations para criar a tabela se necessário.
- **Modelo:**  
  A classe `Tarefa` representa cada tarefa, com campos para Id, Descrição, Concluída e Data de Criação.

### Frontend (`index.html`, `script.js`, `style.css`)

- **Interface:**  
  Formulário para adicionar tarefas, tabela para listar e botões para concluir/excluir.
- **Confirmação de exclusão:**  
  Ao clicar em "Excluir", abre um modal perguntando se deseja realmente deletar a tarefa.
- **AJAX:**  
  Toda comunicação com o backend é feita via `fetch` (sem recarregar a página).
- **Visual:**  
  Layout responsivo e moderno com Bootstrap.

---

## Como rodar o projeto

1. **Pré-requisitos:**
   - .NET 8.0 SDK instalado
   - MySQL Server instalado e rodando
   - Ajuste a connection string no `appsettings.json` ou no código

2. **Restaurar dependências e rodar:**
   ```sh
   dotnet restore
   dotnet run
   ```

3. **Acesse no navegador:**
   ```
   http://localhost:PORTA
   ```

---

## Observações

- O projeto utiliza **apenas uma tabela** para as tarefas, conforme solicitado.
- O código está pronto para rodar em .NET 8.0.
- O projeto permite **adicionar, listar, editar, concluir e excluir tarefas**.
- A edição de tarefas está disponível tanto no backend (endpoint PUT) quanto na interface web (botão Editar), com feedback visual no formulário.

---

## Screenshots

![Tela Principal](screenshot.png)

---

## Autor

Projeto desenvolvido para avaliação prática de ASP.NET 8.0