using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.entity;

namespace Airline.repository
{
    internal interface IRepository<out T> where T : IEntity
    {
        void SaveState();
        T LoadState();
    }
}
