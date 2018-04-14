function CalcularIdade() {

    debugger;
    var textoDataNascimento = document.getElementById("DataNascimento").value;
    var dataNascimento = new Date(textoDataNascimento);
    var hoje = new Date();
    var idade = Math.floor(Math.ceil(Math.abs(dataNascimento.getTime() - hoje.getTime()) / (1000 * 3600 * 24)) / 365.25);
    document.getElementById("Idade").value = idade;

   //Math.abs(nascimento.getTime() - hoje.getTime()) - Retorna a quantidade de milissegundos passados desde nascimento até hoje. A função Math.abs retorna o módulo da subtração, ou seja, transforma um número negativo em positivo e mantém o sinal de um positivo.
   //(1000 * 3600 * 24) - Calcula a quantidade de dias a partir da quantidade de milissegundos retornada na expressão anterior.Dividindo por 1000, temos a quantidade de segundos; a quantidade de segundos dividindo por 3600 temos a quantidade de horas(pois em 1 hora cabem 3600 segundos); e finalmente divide-se a quantidade de horas por 24, que teremos a quantidade de dias correspondente.
   //Math.ceil - Arredonda para cima o valor decimal da operação anterior, pois é considerado que se passou um dia mesmo que a quantidade de horas não dê 24 horas.
   //365.25 - Calculamos o ano dividindo o total de dias pelo total de dias que cabem em um ano. O número 365.25 é porque um ano possui aproximadamente 365 dias e 6 horas, que é igual a 365.25 dias.O ano bixesto vem desta diferença, pois a cada 4 anos, as 6 horas desconsideradas no calendário tornam-se 24 horas, ou seja mais um dia.
   //Math.floor - Arredonda para baixo a quantidade de anos.
}

function CalcularTotalPedidoItem() {

    debugger;
    var quantidade = parseFloat(document.getElementById("Quantidade").value.replace(",", "."), 10); 
    var valorUnitario = parseFloat(document.getElementById("ValorUnitario").value.replace(",", "."), 10);

    var total = quantidade * valorUnitario;
    total = total.toFixed(2);
    document.getElementById("ValorTotal").value = total.replace(".", ",");
}