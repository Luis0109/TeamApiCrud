using Microsoft.AspNetCore.Mvc;
using TeamApi.Data;
using TeamApi.Models;
using Microsoft.EntityFrameworkCore;


namespace TeamApi.Controllers {
    [ApiController]
    [Route("[controller]")]

    public static class TimeRotas {


        public static void addTime(this WebApplication app) {


            var rotasTimes = app.MapGroup("Jogadores");

            //Método POST - adicionar um novo jogador

            rotasTimes.MapPost("", async (AddPlayerRequest request, AppDbContext context) => {
                var vericarJogador = await context.Times.AnyAsync(equipe => equipe.Nome == request.Nome);

                if (vericarJogador)
                    return Results.Conflict("Jogador já esá existe em sua equipe!");

                var novoJogador = new Time(request.Nome, request.Numero, request.Team, request.Posicao);
                await context.Times.AddAsync(novoJogador);
                await context.SaveChangesAsync();

                return Results.Ok(novoJogador);

            });

            //Método GET - mostrar o time completo

            rotasTimes.MapGet("", async (AppDbContext context) => {
                var equipeView = await context.Times.ToListAsync();
                return equipeView;
            });

            //Método GET - exibindo um jogador especifico 

            rotasTimes.MapGet("{Nome}", async (string Nome, AppDbContext context) => {

                var player = await context.Times.SingleOrDefaultAsync(equipe => equipe.Nome == Nome);

                if (player == null)
                    return Results.NotFound("Jogador não encontrado!");

                return Results.Ok(player);

            });

            //Atualizar dados do jogador.

            rotasTimes.MapPut("{Nome}", async (string Nome, UpdatePlayerRequest request, AppDbContext context) => {

                var player = await context.Times.SingleOrDefaultAsync(equipe => equipe.Nome == Nome);

                if (player == null)
                    return Results.NotFound("Jogador não encontrado!");

                player.UpdateInfo(request.Nome, request.Numero, request.Team, request.Posicao);
                await context.SaveChangesAsync();
                return Results.Ok(player);

            });

            //Remover jogador da equipe

            rotasTimes.MapDelete("{Nome}", async (string Nome, AppDbContext context) => {

                var player = await context.Times.SingleOrDefaultAsync(equipe => equipe.Nome == Nome);

                if (player == null)
                    return Results.NotFound("Jogador não encontrado!");

                context.Times.Remove(player);
                await context.SaveChangesAsync();

                return Results.Ok("Jogador removido com sucesso!");


            });


        }


    }
}
