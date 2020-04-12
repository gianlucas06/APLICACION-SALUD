using System;

namespace Entity
{
    public class Paciente
    {
        public string Identificacion { get; set; }
        public decimal ValorServicio { get; set; }
        public decimal Salario { get; set; }
        public decimal Copago { get; set; }
        
        public void CalcularCopago(){

            if(Salario>2500000){
                
                Copago=(ValorServicio * 20)/100;
            }else{
                if(Salario<=2500000){
                    
                    Copago=(ValorServicio * 10)/100;
                }
            }
        }
}
}
 

