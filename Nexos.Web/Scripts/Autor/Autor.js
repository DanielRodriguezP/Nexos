var urlBase = "https://localhost:44305/";

$(document).ready(function () {

    $('#btnNotificacion').hide();
    loadDataTable();

    $.ajax({
        url: urlBase + 'api/Ciudad',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            var clasificacion = $("#cbxCiudad");
            var datos = data;
            $(datos).each(function (i, v) {
                clasificacion.append('<option value="' + v.Id + '">' + v.Nombre + '</option>');
            });
        },
        error: function () {
            console.log('error');
        }
    });

    $('#btnGuardar').click(function () {
        
        $('#FechaNacimiento').focusout(function () {
            s = $(this).val();
            var bits = s.split('/');
            var d = new Date(bits[2] + '/' + bits[0] + '/' + bits[1]);
        });

        if (ValidarCampos() == true) {

            nuevoAutor = {};
            nuevoAutor.Id = $('#Id').val();
            nuevoAutor.NombreCompleto = $('#NombreCompleto').val();
            nuevoAutor.FechaNacimiento = $('#FechaNacimiento').val();
            nuevoAutor.CiudadId = $('#cbxCiudad').val();
            nuevoAutor.Correo = $('#Correo').val();

            $.ajax({
                url: urlBase + 'api/Autor',
                type: 'POST',
                dataType: 'json',
                data: nuevoAutor,
                success: function (data) {
                    var result = data;
                    if (result) {
                        $('#lblmensaje').text('Se guardo el registro exitosamente');
                        $('#divmensaje').addClass('alert alert-success');
                        $('#divmensaje').show();
                        setTimeout(function () {
                            $('#divmensaje').fadeOut(3000);
                        }, 2000);
                        /*loadDataTable();*/
                        $("#tabla").load();
                    } else {
                        var texto = "El autor ya se encuentra registrado";
                        $('#lblmensaje').text(texto);
                        $('#divmensaje').addClass('alert alert-danger');
                        $('#divmensaje').show();
                        setTimeout(function () {
                            $('#divmensaje').fadeOut(3000);
                        }, 3000);
                    }

                    limpiar();
                },
                error: function () {
                    var texto = "Debe llenar todos los campos";
                    $('#lblmensaje').text(texto);
                    $('#divmensaje').addClass('alert alert-danger');
                    $('#divmensaje').show();
                    setTimeout(function () {
                        $('#divmensaje').fadeOut(3000);
                    }, 3000);
                }
            });

        }
        else {
            $('#lblmensaje').text('Validar que todos los campos esten diligenciados correctamente');
            $('#divmensaje').addClass('alert alert-danger');
            $('#divmensaje').show();
            setTimeout(function () {
                $('#divmensaje').fadeOut(3000);
            }, 3000);
        }


    });

    function loadDataTable() {
        $('#tabla').DataTable({
            "ajax": {
                "url": urlBase + "api/Autor",
                "dataSrc": "",
                "type": "GET",
            },
            "columns": [
                { "data": "Id" },
                { "data": "NombreCompleto" },
                { "data": "FechaNacimiento" },
                { "data": "Ciudad" },
                { "data": "Correo" },
            ]
        });
    }

    function ValidarCampos() {

        var nombreCompleto = $('#NombreCompleto').val();
        var ciudadId = $('#cbxCiudad').val();
        var correo = $('#Correo').val();

        if (nombreCompleto == null || nombreCompleto == ''
            || ciudadId == 0
            || correo.indexOf('@', 0) == -1 || correo.indexOf('.', 0) == -1) {
            return false;
        }
        else {
            return true;
        }
    }

    function limpiar() {
        $('#Id').val("");
        $('#NombreCompleto').val("");
        $('#FechaNacimiento').val("");
        $('#cbxCiudad').val("");
        $('#Correo').val("");
    }
});







