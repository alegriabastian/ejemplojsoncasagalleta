// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;
using System.IO;

namespace Microsoft.BotBuilderSamples.Bots
{
    public class EchoBot : ActivityHandler
    {
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {   Casa casa = new Casa();
            casa = CreateCasa();
            await turnContext.SendActivityAsync(MessageFactory.Text($"Casa nombre gato {casa.nombreGato}"), cancellationToken);
            await turnContext.SendActivityAsync(MessageFactory.Text($"Casa numero de guitarras  {casa.numGuitarras}"), cancellationToken);

            foreach(string g in casa.galletas){
            await turnContext.SendActivityAsync(MessageFactory.Text($"Casa lista de galletas {g}"), cancellationToken);
            }
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text($"Hello and welcome!"), cancellationToken);
                }
            }
        }

        private Casa CreateCasa()
        {
            // combine path for cross platform support
            string[] paths = { ".", "casasjsn", "casa.json" };
            string fullPath = Path.Combine(paths);
            var casaj = File.ReadAllText(fullPath);
  
            return JsonConvert.DeserializeObject<Casa>(casaj);

        }
    }
}
