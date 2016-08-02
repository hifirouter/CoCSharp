﻿using CoCSharp.Logic;
using CoCSharp.Network;
using CoCSharp.Network.Messages.Commands;
using CoCSharp.Data.Models;
using CoCSharp.Server.Core;

namespace CoCSharp.Server.Handlers.Commands
{
    public static partial class CommandHandlers
    {
        private static void HandleBuyTrapCommand(CoCServer server, AvatarClient client, Command command)
        {
            var btCommand = (BuyTrapCommand)command;
            var data = server.AssetManager.SearchCsv<TrapData>(btCommand.TrapDataID, 0);
            var trap = new Trap(client.Home, data, btCommand.X, btCommand.Y, client, true);
            trap.ConstructionFinished += TrapConstructionFinished;
            client.ResourcesAmount.GetSlot(GetResourceID(data.BuildResource)).Amount -= data.BuildCost;

            FancyConsole.WriteLine(LogFormats.Logic_Construction_Started, client.Token, btCommand.X, btCommand.Y, trap.Data.Level);
        }
    }
}
