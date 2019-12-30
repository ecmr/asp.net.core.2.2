$(document).ready(function () {
    $(".btn-danger").click(function (e) {
        var resultado = confirm("Tem certeza que deseja excluir este item?");

        if (resultado == false) {
            e.preventDefault();
        }
    });
});