using System;
using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.ComputerComponents;

namespace GenosStore.Services.Implementation.Entity.Items.ComputerComponents {
    public class GraphicsCardService: IGraphicsCardService {
        private IGenosStoreRepositories _repositories;

        public GraphicsCardService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(GraphicsCard item) {
            _repositories.Items.ComputerComponents.GraphicsCards.Create(item);
        }

        public GraphicsCard Get(int id) {
            return _repositories.Items.ComputerComponents.GraphicsCards.Get(id);
        }

        public List<GraphicsCard> List() {
            return _repositories.Items.ComputerComponents.GraphicsCards.List();
        }

        public void Update(GraphicsCard item) {
            _repositories.Items.ComputerComponents.GraphicsCards.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.ComputerComponents.GraphicsCards.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
        
        public List<GraphicsCard> Filter(List<Func<GraphicsCard, bool>> filters) {
            var result = List();
            foreach (var filter in filters) {
                result = result.Where(filter).ToList();
            }
            return result;
        }
    }
}