$(document).ready(function () {
    getAll();
})
function getAll() {
    $("#tdBody").empty()
    $.ajax({
        type: 'GET',
        url: 'https://localhost:7193/api/Producto/GetAll',
        dataType: 'json',
        data: {},
        success: function (result) {
            var html = "";
            if (result.correct) {
                $.each(result.objects, function (i, row) {
                    html += '<tr class="table-striped">';
                    html += '<td> <button type="button" class="btn btn-warning" onclick="GetById(' + row.idProducto + ')"><i class="bi bi-pencil-square"></i>Editar</button></td>';
                    html += '<td> ' + row.nombre +'</td>';
                    html += '<td> ' + row.descripcion + '</td>';
                    html += '<td> ' + row.precio + ' </td>';
                    if (row.imagen == null) {
                        html += '<td><img src="https://back.tiendainval.com/backend/admin/backend/web/archivosDelCliente/items/images/20210108100138no_image_product.png" width="80" height="100" /></td>';
                    } else {
                        html += '<td><img width="80" height="100" src="data:image/jpeg;base64,' + row.imagen + '" /></td>';
                    }
                    html += '<td> ' + row.subCategoria.nombre + ' </td>';
                    html += '<td><button type="button" class="btn btn-danger" onclick="Delete(' + row.idProducto + ')"><i class="bi bi-trash3"></i>Eliminar</button> </td>';
                    html += '<tr>';
                });
                $("#tdBody").append(html);
            } else {
                alert("Error al obtener datos");
            }
        },
        error: function (ex) {
            alert('Failed: ' + ex);
        }
    });
}


function Add(producto) {

    $.ajax({
        type: 'POST',
        url: 'https://localhost:7193/api/Producto/Add',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(producto),

        success: function (result) {
            if (result.correct) {
                alert("Se guardó correctamente");
                getAll();
                $('#Modal').modal('hide');
            } else {
                $('#tdTable').hide();
                alert("Error al guardar datos");
            }
        }
    });
};
function Update(producto) {

    $.ajax({
        type: 'POST',
        url: 'https://localhost:7193/api/Producto/Update',
        datatype: 'json',
        data: JSON.stringify(producto),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#myModal').modal();
            $('#Modal').modal('hide');
            GetAll();
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });

};

function Delete(IdProducto) {

    if (confirm("¿Estás seguro de eliminar el producto seleccionado?")) {
        $.ajax({
            type: 'GET',
            url: 'https://localhost:7193/api/Producto/Delete/'+ IdProducto,
            dataType: 'json',
            data: { 'IdProducto': IdProducto },
            success: function (result) {
                $('#myModal').modal();
                GetAll();
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });

    };
};

function GetById(IdProducto) {
    $.ajax({
        type: 'GET',
        url: 'https://localhost:7193/api/Producto/GetById/' + IdProducto,
        dataType: 'json',
        data: { 'IdProducto': IdProducto },
 
        success: function (result) {
            $('#txtIdProducto').val(result.object.idProducto);
            $('#txtNombre').val(result.object.nombre);
            $('#txtDescripcion').val(result.object.descripcion);
            var urlImg = "";
            if (result.object.imagen == "") {
                urlImg = "https://back.tiendainval.com/backend/admin/backend/web/archivosDelCliente/items/images/20210108100138no_image_product.png"
            } else
            {
                urlImg= "data:image/jpeg;base64," + result.object.imagen
            }
            $("#img").prop("src", urlImg);
            $('#txtImagen').val(result.object.imagen)
            $('#txtPrecio').val(result.object.precio);
            $('#ddlCategoria').val(result.object.subCategoria.categoria.idCategoria);
            consultarSubCategoria(result.object.subCategoria.idSubCategoria);

            $('#Modal').modal('show');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }


    });

}
function Agregar() {
    var fileimg = $('#imagen')[0].files[0];
    var imgBase64;
    if (fileimg != null) {
       imgBase64 = getBase64(fileimg);
    } else {
        imgBase64 = $('#txtImagen').val();
    }
    var producto = {
        IdProducto: $('#txtIdProducto').val(),
        Nombre: $('#txtNombre').val(),
        Descripcion: $('#txtDescripcion').val(),
        Precio: $('#txtPrecio').val(),
        Imagen: imgBase64,
        subCategoria: {
            IdSubCategoria: $('#ddlSubcategoria').val()
        }
    }

    if (producto.IdProducto == 0) {
        Add(producto);

    }
    else {
        Update(producto);
    }
}



function validarImagen() {
    var allowedExtension = ['jpg', 'jpeg', 'png'];
    var fileExtension = document.getElementById('imagen').value.split('.').pop().toLowerCase();
    var isValidFile = false;

    for (var index in allowedExtension) {
        if (fileExtension === allowedExtension[index]) {
            isValidFile = true;
            break;
        }
    }

    if (!isValidFile) {
        alert('Las estensiones permitidas son: *.' + allowedExtension.join(', *.'));
        document.getElementById('imagen').value = "";
    }
    return isValidFile;
}

function previsualizarImagen(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#img').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}


function getBase64(file) {
    var reader = new FileReader();
    reader.readAsDataURL(file);
    //reader.onload = function () {
    //    //reader.result
    //};
    //reader.onerror = function (error) {
    //    console.log('Error: ', error);
    //};
    return reader.result.split(',')[1];
}




function consultarSubCategoria(idSubcategoria) {
    $("#ddlSubcategoria").empty();
    $.ajax({
        type: 'GET',
        url: '/ProductoAjax/GetSubCategoriaByIdCategoria',
        dataType: 'json',
        data: { 'IdCategoria': parseInt($("#ddlCategoria").val()) },
        success: function (grupos) {
            $("#ddlSubcategoria").append('<option value="0">' + 'Seleccione una opcion' + '</option>');
            $.each(grupos.objects, function (i, grupos) {
                $("#ddlSubcategoria").append('<option value="' + grupos.idSubCategoria + '">' + grupos.nombre + '</option>');
            });

            $('#ddlSubcategoria').val(idSubcategoria);


        },
        error: function (ex) {
            alert('Failed.' + ex.ErrorMessage);
        }
    });

}
