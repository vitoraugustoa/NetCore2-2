
$(document).ready(function () {
    debugger;
    var options = {};
    options.url = "/api/contatos";
    options.type = "GET";
    options.dataType = "json";
    options.success = function (data) {
        data.forEach(function (element) {
            $("#id").append("<option>" + element.id + "</option>");
        });
    };
    options.error = function () {
        $("#msg").html("Erro ao chamar a API!");
    };
    $.ajax(options);

    $("#id").change(function () {
        debugger;
        var options = {};
        options.url = "/api/contatos/" + $("#id").val();
        options.type = "GET";
        options.dataType = "json";
        options.success = function (data) {
            $("#nome").val(data.nome);
            $("#email").val(data.email);
            $("#telefone").val(data.telefone);
        };
        options.error = function () {
            $("#msg").html("Erro ao chamar a API!");
        };
        $.ajax(options);
    });

    $("#incluir").click(function () {
        debugger;
        var options = {};
        options.url = "/api/contatos";
        options.type = "POST";

        var obj = {};
        obj.nome = $("#nome").val();
        obj.email = $("#email").val();
        obj.telefone = $("#telefone").val();

        options.data = JSON.stringify(obj);
        options.contentType = "application/json";
        options.dataType = "html";

        options.success = function (msg) {
            $("#msg").html(msg);
        };
        options.error = function () {
            $("#msg").html("Erro ao chamar a API!");
        };
        $.ajax(options);
    });

    $("#atualizar").click(function () {
        debugger;
        var options = {};
        options.url = "/api/contatos/" + $("#id").val();
        options.type = "PUT";

        var obj = {};
        obj.Id = $("#id").val();
        obj.nome = $("#nome").val();
        obj.email = $("#email").val();
        obj.telefone = $("#telefone").val();

        options.data = JSON.stringify(obj);
        options.contentType = "application/json";
        options.dataType = "html";
        options.success = function (msg) {
            $("#msg").html(msg);
        };
        options.error = function () {
            $("#msg").html("Erro ao chamar a API!");
        };
        $.ajax(options);
    });

    $("#excluir").click(function () {
        debugger;
        var options = {};
        options.url = "/api/contatos/" + $("#id").val();
        options.type = "DELETE";
        options.dataType = "html";
        options.success = function (msg) {
            $("#msg").html(msg);
        };
        options.error = function () {
            $("#msg").html("Erro ao chamar a API!");
        };
        $.ajax(options);
    });
});
