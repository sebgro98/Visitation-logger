using Microsoft.EntityFrameworkCore;
using ResourceServer.Model;
using ResourceServer.Data;

namespace ResourceServer.Repositories{

   public class AdminRepository : IAdminRepository{

      private ApplicationDbContext _db;
      private DbSet<Admin> _table = null;

      public AdminRepository(ApplicationDbContext db){
         _db = db;
         _table  = _db.Set<Admin>();  
      } 

      public async Task<IEnumerable<Admin>> GetAll(){
         return await _table.ToListAsync();
      }

      public async Task<Admin> GetById(object id){
         return await _table.FindAsync(id);
      }

      public async Task<Admin> Insert(Admin obj){
        _table.Add(obj);
         await _db.SaveChangesAsync();
         return obj;
      }

      public async Task<Admin> Update(Admin obj){
         _table.Attach(obj);
         _db.Entry(obj).State = EntityState.Modified;
         await _db.SaveChangesAsync();
         return obj;
      }
        
      public async Task<Admin> Delete(object id){
            Admin existing = _table.Find(id);
            _table.Remove(existing);
            await _db.SaveChangesAsync();
            return existing;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public DbSet<Admin> Table { get { return _table; } }

   }
}