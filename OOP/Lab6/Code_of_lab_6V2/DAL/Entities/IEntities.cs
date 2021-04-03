using System;
namespace DAL.Entities
{
    public interface IEntities
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

    }
}
