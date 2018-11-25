$(function () {
    // Reference the auto-generated proxy for the hub.
    var chat = $.connection.EventoHub;
    // Create a function that the hub can call back to display messages.
    chat.client.MostrarNuevosEventosCoord = function (eventos, lat, lng) {
        // Add the message to the page.
        var bodyTabla = '<tr>';
        
        eventos.forEach(function (element) {
            bodyTabla+='<td>'+htmlEncode(element.Id)+'</td>'
            bodyTabla+='<td>'+htmlEncode(element.Fecha)+'</td>'
            bodyTabla+='<td>'+htmlEncode(element.VehiculoRef)+'</td>'
            bodyTabla += '<td>' + htmlEncode(element.TipoEventoRef.Nombre) + '</td>'
        });
        bodyTabla += '</tr>';
        $('#TEventos').append(bodyTabla);
    };


});