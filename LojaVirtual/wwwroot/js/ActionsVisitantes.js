$(document).ready(function () {
    MoverScrollOrdenacao();
    MudarOrdenacao();
});
function MoverScrollOrdenacao() {
    if (window.location.hash.length > 0) {
        var hash = window.location.hash;
        if (hash == "#posicao-produto") {
            window.scrollBy(0, 473);
        }
    }
}
function MudarOrdenacao() {
    $("#ordenacao").change(function () {
        var Pagina = 1;
        var Pesquisa = "";
        var Ordenacao = $(this).val();

        var QueryString = new URLSearchParams(window.location.search);
        if (QueryString.has("pesquisa")) {
            Pesquisa = QueryString.get("pesquisa");
        }

        var URL = window.location.protocol + "//" + window.location.host + window.location.pathname;

        var URLParametros = URL + "?pagina=" + Pagina + "&pesquisa=" + Pesquisa + "&ordenacao=" + Ordenacao + "#posicao-produto";
        //alert(URLParametros);

        window.location.href = URLParametros;

    })
}