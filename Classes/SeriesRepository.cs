using System;
using System.Collections.Generic;
using seriescrud.Interfaces;

namespace seriescrud
{
    public class SeriesRepository : IRepository<Serie>
    {
        private List<Serie> seriesList = new List<Serie>();
        public void Delete(int id)
        {
            seriesList[id].Delete();
        }

        public void Insert(Serie entity)
        {
            seriesList.Add(entity);
        }

        public List<Serie> List()
        {
            return seriesList;
        }

        public int nextId()
        {
            return seriesList.Count;
        }

        public Serie returnById(int id)
        {
            return seriesList[id];
        }

        public void Update(int id, Serie entity)
        {
            seriesList[id] = entity;
        }
    }
}