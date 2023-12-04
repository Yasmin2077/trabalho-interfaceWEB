using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using trabalho_interfaceWEB.trabalho_interface;

namespace trabalho_interfaceWEB.Controllers
{
    public class Calculadora : Controller, ICalculadora<double>
    {
        public double Adicao(double numA, double numB)
        {
            return (numA + numB);
        }

        public double Divisao(double numA, double numB)
        {
            if (numB == 0)
            {
                throw new ArgumentException("Não é possível dividir por zero.");
            }
            return numA / numB;
        }

        //página inicial da calculadora
        public ActionResult Index()
        {
            return View();
        }

        public double Multiplicacao(double numA, double numB)
        {
            return (numA * numB);
        }

        public double Subtracao(double numA, double numB)
        {
            return (numA - numB);
        }
        public IActionResult Calcular(double operando1, double operando2, string operacao)
        {
            double resultado = 0;

            // Realiza a operação selecionada
            switch (operacao)
            {
                case "soma":
                    resultado = Adicao(operando1, operando2);
                    break;
                case "subtracao":
                    resultado = Subtracao(operando1, operando2);
                    break;
                case "multiplicacao":
                    resultado = Multiplicacao(operando1, operando2);
                    break;
                case "divisao":
                    try
                    {
                        resultado = Divisao(operando1, operando2);
                    }
                    catch (ArgumentException ex)
                    {
                        ViewBag.Erro = ex.Message;
                        return View("Index");
                    }
                    break;
                default:
                    resultado = 0;
                    ViewBag.Erro = "Operação inválida.";
                    return View("Index");
            }
                ViewBag.Resultado = resultado;
                return View("Index");
        }
    }
}
