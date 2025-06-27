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

- `Program.cs`: Configura o servidor, endpoints REST e o modelo de dados.
- `wwwroot/index.html`: Interface web (frontend).
- `wwwroot/js/script.js`: Lógica de interação frontend/backend.
- `wwwroot/css/style.css`: Estilos personalizados.
- Banco de dados: **MySQL** (configuração via connection string).

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
- Para editar tarefas, basta implementar um endpoint extra se desejar (atualmente, permite adicionar, concluir e excluir).

---

## Screenshots

![Tela Principal](screenshot.png)

---

## Autor

Projeto desenvolvido para avaliação prática de ASP.NET 8.0