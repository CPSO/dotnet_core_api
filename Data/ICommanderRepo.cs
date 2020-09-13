using System.Collections.Generic;
using coreapi.Models;

namespace coreapi.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
    }
}