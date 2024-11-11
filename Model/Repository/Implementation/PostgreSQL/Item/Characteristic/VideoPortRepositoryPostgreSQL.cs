using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface.Item.Characteristic;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.Characteristic {
    public class VideoPortRepositoryPostgreSQL: IVideoPortRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public VideoPortRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<VideoPort> List() {
            return _context.VideoPorts.ToList();
        }

        public VideoPort Get(int id) {
            return _context.VideoPorts.Find(id);
        }

        public void Create(VideoPort videoPort) {
            _context.VideoPorts.Add(videoPort);
        }

        public void Update(VideoPort videoPort) {
            _context.Entry(videoPort).State = EntityState.Modified;
        }

        public void Delete(int id) {
            VideoPort videoPort = _context.VideoPorts.Find(id);
            if (videoPort != null)
                _context.VideoPorts.Remove(videoPort);
        }
        
    }
}