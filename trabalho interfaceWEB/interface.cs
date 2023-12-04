using Microsoft.AspNetCore.Mvc;

namespace trabalho_interfaceWEB
{

    namespace trabalho_interface
    { 

     interface ICalculadora<T>
        {
            double Adicao(T numA, T numB);
            double Subtracao(T numA, T numB);
            double Multiplicacao(T numA, T numB);
            double Divisao(T numA, T numB);
            IActionResult Calcular(double operando1, double operando2, string operacao);
        }

    }
}
