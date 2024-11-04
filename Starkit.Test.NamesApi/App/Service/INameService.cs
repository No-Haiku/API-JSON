using App.Models;
using System.Collections.Generic;

namespace App.Service
{
    public interface INameService
    {
        IEnumerable<NameModel> GetNames(string gender, string startsWith);
    }
}
