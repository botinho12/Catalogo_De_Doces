// Função javaScript para alterar a quantidade do produto na lista de produtos adicionados
function alterarQuantidade(button, delta) {
    const input = button.parentElement.querySelector('input[type="number"]');
    const valorAtual = parseInt(input.value);
    if (!isNaN(valorAtual)) {
        const novoValor = Math.max(1, valorAtual + delta);
        input.value = novoValor;
    }
}
