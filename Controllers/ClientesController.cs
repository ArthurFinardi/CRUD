using CRUD.Data;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet("v1/clientes")]
        public async Task<IActionResult> ListarTodosClientesAsync(
                [FromServices] CrudDataContext contexto)
        {
            try
            {
                var clientes = await contexto.Clientes.AsNoTracking().ToListAsync();
                return Ok(clientes);
            }
            catch
            {
                return StatusCode(500, ("Falha interna no servidor"));
            }
        }

        [HttpGet("v1/clientes/{id:int}")]
        public async Task<IActionResult> ListarClientePorIdAsync(
            [FromServices] CrudDataContext contexto,
            [FromRoute] int id)
        {
            try
            {
                var cliente = await contexto
                    .Clientes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id.Equals(id));

                if (cliente == null)
                    return NotFound("Cliente não encontrado");

                return Ok(cliente);
            }
            catch
            {
                return StatusCode(500, ("Falha interna no servidor"));
            }
        }

        [HttpPost("v1/clientes")]
        public async Task<IActionResult> InserirClienteAsync(
                [FromBody] Cliente model,
                [FromServices] CrudDataContext contexto)
        {
            try
            {
                var cliente = new Cliente
                {
                    //Id = 0,
                    Cpf = model.Cpf,
                    Nome = model.Nome,
                    Rg = model.Rg,
                    DataExpedicao = model.DataExpedicao,
                    OrgaoExpedicao = model.OrgaoExpedicao,
                    Endereco = model.Endereco,
                    DataNascimento = model.DataNascimento,
                    Genero = model.Genero,
                    EstadoCivil = model.EstadoCivil
                };
                await contexto.Clientes.AddAsync(cliente);
                await contexto.SaveChangesAsync();
                return Created($"v1/clientes/{cliente.Id}", "Cliente criado com sucesso");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ("Não foi possível incluir o cliente no BD"));
            }
            catch
            {
                return StatusCode(500, ("Falha interna no servidor"));
            }
        }
        [HttpPut("v1/clientes/{id:int}")]
        public async Task<IActionResult> AlterarClienteAsync(
            [FromRoute] int id,
            [FromBody] Cliente model,
            [FromServices] CrudDataContext contexto)
        {
            try
            {
                var cliente = await contexto
                    .Clientes
                    .FirstOrDefaultAsync(x => x.Id.Equals(id));

                if (cliente == null)
                    return NotFound("Cliente não encontrado");

                cliente.Cpf = model.Cpf;
                cliente.Nome = model.Nome;
                cliente.Rg = model.Rg;
                cliente.DataExpedicao = model.DataExpedicao;
                cliente.OrgaoExpedicao = model.OrgaoExpedicao;
                cliente.Endereco = model.Endereco;
                cliente.DataNascimento = model.DataNascimento;
                cliente.Genero = model.Genero;
                cliente.EstadoCivil = model.EstadoCivil;

                contexto.Clientes.Update(cliente);
                await contexto.SaveChangesAsync();

                return Ok("Cliente alterado com sucesso");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ("Não foi possível alterar o cliente no BD"));
            }
            catch
            {
                return StatusCode(500, ("Falha interna no servidor"));
            }
        }

        [HttpDelete("v1/clientes/{id:int}")]
        public async Task<IActionResult> DeleteClienteAsync(
            [FromRoute] int id,
            [FromServices] CrudDataContext contexto)
        {
            try
            {
                var cliente = await contexto
                    .Clientes
                    .FirstOrDefaultAsync(x => x.Id.Equals(id));

                if (cliente == null)
                    return NotFound("Cliente não encontrado");

                contexto.Clientes.Remove(cliente);
                await contexto.SaveChangesAsync();

                return Ok("Cliente excluído com sucesso");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ("Não foi possível excluir o cliente no BD"));
            }
            catch
            {
                return StatusCode(500, ("Falha interna no servidor"));
            }
        }
    }
}