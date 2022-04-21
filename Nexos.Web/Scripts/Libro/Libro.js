var urlBase = "https://localhost:44305/";

$(document).ready(function () {
    
    $('#btnNotificacion').hide();
    loadDataTable();
    
    $.ajax({
        url: urlBase + 'api/Genero/LlenarComboboxGenero',
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            var clasificacion = $("#cbxGenero");
            var datos = data;
            $(datos).each(function (i, v) {
                clasificacion.append('<option value="' + v.Id + '">' + v.Nombre + '</option>');
            });
        },
        error: function () {
            console.log('error');
        }
    });

    $.ajax({
        url: urlBase + 'api/Autor/LlenarComboboxAutor',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            var clasificacion = $("#cbxAutor");
            var datos = data;
            $(datos).each(function (i, v) {
                clasificacion.append('<option value="' + v.Id + '">' + v.NombreCompleto + '</option>');
            });
        },
        error: function () {
            console.log('error');
        }
    });

    $('#btnGuardar').click(function () {
        if (ValidarCampos() == true) {

            nuevoLibro = {};
            nuevoLibro.Titulo = $('#Titulo').val();
            nuevoLibro.Ano = $('#Ano').val();
            nuevoLibro.GeneroId = $('#cbxGenero').val();
            nuevoLibro.NumeroPagina = $('#NumPag').val();
            nuevoLibro.AutorId = $('#cbxAutor').val();
            $.ajax({
                url: urlBase + 'api/Libro',
                type: 'POST',
                dataType: 'json',
                data: nuevoLibro,
                success: function (data) {
                    var result = data;
                    alert(result);
                    if (result) {
                        $('#lblmensaje').text('Se guardo el registro exitosamente');
                        alert("Registro exitoso");
                        $('#divmensaje').addClass('alert alert-success');
                        $('#divmensaje').show();
                        setTimeout(function () {
                            $('#divmensaje').fadeOut(3000);
                        }, 2000);
                        loadDataTable();
                        //$("#tabla").load();
                    } else {
                        var texto = "No es posible registrar el libro, se alcanzo un maximo permitido o ya se encuentra registrado";
                        alert(texto);
                        $('#lblmensaje').text(texto);
                        $('#divmensaje').addClass('alert alert-danger');
                        $('#divmensaje').show();
                        setTimeout(function () {
                            $('#divmensaje').fadeOut(3000);
                        }, 2000);
                    }
                    limpiar();
                },
                error: function () {
                    var texto = "Se debe llenar todos los campos";
                    alert(texto);
                    $('#lblmensaje').text(texto);
                    $('#divmensaje').addClass('alert alert-danger');
                    $('#divmensaje').show();
                    setTimeout(function () {
                        $('#divmensaje').fadeOut(3000);
                    }, 2000);
                }
            });
        } else {
            $('#lblmensaje').text('Validar que todos los campos esten diligenciados correctamente');
            $('#divmensaje').addClass('alert alert-danger');
            $('#divmensaje').show();
            setTimeout(function () {
                $('#divmensaje').fadeOut(3000);
            }, 2000);
        }
        
    });

    function loadDataTable() {
        $('#tabla').DataTable({
            "ajax": {
                "url": urlBase + "api/Libro",
                "dataSrc": ""
            },
            "columns": [
                { "data": "Id" },
                { "data": "Titulo" },
                { "data": "Ano" },
                { "data": "NumeroPagina" },
                { "data": "NombreCompleto" },
                { "data": "Genero" },
            ]
        });
    }

    function ValidarCampos() {

        var titulo = $('#Titulo').val();
        var ano = $('#Ano').val();
        var generoId = $('#cbxGenero').val();
        var numPag = $('#NumPag').val();
        var autorId = $('#cbxAutor').val();
        

        if (titulo == null || titulo == '' || generoId == 0 || autorId == 0
            || ano.length > 4 || numPag < 1)
            {
            return false;
        }
        else {
            return true;
        }
    }

    function limpiar() {
        $('#Titulo').val("");
        $('#Ano').val("");
        $('#cbxGenero').val("");
        $('#NumPag').val("");
        $('#cbxAutor').val("");
    }
});







