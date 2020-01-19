﻿$(document).ready(function () {
    $(".btn-danger").click(function (e) {
        var resultado = confirm("Tem certeza que deseja realizar esta operação?");

        if (resultado == false) {
            e.preventDefault();
        }
    });
    $('.dinheiro').mask('000.000.000.000.000,00', { reverse: true });

    AjaxUploadImagemProduto();

});

function AjaxUploadImagemProduto() {
    $('.img-upload').click(function () {
        $(this).parent().find(".input-file").click();
    });

    $(".btn-imagem-excluir").click(function () {
        var CampoHidden = $(this).parent().find("input[name=imagem]");
        var Imagem = $(this).parent().find(".img-upload");
        var btnExcluir = $(this).parent().find(".btn-imagem-excluir");
        var InputFile = $(this).parent().find(".input-file");

        $.ajax({
            type: "GET",
            url: "/Colaborador/Imagem/Deletar?caminho=" + CampoHidden.val(),
            error: function () {
                
            },
            success: function (data) {
                Imagem.attr("src", "/img/imagem-padrao.png");
                btnExcluir.addClass("btn-ocultar");
                CampoHidden.val("");
                InputFile.val("");
            }
        })
    });

    $('.input-file').change(function () {
        var Binario = $(this)[0].files[0];
        var Formulario = new FormData();
        Formulario.append("file", Binario);
        var CampoHidden = $(this).parent().find("input[name=imagem]");
        var Imagem = $(this).parent().find(".img-upload");
        var btnExcluir = $(this).parent().find(".btn-imagem-excluir");

        $.ajax({
            type: "POST",
            url: "/Colaborador/Imagem/Armazenar",
            data: Formulario,
            contentType: false,
            processData: false,
            error: function () {
                alert('Erro no envio do arquivo!');
            },
            success: function (data) {
                //alert('Arquivo enviado com sucesso!\n' + data.caminho);
                var caminho = data.caminho;
                Imagem.attr("src", caminho);
                CampoHidden.val(caminho);
                btnExcluir.removeClass("btn-ocultar");
            }
        });
    });
}