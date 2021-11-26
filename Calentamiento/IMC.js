altura2 = prompt("digite su altura");
peso = prompt("digite su peso");
   
    if(altura2 && peso){
       IMC= peso/(altura2*altura2);
        alert("su IMC es "+IMC)
        

    }else{
       IMC="no es un dato valido" 
    }
    if(IMC<=16){
        alert(IMCtotal="delgadez severa")
    }
    else if(IMC>16.1 && IMC<16.99){
            alert("Delgadez moderada")
    }
    else if(IMC>16.99 && IMC<18.49){
        alert("Delgadez Aceptable")
    }
    else if(IMC>18.49 && IMC<24.99){
        alert("peso Normal")
    }
    else if(IMC>24.49 && IMC<29.99){
        alert("sobre peso")
    }
    else if(IMC>30 && IMC<34.99){
        alert("obesidad tipo 1")
    }
    else if(IMC>34.99 && IMC<39.99){
        alert("obesidad tipo 2")
    }
    else if(IMC>34.99 && IMC<49.99){
        alert("obesidad tipo 3 o morbida")
    }
    else if(IMC>50){
       alert("obesidad tipo 4 o extrema")
    }else{
        alert("error")
    }