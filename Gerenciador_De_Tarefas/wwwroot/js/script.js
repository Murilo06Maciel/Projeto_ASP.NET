document.addEventListener('DOMContentLoaded', function () {
    const form = document.getElementById('tarefa-form');
    const descricaoInput = document.getElementById('descricao');
    const tabela = document.getElementById('tarefas-tabela').querySelector('tbody');
    const btnCancelarEdicao = document.getElementById('cancelar-edicao');
    let tarefaEditandoId = null;

    function carregarTarefas() {
        fetch('/api/tarefas')
            .then(res => res.json())
            .then(tarefas => {
                tabela.innerHTML = '';
                tarefas.forEach(tarefa => {
                    const tr = document.createElement('tr');
                    tr.innerHTML = `
    <td>${tarefa.id}</td>
    <td>${tarefa.descricao}</td>
    <td>
        ${tarefa.concluida 
            ? '<span class="badge bg-success">Concluída</span>' 
            : '<span class="badge bg-danger">Pendente</span>'}
    </td>
    <td>
        <button class="btn btn-success btn-sm" ${tarefa.concluida ? 'disabled' : ''} data-concluir="${tarefa.id}">Concluir</button>
        <button class="btn btn-warning btn-sm" data-editar="${tarefa.id}">Editar</button>
        <button class="btn btn-danger btn-sm" data-excluir="${tarefa.id}">Excluir</button>
    </td>
`;
                    tabela.appendChild(tr);
                });
            });
    }

    form.addEventListener('submit', function (e) {
        e.preventDefault();
        if (tarefaEditandoId) {
            // Atualizar tarefa
            fetch(`/api/tarefas/${tarefaEditandoId}`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ descricao: descricaoInput.value })
            }).then(() => {
                descricaoInput.value = '';
                tarefaEditandoId = null;
                form.querySelector('button[type="submit"]').textContent = 'Salvar';
                btnCancelarEdicao.style.display = 'none';
                carregarTarefas();
            });
        } else {
            // Criar tarefa
            fetch('/api/tarefas', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ descricao: descricaoInput.value })
            }).then(() => {
                descricaoInput.value = '';
                carregarTarefas();
            });
        }
    });

    let tarefaParaExcluir = null;
    const modal = new bootstrap.Modal(document.getElementById('modalConfirmarExclusao'));
    const btnConfirmarExclusao = document.getElementById('btnConfirmarExclusao');

    tabela.addEventListener('click', function (e) {
        const btnConcluir = e.target.closest('button[data-concluir]');
        const btnExcluir = e.target.closest('button[data-excluir]');
        const btnEditar = e.target.closest('button[data-editar]');
        if (btnConcluir) {
            fetch(`/api/tarefas/${btnConcluir.dataset.concluir}/concluir`, { method: 'PUT' })
                .then(carregarTarefas);
        }
        if (btnExcluir) {
            tarefaParaExcluir = btnExcluir.dataset.excluir;
            modal.show();
        }
        if (btnEditar) {
            // Preencher o formulário com a descrição da tarefa
            const tr = btnEditar.closest('tr');
            tarefaEditandoId = btnEditar.dataset.editar;
            descricaoInput.value = tr.children[1].innerText.replace('Concluída', '').trim();
            form.querySelector('button[type="submit"]').textContent = 'Atualizar';
            btnCancelarEdicao.style.display = '';
            descricaoInput.focus();
        }
    });

    btnConfirmarExclusao.addEventListener('click', function () {
        if (tarefaParaExcluir) {
            fetch(`/api/tarefas/${tarefaParaExcluir}`, { method: 'DELETE' })
                .then(() => {
                    modal.hide();
                    carregarTarefas();
                });
            tarefaParaExcluir = null;
        }
    });

    btnCancelarEdicao.addEventListener('click', function () {
        tarefaEditandoId = null;
        descricaoInput.value = '';
        form.querySelector('button[type="submit"]').textContent = 'Salvar';
        btnCancelarEdicao.style.display = 'none';
    });

    carregarTarefas();
});
