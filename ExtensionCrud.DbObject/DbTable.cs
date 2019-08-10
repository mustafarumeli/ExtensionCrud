using System;

namespace ExtensionCrud.DbObject
{
    public abstract class DbTable
    {
        private string _id;

        public DbTable()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

    }
}
