﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Model.Repository.Interface.Item.SimpleComputerComponent;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.SimpleComputerComponent {
    public class CPUCoreRepositoryPostgreSQL: ICPUCoreRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public CPUCoreRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<CPUCore> List() {
            return _context.CPUCores.ToList();
        }

        public CPUCore Get(int id) {
            return _context.CPUCores.Find(id);
        }

        public void Create(CPUCore cpuCore) {
            _context.CPUCores.Add(cpuCore);
        }

        public void Update(CPUCore cpuCore) {
            _context.Entry(cpuCore).State = EntityState.Modified;
        }

        public void Delete(int id) {
            CPUCore cpuCore = _context.CPUCores.Find(id);
            if (cpuCore != null)
                _context.CPUCores.Remove(cpuCore);
        }
        
    }
}