////$(document).ready(function () {
////    $('modal').modal('show')
////    var div = document.getElementById('mensagem')
////    div.innerText = "teste"
////});
function alertaPopUp(mensagem) {
    $('#modal').modal('show')
    var div = document.getElementById('mensagem')
    div.innerText = mensagem

}
//function IncluirEmpresa() {
//    event.preventDefault()
//    //var div = document.getElementById('incluirEmpresa')
//    //div.innerHTML = "<div class='form'>"+
//    //   " <div class='form-group'>"+
//    //        "<label>Nome da Empresa</label>"+
//    //        "<asp:TextBox runat='server' type='text' class='form-control' ID='nomeEmpresa' placeholder='Nome da Empresa'></asp:TextBox>  </div>"     
//    //"</div>"
//    //Local onde será inserido o input
//    var container = document.getElementById("incluirEmpresa");
    
//    //Conta total de elementos e soma +1 para o que irá ser adicionado
//    //var total = container.childElementCount + 1
    
    
//    var input = document.createElement("input");  
//    var input2 = document.createElement("input2");
//    var div1 = document.createElement("div");
//    var div2 = document.createElement("div");
//    var div3 = document.createElement("div");
//    var labelGeral = document.createElement("labelGeral");
//    var label = document.createElement("label");
//    var label2 = document.createElement("label2");
//    var div4 = document.createElement("div");
//    var div5 = document.createElement("div");
//    var div6 = document.createElement("div");
  

//    div1.className = "form";
//    div2.className = "form-group";
//    div4.className = "form";
//    div5.className = "form-group";
//    div3.className = "form";
//    div6.className = "form"
   

//    //diferencie os labels para que sejam unicos
//    labelGeral.htmlFor = 'input_' + total
//    //insira o titulo com o novo total
//    labelGeral.textContent = "Empresa " + total + "";
//    label.textContent = " Nome Empresa " + total + "";
//    label2.textContent = "CNPJ " + total + ""
//    input.className = "form-control";
//    input.name = "inp";
//    input.type = "text";
//    input2.className = "form-control";
//    input2.name = "inp2";
//    input2.type = "text2";
//    //Inclui um ID para cada input, de acordo com o label
//    input.id = 'input_' + total;
//    input2.id = 'input2_' + total;
//    container.appendChild(div1);
//    container.appendChild(div4);

//    div4.appendChild(div5);
//    div2.appendChild(labelGeral);
//    div1.appendChild(label);
//    div4.appendChild(label2);
//    div1.appendChild(div3);
//    div4.appendChild(div6);
//    div3.appendChild(input);
//    div6.appendChild(input2);
//}

