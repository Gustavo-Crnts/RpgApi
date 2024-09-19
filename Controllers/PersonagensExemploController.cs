using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Models;
using RpgApi.Models.Enuns; //D

namespace RpgApi.Controllers
{
    [ApiController] //A
    [Route("[controller]")] //B
    public class PersonagensExemploController : ControllerBase //C
    {
        private static List<Personagem> personagens
        = new List<Personagem>()
        {
            new Personagem() {Id = 1, Nome = "Frodo", PontosVida = 100, Forca = 17, Defesa = 23, Inteligencia = 33, Classe = Models.Enuns.ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida = 100, Forca = 15, Defesa = 25, Inteligencia = 30, Classe= Models.Enuns.ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida = 100, Forca = 18, Defesa = 21, Inteligencia = 35, Classe= Models.Enuns.ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida = 100, Forca = 18, Defesa = 18, Inteligencia = 37, Classe= Models.Enuns.ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida = 100, Forca = 20, Defesa = 17, Inteligencia = 31, Classe= Models.Enuns.ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida = 100, Forca = 21, Defesa = 13, Inteligencia = 34, Classe= Models.Enuns.ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida = 100, Forca = 25, Defesa = 11, Inteligencia = 35, Classe= Models.Enuns.ClasseEnum.Mago }

        };

        [HttpGet("Get")]
        public IActionResult GetFirst()
        {
            Personagem p = personagens[0]; //posição zero
            return Ok(p);
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(personagens);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int Id)
        {
            return Ok(personagens.FirstOrDefault(pe => pe.Id == Id));
        }

        [HttpPost]
        public IActionResult AddPersonagem(Personagem novoPersonagem)
        {
            if (novoPersonagem.Inteligencia == 0)
                return BadRequest("Inteligência não pode ter valor igual a 0 (zero).");

            personagens.Add(novoPersonagem);
            return Ok(personagens);
        }

        [HttpGet("GetOrdenado")]
        public IActionResult GetOrdem()
        {
            List<Personagem> listaFinal = personagens.OrderBy(p => p.Forca).ToList();
            return Ok(listaFinal);
        }

        [HttpGet("GetContagem")]
        public IActionResult GetQuantidade()
        {
            return Ok("Quantidade de personagens: " + personagens.Count);
        }


        [HttpGet("GetSomaForca")]
        public IActionResult GetSomaForca()
        {
            return Ok(personagens.Sum(p => p.Forca));
        }

        [HttpGet("GetSemCavaleiro")]
        public IActionResult GetSemCavaleiro()
        {
            List<Personagem> listaBusca = personagens.FindAll(p => p.Classe != Models.Enuns.ClasseEnum.Cavaleiro);
            return Ok(listaBusca);
        }

        [HttpGet("GetByNomeAproximado/{nome}")]
        public IActionResult GetbyNomeAproximado(string nome)
        {
            List<Personagem> listaBusca = personagens.FindAll(p => p.Nome.Contains(nome));
            return Ok(listaBusca);
        }

        [HttpGet("GetRemovendoMago")]
        public IActionResult GetRemovendoMago()
        {
            Personagem pRemove = personagens.Find(p => p.Classe == Models.Enuns.ClasseEnum.Mago);
            personagens.Remove(pRemove);
            return Ok("Personagem removido: " + pRemove.Nome);
        }

        [HttpGet("GetByForca/{forca}")]
        public IActionResult Get(int forca)
        {
            List<Personagem> listaFinal = personagens.FindAll(p => p.Forca == forca);
            return Ok(listaFinal);
        }


        [HttpPut]
        public IActionResult UpdatePersonagem(Personagem p)
        {
            Personagem personagemAlterado = personagens.Find(pers => pers.Id == p.Id);
            personagemAlterado.Nome = p.Nome;
            personagemAlterado.PontosVida = p.PontosVida;
            personagemAlterado.Forca = p.Forca;
            personagemAlterado.Defesa = p.Defesa;
            personagemAlterado.Inteligencia = p.Inteligencia;
            personagemAlterado.Classe = p.Classe;

            return Ok(personagens);
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            personagens.RemoveAll(pers => pers.Id == id);

            return Ok(personagens);
        }

         [HttpGet("GetByEnum/{enumId}")]
        public IActionResult GetByEnum(int enumId)
        {
            ClasseEnum enumDigitado = (ClasseEnum)enumId;
            List<Personagem> listaBusca = personagens.FindAll(p => p.Classe == enumDigitado);
            return Ok(listaBusca);
        }

















    }
}