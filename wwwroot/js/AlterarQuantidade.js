// Função javaScript para alterar a quantidade do produto na lista de produtos adicionados
function alterarQuantidade(button, delta, produtoId) {
    const input = button.parentElement.querySelector('input[type="number"]');
    const valorAtual = parseInt(input.value);
    if (!isNaN(valorAtual)) {
        const novoValor = Math.max(1, valorAtual + delta);
        input.value = novoValor;

        // Chama backend para atualizar a sessão
        fetch('/ListaProduto/AtualizarQuantidade', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
            },
            body: JSON.stringify({
                produtoId: produtoId,
                quantidade: novoValor
            })
        });
    }
}
