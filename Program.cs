using System.Runtime.ConstrainedExecution;
using System.Text.Json;
using System.Text.RegularExpressions;
using Camille;
using Camille.Enums;
using Camille.RiotGames;
using Camille.RiotGames.ChampionMasteryV4;

var riotApi = RiotGamesApi.NewInstance("RGAPI-15bd872d-e48a-4092-9b1c-4c72b16eae8b"); // Aqui vai a Key

    Conta acc = new Conta();
    // Conta acc2 = new Conta();
    // Conta acc3 = new Conta();

    // acc2.nome = "LNA Bom e Burro";
    // acc2.tag = "Cadu";
    // acc2.puuid = "smzqdWjxUqGhZrE8Yf27wigkyoV-7pnaBM3wuXEmI-2h5PQ5v8T1IzWHpw9slyjdqJVJ9iVsFezalw";

    //acc.nome = "Yudi007";
    //acc.tag = "BR1";

    //acc.nome = "jpsalioni";
    //acc.tag = "BR1";

    //acc.nome = "Madoka Kaname";
    //acc.tag = "00000";

    
    Conta retornaConta(Conta input){



        string[] retAccountv1 = riotApi.AccountV1().GetByRiotId(RegionalRoute.AMERICAS, input.nome, input.tag).ToString().Split(',');

        input.puuid = retAccountv1[0].Substring(15,78);

        string[] retSummonerv4 = riotApi.SummonerV4().GetByPUUID(PlatformRoute.BR1, input.puuid).ToString().Split(',');

        input.icon = retSummonerv4[1].Substring(15, retSummonerv4[1].Length -15); // pega o começo da parte q interessa 

        input.level = retSummonerv4[5].Substring(16, retSummonerv4[5].Length -16); // e calculo o n de caracteres: tamnho final - inicial

        return input;

    }



    Conta retornaMaestrias(Conta input){

        var m = riotApi.ChampionMasteryV4().GetTopChampionMasteriesByPUUID(PlatformRoute.BR1, input.puuid, 3);

        input.maestrias[0] = m[0].ChampionId.ToString();
        input.maestrias[1] = m[1].ChampionId.ToString();
        input.maestrias[2] = m[2].ChampionId.ToString();

        return input;

    }



    void mostraPlayers(Conta input){

        //String partida = riotApi.MatchV5().GetMatchIdsByPUUID.ToString();


    }





        acc.nome = Console.ReadLine();
        acc.tag = Console.ReadLine();

        acc = retornaConta(acc);
        acc = retornaMaestrias(acc);
    

//Console.WriteLine(riotApi.AccountV1().GetByRiotId(RegionalRoute.AMERICAS, acc.nome, acc.tag));
Console.WriteLine("Nome de Invocador: " + acc.nome);
Console.WriteLine("Puuid: " + acc.puuid);
Console.WriteLine("Nivel de Invocador: " + acc.level);
Console.WriteLine("Id do icone :" + acc.icon);
Console.WriteLine("Campeoes: \n  1) " + acc.maestrias[0] + "\n  2) " + acc.maestrias[1] + "\n  3) " + acc.maestrias[2]);




Console.WriteLine("\n");

