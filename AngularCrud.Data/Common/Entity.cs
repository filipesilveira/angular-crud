using System;
using AngularCrud.Core;

namespace AngularCrud.Data.Entities
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; }
    }
}
