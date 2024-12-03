using Microsoft.EntityFrameworkCore;
using Orm.Data;
using Orm.Entities;

namespace Orm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////Orm ucun her bir layihede asagidakilar install olunmalidir
            ////Microsoft.EntityFrameworkCore,Microsoft.EntityFrameworkCore,Microsoft.EntityFrameworkCore.Tools.
            ////Daha sonra Data folderindekileri edirik
            #region CrudWithOrm
            OrmDbContext ormDbContext = new OrmDbContext();
            //AdRange ile bir nece gondermek olur
            ormDbContext.Groups.Add(new() { Name = "Group2" });
            ormDbContext.SaveChanges();
            var groups = ormDbContext.Groups
                .Where(x => x.ID > 1)
                .ToList();
            foreach (var grouppp in groups)
                Console.WriteLine(grouppp.Name);
            //Remove ucun
            var group = ormDbContext.Groups.SingleOrDefault(x => x.ID == 2);
            ormDbContext.Groups.Remove(group);
            ormDbContext.SaveChanges();
            //Update ucun
            var groupp = ormDbContext.Groups.SingleOrDefault(x => x.ID == 1);
            group.Name = "Group11";
            ormDbContext.SaveChanges();
            //Oxumaq ucun (AsNotTracking sureti artirir)
            var groupps = ormDbContext.Groups.AsNoTracking().ToList();//Read edende bele veririk
            var datas = ormDbContext.ChangeTracker.Entries();//izlenilen datalari verir 
            #endregion

            #region Migrations Command
            //Her birin ctrl+b elemeyi unutma
            //Dotnet ef (Instal olub olmadigini yoxlayir)
            //dotnet ef migrations add mig.1 (Migration add etmek ucun)b
            //dotnet ef database update (Migrationyu gondermek ucun)
            //dotnet ef migrations list (Migrations conditions gosterir)
            //dotnet ef migrations remove (Eger sql-e gondermemisikse(Pendigdirse),Axirincini silir) 
            //dotnet ef database update 20241201103058_mig.1(1 ci migrationa qaytarir(Sql den silir diger migrations))
            #endregion

            ormDbContext.Groups.AddRange(new() {Name="Group1" }, new() { Name="Group2"});
            ormDbContext.Students.AddRange(new Students() { Name="Stu1",GroupID=2 },new Students() { Name="Stu2",GroupID=1});
            ormDbContext.SaveChanges();
            var students=ormDbContext.Students
                //Bir tip Joindir bu
                .Include(s=>s.group)
                //Meselen Bookdan genreye kecmek ucun then includeden istifade deirik artiq
                .ThenInclude(x=>x.neyse)
                .AsNoTracking()
                .ToList();
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

        }
    }
}
