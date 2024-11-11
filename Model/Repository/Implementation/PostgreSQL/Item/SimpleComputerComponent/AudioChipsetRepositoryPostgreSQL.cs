using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Model.Repository.Interface.Item.SimpleComputerComponent;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.SimpleComputerComponent {
    public class AudioChipsetRepositoryPostgreSQL: IAudioChipsetRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public AudioChipsetRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<AudioChipset> List() {
            return _context.AudioChipsets.ToList();
        }

        public AudioChipset Get(int id) {
            return _context.AudioChipsets.Find(id);
        }

        public void Create(AudioChipset audioChipset) {
            _context.AudioChipsets.Add(audioChipset);
        }

        public void Update(AudioChipset audioChipset) {
            _context.Entry(audioChipset).State = EntityState.Modified;
        }

        public void Delete(int id) {
            AudioChipset audioChipset = _context.AudioChipsets.Find(id);
            if (audioChipset != null)
                _context.AudioChipsets.Remove(audioChipset);
        }
        
    }
}