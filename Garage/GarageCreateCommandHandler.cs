using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Garage.Library;
using Microsoft.VisualStudio.Commanding;
using Lib = Garage.Library;

namespace Garage
{
    internal sealed class GarageCreateCommandHandler(
        IGarageStore garageStore,
        IEventBus eventBus) 
        : ICommandHandler<GarageCreateCommand>
    {
        public string DisplayName => throw new NotImplementedException();

        public bool ExecuteCommand(GarageCreateCommand args, CommandExecutionContext executionContext)
        {
            throw new NotImplementedException();
        }

        public CommandState GetCommandState(GarageCreateCommand args)
        {
            throw new NotImplementedException();
        }

        public async Task<IGarageStore> Handle(
            GarageCreateCommand command, 
            CancellationToken cancellationToken)
        {
            // ToDo: Invoke the command that creates the Garage.
            Lib.Garage<Vehicle> garage = CreateGarageFromCommand(command);

            // Publish the event
            // await eventBus.PublishAsync(
            //     new CreateGarageRequestEvent(new("My new garage")),
            //     cancellationToken);

            Console.WriteLine("RETURNING STORE");
            return garageStore;
        }

        private Garage<Vehicle> CreateGarageFromCommand(CommandArgs command)
        {
            throw new NotImplementedException();
        }


        //Task<GarageCreateCommand> ICommandHandler<GarageCreateCommand>.Handle(ICommand command, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
