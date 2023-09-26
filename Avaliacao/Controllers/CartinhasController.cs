using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Avaliacao;
using Avaliacao.Models;

namespace Revisao_01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartinhasController : ControllerBase
    {


        private readonly string _registro_cartas;

        public CartinhasController()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            _registro_cartas = Path.Combine(Directory.GetCurrentDirectory(), "Data", "registro_cartinhas.json");
        }

        //public CartinhasController()
        //{
        //    _registro_cartas = Path.Combine(Directory.GetCurrentDirectory(), "Data", "registro_cartas.json");
        //}

        private List<RegistroDeCartasViewModel> LerCartasDoArquivo()
        {
            if (!System.IO.File.Exists(_registro_cartas))
            {
                return new List<RegistroDeCartasViewModel>();
            }

            string json = System.IO.File.ReadAllText(_registro_cartas);
            return JsonConvert.DeserializeObject<List<RegistroDeCartasViewModel>>(json);
        }

        private void EscreverCartasNoArquivo(List<RegistroDeCartasViewModel> cartas)
        {
            string json = JsonConvert.SerializeObject(cartas);
            System.IO.File.WriteAllText(_registro_cartas, json);
        }

        [HttpGet]
        public ActionResult Get()
        {
            
                return Ok(LerCartasDoArquivo());
            
        }

        [HttpPost]

        public IActionResult Post([FromBody] RegistroDeCartasViewModel newCarta)
        {
           
            List<RegistroDeCartasViewModel> cartas = LerCartasDoArquivo();
             
            RegistroDeCartasViewModel novaCarta = new RegistroDeCartasViewModel()
            {

                Nome = newCarta.Nome,
                Endereco = newCarta.Endereco,
                Idade = newCarta.Idade,
                Textinho = newCarta.Textinho
            };

            cartas.Add(novaCarta);
            EscreverCartasNoArquivo(cartas);

            return CreatedAtAction(nameof(Get), new { codigo = novaCarta.Nome }, novaCarta);
        }
        

    }
}
