using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface.Item.ComputerComponent;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.ComputerComponent {
    public class GraphicsCardRepositoryPostgreSQL: IGraphicsCardRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public GraphicsCardRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<GraphicsCard> List() {
            return _context.GraphicsCards.ToList();
        }

        public GraphicsCard Get(int id) {
            return _context.GraphicsCards.Find(id);
        }

        public void Create(GraphicsCard graphicsCard) {
            _context.GraphicsCards.Add(graphicsCard);
        }

        public void Update(GraphicsCard graphicsCard) {
            _context.Entry(graphicsCard).State = EntityState.Modified;
        }

        public void Delete(int id) {
            GraphicsCard graphicsCard = _context.GraphicsCards.Find(id);
            if (graphicsCard != null)
                _context.GraphicsCards.Remove(graphicsCard);
        }
        
    }
}