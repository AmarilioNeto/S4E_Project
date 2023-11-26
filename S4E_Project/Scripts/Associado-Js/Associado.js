
function alertaPopUp(mensagem) {
    $('#modal').modal('show')
    var div = document.getElementById('mensagem')
    div.innerText = mensagem
    
}

