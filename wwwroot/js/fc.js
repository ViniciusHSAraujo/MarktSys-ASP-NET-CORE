/* Variáveis */

var enderecoProduto = "https://localhost:44303/Produto/Produto/";
// var enderecoProduto = "https://localhost:5001/Produto/Produto/";
var compra = [];
var produto;
var valorTotalDaVenda = 0.00;

/* Inicio */

AtualizarValorTotalDaVenda();
$("#posvenda").hide();


/* Preenchimento de Campos*/

function AtualizarValorTotalDaVenda() {
    $("#valorTotalDaVenda").html(valorTotalDaVenda);
}

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

    valorTotalDaVenda += venda.subtotal;
    AtualizarValorTotalDaVenda();

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


/* Finalização da Venda */

$("#BtnFinalizarVenda").click(function () {
    if (valorTotalDaVenda <= 0) {
        alert("Compra inválida! Nenhum produto selecionado!")
        return;
    } else {
        var valorPago = $("#valorPago").val();

        if (isNaN(valorPago)) {
            alert("VALOR INVÁLIDO!");
            return;
        } else if (valorPago < valorTotalDaVenda) {
            alert("Valor pago inferior ao valor da compra!");
            return;
        } else {
            $("#posvenda").show();
            $("#prevenda").hide();
            $("#valorPago").prop("disabled", true)
            var valorTroco = valorPago - valorTotalDaVenda;
            $("#valorTroco").val(valorTroco);
        }
    }
});

function restaurarTela() {
    $("#posvenda").hide();
    $("#prevenda").show();
    $("#valorPago").prop("disabled", false)
    $("#valorPago").val("");
    $("#valorTroco").val("");
}

$("#btnFechar").click(function () {
    restaurarTela();
});