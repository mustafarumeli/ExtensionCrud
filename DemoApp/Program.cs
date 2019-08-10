using ExtensionCrud;
using ExtensionCrud.DbObject;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

using System;

namespace DemoApp
{
    public class SelfContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestDb");
        }
        public virtual DbSet<TestTable> TestTables { get; set; }
    }
    public class TestTable : DbTable
    {
        private string _name;

        public TestTable(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public override string ToString()
        {
            return $"{nameof(Name)}: {_name}";
        }

    }
    public static class ExtraExtensions
    {
        public static void WriteToConsole<T>(this DbSet<T> entities) where T : DbTable
        {
            foreach (var entity in entities)
                Console.WriteLine(entity);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var db = new SelfContext();
            var testTable = new TestTable("Mahmut");
            var testTable2 = new TestTable("Muhtar");
            testTable.AddTo(db);
            testTable2.AddTo(db);
            Console.WriteLine("Insert Test");
            db.TestTables.WriteToConsole();
            Console.WriteLine("Delete Test");
            testTable2.RemoveFrom(db);
            db.TestTables.WriteToConsole();
            Console.WriteLine("Update Test");
            testTable.Name = "Changed";
            testTable.UpdateInstanceIn(db);
            db.TestTables.WriteToConsole();

            Console.ReadKey();
        }
    }
}
