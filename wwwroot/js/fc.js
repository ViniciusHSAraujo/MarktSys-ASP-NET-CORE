/* Variáveis */

var enderecoProduto = "https://localhost:5001/Produto/Produto/";
var compra = [];
var produto;

/* Preenchimento de Campos*/

function preencherForumlario(dadosProduto) {
    $("#NomeProduto").val(dadosProduto.nome)
    $("#CategoriaProduto").val(dadosProduto.categoria.nome)
    $("#FornecedorProduto").val(dadosProduto.fornecedor.nome)
    $("#PrecoCustoProduto").val(dadosProduto.precoCusto)
    $("#PrecoVendaProduto").val(dadosProduto.precoVenda)
}

function limparForumlario() {
    $("#NomeProduto").val("")
    $("#CategoriaProduto").val("")
    $("#FornecedorProduto").val("")
    $("#PrecoCustoProduto").val("")
    $("#PrecoVendaProduto").val("")
    $("#QuantidadeProduto").val("")
}

function removerDaCompra() {
    compra.splice(compra.indexOf(), 1)
}

function adicionarProdutoNaTabela(p, q) {

    var produtoTemp = {};
    Object.assign(produtoTemp, produto)

    var venda = { produto: produtoTemp, quantidade: q, subtotal: produtoTemp.precoVenda * q };

    compra.push(venda);

    $("#produtos").append(`
    <tr>
        <td>${p.id}</td>
        <td>${p.nome}</td>
        <td>${q}</td>
        <td>R$${p.precoVenda}</td>
        <td>${p.unidade.nome}</td>
        <td>R$${p.precoVenda * q}</td>
        <td><button class="btn btn-danger" onclick="removerDaCompra()">Excluir</button></td>
    </tr>`);
}

$("#produtoForm").on("submit", function (event) {
    event.preventDefault();
    var produtoTabela = produto;
    var quantidade = $("#QuantidadeProduto").val()

    adicionarProdutoNaTabela(produtoTabela, quantidade);

        limparForumlario();

});

/* AJAX */
$("#pesquisarProduto").click(function () {
    var codProduto = $("#codProduto").val();
    var enderecoTemporario = enderecoProduto + codProduto
    $.post(enderecoTemporario, function (dados, estados) {
    /*alert("Dados: " + dados + " Status: " + status)*/
        produto = dados;
        preencherForumlario(dados);
    }).fail(function() {
        alert("Produto inválido!");
    })
})