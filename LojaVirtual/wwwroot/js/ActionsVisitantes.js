$(document).ready(function () {
    MudarOrdenacao();
});
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

        var URLParametros = URL + "?pagina=" + Pagina + "&pesquisa=" + Pesquisa + "&ordenacao=" + Ordenacao + "#ordenacao";
        //alert(URLParametros);

        window.location.href = URLParametros;

    })
}