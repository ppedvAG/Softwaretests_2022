using ppedv.Autovermietung.Model;
using ppedv.Autovermietung.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.Autovermietung.Logic.Tests
{
    public class TestRepo : IRepository
    {
        public void Add<T>(T entity) where T : Model.Entity
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>() where T : Model.Entity
        {
            var a1 = new Auto() { PS = 200, Modell = "Grün" };
            var a2 = new Auto() { PS = 300, Modell = "Rot" };
            if (typeof(T) == typeof(Auto))
            {
                return new []{ a1, a2 }.Cast<T>();
            }

            throw new NotImplementedException();
        }

        public T GetById<T>(int id) where T : Model.Entity
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : Model.Entity
        {
            throw new NotImplementedException();
        }
    }
}